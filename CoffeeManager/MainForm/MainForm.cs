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
                button.Tag = item;
                button.Click += Button_Click;
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

        private void ShowBill(int idTable)
        {
            List<BillDTO> billDTOs = DAL.BillDAL.Instance.LoadListBillByIDTable(idTable);
            lvBill.Items.Clear();
            if(billDTOs.Count > 0)
            {
                foreach (BillDTO item in billDTOs)
                {
                    int idBill = item.Id;
                    List<BillInforDTO> billInforDTOs = new List<BillInforDTO>();
                    billInforDTOs = DAL.BillInforDAL.Instance.LoadBillInforByIdBill(idBill);

                    if(billInforDTOs.Count > 0)
                    {
                        foreach (BillInforDTO bill in billInforDTOs)
                        {
                            ListViewItem listViewItem = new ListViewItem(bill.IdFood.ToString());
                            ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(listViewItem, bill.Count.ToString());
                            listViewItem.SubItems.Add(subItem);
                            lvBill.Items.Add(listViewItem);
                        }
                    }
                }
            }
        }

        #endregion
        #region Event
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            TableFoodDTO item = button.Tag as TableFoodDTO;
            int idTable = item.ID;
            ShowBill(idTable);

        }
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
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadTable();
        }
        #endregion


    }
}
