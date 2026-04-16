
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TokenGenerator.Models;

namespace TokenGenerator.UI.ViewModels;

public class SettingsViewModel : INotifyPropertyChanged
{
    private readonly SettingsService _settingsService;

    private string _userEmail;
    public string UserEmail
    {
        get => _userEmail;
        set
        {
            _userEmail = value;
            OnPropertyChanged();
        }
    }

    private bool _isDarkTheme;
    public bool IsDarkTheme
    {
        get => _isDarkTheme;
        set
        {
            _isDarkTheme = value;
            OnPropertyChanged();
        }
    }

    public ICommand SaveCommand { get; }

    public SettingsViewModel(SettingsService settingsService)
    {
        _settingsService = settingsService;

        var settings = _settingsService.Load();
        UserEmail = settings.UserEmail;
        IsDarkTheme = settings.IsDarkTheme;

        SaveCommand = new RelayCommand(Save);
    }

    private void Save()
    {
        var settings = new AppSettings
        {
            UserEmail = UserEmail,
            IsDarkTheme = IsDarkTheme
        };

        _settingsService.Save(settings);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
