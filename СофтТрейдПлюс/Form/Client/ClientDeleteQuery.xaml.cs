using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ClientDeleteQuety.xaml
    /// </summary>
    public partial class ClientDeleteQuery : Window
    {
        public ClientDeleteQuery()
        {
            InitializeComponent();
            Client.FillIdClient(IdClientComboBox);
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }

        private void DeleteQuery_Click(object sender, RoutedEventArgs e)
        {
            if (Client.DeleteQuery(IdClientComboBox))
            {
                MessageBox.Show("Успех");
                Client.LoadTable();
                Close();
            }
        }

        private void IdClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client.FillClientDataGrid(ClientDataGrid, IdClientComboBox);
            FillSellProductDataGrid();
        }

        private void FillSellProductDataGrid()
        {
            SellProduct.FindSellProductByClient(IdClientComboBox, SellProductDataGrid);
        }
    }
}

