using Avalonia.Controls;
using System;
using TokenGenerator.ViewModels;

namespace TokenGenerator.Views;

public partial class SettingsWindow : Window
{
    public SettingsWindow(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

}
