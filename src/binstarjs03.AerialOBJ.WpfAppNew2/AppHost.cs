﻿using System;

using binstarjs03.AerialOBJ.Core.Threading.MessageDispatching;
using binstarjs03.AerialOBJ.WpfAppNew2.Components;
using binstarjs03.AerialOBJ.WpfAppNew2.Factories;
using binstarjs03.AerialOBJ.WpfAppNew2.Services;
using binstarjs03.AerialOBJ.WpfAppNew2.Services.ModalServices;
using binstarjs03.AerialOBJ.WpfAppNew2.Services.SavegameLoaderServices;
using binstarjs03.AerialOBJ.WpfAppNew2.ViewModels;
using binstarjs03.AerialOBJ.WpfAppNew2.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace binstarjs03.AerialOBJ.WpfAppNew2;
public static class AppHost
{
    public static IHost Configure()
    {
        return Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
        {
            // configure components
            services.AddSingleton<GlobalState>(x => new GlobalState(DateTime.Now));
            services.AddSingleton<IMutableImageFactory, MutableImageFactory>();

            // configure models

            // configure factories
            services.AddSingleton<RegionImageModelFactory>();
            services.AddSingleton<IMessageDispatcherFactory, MessageDispatcherFactory>();
            services.AddAbstractFactory<IAboutView, AboutView>();

            // configure views
            services.AddSingleton<MainView>();
            services.AddSingleton<DebugLogView>();

            // configure viewmodels
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<DebugLogViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<ViewportViewModel>();

            // configure services
            //services.AddModalService();
            services.AddSingleton<IModalService, ModalService>();
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<IIOService, IOService>();
            services.AddSingleton<ISavegameLoaderService, SavegameLoaderService>();
            services.AddSingleton<ICoordinateConverterService, CoordinateConverterService>();
            services.AddTransient<IChunkRegionManagerService, ConcurrentChunkRegionManagerService>();
            services.AddTransient<IChunkRegionManagerErrorMemoryService, ChunkRegionManagerErrorMemoryService>();
            services.AddSingleton<IRegionLoaderService, RegionLoaderService>();
            services.AddSingleton<IChunkRenderService, ChunkRenderService>();

        }).Build();
    }

    private static void AddModalService(this IServiceCollection services)
    {
        services.AddSingleton<IModalService, ModalService>(x =>
        {
            ServiceProvider provider = services.BuildServiceProvider();
            return new ModalService(provider.GetRequiredService<IAbstractFactory<IAboutView>>());
        });
    }
}
