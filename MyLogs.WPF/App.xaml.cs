using System;
using System.Threading;
using System.Windows;

namespace MyLogs.WPF
{
    public partial class App : Application
    {
        private const string UniqueEventName = "29a0041e-4f5f-4bdd-9fea-fa43f1a686bf";
        private const string UniqueMutexName = "02ceda4a-8d35-4e8f-9f0f-369b0e8c714a";

        private EventWaitHandle? eventWaitHandle;
        private Mutex? mutex;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mutex = new Mutex(true, UniqueMutexName, out bool isNew);
            eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, UniqueEventName);

            GC.KeepAlive(mutex);

            if (isNew)
            {
                var thread = new Thread(() =>
                {
                    while (eventWaitHandle.WaitOne())
                    {
                        Current.Dispatcher.BeginInvoke(() => ((MainWindow)Current.MainWindow).BringToForeground());
                    }
                });
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                // Notify other instance so it could bring itself to foreground.
                eventWaitHandle.Set();
                Shutdown();
            }
        }
    }
}
