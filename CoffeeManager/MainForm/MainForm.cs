using CoffeeManager.DAL;
using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        #region Method
        private void LoadTable()
        {
            List<TableFoodDTO> tableFoods = TableDAL.Instance.LoadTableList();
            foreach (TableFoodDTO item in tableFoods)
            {
                Button button = new Button() { Width = TableFoodDTO.TableWidth, Height = TableFoodDTO.TableHeight };
                button.Text = item.Name + Environment.NewLine + item.Status;
                switch (item.Status)
                {
                    case "Trống":
                        button.BackColor = Color.LightGray;
                        break;
                    default:
                        button.BackColor = Color.LightGreen;
                        break;
                }
                flowLayoutPanel.Controls.Add(button);

            }
        }
        #endregion
        #region Event

        private void logOutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void personalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonalInformation personalInformation = new PersonalInformation();
            personalInformation.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoffeeManager.OtherForm.Admin admin = new OtherForm.Admin();
            admin.ShowDialog();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
    }
}
