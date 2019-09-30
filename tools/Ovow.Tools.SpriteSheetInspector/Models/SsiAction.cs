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
    public class SsiAction : INotifyPropertyChanged
    {
        private ObservableCollection<SsiActionFrame> frames;

        private string name;

        public ObservableCollection<SsiActionFrame> Frames
        {
            get
            {
                return frames;
            }
            private set
            {
                this.frames = value;
                this.frames.CollectionChanged += (s, e) =>
                {
                    if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                    {
                        foreach(SsiActionFrame frame in e.NewItems)
                        {
                            frame.PropertyChanged += (frSender, frArgs) => OnPropertyChanged("Frame");
                        }
                    }

                    this.OnPropertyChanged("Frames");
                };
            }
        }

        public SsiAction()
        {
            this.Frames = new ObservableCollection<SsiActionFrame>();
        }

        public SsiAction(string name)
            : this()
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.Equals(name, value))
                {
                    OnPropertyChanged("Name");
                }

                name = value;
            }
        }

        public void AddFrame(SsiActionFrame frame)
        {
            var f = GetFrame(frame.BoundingBoxIndex);

            if (f != null)
            {
                throw new InvalidOperationException($"Frame which has the bounding box index of {frame.BoundingBoxIndex} already exists.");
            }

            // frame.PropertyChanged += (s, e) => OnPropertyChanged("Frame");
            this.frames.Add(frame);
        }

        public void RemoveFrame(int boundingBoxIndex)
        {
            var f = GetFrame(boundingBoxIndex);
            if (f != null)
            {
                this.frames.Remove(f);
            }
        }

        public void ClearFrames()
        {
            this.frames.Clear();
        }

        public void MoveFrameUp(int boundingBoxIndex)
        {
            var f = GetFrame(boundingBoxIndex);
            if (f != null)
            {
                var idx = this.frames.IndexOf(f);
                if (idx > 0)
                {
                    this.frames.Move(idx, idx - 1);
                }
            }
        }

        public void MoveFrameDown(int boundingBoxIndex)
        {
            var f = GetFrame(boundingBoxIndex);
            if (f != null)
            {
                var idx = this.frames.IndexOf(f);
                if (idx < Count - 1)
                {
                    this.frames.Move(idx, idx + 1);
                }
            }
        }

        public void MoveFrameTop(int boundingBoxIndex)
        {
            var f = GetFrame(boundingBoxIndex);
            if (f != null)
            {
                var idx = this.frames.IndexOf(f);
                if (idx > 0)
                {
                    this.frames.Move(idx, 0);
                }
            }
        }

        public void MoveFrameBottom(int boundingBoxIndex)
        {
            var f = GetFrame(boundingBoxIndex);
            if (f != null)
            {
                var idx = this.frames.IndexOf(f);
                if (idx < Count - 1)
                {
                    this.frames.Move(idx, Count - 1);
                }
            }
        }

        [JsonIgnore]
        public int Count => this.frames.Count;

        public SsiActionFrame GetFrame(int boundingBoxIndex)
        {
            return this.frames.FirstOrDefault(f => f.BoundingBoxIndex == boundingBoxIndex);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
