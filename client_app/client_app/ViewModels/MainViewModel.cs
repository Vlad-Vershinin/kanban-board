using client_app.Services;

namespace client_app.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public NavigationService NavigationService { get; }

        public MainViewModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
