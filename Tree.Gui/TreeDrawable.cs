using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Classes;

namespace Tree.Gui
{
    public class TreeDrawable : IDrawable
    {
        BinaryTree<string> tree;

        public TreeDrawable()
        {
            List<string> list = new() { "cat", "goldfish", "rabbit", "dog", "bird", "giraffe" };
            tree = new("fox");
            tree.Add(list);
        }

        public void Draw(ICanvas canvas, RectF rect)
        {
            {
                canvas.DrawString(tree.Node, 20, 60, 380, 100, HorizontalAlignment.Center, VerticalAlignment.Top);
            }
        }
    }
}
