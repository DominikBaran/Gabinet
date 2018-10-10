using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Gabinet_CRUD
{
    public partial class MainWindow : Window
    {
        GabinetEntities _db = new GabinetEntities();
        public static DataGrid dataGrid;

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Load();
        }

        private void Load()
        {
            pacjenciGrid.ItemsSource = _db.Pacjencis.ToList();
            dataGrid = pacjenciGrid;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage insertPage = new InsertPage();
            insertPage.ShowDialog();

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            string pesel = (pacjenciGrid.SelectedItem as Pacjenci).Pesel;
            UpdatePage updatePage = new UpdatePage(pesel);
            updatePage.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Czy napewno chcesz usunąć pacjenta?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            { };
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                string pesel = (pacjenciGrid.SelectedItem as Pacjenci).Pesel;
                var deletePacjent = _db.Pacjencis.Where(m => m.Pesel == pesel).Single();
                _db.Pacjencis.Remove(deletePacjent);
                _db.SaveChanges();
                pacjenciGrid.ItemsSource = _db.Pacjencis.ToList();
                MessageBox.Show("Pacjent zostal usuniety", "Potwierdzenie usuniecia", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Pacjent nie zostal usuniety", "Anuluj operacje", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}
