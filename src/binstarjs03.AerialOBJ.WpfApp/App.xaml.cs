﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

using binstarjs03.AerialOBJ.Core.Definitions;
using binstarjs03.AerialOBJ.WpfApp.Services;
using binstarjs03.AerialOBJ.WpfApp.Services.IOService;
using binstarjs03.AerialOBJ.WpfApp.Services.ModalServices;
using binstarjs03.AerialOBJ.WpfApp.Settings;
using binstarjs03.AerialOBJ.WpfApp.Views;

using Microsoft.Extensions.DependencyInjection;

namespace binstarjs03.AerialOBJ.WpfApp;
public partial class App : Application
{
#pragma warning disable CS8618 // nullable warning
    public static new App Current => (Application.Current as App)!;
    public IServiceProvider ServiceProvider { get; private set; }
    public GlobalState GlobalState { get; private set; }
#pragma warning restore CS8618

    protected override void OnStartup(StartupEventArgs e)
    {
        ShutdownMode = ShutdownMode.OnMainWindowClose;

        SettingState setting = SettingState.GetDefaultSetting();
        GlobalState = ConfigureGlobalState(e.Args, setting);
        ServiceProvider = ServiceConfiguration.Configure(GlobalState);

        MainWindow = GetMainWindow();
        MainWindow.Show();
        if (MainWindow is MainView mainView)
            ConfigureDebugLogWindow(mainView);

        InitializeLogService();
        InitializeViewState();
        LoadDefinitions();
        LoadSettings();
    }

    private static GlobalState ConfigureGlobalState(string[] args, SettingState setting)
    {
        DateTime lauchTime = DateTime.Now;
        string version = "Alpha";
        string currentPath = AppDomain.CurrentDomain.BaseDirectory;
        string definitionsPath = Path.Combine(currentPath, "Definitions");
        return new GlobalState(lauchTime, version, currentPath, definitionsPath, args, setting);
    }

    private MainView GetMainWindow() => ServiceProvider.GetRequiredService<MainView>();

    private void ConfigureDebugLogWindow(MainView mainView)
    {
        DebugLogView debugLogView = ServiceProvider.GetRequiredService<DebugLogView>();
        debugLogView.Owner = mainView;
        mainView.RequestSetDebugViewPosition += debugLogView.SetTopLeft;
        mainView.SyncDebugViewPosition();
    }

    private void InitializeLogService()
    {
        ILogService logService = ServiceProvider.GetRequiredService<ILogService>();
        logService.LogRuntimeInfo();
    }

    private void InitializeViewState()
    {
        // immediately set debug log window to visible if debug enabled
        if (GlobalState.IsDebugEnabled)
        {
            ViewState viewState = ServiceProvider.GetRequiredService<ViewState>();
            viewState.IsDebugLogViewVisible = true;
        }
    }

    // TODO we may move out the logic of this method into separate class, maybe "IDefinitionInitializer"
    // load all definitions in definition folder
    private void LoadDefinitions()
    {
        IDefinitionManager definitionManager = ServiceProvider.GetRequiredService<IDefinitionManager>();
        IDefinitionIO definitionIO = ServiceProvider.GetRequiredService<IDefinitionIO>();

        ILogService logService = ServiceProvider.GetRequiredService<ILogService>();
        IModalService modalService = ServiceProvider.GetRequiredService<IModalService>();
        bool hasErrorMessageBoxShown = false;

        List<IRootDefinition> definitions = definitionIO.LoadDefinitionFolder(exceptionHandler);
        foreach (IRootDefinition definition in definitions)
            definitionManager.LoadDefinition(definition);

        void exceptionHandler(Exception e, string definitionFilename)
        {
            string caption = "Cannot load definition";
            logService.LogException($"{caption} {definitionFilename}", e);
            if (hasErrorMessageBoxShown)
                return;
            modalService.ShowErrorMessageBox(new MessageBoxArg()
            {
                Caption = caption,
                Message = $"An exception occured during loading definition {definitionFilename}.\n" +
                          $"See the Debug Log window for detailed information.\n" +
                          $"Any further exception during definition folder loading will be logged to Debug Log window"
            });
            hasErrorMessageBoxShown = true;
        }
    }

    // TODO refactor binding IniDocument values into C# instance, do it automatically using attributes etc
    private void LoadSettings()
    {
        ILogService logService = ServiceProvider.GetRequiredService<ILogService>();
        IModalService modalService = ServiceProvider.GetRequiredService<IModalService>();
        IDefinitionManager definitionManager = ServiceProvider.GetRequiredService<IDefinitionManager>();

        string settingPath = Path.Combine(GlobalState.CurrentPath, "setting.json");
        if (!File.Exists(settingPath))
        {
            SettingIO.SaveDefaultSetting(settingPath);
            return;
        }
        SettingState setting;
        try
        {
            setting = SettingIO.LoadSetting(settingPath, definitionManager);
        }
        catch (Exception e)
        {
            string msg = $"An Exception occured when parsing setting file ({settingPath}).\n" +
                         "Default setting was used instead.\n" +
                         "Please see the debug log window for exception detail";
            logService.LogException(msg, e);
            modalService.ShowErrorMessageBox(new MessageBoxArg()
            {
                Caption = "Cannot read setting file",
                Message = msg
            });
            return;
        }

        // overwrite default setting with setting from file
        GlobalState.Setting = setting;
    }
}
