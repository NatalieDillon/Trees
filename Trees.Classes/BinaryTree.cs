namespace Trees.Classes
{
    public class BinaryTree<T> where T : IComparable
    {     
      
        // Public properties
        public T Node { get; private set; }

        public BinaryTree<T>? Left
        {
            get; protected set;
        }

        public BinaryTree<T>? Right
        {
            get; protected set;
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
            Queue<BinaryTree<T>> queue = new();
            BinaryTree<T>? current = this;
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

        public bool Contains(T node)
        {
            if (Node.CompareTo(node) > 0)
            {
                if (Left != null)
                {
                    return Left.Contains(node);
                }                
            }
            else if (Node.CompareTo(node) < 0)
            {
                if (Right != null)
                {
                    return Right.Contains(node);
                }
            }
            return Node.Equals(node);
        }

        public virtual void Add(T newNode)
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

        public void Remove(T node)
        {
           if (Node.CompareTo(node) == 0)
           {
                return; // We can't remove the root node 
           }
           RemoveNode(node);
        }

       private BinaryTree<T>? RemoveNode(T node)
        {
            if (Node.CompareTo(node) > 0 && Left!= null)
            {
                Left = Left.RemoveNode(node);
                return this;
            }
            else if (Node.CompareTo(node) < 0 && Right != null)
            {
               Right = Right.RemoveNode(node);
               return this;
            }
            else if (Node.Equals(node))
            {
                 if (Left == null) {
                    return Right; 
                }
                else if (Right == null)
                {
                    return Left; 
                }

                // Return the smallest node in the right sub tree
                BinaryTree<T> current = Right;
                while (current.Left != null)
                {
                    current= current.Left;
                }
                Node = current.Node;
                Right = Right.RemoveNode(current.Node);
                return this;
            }
            else
            {
                return this; // node not found
            }
        }
    }
}