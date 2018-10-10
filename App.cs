using System.Windows;

namespace Gabinet_CRUD
{
    public partial class App
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            //Disable shutdown when the dialog closes
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            var dialog = new LoginPage();

            if (dialog.ShowDialog() == true)
            {
                var mainWindow = new MainWindow();
                //Re-enable normal shutdown mode.
                Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                Current.MainWindow = mainWindow;
                mainWindow.Show();
            }
            else
            {
                  Current.Shutdown(-1);
            }
        }
    }
}
