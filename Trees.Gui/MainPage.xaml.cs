using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace Trees.Gui
{
    public partial class MainPage : ContentPage
    {
        DrawableTree<string> tree;
        List<string> traversedItems = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            if (tree == null)
            {
                tree = new DrawableTree<string>(entry.Text);
                graphicsView.Drawable = tree;
            }
            else
            {
                tree.Add(entry.Text);
            }
            entry.Text= string.Empty;
            graphicsView.Invalidate();
        }

        private async void OnRemoveClicked(object sender, EventArgs e)
        {
            try
            {
                if (tree != null)
                {
                    tree.Remove(remove.Text);
                    graphicsView.Invalidate();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Could not remove node {ex.Message}", "OK");
            }
        }

        private async void OnInOrderClicked(object sender, EventArgs e)
        {
            try
            {
                traversedItems.Clear();
                if (tree != null)
                {
                    tree.InOrder(traversedItems);
                    displayNodes.Text = string.Empty;
                    foreach (string node in traversedItems)
                    {
                        displayNodes.Text += node + "\n";
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Could not display nodes in order. {ex.Message}", "OK");
            }
        }

        private void OnClearClicked(object sender, EventArgs e)
        {
            tree = null;
            displayNodes.Text = string.Empty;
            graphicsView.Drawable = null;
            graphicsView.Invalidate();
        }
    }
}