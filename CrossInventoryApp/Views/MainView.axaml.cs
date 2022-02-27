using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Globalization;
using System.Reactive.Linq;
using System.Threading;

namespace CrossInventoryApp.Views
{
    public partial class MainView : UserControl
    {
        private CrossInventoryApp.ViewModels.MainViewModel mainViewModel = null;

        public MainView()
        {
            InitializeComponent();


            this.DataContextChanged += MainView_DataContextChanged;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);


        }

        private void MainView_DataContextChanged(object sender, System.EventArgs e)
        {
            //// Check if is In DesignMode, otherwise the live previewer doesn't show correctly the view.
            //if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            //    return;

            this.mainViewModel = this.DataContext as CrossInventoryApp.ViewModels.MainViewModel;

            if (mainViewModel != null)
            {
                mainViewModel.ChangeCultureCommand.Subscribe(languageCode => { this.RefreshUI(languageCode); });
            }
        }

        private void RefreshUI(string languageCode)
        {
            if (string.IsNullOrEmpty(languageCode)) return;

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(languageCode);

            ViewModels.MenuViewModel menuViewModel = this.Content as ViewModels.MenuViewModel;
            this.Content = null;
            this.Content = menuViewModel;
        }
    }
}