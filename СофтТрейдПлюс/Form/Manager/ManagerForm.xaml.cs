using System.Windows;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ManagerForm.xaml
    /// </summary>
    public partial class ManagerForm : Window
    {
        public ManagerForm()
        {
            InitializeComponent();
            Manager.SetDataGrid(ManagerDataGrid);
            Manager.LoadTable();
        }

        private void ManagerInsertForm_Click(object sender, RoutedEventArgs e)
        {
            ManagerInsertQuery ManagerInsertQuery = new ManagerInsertQuery();
            ManagerInsertQuery.Show();
        }

        private void ManagerUpdateForm_Click(object sender, RoutedEventArgs e)
        {
            ManagerUpdateQuery ManagerUpdateQuery = new ManagerUpdateQuery();
            ManagerUpdateQuery.Show();
        }

        private void ManagerDeleteForm_Click(object sender, RoutedEventArgs e)
        {
            ManagerDeleteQuery managerDeleteQuery = new ManagerDeleteQuery();
            managerDeleteQuery.Show();
        }

        private void ManagerFindForm_Click(object sender, RoutedEventArgs e)
        {
            ManagerFindForm ManagerFindForm = new ManagerFindForm();
            ManagerFindForm.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Manager.LoadTable();
        }
        
        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }
    }
}
