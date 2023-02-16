using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace Trees.Gui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        DrawableTree<string> tree;

        public MainPage()
        {
            InitializeComponent();
            tree = new DrawableTree<string>("mammoth");
            tree.Add("penguin");
            tree.Add("cat");           
            tree.Add("bat");
            tree.Add("dog");
            GraphicsView graphicsView = new GraphicsView();
            graphicsView.Drawable = tree;
            graphicsView.HeightRequest = 600;
            graphicsView.WidthRequest = 800;           


            Border border = new Border
            {
                Stroke = Colors.Black,
                Background = Colors.Aquamarine,
                StrokeThickness = 4,
                Padding = new Thickness(16, 8),
                HorizontalOptions = LayoutOptions.Center
            };

            border.Content = graphicsView;
            layout.Children.Add(border);

        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}