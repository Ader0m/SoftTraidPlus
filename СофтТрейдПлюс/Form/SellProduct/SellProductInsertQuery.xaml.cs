using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для SellProductInsertQuery.xaml
    /// </summary>
    public partial class SellProductInsertQuery : Window
    {
        public SellProductInsertQuery()
        {
            InitializeComponent();
            Client.FillIdClient(IdClientComboBox);
            Product.FillIdProductComboBox(IdProductComboBox);
        }

        private void InsertQuery_Click(object sender, RoutedEventArgs e)
        {
            if(SellProduct.InsertQuery(IdProductComboBox, IdClientComboBox, DatePicker))
            {
                MessageBox.Show("Успех");
                SellProduct.LoadTable();
                Close();
            }
        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void IdClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client.FillClientDataGrid(ClientDataGrid, IdClientComboBox);
        }

        private void IdProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product.FillProductDataGrid(ProductDataGrid, IdProductComboBox);
        }
    }
}
