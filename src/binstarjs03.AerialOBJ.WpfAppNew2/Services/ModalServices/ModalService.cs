﻿using System.Windows;

using binstarjs03.AerialOBJ.WpfAppNew2.Factories;
using binstarjs03.AerialOBJ.WpfAppNew2.Views;

using Ookii.Dialogs.Wpf;

namespace binstarjs03.AerialOBJ.WpfAppNew2.Services.ModalServices;

public delegate void ShowMessageBoxHandler(MessageBoxArg dialogArg);
public delegate FileDialogResult ShowSaveFileDialogHandler(FileDialogArg dialogArg);

public class ModalService : IModalService
{
    private readonly IAbstractFactory<IAboutView> _aboutViewFactory;

    public ModalService(IAbstractFactory<IAboutView> aboutViewFactory)
    {
        _aboutViewFactory = aboutViewFactory;
    }

    public void ShowMessageBox(MessageBoxArg dialogArg)
    {
        MessageBox.Show(dialogArg.Message, dialogArg.Caption, MessageBoxButton.OK);
    }

    public void ShowErrorMessageBox(MessageBoxArg dialogArg)
    {
        MessageBox.Show(dialogArg.Message, dialogArg.Caption, MessageBoxButton.OK, MessageBoxImage.Error);
    }

    public void ShowAbout()
    {
        _aboutViewFactory.Create()
                         .ShowDialog();
    }

    public FileDialogResult ShowSaveFileDialog(FileDialogArg dialogArg)
    {
        VistaSaveFileDialog dialog = new()
        {
            FileName = dialogArg.FileName,
            DefaultExt = dialogArg.FileExtension,
            Filter = dialogArg.FileExtensionFilter
        };
        bool? result = dialog.ShowDialog();
        return new FileDialogResult()
        {
            SelectedFilePath = dialog.FileName,
            Result = result == true,
        };
    }

    public FolderDialogResult ShowFolderBrowserDialog()
    {
        VistaFolderBrowserDialog dialog = new();
        bool? result = dialog.ShowDialog();
        return new FolderDialogResult()
        {
            Result = result == true,
            SelectedDirectoryPath = dialog.SelectedPath,
        };
    }
}