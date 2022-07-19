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
    internal class SellProduct
    {
        private static SqlDataAdapter adapter;
        private static DataTable sellProductTable;
        private static DataGrid dataGrid;

        public static DataTable SellProductTable { get => sellProductTable; set => sellProductTable = value; }

        public static void SetDataGrid(DataGrid dataGrid1)
        {
            dataGrid = dataGrid1;
        }

        public static void LoadTable()
        {
            if (dataGrid != null)
            {
                string cmdText = "SELECT * FROM SellProduct";
                SellProductTable = new DataTable();
                SqlCommand cmd;

                try
                {
                    cmd = new SqlCommand(cmdText, DataBase.getConnect());
                    adapter = new SqlDataAdapter(cmd);

                    DataBase.OpenConnection();
                    adapter.Fill(SellProductTable);
                    DataColumn[] column = new DataColumn[2];
                    column[0] = SellProductTable.Columns["id Product"];
                    column[1] = SellProductTable.Columns["id Client"];
                    SellProductTable.PrimaryKey = column;
                    dataGrid.ItemsSource = SellProductTable.DefaultView;
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

        public static void FillIdSellProductComboBox(ComboBox comboBox)
        {
            Query.ReadOneColumn("SELECT id FROM SellProduct", comboBox);
        }
        
        public static bool InsertQuery(ComboBox idProduct, ComboBox idClient, DatePicker dateSell)
        {
            string cmdText = @"INSERT INTO SellProduct 
                            ([id Product], [id Client], [Data Sell])
                            VALUES
                            (@idProduct, @idClient, @dateSell)";
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());               
                cmd.Parameters.AddWithValue("@idProduct", idProduct.Text);
                cmd.Parameters.AddWithValue("@idClient", idClient.Text);
                cmd.Parameters.AddWithValue("@dateSell", dateSell.Text);
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

        public static bool DeleteQuery(ComboBox idProduct, ComboBox idClient)
        {
            string cmdText = @"Delete FROM SellProduct                                                      
                            WHERE [id Product] = @idProduct AND [id Client] = @idClient";
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                cmd.Parameters.AddWithValue("@idProduct", int.Parse(idProduct.SelectedItem.ToString()));
                cmd.Parameters.AddWithValue("@idClient", int.Parse(idClient.SelectedItem.ToString()));

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

        public static void FindSellProductByClient(ComboBox idClient, DataGrid ldataGrid)
        {
            string cmdText = "SELECT * FROM SellProduct WHERE SellProduct.[id Client] = @idClient";           
            SqlCommand cmd;
            DataTable Table = new DataTable();
            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                cmd.Parameters.AddWithValue("@idClient", int.Parse(idClient.SelectedItem.ToString()));
                adapter = new SqlDataAdapter(cmd);

                DataBase.OpenConnection();
                adapter.Fill(Table);
                DataColumn[] column = new DataColumn[1];                
                ldataGrid.ItemsSource = Table.DefaultView;
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

        public static void FindSellProductByProduct(ComboBox idProduct, DataGrid ldataGrid)
        {
            string cmdText = "SELECT * FROM SellProduct WHERE SellProduct.[id Product] = @idProduct";
            SqlCommand cmd;
            DataTable Table = new DataTable();
            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                cmd.Parameters.AddWithValue("@idProduct", int.Parse(idProduct.SelectedItem.ToString()));
                adapter = new SqlDataAdapter(cmd);

                DataBase.OpenConnection();
                adapter.Fill(Table);
                DataColumn[] column = new DataColumn[1];
                ldataGrid.ItemsSource = Table.DefaultView;
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

        public static void FindSellProductByData(DatePicker datePicker, DataGrid ldataGrid)
        {
            string cmdText = "SELECT * FROM SellProduct WHERE SellProduct.[Data Sell] = @dateSell";
            SqlCommand cmd;
            DataTable Table = new DataTable();
            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                cmd.Parameters.AddWithValue("@dateSell", datePicker.Text);
                adapter = new SqlDataAdapter(cmd);

                DataBase.OpenConnection();
                adapter.Fill(Table);
                DataColumn[] column = new DataColumn[1];
                ldataGrid.ItemsSource = Table.DefaultView;
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

        public static void FillSellProductDataGrid(DataGrid dataGrid, ComboBox comboBox)
        {
            DataTable dt = new DataTable();
            foreach (DataColumn dataColumn in SellProductTable.Columns)
            {
                dt.Columns.Add(dataColumn.ColumnName);
            }
            DataRow dr = SellProductTable.Rows.Find(int.Parse(comboBox.SelectedItem.ToString()));
            dt.Rows.Add(dr.ItemArray);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
