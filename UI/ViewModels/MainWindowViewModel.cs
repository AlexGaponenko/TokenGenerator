using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using TokenGenerator.Domain.Interfaces;
using TokenGenerator.Domain.Models;
using TokenGenerator.Helpers;


namespace TokenGenerator.UI.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private StringHelper _stringHelper = new StringHelper();
        private DateTimehelper _dateTimeHelper = new DateTimehelper();
        private readonly IAuthenticationService _authenticationService;
        private readonly IClipboardService _clipboardService;
        public SettingsViewModel SettingsViewModel { get; }


        [ObservableProperty]
        private string? accessToken;

        [ObservableProperty]
        private string? maskedAccessToken;

        [ObservableProperty]
        private DateTimeOffset? expiresOn;

        [ObservableProperty]
        private bool _isBusy;


        public MainWindowViewModel(
            IAuthenticationService authenticationService,
            SettingsViewModel settingsViewModel,
            IClipboardService clipboardService)
        {
            _authenticationService = authenticationService;
            SettingsViewModel = settingsViewModel;
            _clipboardService = clipboardService;
        }


        [RelayCommand]
        private async Task GenerateTokenAsync()
        {
            try
            {
                _isBusy = true;

                TokenData token = await _authenticationService.AuthenticateInteractiveAsync();


                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    AccessToken = token.Token;
                    MaskedAccessToken = _stringHelper.MaskToken(token.Token);
                    ExpiresOn = _dateTimeHelper.GetLocalTime(token.ExpiresOn);
                });

            }

            catch (OperationCanceledException)
            {
                AccessToken = "LOGIN CANCELED (timeout)";
            }

            catch (Exception ex)
            {

                await Dispatcher.UIThread.InvokeAsync(() =>
                {
                    AccessToken = "ERROR: " + ex.Message;
                });

            }
            finally
            {
                _isBusy = false;
            }
        }


        [RelayCommand]
        private async Task CopyTokenAsync()
        {
            if (!string.IsNullOrWhiteSpace(AccessToken))
            {
                await _clipboardService.SetTextAsync(AccessToken);
            }
        }





    }
}