namespace Trees.Classes
{
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        public T Node { get; private set; }
        public IBinaryTree<T>? Left { get; private set; }
        public IBinaryTree<T>? Right { get; private set; }

        public BinaryTree(T node)
        {
            Node = node;
        }

        public void InOrder(List<T> nodeValues) 
        {
            if (Left != null) 
            { 
                Left.InOrder(nodeValues); 
            }
            nodeValues.Add(Node);
            if (Right != null)
            {
                Right.InOrder(nodeValues);
            }
        }

        public void PreOrder(List<T> nodeValues)
        {
            nodeValues.Add(Node);
            if (Left != null)
            {
                Left.PreOrder(nodeValues);
            }
            if (Right != null)
            {
                Right.PreOrder(nodeValues);
            }
        }

        public void PostOrder(List<T> nodeValues)
        {           
            if (Left != null)
            {
                Left.PostOrder(nodeValues);
            }
            if (Right != null)
            {
                Right.PostOrder(nodeValues);
            }
            nodeValues.Add(Node);
        }

        public List<T> BreadthFirst()
        {
            List<T> nodeValues = new();
            Queue<IBinaryTree<T>> queue = new();
            IBinaryTree<T>? current = this;
            while (current != null)
            {
                nodeValues.Add(current.Node);
                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
                current = queue.Count == 0 ? null : queue.Dequeue();
            }
            return nodeValues;
        }

        public void Add(T newNode)  
        {
            if (Node.CompareTo(newNode) > 0)
            {
                if (Left == null)
                {
                    Left = new BinaryTree<T>(newNode);
                }
                else
                {
                    Left.Add(newNode);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinaryTree<T>(newNode);
                }
                else
                {
                    Right.Add(newNode);
                }
            }
        }

        public void Add(List<T> newNodes)
        {
            foreach (T node in newNodes)
            {
                Add(node);
            }
        }
    }
}