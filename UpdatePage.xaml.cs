using System.Linq;
using System.Windows;


namespace Gabinet_CRUD
{
    public partial class UpdatePage : Window
    {
        GabinetEntities _db = new GabinetEntities();
        string pesel;

        public UpdatePage(string pacjentPesel)
        {
            InitializeComponent();
            pesel = pacjentPesel;

            Pacjenci pacjent = (from m in _db.Pacjencis
                                where m.Pesel == pesel
                                select m).Single();

            nameTextBox.Text = pacjent.Imie;
            surnameTextBox.Text = pacjent.Nazwisko;
            peselTextBox.Text = pacjent.Pesel;
            addressTextBox.Text = pacjent.Adres;
            phoneTextBox.Text = pacjent.Telefon;
            descriptionTextBox.Text = pacjent.Opis;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Pacjenci pacjent = (from m in _db.Pacjencis
                               where m.Pesel == pesel
                               select m).Single();

            pacjent.Imie = nameTextBox.Text;
            pacjent.Nazwisko = surnameTextBox.Text;
            pacjent.Pesel = peselTextBox.Text;
            pacjent.Adres = addressTextBox.Text;
            pacjent.Telefon = phoneTextBox.Text;
            pacjent.Opis = descriptionTextBox.Text;

            //TODO: Pesel nie moze byc zmieniony
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.Pacjencis.ToList();
            this.Hide();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
