using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovow.Tools.Core.Components
{
    public sealed class FormAction : Component
    {
        private readonly IEnumerable<ToolStripItem> _items;
        private readonly EventHandler _handler;
        private bool _enabled;
        private bool _visible;
        private Image? _image;
        private string? _toolTipText;
        private Keys? _shortcutKeys;

        public FormAction(IEnumerable<ToolStripItem> items, EventHandler handler)
        {
            _items = items;
            _handler = handler;
            foreach (var item in _items)
            {
                item.Click += _handler;
            }

            Enabled = true;
            Visible = true;
        }

        public bool Enabled
        {
            get => _enabled;
            set
            {
                if (_enabled == value) return;
                _enabled = value;
                foreach (var item in _items)
                {
                    item.Enabled = _enabled;
                }
            }
        }

        public bool Visible
        {
            get => _visible;
            set
            {
                if (_visible == value) return;
                _visible = value;
                foreach (var item in _items)
                {
                    item.Visible = _visible;
                }
            }
        }

        public Image? Image
        {
            get => _image;
            set
            {
                _image = value;
                if (_image is null) return;
                foreach (var item in _items)
                {
                    item.Image = value;
                }
            }
        }

        public string? ToolTipText
        {
            get => _toolTipText;
            set
            {
                if (_toolTipText != value)
                {
                    _toolTipText = value;
                    if (string.IsNullOrWhiteSpace(_toolTipText)) return;
                    foreach (var item in _items)
                    {
                        item.ToolTipText = _toolTipText;
                    }
                }
            }
        }

        public Keys? ShortcutKeys
        {
            get => _shortcutKeys;
            set
            {
                if (_shortcutKeys != value)
                {
                    _shortcutKeys = value;
                    if (_shortcutKeys is null) return;
                    foreach (var item in _items)
                    {
                        if (item is not ToolStripMenuItem toolStripMenuItem) continue;
                        toolStripMenuItem.ShortcutKeys = _shortcutKeys.Value;
                        toolStripMenuItem.ShowShortcutKeys = true;
                    }
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var item in _items)
                {
                    item.Click -= _handler;
                }
            }

            base.Dispose(disposing);
        }
    }
}
