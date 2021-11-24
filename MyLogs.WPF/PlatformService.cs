using MyLogs.Services;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MyLogs.WPF
{
    internal class PlatformService : IPlatformService
    {
        private readonly MainWindow window;

        public string DefaultDataDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyLogs");

        public PlatformService(MainWindow window)
        {
            this.window = window;
            this.window.Activated += (s, e) => Activated?.Invoke(this, e);
            this.window.Deactivated += (s, e) => Deactivated?.Invoke(this, e);
        }

        public string SelectFolder()
        {
            using var dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            return dialog.SelectedPath;
        }

        public void Close()
        {
            window.Close();
        }

        public Task SwitchBackgroundBlur(bool value)
        {
            try
            {
                window.EnableBakcgroundBlur(value);
            }
            catch (Exception)
            {
            }
            return Task.CompletedTask;
        }

        public Task SwitchAutoStart(bool isEnable)
        {
            var appName = "MyLogs";
            var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isEnable)
            {
                try
                {
                    var entry = Assembly.GetEntryAssembly();
                    var exeFile = Path.Combine(Path.GetDirectoryName(entry.Location), Path.GetFileNameWithoutExtension(entry.Location) + ".exe");
                    key?.SetValue(appName, $"\"{exeFile}\"");
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                try
                {
                    key?.DeleteValue(appName);
                }
                catch (Exception)
                {
                }
            }

            return Task.CompletedTask;
        }

        public Tuple<double, double> GetSize()
        {
            return new Tuple<double, double>(window.Width, window.Height);
        }

        public void ShowWindowController()
        {
            var borderSize = 3;
            window.rootGrid.Margin = new Thickness(borderSize, 0, borderSize, borderSize);
            window.windowChrome.ResizeBorderThickness = new Thickness(borderSize, 0, borderSize, borderSize);
            window.dragBar.Visibility = Visibility.Visible;
        }

        public void HideWindowController()
        {
            window.rootGrid.Margin = new Thickness(0);
            window.windowChrome.ResizeBorderThickness = new Thickness(0);
            window.dragBar.Visibility = Visibility.Collapsed;
        }

        public event EventHandler? Activated;
        public event EventHandler? Deactivated;
    }
}
