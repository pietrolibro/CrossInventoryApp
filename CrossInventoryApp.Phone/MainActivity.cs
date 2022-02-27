using Android.App;
using Android.Content.PM;
using Android.OS;
using Avalonia.Android;
using CrossInventoryApp.Views;

namespace CrossInventoryApp.Phone
{
    [Activity(Label = "CrossInventoryApp.Phone",
    
        LaunchMode = LaunchMode.SingleInstance)]
    public class MainActivity : AvaloniaActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Content = new MainView();
        }
    }

    //[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    //public class MainActivity : Ava AppCompatActivity
    //{
    //    protected override void OnCreate(Bundle savedInstanceState)
    //    {
    //        base.OnCreate(savedInstanceState);
    //        Xamarin.Essentials.Platform.Init(this, savedInstanceState);
    //        // Set our view from the "main" layout resource
    //        SetContentView(Resource.Layout.activity_main);
    //    }
    //    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    //    {
    //        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

    //        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    //    }
    //}
}