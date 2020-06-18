using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManager.OtherForm
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadAccount();
        }

        private void LoadAccount()
        {
            string connecttionString = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyQuanCafe;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connecttionString);
            connection.Open();
            string query = "SELECT DisplayName FROM dbo.Account";
            SqlCommand command = new SqlCommand(query, connection);

            DataTable data = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(data);

            connection.Close();

            dataGridViewAccount.DataSource = data;

        }
    }
}
