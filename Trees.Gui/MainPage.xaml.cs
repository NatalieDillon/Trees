using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace Trees.Gui
{
    public partial class MainPage : ContentPage
    {
        DrawableTree<IComparable> tree;
        List<IComparable> traversedItems = new();

		public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            try
            {
                if (tree == null)
                {
                    // If the tree is null pick between string and decimal
                    decimal decimalItem;
                    if (decimal.TryParse(entry.Text, out decimalItem))
                    {
                        tree = new DrawableTree<IComparable>(decimalItem);
                    }
                    else
                    {
                        tree = new DrawableTree<IComparable>(entry.Text);
                    }

                    graphicsView.Drawable = tree;
                }
                else
                {
                    // If the tree is not null convert to the same type 
                    if (tree.Node is decimal)
                    {
                        tree.Add(decimal.Parse(entry.Text));
                    }
                    else
                    {
                        tree.Add(entry.Text);
                    }
                }
                entry.Text = string.Empty;
                graphicsView.Invalidate();
            }
            catch (Exception ex) {
				await DisplayAlert("Error", $"Could not add node {ex.Message}", "OK");
			}
        }

        private async void OnRemoveClicked(object sender, EventArgs e)
        {
            try
            {
                if (tree != null)
                {
					if (tree.Node is decimal)
					{
						tree.Remove(decimal.Parse(remove.Text));
					}
					else
					{
						tree.Remove(remove.Text);
					};
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