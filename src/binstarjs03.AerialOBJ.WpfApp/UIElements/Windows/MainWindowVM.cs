﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

using binstarjs03.AerialOBJ.WpfApp.Services;
using binstarjs03.AerialOBJ.WpfApp.UIElements.Controls;

using Application = System.Windows.Application;

namespace binstarjs03.AerialOBJ.WpfApp.UIElements.Windows;

public class MainWindowVM : ViewModelWindow<MainWindowVM, MainWindow>
{
    #region States - Fields and Properties

    private string _title = App.Current.State.SavegameLoadInfo is null ?
        AppState.AppName : $"{AppState.AppName} - {App.Current.State.SavegameLoadInfo!.WorldName}";

    public bool HasSavegameLoaded => App.Current.State.HasSavegameLoaded;

    public string Title
    {
        get => _title;
        set => SetAndNotifyPropertyChanged(value, ref _title);
    }

    public bool DebugLogWindowVisible
    {
        get => App.Current.State.DebugLogWindowVisible;
        set => App.Current.State.DebugLogWindowVisible = value;
    }

    #endregion States - Fields and Properties

    public MainWindowVM(MainWindow window) : base(window)
    {
        App.Current.State.SavegameLoadChanged += OnSavegameLoadChanged;
        App.Current.State.DebugLogWindowVisibleChanged += OnDebugLogWindowVisibleChanged;

        // set commands to its corresponding implementations
        AboutCommand = new RelayCommand(OnAbout);
        OpenCommand = new RelayCommand(OnOpen);
        CloseCommand = new RelayCommand(OnClose, (arg) => HasSavegameLoaded);
        SettingCommand = new RelayCommand(OnSetting);
        ForceGCCommand = new RelayCommand(OnForceGCCommand);
    }

    #region Commands

    public ICommand AboutCommand { get; }
    public ICommand OpenCommand { get; }
    public ICommand CloseCommand { get; }
    public ICommand SettingCommand { get; }
    public ICommand ForceGCCommand { get; }

    protected override void OnWindowClose(object? arg)
    {
        Application.Current.Shutdown();
    }

    private void OnAbout(object? arg)
    {
        ModalService.ShowAboutModal();
    }

    private void OnOpen(object? arg)
    {
        LogService.Log("Attempting to loading savegame...");
        using FolderBrowserDialog dialog = new();
        DialogResult dialogResult = dialog.ShowDialog();
        if (dialogResult != DialogResult.OK)
        {
            LogService.LogAborted("Dialog cancelled. Aborting...", useSeparator: true);
            return;
        }

        SavegameLoadInfo? loadInfo = IOService.LoadSavegame(dialog.SelectedPath);
        if (loadInfo is null)
        {
            LogService.LogAborted("Failed changing savegame. Aborting...", useSeparator: true);
            return;
        }

        // close if session exist, this is to ensure
        // every components are reinitialized, such as ChunkManager, etc
        if (App.Current.State.HasSavegameLoaded)
        {
            LogService.Log("Savegame already opened, closing...");
            OnClose(null);
        }

        App.Current.State.SavegameLoadInfo = loadInfo;
        LogService.LogSuccess("Successfully changed savegame.", useSeparator: true);
    }

    private void OnClose(object? arg)
    {
        string logSuccessMsg;
        LogService.Log("Attempting to closing savegame...");

        if (App.Current.State.SavegameLoadInfo is null)
        {
            LogService.LogWarning($"{nameof(App.Current.State.SavegameLoadInfo)} is already closed!");
            logSuccessMsg = "Successfully closed savegame.";
        }
        else
        {
            string worldName = App.Current.State.SavegameLoadInfo.WorldName;
            logSuccessMsg = $"Successfully closed savegame \"{worldName}\".";
        }

        App.Current.State.SavegameLoadInfo = null;
        LogService.LogSuccess(logSuccessMsg, useSeparator: true);
    }

    private void OnSetting(object? arg)
    {
        ModalService.ShowSettingModal();
    }

    private void OnForceGCCommand(object? arg)
    {
        GC.Collect();
        LogService.LogWarning("Garbage collection was forced done by the user!", useSeparator: true);
    }

    #endregion Commands

    #region Event Handlers

    private void OnSavegameLoadChanged(SavegameLoadState state)
    {
        string title = state switch
        {
            SavegameLoadState.Opened => $"{AppState.AppName} - {App.Current.State.SavegameLoadInfo!.WorldName}",
            SavegameLoadState.Closed => AppState.AppName,
            _ => throw new NotImplementedException()
        };
        Title = title;
        NotifyPropertyChanged(nameof(HasSavegameLoaded));
    }

    private void OnDebugLogWindowVisibleChanged(bool obj)
    {
        NotifyPropertyChanged(nameof(DebugLogWindowVisible));
    }

    #endregion Event Handlers
}
