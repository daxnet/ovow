﻿using System.ComponentModel;

namespace Ovow.Tools.Core.Workspaces
{
    public sealed class WorkspaceSavedEventArgs<TModel>(string? fileName, TModel? model) : EventArgs
        where TModel : INotifyPropertyChanged
    {
        public string? FileName { get; } = fileName;

        public TModel? Model { get; } = model;
    }
}
