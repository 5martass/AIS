using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CarService
{
    public partial class FormWorkInfo : Form
    {
        public FormWorkInfo()
        {
            InitializeComponent();
        }

        private int customerPK;
        private int stuffPK;
        private int workPK;
        private int carPK;
        private int price;
        private string typeWork;

        public void zapol(string workPK, string dateBegin, string dateEnd, string typeWork, string status, 
            int customerPK, int stuffPK, int carPK)
        {
            this.workPK = Convert.ToInt16(workPK);
            this.typeWork = typeWork;
            lblDateBegin.Text += dateBegin;
            lblDateEnd.Text += dateEnd;
            lblStatus.Text += status;
            lblTypeWork.Text += typeWork;
            lblWorkPK.Text += workPK;
            this.customerPK = customerPK;
            this.stuffPK = stuffPK;
            this.carPK = carPK;
            if (status == "выполнена")
            {
                lblStatus.ForeColor = Color.Green;
            }
            if (status == "выполняется")
            {
                lblStatus.ForeColor = Color.Gold;
            }
            if (status == "в ожидании")
            {
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void setWorkPK(int workPK)
        {
            this.workPK = workPK;
            lblWorkPK.Text += workPK.ToString();
            DataTable tableWorks = new DataTable();
            {
                string strSQL = "SELECT * FROM Works WHERE WorkPK=" + workPK;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableWorks.Load(reader);
            }
            lblDateBegin.Text += ((DateTime)tableWorks.Rows[0].ItemArray[1]).ToString("dd.MM.yyyy");
            if (tableWorks.Rows[0].ItemArray[2].ToString() == "")
                lblDateEnd.Text += "----------";
            else
            lblDateEnd.Text += ((DateTime)tableWorks.Rows[0].ItemArray[2]).ToString("dd.MM.yyyy");
            DataTable tableTypeWorks = new DataTable();
            {
                string strSQL = "SELECT * FROM TypeWorks WHERE TypeWorkPK=" + tableWorks.Rows[0].ItemArray[3].ToString();
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableTypeWorks.Load(reader);
            }
            lblTypeWork.Text += tableTypeWorks.Rows[0].ItemArray[1].ToString();
            lblPriceWork.Text += tableTypeWorks.Rows[0].ItemArray[3].ToString();
            price = int.Parse(tableTypeWorks.Rows[0].ItemArray[3].ToString());
            DataTable tableCar = new DataTable();
            {
                string strSQL = "SELECT * FROM Cars WHERE CarPK=" + tableWorks.Rows[0].ItemArray[7].ToString();
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableCar.Load(reader);
            }
            DataTable tableCarBrand = new DataTable();
            {
                string strSQL = "SELECT * FROM CarBrand WHERE CarBrandPK=" + tableCar.Rows[0].ItemArray[1].ToString();
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableCarBrand.Load(reader);
            }
            lblCar.Text += tableCarBrand.Rows[0].ItemArray[1].ToString() + " ";
            DataTable tableCarModel = new DataTable();
            {
                string strSQL = "SELECT * FROM CarModel WHERE CarModelPK=" + tableCar.Rows[0].ItemArray[2].ToString();
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableCarModel.Load(reader);
            }
            lblCar.Text += tableCarModel.Rows[0].ItemArray[2].ToString();
            lblStatus.Text += tableWorks.Rows[0].ItemArray[4].ToString();
            stuffPK = (int)tableWorks.Rows[0].ItemArray[5];
            customerPK = (int)tableWorks.Rows[0].ItemArray[6];

            DataTable tableTypeWorksSpares = new DataTable();
            {
                string strSQL = "SELECT * FROM TypeWorksSpares WHERE TypeWorkPK=" + tableWorks.Rows[0].ItemArray[3];
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableTypeWorksSpares.Load(reader);
                //dgvSpares.DataSource = tableTypeWorksSpares;
            }

            //dgvSpares.Columns["TypeWorkPK"].Visible = false;
            //dgvSpares.Columns["SparePK"].Visible = false;

            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Название";
            newColumn.Name = "Name";
            newColumn.Width = 150;
            newColumn.DisplayIndex = 0;
            dgvSpares.Columns.Add(newColumn);

            newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Колличество";
            newColumn.Name = "Count";
            newColumn.Width = 125;
            newColumn.DisplayIndex = 1;
            dgvSpares.Columns.Add(newColumn);

            newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Стоимость единицы";
            newColumn.Name = "Price";
            newColumn.Width = 140;
            newColumn.DisplayIndex = 2;
            dgvSpares.Columns.Add(newColumn);

            newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Цена";
            newColumn.Name = "Цена";
            newColumn.Width = 140;
            newColumn.DisplayIndex = 3;
            dgvSpares.Columns.Add(newColumn);

            int summ = 0;

            for (int i = 0; i < tableTypeWorksSpares.Rows.Count; i++)
            {
                DataTable tableSpares = new DataTable();
                {
                    string strSQL = "SELECT * FROM Spares WHERE SparePK=" + tableTypeWorksSpares.Rows[i].ItemArray[1];
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                    tableSpares.Load(reader);
                }
                dgvSpares.Rows.Add();
                dgvSpares.Rows[i].Cells["Name"].Value = tableSpares.Rows[0].ItemArray[1].ToString();
                dgvSpares.Rows[i].Cells["Count"].Value = tableTypeWorksSpares.Rows[i].ItemArray[2];
                dgvSpares.Rows[i].Cells["Price"].Value = tableSpares.Rows[0].ItemArray[3];
                dgvSpares.Rows[i].Cells["Цена"].Value = int.Parse(dgvSpares.Rows[i].Cells["Count"].Value.ToString()) * int.Parse(dgvSpares.Rows[i].Cells["Price"].Value.ToString());
                summ += int.Parse(dgvSpares.Rows[i].Cells["Цена"].Value.ToString());
            }
            summ += price;
            lblResultPrice.Text += summ;
        }

        private void btnCustomerInfo_Click(object sender, EventArgs e)
        {
            FormAddCustomer form = new FormAddCustomer();
            form.hideButtons();
            form.setCustomerPK(customerPK);
            form.ShowDialog();
        }

        private void btnStuffInfo_Click(object sender, EventArgs e)
        {
            if (stuffPK == -1) { MessageBox.Show("Ожидается механик");return; }
            FormAddInfo form = new FormAddInfo();
            form.hideForm();
            form.setStuffPK(stuffPK);
            form.ShowDialog();
        }

        private void FormWorkInfo_Load(object sender, EventArgs e)
        {
            
        }   
            
    }
}
