﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

using binstarjs03.AerialOBJ.Core.CoordinateSystem;
using binstarjs03.AerialOBJ.Core.Nbt;

namespace binstarjs03.AerialOBJ.Core.WorldRegion;

public class Section
{
    public const int BlockCount = 16;
    public const int TotalBlockCount = BlockCount * BlockCount * BlockCount;
    public const int BlockRange = BlockCount - 1;
    public static readonly CoordsRange3 BlockRangeRel = new(
        min: Coords3.Zero,
        max: new Coords3(BlockRange, BlockRange, BlockRange)
    );

    private static readonly Block s_airBlock = new();

    private readonly int _yPos;
    private readonly Coords3 _coordsAbs;
    private readonly CoordsRange3 _blockRangeAbs;

    private readonly int[,,]? _blockPaletteIndexTable;
    private readonly Block[]? _blockTable;

    public Coords3 CoordsAbs => _coordsAbs;
    public CoordsRange3 BlockRangeAbs => _blockRangeAbs;

    public Section(Coords2 chunkCoordsAbs, NbtCompound sectionNbt)
    {
        _yPos = sectionNbt.Get<NbtByte>("Y").Value;
        _coordsAbs = calculateCoordsAbs(chunkCoordsAbs, _yPos);
        _blockRangeAbs = calculateBlockRangeAbs(_coordsAbs);

        if (!sectionNbt.HasTag("block_states"))
            return;
        NbtCompound blockStatesNbt = sectionNbt.Get<NbtCompound>("block_states");
        NbtList? paletteBlockNbt = readPaletteNbt(blockStatesNbt);

        if (paletteBlockNbt is null)
            return;

        _blockTable = new Block[paletteBlockNbt.Length];
        for (int i = 0; i < paletteBlockNbt.Length; i++)
        {
            NbtCompound blockPropertyNbt = paletteBlockNbt.Get<NbtCompound>(i);
            // block template in block table coordinate doesn't matter
            // so we set it to zero
            _blockTable[i] = new Block(Coords3.Zero, blockPropertyNbt);
        }

        NbtArrayLong? dataNbt = readDataNbt(blockStatesNbt);
        if (dataNbt is not null)
            _blockPaletteIndexTable = ReadNbtLongData(dataNbt, paletteBlockNbt.Length);

        static Coords3 calculateCoordsAbs(Coords2 chunkCoordsAbs, int yPos)
        {
            int x = chunkCoordsAbs.X;
            int y = yPos;
            int z = chunkCoordsAbs.Z;
            return new Coords3(x, y, z);
        }
        static CoordsRange3 calculateBlockRangeAbs(Coords3 coordsAbs)
        {
            int minAbsBx = coordsAbs.X * BlockCount;
            int minAbsBy = coordsAbs.Y * BlockCount;
            int minAbsBz = coordsAbs.Z * BlockCount;
            Coords3 minAbsB = new(minAbsBx, minAbsBy, minAbsBz);

            int maxAbsBx = minAbsBx + BlockRange;
            int maxAbsBy = minAbsBy + BlockRange;
            int maxAbsBz = minAbsBz + BlockRange;
            Coords3 maxAbsB = new(maxAbsBx, maxAbsBy, maxAbsBz);

            return new CoordsRange3(minAbsB, maxAbsB);
        }
        static NbtList? readPaletteNbt(NbtCompound nbtBlockStates)
        {
            if (!nbtBlockStates.HasTag("palette"))
                return null;
            return nbtBlockStates.Get<NbtList>("palette");
        }
        static NbtArrayLong? readDataNbt(NbtCompound nbtBlockStates)
        {
            if (!nbtBlockStates.HasTag("data"))
                return null;
            return nbtBlockStates.Get<NbtArrayLong>("data");
        }
    }

    public static Coords3 ConvertBlockAbsToRel(Coords3 coords)
    {
        int relBx = MathUtils.Mod(coords.X, BlockCount);
        int relBy = MathUtils.Mod(coords.Y, BlockCount);
        int relBz = MathUtils.Mod(coords.Z, BlockCount);
        return new Coords3(relBx, relBy, relBz);
    }

    public (Coords3 blockCoordsRel, Coords3 blockCoordsAbs) CalculateBlockCoords(Coords3 blockCoords, bool relative, bool skipTest = false)
    {
        Coords3 blockCoordsRel;
        Coords3 blockCoordsAbs;
        if (relative)
        {
            if (!skipTest)
                BlockRangeRel.ThrowIfOutside(blockCoords);
            blockCoordsRel = blockCoords;
            blockCoordsAbs = new Coords3(_coordsAbs.X * BlockCount + blockCoords.X,
                                         _coordsAbs.Y * BlockCount + blockCoords.Y,
                                         _coordsAbs.Z * BlockCount + blockCoords.Z);
        }
        else
        {
            if (!skipTest)
                BlockRangeAbs.ThrowIfOutside(blockCoords);
            blockCoordsRel = ConvertBlockAbsToRel(blockCoords);
            blockCoordsAbs = blockCoords;
        }
        return (blockCoordsRel, blockCoordsAbs);
    }

