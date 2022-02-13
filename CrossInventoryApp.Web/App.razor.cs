using Avalonia.ReactiveUI;
using Avalonia.Web.Blazor;

namespace CrossInventoryApp.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        
        WebAppBuilder.Configure<CrossInventoryApp.App>()
            .UseReactiveUI()
            .SetupWithSingleViewLifetime();
    }
}