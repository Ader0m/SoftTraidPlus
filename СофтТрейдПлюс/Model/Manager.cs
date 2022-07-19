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
    internal class Manager
    {
        private static SqlDataAdapter adapter;
        private static DataTable managerTable;
        private static DataGrid dataGrid;

        public static DataTable ManagerTable { get => managerTable; set => managerTable = value; }

        public static void SetDataGrid(DataGrid dataGrid1)
        {
            dataGrid = dataGrid1;
        }

        public static void LoadTable()
        {
            if (dataGrid != null)
            {
                string cmdText = "SELECT * FROM Manager";
                ManagerTable = new DataTable();
                SqlCommand cmd;

                try
                {
                    cmd = new SqlCommand(cmdText, DataBase.getConnect());
                    adapter = new SqlDataAdapter(cmd);

                    DataBase.OpenConnection();
                    adapter.Fill(ManagerTable);
                    DataColumn[] column = new DataColumn[1];
                    column[0] = ManagerTable.Columns["id"];
                    ManagerTable.PrimaryKey = column;
                    dataGrid.ItemsSource = ManagerTable.DefaultView;
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

        public static bool InsertQuery(TextBox name)
        {
            string cmdText = @"INSERT INTO Manager 
                            ([Name])
                            VALUES
                            (@name)";
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                DataBase.OpenConnection();
                cmd.Parameters.AddWithValue("@name", name.Text);
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

        public static void FillIdManagerComboBox(ComboBox comboBox)
        {
            Query.ReadOneColumn("SELECT id FROM Manager", comboBox);
        }

        public static bool UpdateQuery(ComboBox id, TextBox name)
        {
            string cmdText = @"UPDATE Manager SET           
                            Name = @name                         
                            WHERE id = @id";
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                DataBase.OpenConnection();
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                
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
            string cmdText = @"Delete FROM Manager                                                             
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

        public static void FillManagerDataGrid(DataGrid dataGrid, ComboBox comboBox)
        {
            DataTable dt = new DataTable();
            foreach (DataColumn dataColumn in ManagerTable.Columns)
            {
                dt.Columns.Add(dataColumn.ColumnName);
            }
            DataRow dr = ManagerTable.Rows.Find(int.Parse(comboBox.SelectedItem.ToString()));
            dt.Rows.Add(dr.ItemArray);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
