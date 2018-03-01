using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.SpriteSheetInspector.Models
{
    public class SsiAction
    {
        public SsiAction()
        {
            this.Frames = new List<SsiActionFrame>();
        }

        public string Name { get; set; }

        public List<SsiActionFrame> Frames { get; set; }
    }
}
