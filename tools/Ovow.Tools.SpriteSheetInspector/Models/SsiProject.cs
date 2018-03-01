using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.SpriteSheetInspector.Models
{
    public sealed class SsiProject : INotifyPropertyChanged
    {
        private readonly List<SsiAction> actions = new List<SsiAction>();

        public SsiProject(string spriteSheetFileName)
        {
            this.SpriteSheetFileName = spriteSheetFileName;
        }

        public string SpriteSheetFileName { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
