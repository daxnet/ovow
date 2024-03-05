using System.ComponentModel;

namespace Ovow.Tools.Core.Workspaces
{
    public abstract class Workspace<TModel>
        where TModel : INotifyPropertyChanged
    {
        private TModel? model;

        private bool changed;
        private string? workspaceFileName;

        public event EventHandler<WorkspaceCreatedEventArgs<TModel>>? WorkspaceCreated;
        public event EventHandler? WorkspaceChanged;
        public event EventHandler? WorkspaceClosed;
        public event EventHandler<WorkspaceOpenedEventArgs<TModel>>? WorkspaceOpened;
        public event EventHandler<WorkspaceSavedEventArgs<TModel>>? WorkspaceSaved;

        protected Workspace()
        {

        }

        public bool HasSaved => !string.IsNullOrEmpty(workspaceFileName);

        public TModel? Model => model;

        public bool New()
        {
            var creatingModel = Create();
            if (creatingModel != null)
            {
                var canClose = Close();
                if (canClose)
                {
                    model = creatingModel;

                    model.PropertyChanged += (ps, pe) =>
                      {
                          OnWorkspaceChanged(EventArgs.Empty);
                      };

                    OnWorkspaceCreated(new WorkspaceCreatedEventArgs<TModel>(model));
                    OnWorkspaceChanged(EventArgs.Empty);

                    return true;
                }
            }

            return false;
        }

        public bool Open()
        {
            using var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = $"{WorkspaceFileDescription}(*.{WorkspaceFileExtension})|*.{WorkspaceFileExtension}";
            openFileDialog.AddExtension = true;
            openFileDialog.DefaultExt = WorkspaceFileExtension;
            openFileDialog.Title = "Open Workspace";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                model = OpenFromFile(openFileDialog.FileName);
                model.PropertyChanged += (_, _) =>
                {
                    OnWorkspaceChanged(EventArgs.Empty);
                };

                workspaceFileName = openFileDialog.FileName;
                OnWorkspaceOpened(new WorkspaceOpenedEventArgs<TModel>(openFileDialog.FileName, model));
                return true;
            }

            return false;
        }

        public bool Save(bool saveAs = false)
        {
            if (HasSaved && !saveAs)
            {
                try
                {
                    SaveToFile(model, workspaceFileName);
                    OnWorkspaceSaved(new WorkspaceSavedEventArgs<TModel>(workspaceFileName, model));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                using var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = $"{WorkspaceFileDescription}(*.{WorkspaceFileExtension})|*.{WorkspaceFileExtension}";
                saveFileDialog.AddExtension = true;
                saveFileDialog.DefaultExt = WorkspaceFileExtension;
                saveFileDialog.Title = "Save Workspace";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        SaveToFile(model, saveFileDialog.FileName);
                        OnWorkspaceSaved(new WorkspaceSavedEventArgs<TModel>(saveFileDialog.FileName, model));
                        workspaceFileName = saveFileDialog.FileName;
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                return false;
            }
        }

        public bool Close()
        {
            if (changed)
            {
                var dlg = MessageBox.Show("Workspace has changed, do you want to save the changes?",
                    "Confirmation",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (dlg == DialogResult.Cancel)
                {
                    return false;
                }
                else if (dlg == DialogResult.Yes)
                {
                    var savedResult = Save();
                    if (savedResult)
                    {
                        OnWorkspaceClosed(EventArgs.Empty);
                        changed = false;
                    }

                    return savedResult;
                }
            }

            OnWorkspaceClosed(EventArgs.Empty);
            changed = false;
            return true;
        }

        protected abstract string WorkspaceFileDescription { get; }

        protected abstract string WorkspaceFileExtension { get; }


        protected virtual void OnWorkspaceChanged(EventArgs e)
        {
            WorkspaceChanged?.Invoke(this, e);
            changed = true;
        }

        protected virtual void OnWorkspaceCreated(WorkspaceCreatedEventArgs<TModel> e)
        {
            WorkspaceCreated?.Invoke(this, e);
            changed = true;
        }

        protected virtual void OnWorkspaceOpened(WorkspaceOpenedEventArgs<TModel> e)
        {
            WorkspaceOpened?.Invoke(this, e);
            changed = false;
        }

        protected virtual void OnWorkspaceSaved(WorkspaceSavedEventArgs<TModel> e)
        {
            WorkspaceSaved?.Invoke(this, e);
            changed = false;
        }

        protected virtual void OnWorkspaceClosed(EventArgs e)
        {
            WorkspaceClosed?.Invoke(this, e);

            changed = false;
            workspaceFileName = null;
        }

        protected abstract void SaveToFile(TModel? model, string? fileName);

        protected abstract TModel? Create();

        protected abstract TModel OpenFromFile(string fileName);
    }
}
