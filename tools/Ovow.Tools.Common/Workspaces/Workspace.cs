using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ovow.Tools.Common.Workspaces
{
    public abstract class Workspace<TModel>
        where TModel : INotifyPropertyChanged
    {
        private TModel model;

        private bool changed;
        private string workspaceFileName;

        public event EventHandler<WorkspaceCreatedEventArgs<TModel>> WorkspaceCreated;
        public event EventHandler WorkspaceChanged;
        public event EventHandler WorkspaceClosed;
        public event EventHandler<WorkspaceOpenedEventArgs> WorkspaceOpened;
        public event EventHandler<WorkspaceSavedEventArgs> WorkspaceSaved;

        protected Workspace()
        {
            
        }

        public bool HasSaved
        {
            get { return !string.IsNullOrEmpty(workspaceFileName); }
        }

        public TModel Model => this.model;

        public void New()
        {
            this.model = Create();

            if (this.model != null)
            {
                this.model.PropertyChanged += (ps, pe) =>
                  {
                      this.OnWorkspaceChanged(EventArgs.Empty);
                  };

                this.OnWorkspaceCreated(new WorkspaceCreatedEventArgs<TModel>(this.model));
                this.OnWorkspaceChanged(EventArgs.Empty);
            }
        }

        public bool Open()
        {
            using (var openFileDialog = new OpenFileDialog
                {
                    Filter = $"{WorkspaceFileDescription}(*.{WorkspaceFileExtension})|*.{WorkspaceFileExtension}",
                    AddExtension = true,
                    DefaultExt = WorkspaceFileExtension,
                    Title = "Open Workspace"
                })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.model = OpenFromFile(openFileDialog.FileName);
                    this.model.PropertyChanged += (ps, pe) =>
                      {
                          this.OnWorkspaceChanged(EventArgs.Empty);
                      };

                    this.OnWorkspaceOpened(new WorkspaceOpenedEventArgs(openFileDialog.FileName));
                    return true;
                }

                return false;
            }
        }

        public bool Save(bool saveAs = false)
        {
            if (HasSaved && !saveAs)
            {
                try
                {
                    this.SaveToFile(this.model, workspaceFileName);
                    this.OnWorkspaceSaved(new WorkspaceSavedEventArgs(workspaceFileName));
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                using (var saveFileDialog = new SaveFileDialog
                {
                    Filter = $"{WorkspaceFileDescription}(*.{WorkspaceFileExtension})|*.{WorkspaceFileExtension}",
                    AddExtension = true,
                    DefaultExt = WorkspaceFileExtension,
                    Title = "Save Workspace"
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            this.SaveToFile(this.model, saveFileDialog.FileName);
                            this.OnWorkspaceSaved(new WorkspaceSavedEventArgs(saveFileDialog.FileName));
                            this.workspaceFileName = saveFileDialog.FileName;
                            return true;
                        }
                        catch
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                
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
                    var savedResult = this.Save();
                    if (savedResult)
                    {
                        OnWorkspaceClosed(EventArgs.Empty);
                    }

                    return savedResult;
                }
            }

            OnWorkspaceClosed(EventArgs.Empty);
            return true;
        }

        protected abstract string WorkspaceFileDescription { get; }

        protected abstract string WorkspaceFileExtension { get; }


        protected virtual void OnWorkspaceChanged(EventArgs e)
        {
            this.WorkspaceChanged?.Invoke(this, e);
            changed = true;
        }

        protected virtual void OnWorkspaceCreated(WorkspaceCreatedEventArgs<TModel> e)
        {
            this.WorkspaceCreated?.Invoke(this, e);
            changed = true;
        }

        protected virtual void OnWorkspaceOpened(WorkspaceOpenedEventArgs e)
        {
            this.WorkspaceOpened?.Invoke(this, e);
            changed = false;
        }

        protected virtual void OnWorkspaceSaved(WorkspaceSavedEventArgs e)
        {
            this.WorkspaceSaved?.Invoke(this, e);
            changed = false;
        }

        protected virtual void OnWorkspaceClosed(EventArgs e)
        {
            this.WorkspaceClosed?.Invoke(this, e);
        }

        protected abstract void SaveToFile(TModel model, string fileName);

        protected abstract TModel Create();

        protected abstract TModel OpenFromFile(string fileName);
    }
}
