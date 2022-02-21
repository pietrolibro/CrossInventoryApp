using System;

using Avalonia;
using Avalonia.Headless;
using Avalonia.ReactiveUI;
using Avalonia.Threading;
using Avalonia.Controls.ApplicationLifetimes;

using CrossInventoryApp.Views;


namespace CrossInventoryApp.UITests
{
    public static class AvaloniaApp
    {
        public static void RegisterDependencies()
        {
         
        }

        public static void Stop()
        {
            var app = GetApp();
            if (app is IDisposable disposable)
            {
                Dispatcher.UIThread.Post(disposable.Dispose);
            }

            Dispatcher.UIThread.Post(() => app.Shutdown());
        }

        public static MainWindowView GetMainWindow() => (MainWindowView)GetApp().MainWindow;

        public static IClassicDesktopStyleApplicationLifetime GetApp() => 
            (IClassicDesktopStyleApplicationLifetime)Application.Current.ApplicationLifetime;

        public static AppBuilder BuildAvaloniaApp() =>
            AppBuilder
                .Configure<App>()
                .UsePlatformDetect()
                .UseReactiveUI()
                .UseHeadless();
    }
}