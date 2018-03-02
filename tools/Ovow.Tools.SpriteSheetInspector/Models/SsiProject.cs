using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.SpriteSheetInspector.Models
{
    public sealed class SsiProject : INotifyPropertyChanged
    {
        [JsonProperty]
        private readonly ObservableCollection<SsiAction> actions = new ObservableCollection<SsiAction>();

        public SsiProject(string spriteSheetFileName)
        {
            this.SpriteSheetFileName = spriteSheetFileName;
            this.actions.CollectionChanged += (ccs, cce) =>
              {
                  OnPropertyChanged("actions");
              };
        }

        public string SpriteSheetFileName { get; }

        public void AddAction(string name)
        {
            if (this.actions.Any(a => a.Name.Equals(name)))
            {
                throw new InvalidOperationException($"The action '{name}' already exists.");
            }

            var action = new SsiAction(name);
            action.PropertyChanged += (s, e) => OnPropertyChanged("action");
            this.actions.Add(action);
        }

        public void AddAction(SsiAction action)
        {
            if (this.actions.Any(a => a.Name.Equals(action.Name)))
            {
                throw new InvalidOperationException($"The action '{action.Name}' already exists.");
            }

            action.PropertyChanged += (s, e) => OnPropertyChanged("action");
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
        public int Count => this.actions.Count;

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
