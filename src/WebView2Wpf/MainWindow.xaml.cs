using Microsoft.Web.WebView2.Core;
using System.Windows;

namespace WebView2Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.webview.CoreWebView2InitializationCompleted += WebviewOnCoreWebView2InitializationCompleted;

            var options = new CoreWebView2EnvironmentOptions();
            var e = CoreWebView2Environment.CreateAsync(options: options).Result;
            this.webview.EnsureCoreWebView2Async(e);
        }

        private void WebviewOnCoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            this.webview.CoreWebView2.Navigate("https://news.ycombinator.com");
            this.webview.CoreWebView2.NavigationCompleted += CoreWebView2OnNavigationCompleted;
        }

        private void CoreWebView2OnNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            this.urlToNavTo.Text = this.webview.Source.OriginalString;
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            this.webview.CoreWebView2.Navigate(this.urlToNavTo.Text);
        }
    }
}
