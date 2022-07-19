using System.Windows;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class ClientForm : Window
    {
        public ClientForm()
        {
            InitializeComponent();
            Client.SetDataGrid(ClientDataGrid);
            Client.LoadTable();
        }
        
        private void ClientFindForm_Click(object sender, RoutedEventArgs e)
        {
            ClientFindForm clientFindForm = new ClientFindForm();
            clientFindForm.Show();
        }

        private void ClientInsertForm_Click(object sender, RoutedEventArgs e)
        {
            ClientInsertQuery clientInsertQuery = new ClientInsertQuery();
            clientInsertQuery.Show();
        }

        private void ClientUpdateForm_Click(object sender, RoutedEventArgs e)
        {
            ClientUpdateQuery clientUpdateQuery = new ClientUpdateQuery();
            clientUpdateQuery.Show();
        }

        private void ClientDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            ClientDeleteQuery clientDeleteQuery = new ClientDeleteQuery();
            clientDeleteQuery.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Client.LoadTable();
        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }
    }
}
