using Trees.Classes;

namespace Trees
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            BinaryTree<int> tree = new(88);
            tree.Add(15);
            tree.Add(12);
            Console.WriteLine(tree.Contains(15));
			Console.WriteLine(tree.Contains(91));
		}
    }
}