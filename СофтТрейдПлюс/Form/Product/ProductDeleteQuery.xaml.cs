using System.Data;
using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ProductDeleteQuery.xaml
    /// </summary>
    public partial class ProductDeleteQuery : Window
    {
        public ProductDeleteQuery()
        {
            InitializeComponent();
            Product.FillIdProductComboBox(IdProductComboBox);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product.FillProductDataGrid(ProductDataGrid, IdProductComboBox);
            SellProduct.FindSellProductByProduct(IdProductComboBox, SellProductDataGrid);
        }

        private void DeleteQuery_Click(object sender, RoutedEventArgs e)
        {
            if (Product.DeleteQuery(IdProductComboBox))
            {
                MessageBox.Show("Успех");
                Product.LoadTable();
                Close();
            }
        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
