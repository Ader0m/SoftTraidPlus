using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ManagerFindForm.xaml
    /// </summary>
    public partial class ManagerFindForm : Window
    {
        public ManagerFindForm()
        {
            InitializeComponent();
            Manager.FillIdManagerComboBox(IdComboBox);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client.FindClientByManager(ManagerDataGrid, IdComboBox);          
        }

        private void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
