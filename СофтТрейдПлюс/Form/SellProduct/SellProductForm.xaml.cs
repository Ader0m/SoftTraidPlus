using System.Windows;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для SellProductForm.xaml
    /// </summary>
    public partial class SellProductForm : Window
    {
        public SellProductForm()
        {
            InitializeComponent();
            SellProduct.SetDataGrid(SellProductDataGrid);
            SellProduct.LoadTable();
        }

        private void SellProductInsertForm(object sender, RoutedEventArgs e)
        {
            SellProductInsertQuery SellProductInsertQuery = new SellProductInsertQuery();
            SellProductInsertQuery.Show();

        }

        private void SellProductFindForm_Click(object sender, RoutedEventArgs e)
        {
            SellProductFindForm sellProductFindForm = new SellProductFindForm();
            sellProductFindForm.Show();
        }

        private void SellProductDeleteForm(object sender, RoutedEventArgs e)
        {
            SellProductDeleteQuery sellProductDeleteQuery = new SellProductDeleteQuery();
            sellProductDeleteQuery.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            SellProduct.LoadTable();
        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            Close();
        }

    }
}
