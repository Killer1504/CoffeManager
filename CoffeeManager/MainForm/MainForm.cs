using CoffeeManager.DAL;
using CoffeeManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private void LoadFoodByIDCategory(int id)
        {
            List<FoodDTO> foodDTOs = FoodDAL.Instance.LoadFoodByIDCategory(id);

            cbbFood.DataSource = foodDTOs;
            cbbFood.DisplayMember = "Name";
        }
        private void LoadFoodCategory()
        {
            List<CategoryDTO> categoryDTOs = CategoryDAL.Instance.LoadCategory();

            cbbCategory.DataSource = categoryDTOs;
            cbbCategory.DisplayMember = "Name";
        }
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
            List<BillMenuDTO> billMenuDTOs = BillMenuDAL.Instance.LoadListBillMenuByTable(idTable);
            lvBill.Items.Clear();
            float totalPrice = 0;
            if(billMenuDTOs.Count > 0)
            {
                foreach (BillMenuDTO item in billMenuDTOs)
                {
                    ListViewItem listViewItem = new ListViewItem(item.NameFood);
                    ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item.Count.ToString());
                    ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, item.Price.ToString());
                    ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, item.TotalPrice.ToString());
                    listViewItem.SubItems.Add(subItem1);
                    listViewItem.SubItems.Add(subItem2);
                    listViewItem.SubItems.Add(subItem3);
                    totalPrice += item.TotalPrice;
                    lvBill.Items.Add(listViewItem);
                }
            }

            CultureInfo cultureInfo = new CultureInfo("vi-VN");
            txtTotalPrice.Text = totalPrice.ToString("c",cultureInfo.NumberFormat);
        }

        #endregion
        #region Event
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            TableFoodDTO item = button.Tag as TableFoodDTO;
            lvBill.Tag = item;
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
            LoadFoodCategory();
        }
        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedItem == null)
                return;
            CategoryDTO category = cbbCategory.SelectedItem as CategoryDTO;
            int idCategory = category.ID;
            LoadFoodByIDCategory(idCategory);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            TableFoodDTO tableFoodDTO = lvBill.Tag as TableFoodDTO;

            int idTable = tableFoodDTO.ID;
            int idBill = BillDAL.Instance.GetUncheckBillByIdTable(idTable);

            int idFood = 0;
            FoodDTO foodDTO = cbbFood.SelectedItem as FoodDTO;
            idFood = foodDTO.Id;
            int countFood = (int)numCountFood.Value;
            if(idBill == -1)
            {
                //bill chua ton tai, them bill
                BillDAL.Instance.InsertBill(idTable);
                BillInforDAL.Instance.InserBillInfor(BillDAL.Instance.GetMaxIdBill(), idFood, countFood);
            }
            else
            {
                //bil da ton tai, them vao mon
                BillInforDAL.Instance.InserBillInfor(idBill, idFood, countFood);
            }
            ShowBill(idTable);
        }
        #endregion


    }
}
