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
    internal static class Query
    {
        public static void ReadOneColumn(string cmdText, ComboBox comboBox)
        {
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand(cmdText, DataBase.getConnect());
                DataBase.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox.Items.Add(reader[0].ToString());
                }
                reader.Close();
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
}
