using System;
using System.Windows;
using System.Windows.Controls;

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

        private void StartAction(object sender, Action action)
        {
            Button btn = (Button)sender;
            btn.IsEnabled = false;
            action.Invoke();
            btn.IsEnabled = true;
        }

        private void ShortLivedEventRaisersClick(object sender, RoutedEventArgs e)
        {
            StartAction(sender, _viewModel.OnSubscribeToShortlivedObjects);
        }

        private void ForceGarbageCollectionClick(object sender, RoutedEventArgs e)
        {
            StartAction(sender, _viewModel.OnForceGcClick);
        }

        private void ShortLivedEventSubscribersClick(object sender, RoutedEventArgs e)
        {
            StartAction(sender, _viewModel.OnShortlivedEventSubscribersClick);
        }

        private void ShortLivedPublishersClick(object sender, RoutedEventArgs e)
        {
            StartAction(sender, _viewModel.OnShortlivedEventPublishersClick);
        }

        private void ShortLivedSubscribersClick(object sender, RoutedEventArgs e)
        {
            StartAction(sender, _viewModel.OnShortLivedEventBusSubscribersClick);
        }

        private void ShortLivedWeakSubscribersClick(object sender, RoutedEventArgs e)
        {
            StartAction(sender, _viewModel.OnShortLivedWeakSubscribersClick);
        }
    }
}
