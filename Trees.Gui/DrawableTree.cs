using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees.Classes;

#nullable enable

namespace Trees.Gui
{
    internal class DrawableTree<T> : BinaryTree<T>, IDrawable where T : IComparable<T>
    {
               
        // Protected methods
        protected override void CreateRightNode(T node)
        {
            _right = new DrawableTree<T>(node);
        }

        protected override void CreateLeftNode(T node)
        {
            _left = new DrawableTree<T>(node);
        }
        public DrawableTree(T node) : base(node)
        {
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 1;
            canvas.DrawString(Node.ToString(), dirtyRect.Center.X, dirtyRect.Y, 100, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
            if (Left != null)
            {                
                canvas.DrawLine(dirtyRect.Center.X, dirtyRect.Y, dirtyRect.Center.X - 50, dirtyRect.Y + 50);
                dirtyRect.X -= 50;
                dirtyRect.Y += 50;
                ((DrawableTree<T>)Left).Draw(canvas, dirtyRect);
                dirtyRect.X += 50;
                dirtyRect.Y -= 50;
            }
            if (Right != null)
            {
                canvas.DrawLine(dirtyRect.Center.X, dirtyRect.Y, dirtyRect.Center.X + 50, dirtyRect.Y + 50);
                dirtyRect.X += 50;
                dirtyRect.Y += 50;
                ((DrawableTree<T>)Right).Draw(canvas, dirtyRect);
                dirtyRect.X -= 50;
                dirtyRect.Y -= 50;
            }
        }

        
    }
}
