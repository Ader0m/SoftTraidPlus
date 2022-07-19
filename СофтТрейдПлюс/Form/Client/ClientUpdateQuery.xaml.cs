using System.Windows;
using System.Windows.Controls;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для ClientUpdateQuery.xaml
    /// </summary>
    public partial class ClientUpdateQuery : Window
    {
        public ClientUpdateQuery()
        {
            InitializeComponent();
            Client.FillIdClient(IdClientComboBox);
            Manager.FillIdManagerComboBox(IdManagerComboBox);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Client.FillClientDataGrid(ClientDataGrid, IdClientComboBox);           
        }

        public void UpdateQuery_Click(object sender, RoutedEventArgs e)
        {
            if (Client.UpdateQuery(IdClientComboBox, NameTextBox, StateComboBox, IdManagerComboBox, EntityCheckBox, ContactTextBox))
            { 
                MessageBox.Show("Успех");
                Client.LoadTable();
                Close();
            }
        }       
        
        private void EntityCheckBox_Checked(object sender, RoutedEventArgs e)
        {           
            ContactTextBox.IsReadOnly = false;
            ContactTextBox.IsEnabled = true;
        }

        private void EntityCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ContactTextBox.Text = "";
            ContactTextBox.IsEnabled = false;
            ContactTextBox.IsReadOnly = true;
        }

        void CloseForm_Client(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
