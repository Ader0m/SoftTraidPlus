using System.Windows;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ManagerInsertQuery.xaml
    /// </summary>
    public partial class ManagerInsertQuery : Window
    {
        public ManagerInsertQuery()
        {
            InitializeComponent();
        }

        public void InsertQuery_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.InsertQuery(NameTextBox))
            {
                MessageBox.Show("Успех");
                Manager.LoadTable();
                Close();
            }
        }

        public void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
