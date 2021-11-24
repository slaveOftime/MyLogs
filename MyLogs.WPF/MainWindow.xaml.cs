using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.Core;
using MudBlazor.Services;
using MyLogs.Services;
using Serilog;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace MyLogs.WPF
{

    public partial class MainWindow : Window
    {
        private readonly PlatformService platformService;
        private readonly ServiceProvider serviceProvider;
        public readonly ISettingsService? settingsService;

        public MainWindow()
        {
            var appDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyLogs");
            if (!Directory.Exists(appDir)) Directory.CreateDirectory(appDir);

            var logDir = Path.Combine(appDir, "AppLogs");
            if (!Directory.Exists(logDir)) Directory.CreateDirectory(logDir);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(logDir, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application starting");

            try
            {
                platformService = new PlatformService(this);

                var serviceCollection = new ServiceCollection();
                serviceCollection
                    .AddBlazorWebView()
                    .AddFunBlazor()
                    .AddMudServices()
                    .AddSingleton<ILogsService, LogsService>()
                    .AddSingleton<ISettingsService, SettingsService>()
                    .AddSingleton<IPlatformService>(platformService);

                serviceProvider = serviceCollection.BuildServiceProvider();
                settingsService = serviceProvider.GetService<ISettingsService>();

                Resources.Add("services", serviceProvider);

                InitializeComponent();

                try
                {
                    var webView2Version = CoreWebView2Environment.GetAvailableBrowserVersionString();
                    Log.Information($"Got version for WebView2 {webView2Version}");
                }
                catch (Exception)
                {
                    Log.Information("Start to install WebView2");
                    System.Diagnostics.Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MicrosoftEdgeWebview2Setup.exe"), "/silent /install").WaitForExit();
                    Log.Information("Installed WebView2");
                }

                blazor.HostPage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot/index.html");
                blazor.ApplyTemplate();
                blazor.WebView.DefaultBackgroundColor = System.Drawing.Color.Transparent;

                Loaded += MainWindow_Loaded;
                Activated += MainWindow_Activated;
                Deactivated += MainWindow_Deactivated;
                SourceInitialized += MainWindow_SourceInitialized;
                Closed += MainWindow_Closed;

                Log.Information("Application started");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error");
                throw;
            }
        }

        public void SetDragbarColor()
        {
            var settings = settingsService?.GetSettings();
            if (settings != null)
            {
                var mudColor = new MudBlazor.Utilities.MudColor(settings.BackgroundColor);
                var color = mudColor.SetAlpha(mudColor.APercentage + 0.3).ChangeLightness(0.25);
                Dispatcher.Invoke(() =>
                {
                    dragBar.Background = new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
                });
            }
        }

        public void BringToForeground()
        {
            if (WindowState == WindowState.Minimized || Visibility == Visibility.Hidden)
            {
                Show();
                WindowState = WindowState.Normal;
            }

            // According to some sources these steps gurantee that an app will be brought to foreground.
            Activate();
            Topmost = true;
            Topmost = false;
            Focus();
        }


        private void MainWindow_SourceInitialized(object? sender, EventArgs e)
        {
            Height = Properties.Settings.Default.Height;
            Width = Properties.Settings.Default.Width;
            if (Properties.Settings.Default.Top != 0 && Properties.Settings.Default.Left != 0)
            {
                Top = Properties.Settings.Default.Top;
                Left = Properties.Settings.Default.Left;
            }

            this.EnableBakcgroundBlur(settingsService?.GetSettings().EnableBakcgroundBlur ?? false);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            platformService.ShowWindowController();

            if (settingsService?.GetSettings().EnableAlwaysOnBottom ?? false)
                Dispatcher.Invoke(() => this.SetAlwaysToBottom());
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            Background = new SolidColorBrush(Color.FromArgb(1, 255, 255, 255));
            SetDragbarColor();
        }

        private void MainWindow_Deactivated(object? sender, EventArgs e)
        {
            if (!(settingsService?.GetSettings()?.AlwaysClickable ?? false))
                Dispatcher.Invoke(() => Background = new SolidColorBrush(Colors.Transparent));
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            Properties.Settings.Default.Top = Top;
            Properties.Settings.Default.Left = Left;
            Properties.Settings.Default.Height = Height;
            Properties.Settings.Default.Width = Width;
            Properties.Settings.Default.Save();
        }

        private void dragBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
