using client_app.Services;

namespace client_app.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public INavigationService NavigationService => _navigationService;
    }
}
