using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ovow.Tools.SpriteSheetInspector
{
    public static class Utils
    {
        public static void MoveUp(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index - 1, node);
                }
            }

            node.TreeView.SelectedNode = node;
        }

        public static void MoveDown(this TreeNode node)
        {
            TreeNode parent = node.Parent;
            
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, node);
                }
            }

            node.TreeView.SelectedNode = node;
        }

        public static void MoveTop(this TreeNode node)
        {
            while(node.PrevNode != null)
            {
                node.MoveUp();
            }

            node.TreeView.SelectedNode = node;
        }

        public static void MoveBottom(this TreeNode node)
        {
            while(node.NextNode != null)
            {
                node.MoveDown();
            }

            node.TreeView.SelectedNode = node;
        }

        public static void RemoveEx(this TreeNode node)
        {
            var tv = node.TreeView;
            TreeNode nextSelectedNode = null;
            if (node.Parent.Nodes.Count == 1)
            {
                nextSelectedNode = node.Parent;
            }
            else
            {
                if (node.NextNode != null)
                {
                    nextSelectedNode = node.NextNode;
                }
                else
                {
                    nextSelectedNode = node.PrevNode;
                }
            }

            node.Remove();
            tv.SelectedNode = nextSelectedNode;
        }
    }
}
