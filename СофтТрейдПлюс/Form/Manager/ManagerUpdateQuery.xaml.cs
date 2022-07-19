using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ManagerUpdateQuery.xaml
    /// </summary>
    public partial class ManagerUpdateQuery : Window
    {
        public ManagerUpdateQuery()
        {
            InitializeComponent();
            Manager.FillIdManagerComboBox(IdComboBox);           
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Manager.FillManagerDataGrid(ManagerUpdateDataGrid, IdComboBox);
        }

        public void UpdateQuery_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.UpdateQuery(IdComboBox, NameTextBox))
            {
                MessageBox.Show("Успех");
                Manager.LoadTable();
                Close();
            }
        }

        void CloseForm_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
