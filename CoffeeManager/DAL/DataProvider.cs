using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeManager
{
    /// <summary>
    /// Execute Query
    /// </summary>
    public class DataProvider
    {

        private static DataProvider instance;
        private string connecttionString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";

        public string ConnecttionString { get => connecttionString; set => connecttionString = value; }
        public static DataProvider Instance
        {
            //kien truc Singleton 
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            private set => instance = value;
        }
        private DataProvider()
        { }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnecttionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                sqlDataAdapter.Fill(data);
                connection.Close();
            }

            return data;
        }

        /// <summary>
        /// Use for insert, update, delete
        /// </summary>
        public int ExecuteNoneQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(ConnecttionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }

            return data;
        }

        public object ExecuteNoneScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(ConnecttionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;

                    foreach (string item in listPara)
                    {
                        if (item.Contains("@"))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }

            return data;
        }
    }
}
