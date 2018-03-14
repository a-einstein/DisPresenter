using System;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace RCS.DIS.Presenter
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SetupExceptionHandling();

            // Use an explicit instantiation instead of setting StartupUri to be able to catch exceptions, in particular EndpointNotFoundException.
            MainWindow = new MainWindow();
            MainWindow.Show();

            // Call this explicitly to already have a window shown in case of exceptions.
            (MainWindow as MainWindow).Initialize();
        }

        #region Error handling
        private void SetupExceptionHandling()
        {
            DispatcherUnhandledException += Dispatcher_UnhandledException;

            Dispatcher.UnhandledException += Dispatcher_UnhandledException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        private void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            HandleException(e.Exception);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException((Exception)e.ExceptionObject);
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            HandleException(e.Exception);
        }

        void HandleException(Exception exception)
        {
            // Try to prevent repeated messages.
            // TODO Does not work.
            bool communicationExceptionHandled = false;
            bool otherExceptionHandled = false;

            if (exception is CommunicationException && !communicationExceptionHandled)
            {
                communicationExceptionHandled = true;
                DisplayMessage(exception, "There is a problem using our data service.");
            }
            else
            {
                if (!otherExceptionHandled)
                {
                    otherExceptionHandled = true;
                    DisplayMessage(exception, "There is a unknown problem.");
                }
            }
        }

        private static void DisplayMessage(Exception exception, string errorMessage)
        {
            const string applicationName = "DIS Presenter";

            // Pity the No button cannot be made default.
            var result = MessageBox.Show($"{errorMessage}\n\nDo you want the see the details?", $"{applicationName} - Error", MessageBoxButton.YesNo, MessageBoxImage.Error);

            if (result == MessageBoxResult.Yes)
                MessageBox.Show(exception.Message, $"{applicationName} - Details", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion
    }
}
