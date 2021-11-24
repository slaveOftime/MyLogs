using Microsoft.Maui.Essentials;
using MyLogs.Services;
using System;
using System.Threading.Tasks;

namespace MyLogs.MAUI
{
    internal class PlatformService : IPlatformService
    {
        public PlatformService()
        {

        }

        public string DefaultDataDir => FileSystem.AppDataDirectory;

        public event EventHandler Activated;
        public event EventHandler Deactivated;

        public void Close()
        {
        }

        public Tuple<double, double> GetSize()
        {
            return new Tuple<double, double>(0, 0);
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
