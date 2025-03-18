using Trees.Classes;

namespace Trees
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            BinaryTree<int> tree = new(14);
            tree.Add(12);
            tree.Add(7);
			tree.Add(4);
            tree.Remove(7);
		}
    }
}