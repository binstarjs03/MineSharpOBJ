﻿using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

using binstarjs03.MineSharpOBJ.WpfApp.Services;

using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using DialogResult = System.Windows.Forms.DialogResult;

namespace binstarjs03.MineSharpOBJ.WpfApp.UIElements.Windows;

public class DebugLogWindowViewModel : ViewModelWindow<DebugLogWindowViewModel, DebugLogWindow> {
    private string _logContent = string.Empty;

    public DebugLogWindowViewModel(DebugLogWindow window) : base(window) {
        // listen to service events
        LogService.LogHandlers += LogHandler;

        // assign command implementation to commands
        SaveLog = new RelayCommand(OnSaveLog);
        ClearLog = new RelayCommand(OnClearLog);
        WriteSingle = new RelayCommand(OnWriteSingle);
        WriteHorizontal = new RelayCommand(OnWriteHorizontal);
        WriteVertical = new RelayCommand(OnWriteVertical);
    }

    public override void StartEventListening() {
        Window.MainWindow.ViewModel.PropertyChanged += OnOtherViewModelPropertyChanged;
    }

    // States -----------------------------------------------------------------

    public new bool IsVisible {
        get { return Window.MainWindow.ViewModel.IsDebugLogViewVisible; }
        set { Window.MainWindow.ViewModel.IsDebugLogViewVisible = value; }
    }

    public string LogContent { 
        get { return _logContent; }
        set { 
            _logContent = value;
            OnPropertyChanged(nameof(LogContent));
        }
    }

    // Commands ---------------------------------------------------------------

    public ICommand SaveLog { get; }
    public ICommand ClearLog { get; }
    public ICommand WriteSingle { get; }
    public ICommand WriteHorizontal { get; }
    public ICommand WriteVertical { get; }

    // Command Implementations ------------------------------------------------

    private void OnSaveLog(object? arg) {
        using SaveFileDialog dialog = new() {
            FileName = $"MineSharpOBJ Log",
            DefaultExt = ".txt",
            Filter = "Text Document (.txt)|*.txt"
        };
        DialogResult result = dialog.ShowDialog();
        if (result != DialogResult.OK)
            return;
        string path = dialog.FileName;
        try {
            IOService.WriteText(path, _window.LogTextBox.Text);
        }
        catch (IOException ex) {
            ModalService.ShowErrorOK($"Unhandled Exception ({ex})", ex.Message);
        }
    }

    private void OnClearLog(object? arg) {
        LogContent = "";
        LogService.LogRuntimeInfo();
    }

    private void OnWriteSingle(object? arg) {
        LogService.Log("Hello World!");
    }

    private void OnWriteHorizontal(object? arg) {
        LogService.Log("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec eget hendrerit nisl. In ut gravida metus. Suspendisse vitae gravida lacus. Nulla faucibus congue velit, at iaculis dolor interdum a. Nunc id metus sed nunc molestie varius. Cras lobortis auctor urna, ut pulvinar ante. Pellentesque vehicula lobortis nunc et iaculis. Vivamus at lacus tortor. Vivamus euismod eget quam sed rhoncus. Curabitur ipsum velit, venenatis et accumsan vitae, dictum nec augue.");
    }

    private void OnWriteVertical(object? arg) {
        string[] contents = new string[] {
                "Lorem ipsum dolor sit amet",
                "Suspendisse vitae gravida lacus",
                "Nunc id metus sed nunc molestie varius",
                "Vivamus euismod eget quam sed rhoncus",
                "venenatis et accumsan vitae",
                "at iaculis dolor interdum",
                "consectetur adipiscing elit",
                "Donec eget hendrerit nisl",
                "Nulla faucibus congue velit",
            };
        foreach (string content in contents) {
            LogService.Log(content);
        }
    }

    // Event Handlers ---------------------------------------------------------

    protected override void OnOtherViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e) {
        if (sender is MainWindowViewModel)
            if (e.PropertyName == nameof(MainWindowViewModel.IsDebugLogViewVisible))
                OnPropertyChanged(nameof(IsVisible));
    }

    private void LogHandler(string content) {
        LogContent += $"{content}{Environment.NewLine}";
        Window.LogTextBox.ScrollToEnd();
    }
}