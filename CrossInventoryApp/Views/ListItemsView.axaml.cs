using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CrossInventoryApp.Views
{
    public partial class ListItemsView : UserControl
    {
        public ListItemsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
