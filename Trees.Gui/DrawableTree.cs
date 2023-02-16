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

        public void Draw(ICanvas canvas, RectF dirtyRect, int level)
        {
            int xOffset = 50;
            canvas.DrawString(Node.ToString(), dirtyRect.Center.X, dirtyRect.Y, 100, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
            if (Left != null)
            {                
                if (level == 1)
                {
                    xOffset *= 2;
                }
                canvas.DrawLine(dirtyRect.Center.X - 5, dirtyRect.Y + 10, dirtyRect.Center.X - xOffset, dirtyRect.Y + 50);
                dirtyRect.X -= xOffset;
                dirtyRect.Y += 50;
                level += 1;
                ((DrawableTree<T>)Left).Draw(canvas, dirtyRect, level);
                dirtyRect.X += xOffset;
                dirtyRect.Y -= 50;
                level -= 1;
            }
            if (Right != null)
            {               
                if (level == 1)
                {
                    xOffset *= 2;
                }
                canvas.DrawLine(dirtyRect.Center.X + 20, dirtyRect.Y + 15, dirtyRect.Center.X + xOffset, dirtyRect.Y + 45);
                dirtyRect.X += xOffset;
                dirtyRect.Y += 50;
                level += 1;
                ((DrawableTree<T>)Right).Draw(canvas, dirtyRect, level);
                dirtyRect.X -= xOffset;
                dirtyRect.Y -= 50;
                level -= 1;
            }
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 1;
            Draw(canvas, dirtyRect, 1);
        }

        
    }
}
