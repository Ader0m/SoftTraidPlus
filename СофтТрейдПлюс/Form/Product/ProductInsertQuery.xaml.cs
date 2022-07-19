using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ProductInsertQuery.xaml
    /// </summary>
    public partial class ProductInsertQuery : Window
    {
        public ProductInsertQuery()
        {           
            InitializeComponent();
            TermComboBox.IsReadOnly = true;
            TermComboBox.IsEnabled = false;
        }

        public void InsertQuery_Click(object sender, RoutedEventArgs e)
        {
            if (Product.InsertQuery(NameTextBox, PriceTextBox, TypeComboBox, TermComboBox))
            {
                MessageBox.Show("Успех");
                Product.LoadTable();
                Close();
            }
        }

        public void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
    }
}
            
