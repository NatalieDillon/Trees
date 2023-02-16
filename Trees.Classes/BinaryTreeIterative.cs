namespace Trees.Classes
{
    public class BinaryTreeIterative<T> : IBinaryTree<T> where T : IComparable<T>
    {
        public T Node { get; private set; }
        public IBinaryTree<T>? Left { get; private set; }
        public IBinaryTree<T>? Right { get; private set; }

        public BinaryTreeIterative(T node)
        {
            Node = node;
        }

        public void InOrder(List<T> nodeValues) 
        {
            Stack<IBinaryTree<T>> stack = new();
            IBinaryTree<T>? current = this;
            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                IBinaryTree<T> output = stack.Pop();
                nodeValues.Add(output.Node);
                current = output.Right;
            }
        }

        public void Add(List<T> newNodes)
        {
            foreach (T node in newNodes)
            {
                Add(node);
            }
        }

        public void Add(T newNode)
        {
            BinaryTreeIterative<T> current = this;
            while (current != null)
            {
                if (current.Node.CompareTo(newNode) > 0)
                {
                    if (current.Left == null)
                    {
                        current.Left = new BinaryTreeIterative<T>(newNode);
                        return;
                    }
                    else
                    {
                        current = (BinaryTreeIterative<T>)current.Left;
                    }
                }
                else
                {
                    if (current.Right == null)
                    {
                        current.Right = new BinaryTreeIterative<T>(newNode);
                        return;
                    }
                    else
                    {
                        current = (BinaryTreeIterative<T>)current.Right;
                    }
                }
            }
        }

        public void PreOrder(List<T> nodeValues)
        {
            throw new NotImplementedException();
        }

        public void PostOrder(List<T> nodeValues)
        {
            throw new NotImplementedException();
        }

        public List<T> BreadthFirst()
        {
            throw new NotImplementedException();
        }
    }
}