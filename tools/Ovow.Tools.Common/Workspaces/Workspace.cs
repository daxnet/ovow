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

        public event EventHandler WorkspaceCreated;
        public event EventHandler<WorkspaceEventArgs> WorkspaceOpened;
        public event EventHandler WorkspaceChanged;
        public event EventHandler<WorkspaceEventArgs> WorkspaceSaved;

        protected Workspace()
        {
            
        }

        public bool HasSaved
        {
            get { return !string.IsNullOrEmpty(workspaceFileName); }
        }

        public void New()
        {
            this.model = Create();
            this.model.PropertyChanged += (ps, pe) =>
              {
                  this.OnWorkspaceChanged(EventArgs.Empty);
              };

            this.OnWorkspaceCreated(EventArgs.Empty);
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

                    this.OnWorkspaceOpened(new WorkspaceEventArgs(openFileDialog.FileName));
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
                    this.OnWorkspaceSaved(new WorkspaceEventArgs(workspaceFileName));
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
                            this.OnWorkspaceSaved(new WorkspaceEventArgs(saveFileDialog.FileName));
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
                    this.Save();
                    return true;
                }
                else
                {
                    return true;
                }
            }

            return true;
        }

        protected abstract string WorkspaceFileDescription { get; }

        protected abstract string WorkspaceFileExtension { get; }

        

        protected virtual void OnWorkspaceChanged(EventArgs e)
        {
            this.WorkspaceChanged?.Invoke(this, e);
            changed = true;
        }

        protected virtual void OnWorkspaceCreated(EventArgs e)
        {
            this.WorkspaceCreated?.Invoke(this, e);
            changed = true;
        }

        protected virtual void OnWorkspaceOpened(WorkspaceEventArgs e)
        {
            this.WorkspaceOpened?.Invoke(this, e);
            changed = false;
        }

        protected virtual void OnWorkspaceSaved(WorkspaceEventArgs e)
        {
            this.WorkspaceSaved?.Invoke(this, e);
            changed = false;
        }

        protected abstract void SaveToFile(TModel model, string fileName);

        protected abstract TModel Create();

        protected abstract TModel OpenFromFile(string fileName);
    }
}
