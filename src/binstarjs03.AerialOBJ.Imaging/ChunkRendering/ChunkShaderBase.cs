﻿using binstarjs03.AerialOBJ.Core.Definitions;
using binstarjs03.AerialOBJ.Core.MinecraftWorld;
using binstarjs03.AerialOBJ.Core.Pooling;
using binstarjs03.AerialOBJ.Core.Primitives;

namespace binstarjs03.AerialOBJ.Imaging.ChunkRendering;

// TODO implement IUseArrayPooler and implement method that clean the array pool
public abstract class ChunkShaderBase : IChunkShader
{
    protected readonly ArrayPool2<BlockSlim> _highestBlockPooler = new(IChunk.BlockCount, IChunk.BlockCount);

    public abstract void RenderChunk(ChunkRenderOptions setting);

    protected static Color GetBlockColor(ViewportDefinition vd, in BlockSlim block)
    {
        // try get color from block definition else return missing block color
        string blockName = block.Name;
        if (vd.BlockDefinitions.TryGetValue(blockName, out ViewportBlockDefinition? bd))
            return bd.Color;
        else
            return vd.MissingBlockDefinition.Color;
    }

    protected static void SetBlockPixelColorToImage(IImage image, Color color, PointY<int> renderPosition, PointZ<int> chunkCoordsRel, PointZ<int> blockCoordsRel)
    {
        PointY<int> pixelCoords = IChunkShader.GetPixelCoordsForBlock(renderPosition, chunkCoordsRel, blockCoordsRel);
        image[pixelCoords.X, pixelCoords.Y] = color;
    }

    // rent highest block buffer from internal pooler if caller (setting) didn't supplement it
    protected BlockSlim[,] GetChunkHighestBlock(ChunkRenderOptions setting)
    {
        BlockSlim[,] highestBlocks = _highestBlockPooler.Rent();
        setting.Chunk.GetHighestBlockSlim(highestBlocks, setting.HeightLimit, setting.Exclusions);
        return highestBlocks;
    }

    // return highest block buffer if it was coming from internal pooler
    protected void ReturnChunkHighestBlock(ChunkRenderOptions setting, BlockSlim[,] highestBlocks)
    {
        if (setting.HighestBlocks is null)
            _highestBlockPooler.Return(highestBlocks);
    }
}