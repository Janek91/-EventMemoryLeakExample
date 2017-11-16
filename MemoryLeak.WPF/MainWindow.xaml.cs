using System.Windows;

namespace MemoryLeak.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = DataContext as MainWindowViewModel;
        }

        private void ShortLivedEventRaisersClick(object sender, RoutedEventArgs e)
        {
            _viewModel.OnSubscribeToShortlivedObjects();
        }

        private void ForceGarbageCollectionClick(object sender, RoutedEventArgs e)
        {
            _viewModel.OnForceGcClick();
        }

        private void ShortLivedEventSubscribersClick(object sender, RoutedEventArgs e)
        {
            _viewModel.OnShortlivedEventSubscribersClick();
        }

        private void ShortLivedPublishersClick(object sender, RoutedEventArgs e)
        {
            _viewModel.OnShortlivedEventPublishersClick();
        }

        private void ShortLivedSubscribersClick(object sender, RoutedEventArgs e)
        {
            _viewModel.OnShortLivedEventBusSubscribersClick();
        }

        private void ShortLivedWeakSubscribersClick(object sender, RoutedEventArgs e)
        {
            _viewModel.OnShortLivedWeakSubscribersClick();
        }
    }
}
