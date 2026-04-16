using Avalonia.Controls;
using System;
using TokenGenerator.UI.ViewModels;

namespace TokenGenerator.UI.Views;

public partial class SettingsWindow : Window
{
    public SettingsWindow(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

}
