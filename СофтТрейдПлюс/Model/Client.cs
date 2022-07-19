using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace СофтТрейдПлюс.Model
{
    internal static class Client
    {
        private static SqlDataAdapter adapter;
        private static DataTable clientTable;
        private static DataGrid dataGrid;

        public static DataTable ClientTable { get => clientTable; set => clientTable = value; }

        public static void SetDataGrid(DataGrid dataGrid1)
        {
            dataGrid = dataGrid1;
        }

        public static void LoadTable()
        {
            if (dataGrid != null)
            {
                string cmdText = "SELECT * FROM Client";
                ClientTable = new DataTable();
                SqlCommand cmd;

                try
                {
                    cmd = new SqlCommand(cmdText, DataBase.getConnect());
                    adapter = new SqlDataAdapter(cmd);

                    DataBase.OpenConnection();
                    adapter.Fill(ClientTable);
                    DataColumn[] column = new DataColumn[1];
                    column[0] = ClientTable.Columns["id"];
                    ClientTable.PrimaryKey = column;
                    dataGrid.ItemsSource = ClientTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DataBase.CloseConnection();
                }
            }
        }

        public static void PresentClient(DataGrid menuDataGrid)
        {
            
            string cmdText = "SELECT [Name] FROM Client";
            SqlDataAdapter localAdapter;
            DataTable localClientTable = new DataTable();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                localAdapter = new SqlDataAdapter(cmd);

                DataBase.OpenConnection();
                localAdapter.Fill(localClientTable);
                menuDataGrid.ItemsSource = localClientTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DataBase.CloseConnection();
            }
        }       
      
        

        public static void FillIdClient(ComboBox comboBox)
        {
            Query.ReadOneColumn("SELECT id FROM Client", comboBox);
        }

        public static bool InsertQuery(TextBox name, ComboBox state, ComboBox idManager, CheckBox entity, TextBox contact)
        {
            string cmdText = @"INSERT INTO Client 
                            ([Name], [State], [id Manager], [Entity], [Contact])
                            VALUES
                            (@name, @state, @idMan, @entity, @contact)";
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());        
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@state", state.Text);
                cmd.Parameters.AddWithValue("@idMan", idManager.Text);
                cmd.Parameters.AddWithValue("@entity", entity.IsChecked);
                cmd.Parameters.AddWithValue("@contact", contact.Text);
                DataBase.OpenConnection();
                cmd.ExecuteNonQuery();            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                DataBase.CloseConnection();
                
            }

            return true;
        }

        public static bool UpdateQuery(ComboBox id, TextBox name, ComboBox state, ComboBox idManager, CheckBox entity, TextBox contact)
        {
            string cmdText = @"UPDATE Client SET           
                            Name = @name, 
                            State = @state, 
                            [id Manager] = @idMan, 
                            Entity = @entity,
                            Contact = @contact
                            WHERE id = @id";            
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());                
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@state", state.Text);
                cmd.Parameters.AddWithValue("@idMan", idManager.Text);
                cmd.Parameters.AddWithValue("@entity", entity.IsChecked);
                cmd.Parameters.AddWithValue("@contact", contact.Text);
                DataBase.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                DataBase.CloseConnection();

            }

            return true;
        }

        public static bool DeleteQuery(ComboBox id)
        {
            string cmdText = @"Delete FROM Client                                                             
                            WHERE id = @id";
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                cmd.Parameters.AddWithValue("@id", int.Parse(id.SelectedItem.ToString()));

                DataBase.OpenConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                DataBase.CloseConnection();

            }

            return true;
        }

        public static bool FindClientByManager(DataGrid ldataGrid, ComboBox idManager)
        {
            string cmdText = @"SELECT * FROM Client                                                             
                            WHERE [id Manager] = @idManager";
            SqlDataAdapter localAdapter;
            DataTable localClientTable = new DataTable();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                cmd.Parameters.AddWithValue("@idManager", int.Parse(idManager.SelectedItem.ToString()));
                localAdapter = new SqlDataAdapter(cmd);

                DataBase.OpenConnection();

                localAdapter.Fill(localClientTable);
                DataColumn[] column = new DataColumn[1];
                column[0] = ClientTable.Columns["id"];
                ClientTable.PrimaryKey = column;
                ldataGrid.ItemsSource = localClientTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                DataBase.CloseConnection();

            }

            return true;
        }

        public static void FillClientDataGrid(DataGrid dataGrid, ComboBox comboBox)
        {
            DataTable dt = new DataTable();
            foreach (DataColumn dataColumn in ClientTable.Columns)
            {
                dt.Columns.Add(dataColumn.ColumnName);
            }
            DataRow dr = ClientTable.Rows.Find(int.Parse(comboBox.SelectedItem.ToString()));
            dt.Rows.Add(dr.ItemArray);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }          
}
