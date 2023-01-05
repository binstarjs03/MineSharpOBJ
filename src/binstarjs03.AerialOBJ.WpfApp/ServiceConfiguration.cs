using System;

using binstarjs03.AerialOBJ.WpfApp.Components;
using binstarjs03.AerialOBJ.WpfApp.Factories;
using binstarjs03.AerialOBJ.WpfApp.Services.ChunkRendering;
using binstarjs03.AerialOBJ.WpfApp.Services.ModalServices;
using binstarjs03.AerialOBJ.WpfApp.Services.SavegameLoaderServices;
using binstarjs03.AerialOBJ.WpfApp.Services;
using binstarjs03.AerialOBJ.WpfApp.ViewModels;
using binstarjs03.AerialOBJ.WpfApp.Views;

using Microsoft.Extensions.DependencyInjection;

namespace binstarjs03.AerialOBJ.WpfApp;

internal static class ServiceConfiguration
{
    internal static IServiceProvider Configure()
    {
        IServiceCollection services = new ServiceCollection();

        // configure components
        services.AddSingleton<GlobalState>(x => new GlobalState(DateTime.Now, "Alpha", Environment.CurrentDirectory));
        services.AddSingleton<ViewState>();
        services.AddTransient<IChunkRegionManagerErrorMemory, ChunkRegionManagerErrorMemory>();

        // configure models
        // models configuration goes here

        // configure factories
        services.AddSingleton<RegionModelFactory>();
        services.AddSingleton<IMutableImageFactory, MutableImageFactory>();

        // configure views
        services.AddSingleton<MainView>();
        services.AddSingleton<DebugLogView>();
        services.AddTransient<AboutView>();
        services.AddTransient<DefinitionManagerView>();
        services.AddTransient<ViewportView>();

        // configure viewmodels
        services.AddSingleton<AbstractViewModel>();
        services.AddSingleton<MainViewModel>(x =>
        {
            GlobalState globalState = x.GetRequiredService<GlobalState>();
            ViewState viewState = x.GetRequiredService<ViewState>();
            IModalService modalService = x.GetRequiredService<IModalService>();
            ILogService logService = x.GetRequiredService<ILogService>();
            ISavegameLoaderService savegameLoaderService = x.GetRequiredService<ISavegameLoaderService>();
            IView viewportView = x.GetRequiredService<ViewportView>();
            return new MainViewModel(globalState, viewState, modalService, logService, savegameLoaderService, viewportView);
        });
        services.AddSingleton<DebugLogViewModel>();
        services.AddTransient<ViewportViewModel>();
        services.AddTransient<DefinitionManagerViewModel>();

        // configure services
        services.AddSingleton<IModalService, ModalService>(x =>
        {
            IDialogView aboutViewFactory() => x.GetRequiredService<AboutView>();
            IDialogView definitionManagerViewFactory() => x.GetRequiredService<DefinitionManagerView>();
            return new ModalService(aboutViewFactory, definitionManagerViewFactory);
        });
        services.AddSingleton<DefinitionManagerService>();
        services.AddSingleton<ILogService, LogService>();
        services.AddSingleton<IIOService, IOService>();
        services.AddSingleton<ISavegameLoaderService, SavegameLoaderService>();
        services.AddTransient<IChunkRegionManagerService, ConcurrentChunkRegionManagerService>();
        services.AddSingleton<IRegionLoaderService, RegionLoaderService>();
        services.AddSingleton<IChunkRenderService, ChunkRenderService>(x =>
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IChunkShader shader = new FlatChunkShader(provider.GetRequiredService<DefinitionManagerService>());
            return new ChunkRenderService(shader);
        });
        services.AddSingleton<IViewportDefinitionLoaderService, ViewportDefinitionLoaderService>();

        return services.BuildServiceProvider();
    }
}