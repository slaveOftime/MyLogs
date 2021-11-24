using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;


namespace MyLogs.WPF
{
    static class BlurWindow
    {
        [DllImport("user32.dll")]
        static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwnd, IntPtr parentHwnd);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string className, string winName);


        public static void SetAlwaysToBottom(this Window window)
        {
            var programIntPtr = FindWindow("Progman", null);
            var handle = new WindowInteropHelper(window).Handle;
            SetParent(handle, programIntPtr);
        }

        public static void EnableBakcgroundBlur(this Window window, bool isEnabled)
        {
            window.Dispatcher.Invoke(() =>
            {
                var windowHelper = new WindowInteropHelper(window);

                var accent = new AccentPolicy();
                accent.AccentState = isEnabled ? AccentState.ACCENT_ENABLE_BLURBEHIND : AccentState.ACCENT_DISABLED;

                var accentStructSize = Marshal.SizeOf(accent);

                var accentPtr = Marshal.AllocHGlobal(accentStructSize);
                Marshal.StructureToPtr(accent, accentPtr, false);

                var data = new WindowCompositionAttributeData();
                data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
                data.SizeOfData = accentStructSize;
                data.Data = accentPtr;

                SetWindowCompositionAttribute(windowHelper.Handle, ref data);

                Marshal.FreeHGlobal(accentPtr);

                var hwnd = windowHelper.Handle;
                var value = GetWindowLong(hwnd, GWL_STYLE);
                SetWindowLong(hwnd, GWL_STYLE, (int)(value & ~WS_MAXIMIZEBOX));
            });
        }


        private const int GWL_STYLE = -16;
        private const int WS_MAXIMIZEBOX = 0x10000;


        enum AccentState
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_INVALID_STATE = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        enum WindowCompositionAttribute
        {
            WCA_ACCENT_POLICY = 19
        }
    }
}
