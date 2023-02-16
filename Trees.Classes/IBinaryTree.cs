using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees.Classes
{
    public interface IBinaryTree<T> 
    {
        public T Node { get; }
        public IBinaryTree<T>? Left { get;  }
        public IBinaryTree<T>? Right { get;  }

        public void InOrder(List<T> nodeValues); // left, then node, then right
        public void PreOrder(List<T> nodeValues); // node, then left, then right
        public void PostOrder(List<T> nodeValues); // left, then right, then node

        public void Add(T newNode);

        public void Add(List<T> newNodes);

        public List<T> BreadthFirst();
    }
}
