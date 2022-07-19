using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ProductUpdateQuery.xaml
    /// </summary>
    public partial class ProductUpdateQuery : Window
    {
        public ProductUpdateQuery()
        {
            InitializeComponent();

            TermComboBox.IsReadOnly = true;
            TermComboBox.IsEnabled = false;
            FillIDProduct();
        }
        public void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FillIDProduct()
        {
            Product.FillIdProductComboBox(IdComboBox);
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBoxItem)TypeComboBox.SelectedItem).Content.ToString() == "Постоянная лицензия")
            {
                TermComboBox.IsReadOnly = true;
                TermComboBox.IsEnabled = false;
            }
            else
            {
                TermComboBox.SelectedValue = "";
                TermComboBox.IsReadOnly = false;
                TermComboBox.IsEnabled = true;

            }
        }

        private void IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product.FillProductDataGrid(ProductDataGrid, IdComboBox);
        }

        public void UpdateQuery_Click(object sender, RoutedEventArgs e)
        {
            if (Product.UpdateQuery(IdComboBox, NameTextBox, PriceTextBox, TypeComboBox, TermComboBox))
            {
                MessageBox.Show("Успех");
                Product.LoadTable();
                Close();
            }
        }
    }
}
