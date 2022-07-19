using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ClientFindForm.xaml
    /// </summary>
    public partial class ClientFindForm : Window
    {
        public ClientFindForm()
        {
            InitializeComponent();
            Client.FillIdClient(IdClientComboBox);
        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void IdClientComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SellProduct.FindSellProductByClient(IdClientComboBox, DataGrid);
        }
    }
}
