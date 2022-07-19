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
    internal class Product
    {
        private static SqlDataAdapter adapter;
        private static DataTable productTable;
        private static DataGrid dataGrid;

        public static DataTable ProductTable { get => productTable; set => productTable = value; }

        public static void SetDataGrid(DataGrid dataGrid1)
        {
            dataGrid = dataGrid1;
        }

        public static void LoadTable()
        {
            if (dataGrid != null)
            {
                string cmdText = "SELECT * FROM Product";
                ProductTable = new DataTable();
                SqlCommand cmd;

                try
                {
                    cmd = new SqlCommand(cmdText, DataBase.getConnect());
                    adapter = new SqlDataAdapter(cmd);

                    DataBase.OpenConnection();
                    adapter.Fill(ProductTable);
                    DataColumn[] column = new DataColumn[1];
                    column[0] = ProductTable.Columns["id"];
                    ProductTable.PrimaryKey = column;
                    dataGrid.ItemsSource = ProductTable.DefaultView;
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

        public static void FillIdProductComboBox(ComboBox comboBox)
        {
            Query.ReadOneColumn("SELECT id FROM Product", comboBox);
        }

        public static bool InsertQuery(TextBox name, TextBox price, ComboBox type, ComboBox term)
        {
            string cmdText = @"INSERT INTO Product 
                            ([Name], [Price], [Type], [Term])
                            VALUES
                            (@name, @price, @type, @term)";
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.Parameters.AddWithValue("@type", type.Text);               
                cmd.Parameters.AddWithValue("@term", term.Text);

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

        public static bool UpdateQuery(ComboBox id, TextBox name, TextBox price, ComboBox Type, ComboBox Term)
        {
            string cmdText = @"UPDATE Product SET           
                            Name = @name, 
                            Price = @price, 
                            Type = @type,                             
                            Term = @Term
                            WHERE id = @id";
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@name", name.Text);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.Parameters.AddWithValue("@type", Type.Text);              
                cmd.Parameters.AddWithValue("@Term", Term.Text);
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
            string cmdText = @"Delete FROM Product                                                             
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

        public static void FillProductDataGrid(DataGrid dataGrid, ComboBox comboBox)
        {
            DataTable dt = new DataTable();
            foreach (DataColumn dataColumn in ProductTable.Columns)
            {
                dt.Columns.Add(dataColumn.ColumnName);
            }
            DataRow dr = ProductTable.Rows.Find(int.Parse(comboBox.SelectedItem.ToString()));
            dt.Rows.Add(dr.ItemArray);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
