﻿using binstarjs03.AerialOBJ.WpfApp.Models.Settings;

namespace binstarjs03.AerialOBJ.WpfApp.Services.ChunkRegionManaging;
public class ChunkRendererProvider
{
    private readonly Setting _setting;

    public ChunkRendererProvider(Setting setting)
    {
        _setting = setting;
    }
}