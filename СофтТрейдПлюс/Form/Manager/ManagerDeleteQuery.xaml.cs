using System.Data;
using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ManagerDeleteQuery.xaml
    /// </summary>
    public partial class ManagerDeleteQuery : Window
    {
        public ManagerDeleteQuery()
        {
            InitializeComponent();
            Manager.FillIdManagerComboBox(IdComboBox);
        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {            
            Close();
        }

        private void DeleteQuery_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.DeleteQuery(IdComboBox))
            {
                MessageBox.Show("Успех");
                Manager.LoadTable();
                Close();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.FillManagerDataGrid(ManagerDataGrid, IdComboBox);
            Client.FindClientByManager(ClientDataGrid, IdComboBox);
        }
    }
}
