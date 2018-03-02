using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.SpriteSheetInspector.Models
{
    public sealed class SsiActionFrame : INotifyPropertyChanged
    {
        [JsonProperty]
        private int boundingBoxIndex;

        [JsonProperty]
        private int x;

        [JsonProperty]
        private int y;

        [JsonProperty]
        private int width;

        [JsonProperty]
        private int height;

        [JsonIgnore]
        public int BoundingBoxIndex
        {
            get
            {
                return boundingBoxIndex;
            }
            set
            {
                if (boundingBoxIndex != value)
                {
                    OnPropertyChanged("BoundingBoxIndex");
                }

                boundingBoxIndex = value;
            }
        }

        [JsonIgnore]
        public int X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    OnPropertyChanged("X");
                }

                x = value;
            }
        }

        [JsonIgnore]
        public int Y
        {
            get { return y; }
            set
            {
                if (y != value)
                {
                    OnPropertyChanged("Y");
                }

                y = value;
            }
        }

        [JsonIgnore]
        public int Width
        {
            get { return width; }
            set
            {
                if (width != value)
                {
                    OnPropertyChanged("Width");
                }

                width = value;
            }
        }

        [JsonIgnore]
        public int Height
        {
            get { return height; }
            set
            {
                if (height != value)
                {
                    OnPropertyChanged("Height");
                }

                height = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"[{BoundingBoxIndex}] - (X={X}, Y={Y}, W={Width}, H={Height})";
        }
    }
}
