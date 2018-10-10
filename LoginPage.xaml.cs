using System.Windows;
using System.Linq;
using Gabinet_CRUD.Helpers;

namespace Gabinet_CRUD
{
    public partial class LoginPage : Window
    {
        GabinetEntities _db = new GabinetEntities();

        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            var adminList = _db.AppAdmins.ToList();
            var hashPassword = PasswordHashHelper.GetHash(passwordBox.Password.Trim());


            if (adminList.Find(x => x.login.Equals(textBox.Text.Trim()) && x.password.Equals(hashPassword)) == null)
            {
                MessageBox.Show("Bledny login i/lub haslo", "Bledne dane logowania.", MessageBoxButton.OK, MessageBoxImage.Error);
                textBox.Clear();
                passwordBox.Clear();
                return;
            }

            this.DialogResult = true;
            this.Close();
        }

        private void quitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