    // get what block the block table returned from given input.
    // This method does generate heap so avoid calling this method at tight-loops
    public Block GetBlock(Coords3 coords, bool relative)
    {
        (Coords3 coordsRel, Coords3 coordsAbs) = CalculateBlockCoords(coords, relative);
        if (_blockPaletteIndexTable is null)
        {
            Block block = s_airBlock.Clone();
            block.CoordsAbs = coordsAbs;
            return block;
        }
        else
        {
            int blockTableIndex = _blockPaletteIndexTable[coordsRel.X, coordsRel.Y, coordsRel.Z];
            Block block = _blockTable![blockTableIndex].Clone();
            block.CoordsAbs = coordsAbs;
            return block;
        }
    }

    // peek what the block table returned from given input.
    // does not generate heap since it just referencing palette block
    public Block GetBlockPalette(Coords3 blockCoordsRel)
    {
        if (_blockPaletteIndexTable is null)
            return s_airBlock;
        else
        {
            int blockTableIndex = _blockPaletteIndexTable[blockCoordsRel.X, blockCoordsRel.Y, blockCoordsRel.Z];
            return _blockTable![blockTableIndex];
        }
    }

    // set all input block properties to block table block properties, if inequal.
    // does not generate heap, return true if setting is succeed
    public bool SetBlock(Block block, Coords3 coordsRel, string[]? exclusions = null)
    {
        if (_blockPaletteIndexTable is null) // set to air block
            return false;
        else
        {
            int blockTableIndex = _blockPaletteIndexTable[coordsRel.X, coordsRel.Y, coordsRel.Z];
            Block blockTemplate = _blockTable![blockTableIndex];
            if (blockTemplate.Name == s_airBlock.Name)
                return false;
            if (exclusions is not null && exclusions.Contains(blockTemplate.Name))
                return false;
            block.Name = blockTemplate.Name;
            block.CoordsAbs = new Coords3(CoordsAbs.X * BlockCount + coordsRel.X,
                                          CoordsAbs.Y * BlockCount + coordsRel.Y,
                                          CoordsAbs.Z * BlockCount + coordsRel.Z);
            block.Properties = blockTemplate.Properties;
            return true;
        }
    }

    // long data stores what block is at xyz, and that block is corresponds
    // to one block from palette. The long data itself is in long data type form
    // and when being interpreted as binary, it can be broken into several sub-numbers,
    // holding many integers that stores pointers to palette index
    private static int[,,] ReadNbtLongData(NbtArrayLong dataNbt, int paletteLength)
    {
        // bit-length required for single block id (minimum of 4) based from palette length.
        int blockBitLength = Math.Max((paletteLength - 1).Bitlength(), 4);

        int bitsInByte = 8;

        int longBitLength = sizeof(long) * bitsInByte; // sizeof unit is byte, convert to bit

        // maximum count of blocks can fit within single 'long' value
        int blockCount = longBitLength / blockBitLength;

        /* bit-length required for many blocks that can fit as much in 'long' bit-length (64-bit)
         * bit-length required to store block as many as block count
         * 
         * for example 6 bits required for single block, that means it can hold
         * at most 10 blocks: 6 bits * 10 blocks = 60 bits,
         * two more bits (become 66) are required to store one more block,
         * 4 bits are left redundant and discarded.
         * 
         * If for example the bit-length required for single block is 4 bits,
         * then it can hold at most 16 blocks: 4 bits * 16 blocks = 64 bits,
         * which in this case no single bit are left discarded, no wastage.
         */

        // 3D table, order is XZY
        int[,,] paletteIndexTable3D = new int[BlockCount, BlockCount, BlockCount];

        // pos is filling position to which index is to fill
        Coords3 fillPos = Coords3.Zero;
        // int longIndex = 0; this was added before for easier debugging

        int[] buffer = new int[blockCount];

        bool breaking = false;
        foreach (long longValue in dataNbt.Values)
        {
            if (breaking)
                break;
            BinaryUtils.SplitSubnumberFastNoCheck(longValue, buffer, blockBitLength);
            foreach (int value in buffer)
            {
                if (breaking)
                    break;
                paletteIndexTable3D[fillPos.X, fillPos.Y, fillPos.Z] = value;
                if (fillPos.X < 15)
                    fillPos.X++;
                else
                {
                    fillPos.X = 0;
                    if (fillPos.Z < 15)
                        fillPos.Z++;
                    else
                    {
                        fillPos.Z = 0;
                        if (fillPos.Y < 15)
                            fillPos.Y++;
                        else
                            // if Y reached 15 and want to increment,
                            // it means filling is finished so we want to break
                            breaking = true;
                    }
                }
            }
            // longIndex++;
        }
        return paletteIndexTable3D;
    }

    public override string ToString()
    {
        return $"Section {_yPos} of {_coordsAbs}";
    }
}
