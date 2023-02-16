using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace Trees.Gui
{
    public partial class MainPage : ContentPage
    {
        DrawableTree<string> tree;

        public MainPage()
        {
            InitializeComponent();
            tree = new DrawableTree<string>("mammoth");
            List<string> list = new() { "penguin", "cat", "bat", "dog", "bird", "snake", "panda", "ant" };
            tree.Add(list);
            graphicsView.Drawable = tree;  
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            tree.Add(entry.Text);
            graphicsView.Invalidate();
        }
    }
}