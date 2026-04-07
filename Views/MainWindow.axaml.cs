using Avalonia.Controls;
using TokenGenerator.ViewModels;

namespace TokenGenerator.Views
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