using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.ApplicationLifetimes;

using CrossInventoryApp.Views;
using CrossInventoryApp.ViewModels;

using Microsoft.Extensions.DependencyInjection;


namespace CrossInventoryApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public ServiceProvider ServiceProvider { get; private set; }

        public override void OnFrameworkInitializationCompleted()
        {
            IServiceCollection services = new ServiceCollection()
                .AddSingleton<Services.IInventoryRepository>(new Services.InventoryRepository());

            this.ServiceProvider =services.BuildServiceProvider();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindowView
                {
                    DataContext = new MainWindowViewModel(services)
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = new MainViewModel(services)
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}