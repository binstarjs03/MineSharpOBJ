﻿using binstarjs03.AerialOBJ.Core.MinecraftWorld;
using binstarjs03.AerialOBJ.Core.Primitives;
using binstarjs03.AerialOBJ.WpfAppNew2.Components;

namespace binstarjs03.AerialOBJ.WpfAppNew2.Models;
public class RegionImageModel
{
    public required Point2Z<int> RegionPosition { get; init; }
    public Point2<float> WorldPosition => new(RegionPosition.X * Region.BlockCount, RegionPosition.Z * Region.BlockCount);
    public required IMutableImage Image { get; init; }
}