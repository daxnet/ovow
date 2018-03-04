using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.SpriteSheetInspector.Models
{
    public sealed class SsiProject : INotifyPropertyChanged
    {
        private ObservableCollection<SsiAction> actions;

        private SsiProject()
        {
            this.backgroundColor = ColorArgb.FromColor(default(Color));
        }

        public ObservableCollection<SsiAction> Actions
        {
            get
            {
                return actions;
            }
            private set
            {
                this.actions = value;
                this.actions.CollectionChanged += (s, e) =>
                  {
                      if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                      {
                          foreach(SsiAction action in e.NewItems)
                          {
                              action.PropertyChanged += (actSender, actEventArgs) => OnPropertyChanged("Action");
                          }
                      }

                      OnPropertyChanged("Actions");
                  };
            }
        }

        public SsiProject(string spriteSheetFileName)
            : this()
        {
            this.SpriteSheetFileName = spriteSheetFileName;

            this.Actions = new ObservableCollection<SsiAction>();
        }

        public string SpriteSheetFileName { get; }

        private ColorArgb backgroundColor;

        public ColorArgb BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                if (!backgroundColor.A.Equals(value.A) ||
                    !backgroundColor.R.Equals(value.R) ||
                    !backgroundColor.G.Equals(value.G) ||
                    !backgroundColor.B.Equals(value.B))
                {
                    OnPropertyChanged("BackgroundColor");
                }

                backgroundColor = value;
            }
        }

        public void AddAction(string name)
        {
            if (this.actions.Any(a => a.Name.Equals(name)))
            {
                throw new InvalidOperationException($"The action '{name}' already exists.");
            }

            var action = new SsiAction(name);

            this.actions.Add(action);
        }

        public void AddAction(SsiAction action)
        {
            if (this.actions.Any(a => a.Name.Equals(action.Name)))
            {
                throw new InvalidOperationException($"The action '{action.Name}' already exists.");
            }

            this.actions.Add(action);
        }

        public void RemoveAction(string name)
        {
            var action = GetAction(name);
            if (action != null)
            {
                this.actions.Remove(action);
            }
        }

        public void ClearActions()
        {
            this.actions.Clear();
        }

        public SsiAction GetAction(string name)
        {
            return this.actions.FirstOrDefault(a => a.Name.Equals(name));
        }

        public void RenameAction(string originalName, string newName)
        {
            var action = GetAction(originalName);
            if (action != null)
            {
                action.Name = newName;
            }
        }

        [JsonIgnore]
        public int ActionCount => this.actions.Count;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return this.SpriteSheetFileName;
        }
    }
}
