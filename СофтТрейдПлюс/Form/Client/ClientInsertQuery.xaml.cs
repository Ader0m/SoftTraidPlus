using System.Windows;
using СофтТрейдПлюс.Model;

namespace СофтТрейдПлюс.Form
{
    /// <summary>
    /// Логика взаимодействия для InsertQuery.xaml
    /// </summary>
    public partial class ClientInsertQuery : Window
    {
        public ClientInsertQuery()
        {
            InitializeComponent();
            Manager.FillIdManagerComboBox(IdManagerComboBox);
        }
      
        void InsertQuery_Click(object sender, RoutedEventArgs e)
        {
            if (Client.InsertQuery(NameTextBox, StateComboBox, IdManagerComboBox, EntityCheckBox, ContactTextBox))
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

        void CloseForm_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
