﻿using System;

using binstarjs03.AerialOBJ.Core.MinecraftWorld;
using binstarjs03.AerialOBJ.Core.Primitives;

namespace binstarjs03.AerialOBJ.WpfAppNew2.Services;
public interface IIOService
{
    bool WriteText(string path, string content, out Exception? e);

    Region? ReadRegionFile(Point2Z<int> regionCoords, out Exception? e);
}
