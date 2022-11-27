﻿using System;

using binstarjs03.AerialOBJ.Core.Primitives;

namespace binstarjs03.AerialOBJ.Core.Visualization.TwoDimension;
public interface IChunkRegionViewport
{
    event Action<IImage> RegionImageLoaded;
    event Action<IImage> RegionImageUnloaded;

    float PixelPerBlock { get; }
    float PixelPerChunk { get; }
    float PixelPerRegion { get; }
    Point2<int> ScreenCenter { get; }
    public int HeightLimit { get; set; }

    Point2ZRange<int> VisibleRegionRange { get; }
    int LoadedRegionCount { get; }
    int PendingRegionCount { get; }

    Point2ZRange<int> VisibleChunkRange { get; }
    int LoadedChunkCount { get; }
    int PendingChunkCount { get; }
}