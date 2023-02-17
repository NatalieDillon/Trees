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
    internal class DrawableTree<T> : BinaryTree<T>, IDrawable where T : IComparable<T>, IEquatable<T>
    {               
        public int Level { get; set; }
     
        public DrawableTree(T node, int level) : base(node)
        {
            Level = level;
        }

        public DrawableTree(T node) : base(node)
        {
            Level = 1;
        }

        private const int OffsetIncrement = 75;
        private const int MinimumOffset = 50;
        private const int MaxOffset = 200;
        private const int YIncrement = 75;
        
        private int CalcOffset()
        {
            int offset = MaxOffset - ((Level-1) * OffsetIncrement);
            return offset > MinimumOffset ? offset : MinimumOffset;
        }      

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.StrokeColor = Colors.Red;
            canvas.StrokeSize = 1;

            int offset = CalcOffset();
            canvas.DrawString(Node.ToString(), dirtyRect.Center.X, dirtyRect.Y, 100, 100, HorizontalAlignment.Left, VerticalAlignment.Top);
            if (Left != null)
            {
                canvas.DrawLine(dirtyRect.Center.X - 5, dirtyRect.Y + 10, dirtyRect.Center.X - offset, dirtyRect.Y + YIncrement);
                dirtyRect.X -= offset;
                dirtyRect.Y += YIncrement;
                ((DrawableTree<T>)Left).Draw(canvas, dirtyRect);
                dirtyRect.X += offset;
                dirtyRect.Y -= YIncrement;
            }
            if (Right != null)
            {
                canvas.DrawLine(dirtyRect.Center.X + 5, dirtyRect.Y + 15, dirtyRect.Center.X + offset, dirtyRect.Y + YIncrement);
                dirtyRect.X += offset;
                dirtyRect.Y += YIncrement;
                ((DrawableTree<T>)Right).Draw(canvas, dirtyRect);
                dirtyRect.X -= offset;
                dirtyRect.Y -= YIncrement;
            }
        }

        public override void Add(T newNode)
        {
            DrawableTree<T> current = this;
            while (current != null)
            {
                if (current.Node.CompareTo(newNode) > 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new DrawableTree<T>(newNode, current.Level+1);
                        return;
                    }
                    else
                    {
                        current = (DrawableTree<T>)current.Left;
                    }
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new DrawableTree<T>(newNode, current.Level+1);
                        return;
                    }
                    else
                    {
                        current = (DrawableTree<T>)current.Right;
                    }
                }
            }
        }


    }
}
