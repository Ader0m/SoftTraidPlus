using System.Windows;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ProductForm.xaml
    /// </summary>
    public partial class ProductForm : Window
    {
        public ProductForm()
        {           
            InitializeComponent();
            Product.SetDataGrid(ProductDataGrid);
            Product.LoadTable();
        }

        private void ProductInsertForm_Click(object sender, RoutedEventArgs e)
        {
            ProductInsertQuery ProductInsertQuery = new ProductInsertQuery();
            ProductInsertQuery.Show();
        }

        private void ProductUpdateForm_Click(object sender, RoutedEventArgs e)
        {
            ProductUpdateQuery ProductUpdateQuery = new ProductUpdateQuery();
            ProductUpdateQuery.Show();
        }

        private void ProductDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            ProductDeleteQuery productDeleteQuery = new ProductDeleteQuery();
            productDeleteQuery.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Product.LoadTable();
        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            Close();
        }
    }
}
