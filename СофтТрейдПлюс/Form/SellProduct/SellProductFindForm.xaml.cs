using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для SellProductFindForm.xaml
    /// </summary>
    public partial class SellProductFindForm : Window
    {
        public SellProductFindForm()
        {
            InitializeComponent();
            Client.FillIdClient(IdClientComboBox);
            Product.FillIdProductComboBox(IdProductComboBox);
        } 

        private void IdClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IdClientComboBox.SelectedIndex != -1)
            {
                FillClientGrid();
                SellProduct.FindSellProductByClient(IdClientComboBox, ProductDataGrid);
                IdProductComboBox.SelectedIndex = -1;
                DatePicker.Text = "";
            }
        }

        private void FillClientGrid()
        {
            Client.FillClientDataGrid(ClientDataGrid, IdClientComboBox);
        }

        private void IdProductComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IdProductComboBox.SelectedIndex != -1)
            {
                FillProductGrid();
                SellProduct.FindSellProductByProduct(IdProductComboBox, ClientDataGrid);
                IdClientComboBox.SelectedIndex = -1;
                DatePicker.Text = "";
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePicker.Text != "")
            {
                IdProductComboBox.SelectedIndex = -1;
                IdClientComboBox.SelectedIndex = -1;
                SellProduct.FindSellProductByData(DatePicker, ProductDataGrid);
                ClientDataGrid.ItemsSource = "";
            }
        }

        private void FillProductGrid()
        {
            Product.FillProductDataGrid(ProductDataGrid, IdProductComboBox);
        }

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
