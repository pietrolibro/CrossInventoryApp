using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CrossInventoryApp.Views
{
    public partial class CloseAppView : UserControl
    {
        public CloseAppView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
