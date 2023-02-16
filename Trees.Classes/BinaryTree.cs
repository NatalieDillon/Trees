namespace Trees.Classes
{
    public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
    {
        // Private fields
        protected BinaryTree<T>? _right;
        protected BinaryTree<T>? _left;

        // Protected methods
        protected virtual void CreateRightNode(T node)
        {
            _right = new BinaryTree<T>(node);
        }

        protected virtual void CreateLeftNode(T node)
        {
            _left = new BinaryTree<T>(node);
        }

        // Public properties
        public T Node { get; private set; }

        public virtual IBinaryTree<T>? Left
        {
            get
            {
                return _left;
            }
        }

        public virtual IBinaryTree<T>? Right
        {
            get
            {
                return _right;
            }
        }

        // Constructor
        public BinaryTree(T node)
        {
            Node = node;
        }

        // Public methods
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
                    CreateLeftNode(newNode);
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
                    CreateRightNode(newNode);
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