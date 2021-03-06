using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace CrossInventoryApp.Views
{
    public partial class AddNewItemView : UserControl
    {
        public AddNewItemView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            TextBox codeTextBox = this.FindControl<TextBox>("codeTextBox");

            if(codeTextBox != null) codeTextBox.Focus();
        }

    }
}
