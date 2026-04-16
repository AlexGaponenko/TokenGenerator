using Avalonia.Controls;
using TokenGenerator.UI.ViewModels;

namespace TokenGenerator.UI.Views
{
    public partial class MainWindow : Window
    {

        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

    }
}