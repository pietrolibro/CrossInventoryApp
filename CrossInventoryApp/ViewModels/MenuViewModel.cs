namespace CrossInventoryApp.ViewModels
{

    public class MenuViewModel : ViewModelBase
    {
        public MainViewModel MainView { get; set; }

        public MenuViewModel()
        {
            
        }

        public MenuViewModel(MainViewModel mainView)
        {
            MainView = mainView;
        }

    }
}
