using Microsoft.Maui;
using MyLogs.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyLogs.MAUI
{
    internal class PlatformService : IPlatformService
    {
        private readonly MainApplication mainApplication;

        public PlatformService(MainApplication mainApplication)
        {
            this.mainApplication = mainApplication;
        }

        public string DefaultDataDir => Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, Android.OS.Environment.DirectoryDocuments, "MyLogs");

        public event EventHandler Activated;
        public event EventHandler Deactivated;

        public void Close()
        {
            throw new NotImplementedException();
        }

        public Tuple<double, double> GetSize()
        {
            var window = mainApplication.GetWindow();
            if (window == null) return new Tuple<double, double>(0, 0);

            return new Tuple<double, double>(window.Content.Width, window.Content.Height);
        }

        public void HideWindowController()
        {
        }

        public string SelectFolder()
        {
            return "";
        }

        public void ShowWindowController()
        {
        }

        public Task SwitchAutoStart(bool value)
        {
            return Task.CompletedTask;
        }

        public Task SwitchBackgroundBlur(bool value)
        {
            return Task.CompletedTask;
        }
    }
}
