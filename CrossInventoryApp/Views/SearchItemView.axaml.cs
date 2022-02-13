using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CrossInventoryApp.Views
{
    public partial class SearchItemView : UserControl
    {
        public SearchItemView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
