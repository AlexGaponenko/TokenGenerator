using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using System.Windows.Input;
using TokenGenerator.Domain.Interfaces;
using TokenGenerator.Views;

namespace TokenGenerator.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        private readonly IAuthenticationService _authenticationService;
        public SettingsViewModel SettingsViewModel { get; }

        public MainWindowViewModel(
            IAuthenticationService authenticationService,
            SettingsViewModel settingsViewModel)
        {
            _authenticationService = authenticationService;
            SettingsViewModel = settingsViewModel;
        }

        [RelayCommand]
        private async Task GenerateTokenAsync()
        {
            var token = await _authenticationService.AuthenticateInteractiveAsync();
            // сохранить / показать токен
        }



    }
}