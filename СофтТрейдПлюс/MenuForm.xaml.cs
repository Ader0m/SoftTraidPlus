using System.Windows;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MenuForm : Window
    {                    
        public MenuForm()
        {
            InitializeComponent();
            PresentClient();

            Client.SetDataGrid(FictiveDataGride);
            Product.SetDataGrid(FictiveDataGride);
            SellProduct.SetDataGrid(FictiveDataGride);
            Manager.SetDataGrid(FictiveDataGride);

            Client.LoadTable();
            Product.LoadTable();
            SellProduct.LoadTable();
            Manager.LoadTable();

        }

        private void PresentClient()
        {
            Client.PresentClient(MainDataGrid);
        }

        private void SellProduct_Cliick(object sender, RoutedEventArgs e)
        {
            Form.SellProductForm sellProductForm = new Form.SellProductForm();
            sellProductForm.Show();
            Close();
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            Form.ProductForm productForm = new Form.ProductForm();
            productForm.Show();
            Close();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            Form.ClientForm clientForm = new Form.ClientForm();
            clientForm.Show();
            Close();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            Form.ManagerForm managerForm = new Form.ManagerForm();
            managerForm.Show();
            Close();
        }
    }
}
