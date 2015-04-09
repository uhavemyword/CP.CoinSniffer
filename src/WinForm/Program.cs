using CP.CoinSniffer.Common;
using CP.CoinSniffer.WinForm.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;

namespace CP.CoinSniffer.WinForm
{
    public static class Program
    {
        public static long CurrentFound { get; set; }
        public static long CurrentScanned { get; set; }
        public static long CurrentElapsedTicks { get; set; }
        public static long TotalFound { get; set; }
        public static long TotalScanned { get; set; }
        public static long TotalElapsedTicks { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        public static void Main()
        {
            var config = MySettingsManager.GetSettings<ClientSettings>();
            TotalFound = config.TotalFound;
            TotalScanned = config.TotalScanned;
            TotalElapsedTicks = config.TotalElapsedTicks;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Net.ServicePointManager.DefaultConnectionLimit = 512;
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;

            // Unhandled exceptions  http://msdn.microsoft.com/en-us/library/system.windows.forms.application.threadexception.aspx
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += UIThreadException;

            // Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event.
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;

            Application.ApplicationExit += Application_ApplicationExit;
            Application.Run(new MainForm());
        }

        public static void Application_ApplicationExit(object sender, EventArgs e)
        {
            try
            {
                var config = MySettingsManager.GetSettings<ClientSettings>();
                config.TotalFound = TotalFound;
                config.TotalScanned = TotalScanned;
                config.TotalElapsedTicks = TotalElapsedTicks + CurrentElapsedTicks;
                MySettingsManager.SaveSingle(config);
            }
            catch (Exception)
            {
            }
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                Exception ex = e.ExceptionObject as Exception;
                result = MessageBox.Show(ex.Message, "UnhandledException", MessageBoxButtons.AbortRetryIgnore);
            }
            catch
            {
                Application.Exit();
            }
            if (result == DialogResult.Abort)
            {
                Application.Exit();
            }
        }

        private static void UIThreadException(object sender, ThreadExceptionEventArgs e)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = MessageBox.Show(e.Exception.Message, "UIThreadException", MessageBoxButtons.AbortRetryIgnore);
            }
            catch
            {
                Application.Exit();
            }
            if (result == DialogResult.Abort)
            {
                Application.Exit();
            }
        }
    }
}
