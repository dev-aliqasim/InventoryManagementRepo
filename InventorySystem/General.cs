using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PickAndChooseGroceryStore
{
    public static class General
    {
        //public static string connectionString = @"Data Source=192.168.100.200,1433;Initial Catalog=GroceryStore;User ID=imsLogin;Password=12345";
        public static string connectionString = @"Data Source=.;Initial Catalog=GroceryStore;Integrated Security=true";

        public static void ExecuteNonQuery(string Query)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Exception in ExecuteNonQuery","Critical Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
               
            }
        }

        public static DataTable FetchData(string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(Query ,con);
                da.Fill(dt);
                con.Close();
                return dt;

            }
            catch (Exception)
            {
                MessageBox.Show("Exception in Fetch Data", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }
    }
}
