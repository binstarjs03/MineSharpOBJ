﻿using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

using binstarjs03.MineSharpOBJ.Core.Utils;
using binstarjs03.MineSharpOBJ.WpfApp.Services;

namespace binstarjs03.MineSharpOBJ.WpfApp.UIElements.Windows;

public class MainWindowViewModel : ViewModelWindow<MainWindowViewModel, MainWindow> {
    private bool _isDebugLogWindowVisible = false;
    private bool _isViewportDebugControlVisible = false;
    private bool _isViewportCameraPositionGuideVisible = false;
    private string _title = "MineSharpOBJ";
    private SessionInfo? _session;

    public MainWindowViewModel(MainWindow view) : base(view) {
        // assign command implementation to commands
        LoadSavegameFolder = new RelayCommand(OnLoadSavegameFolder);
        CloseSession = new RelayCommand(OnCloseSession, HasSession);
        OpenAboutView = new RelayCommand(OnOpenAboutView);
        ViewportGoto = new RelayCommand(OnViewportGoto, HasSession);
    }

    public override void StartEventListening() {
        DebugLogWindowViewModel.Context!.PropertyChanged += OnOtherViewModelPropertyChanged;
    }

    // States -----------------------------------------------------------------

    public bool IsDebugLogViewVisible {
        get { return _isDebugLogWindowVisible; }
        set {
            if (value == _isDebugLogWindowVisible)
                return;
            _isDebugLogWindowVisible = value;
            OnPropertyChanged(nameof(IsDebugLogViewVisible));
        }
    }

    public bool IsViewportDebugControlVisible {
        get { return _isViewportDebugControlVisible; }
        set {
            if (value == _isViewportDebugControlVisible)
                return;
            _isViewportDebugControlVisible = value;
            OnPropertyChanged(nameof(IsViewportDebugControlVisible));
        }
    }

    public bool IsViewportCameraPositionGuideVisible {
        get { return _isViewportCameraPositionGuideVisible; }
        set {
            if (value == _isViewportCameraPositionGuideVisible)
                return;
            _isViewportCameraPositionGuideVisible = value;
            OnPropertyChanged(nameof(IsViewportCameraPositionGuideVisible));
        }
    }

    public string Title {
        get { return _title; }
        set {
            _title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    // Commands ---------------------------------------------------------------

    public ICommand LoadSavegameFolder { get; }

    public ICommand CloseSession { get; }

    public ICommand OpenAboutView { get; }

    public ICommand ViewportGoto { get; }

    // Command Implementations ------------------------------------------------

    private void OnLoadSavegameFolder(object? arg) {
        using FolderBrowserDialog dialog = new();
        DialogResult dialogResult = dialog.ShowDialog();
        if (dialogResult != DialogResult.OK)
            return;
        SessionInfo? session = IOService.LoadSavegame(dialog.SelectedPath);
        if (session is null) {
            LogService.Log("Failed changing session. Aborting...", useSeparator: true);
            return;
        }
        ChangeTitle(session.Value.WorldName);
        _session = session;
        LogService.Log("Successfully changed session.", useSeparator: true);
    }

    private void OnCloseSession(object? arg) {
        ChangeTitle();
        _session = null;
        LogService.Log("Successfully closed session.", useSeparator: true);
    }

    private void OnOpenAboutView(object? arg) {
        ModalService.ShowAboutModal();
    }

    private void OnViewportGoto(object? arg) {
        // TODO instead of mutating the camera position of viewport
        // inside Goto vm, viewport vm should call Goto and return
        // the returned PointF, null means cancelling just return,
        // else set camera position to return values of Goto PointF
        PointF? cameraPos = ModalService.ShowGotoModal(Window.Viewport);
        if (cameraPos is null)
            return;
        Window.Viewport.SetCameraPosition((PointF)cameraPos);
    }

    // Command Availability ---------------------------------------------------

    private bool HasSession(object? arg) {
        return _session is not null;
    }

    // Event Handlers ---------------------------------------------------------

    protected override void OnOtherViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e) {
        if (sender is DebugLogWindowViewModel vm) {
            if (e.PropertyName == nameof(DebugLogWindowViewModel.IsVisible))
                IsDebugLogViewVisible = vm.IsVisible;
        }
    }

    // Private Methods --------------------------------------------------------

    private void ChangeTitle(string? title = null) {
        if (title is null)
            Title = $"MineSharpOBJ";
        else
            Title = $"MineSharpOBJ - {title}";
    }
}
