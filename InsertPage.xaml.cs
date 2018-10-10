using System.Linq;
using System.Windows;

namespace Gabinet_CRUD
{
    public partial class InsertPage : Window
    {
        GabinetEntities _db = new GabinetEntities();

        public InsertPage()
        {
            InitializeComponent();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            Pacjenci pacjent = new Pacjenci()
            {
                Imie = nameTextBox.Text,
                Nazwisko = surnameTextBox.Text,
                Pesel = peselTextBox.Text,
                Adres = addressTextBox.Text,
                Telefon = phoneTextBox.Text,
                Opis = descriptionTextBox.Text
            };

            if (zagranica.IsChecked == true)
            {
                pacjent.Pesel = "NA" + System.Guid.NewGuid().ToString().Substring(0,9);
            }

            _db.Pacjencis.Add(pacjent);
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.Pacjencis.ToList();
            this.Hide();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void checkPlace_Checked(object sender, RoutedEventArgs e)
        {
            if (zagranica.IsChecked == true)
                peselTextBox.IsEnabled = false;

            if (zagranica.IsChecked == false)
                peselTextBox.IsEnabled = true;
        }
    }
}
