﻿namespace binstarjs03.AerialOBJ.WpfAppNew2.Services;

public readonly struct MessageBoxArg
{
    public required string Message { get; init; }
    public required string Caption { get; init; }
}

public readonly struct SaveFileDialogArg
{
    public required string FileName { get; init; }
    public required string FileExtension { get; init; }
    public required string FileExtensionFilter { get; init; }
}