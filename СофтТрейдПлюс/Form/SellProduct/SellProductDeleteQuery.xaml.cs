using System.Windows;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для SellProductDeleteQuery.xaml
    /// </summary>
    public partial class SellProductDeleteQuery : Window
    {
        public SellProductDeleteQuery()
        {
            InitializeComponent();
            Client.FillIdClient(IdClientComboBox);
            Product.FillIdProductComboBox(IdProductComboBox);
        }

        private void DeleteQuery_Click(object sender, RoutedEventArgs e)
        {
            if (SellProduct.DeleteQuery(IdProductComboBox, IdClientComboBox))
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

        
    }
}
