using System.ComponentModel;

namespace Ovow.Tools.Core.Workspaces
{
    public sealed class WorkspaceCreatedEventArgs<TModel> : EventArgs
        where TModel : INotifyPropertyChanged
    {
        public WorkspaceCreatedEventArgs(TModel model)
        {
            Model = model;
        }

        public TModel Model { get; }
    }
}
