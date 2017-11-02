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
    public partial class FormMechanic : Form
    {
        string stuffPK;

        public FormMechanic(string stuffPk)
        {
            InitializeComponent();
            this.stuffPK = stuffPk;
        }

        void splittersVisibleOff()
        {
            for (int i = 0; i < this.Controls.Count; i++)
                if (Controls[i].GetType() == typeof(Panel))
                    if (Controls[i].Name != "panelMenu")
                        Controls[i].Visible = false;
        }

        private void FormMechanic_Load(object sender, EventArgs e)
        {
            splittersVisibleOff();
            buttonWorks_Click(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из программы?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnExitMec_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из раздела автомеханика?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void buttonWorks_Click(object sender, EventArgs e)
        {
            dgvWorks.Columns.Clear();
            splittersVisibleOff();
            panelWorks.Visible = true;
            DataTable tableWorks = new DataTable();
            {
                string strSQL = "SELECT * FROM Works WHERE stuffPK=" + stuffPK;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableWorks.Load(reader);
                dgvWorks.DataSource = tableWorks;
            }

            dgvWorks.Columns["Status"].Width = 150;
            dgvWorks.Columns["WorkPK"].Visible = false;
            dgvWorks.Columns["TypeWorkPK"].Visible = false;
            dgvWorks.Columns["StuffPK"].Visible = false;
            dgvWorks.Columns["CustomerPK"].Visible = false;
            dgvWorks.Columns["CarPK"].Visible = false;

            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Услуга";
            newColumn.Name = "Услуга";
            newColumn.DisplayIndex = 0;
            dgvWorks.Columns.Add(newColumn);

            newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Автомобиль";
            newColumn.Name = "Автомобиль";
            newColumn.Width = 150;
            newColumn.DisplayIndex = 1;
            dgvWorks.Columns.Add(newColumn);

            newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Клиент";
            newColumn.Name = "Клиент";
            newColumn.Width = 150;
            newColumn.DisplayIndex = 2;
            dgvWorks.Columns.Add(newColumn);

            for (int i = 0; i < dgvWorks.RowCount; i++)
            {
                ///////////NameTypeWork
                string strSQL = "SELECT * FROM TypeWorks WHERE [TypeWorkPK]=" + dgvWorks.Rows[i].Cells["TypeWorkPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dgvWorks.Rows[i].Cells["Услуга"].Value = table.Rows[0].ItemArray[1].ToString();

                /////////NameCar
                string nameCar = "";
                strSQL = "SELECT * FROM Cars WHERE [CarPK]=" + dgvWorks.Rows[i].Cells["CarPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                reader = SQLCommands.myCommand.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                int CarBrandPK = (int)table.Rows[0].ItemArray[1];
                int CarModelPK = (int)table.Rows[0].ItemArray[2];

                strSQL = "SELECT * FROM CarBrand WHERE [CarBrandPK]=" + CarBrandPK;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                reader = SQLCommands.myCommand.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                nameCar += table.Rows[0].ItemArray[1].ToString() + " ";

                strSQL = "SELECT * FROM CarModel WHERE [CarModelPK]=" + CarModelPK;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                reader = SQLCommands.myCommand.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                nameCar += table.Rows[0].ItemArray[2].ToString();
                dgvWorks.Rows[i].Cells["Автомобиль"].Value = nameCar;

                //////////Имя клиента
                strSQL = "SELECT * FROM Customers WHERE [CustomerPK]=" + dgvWorks.Rows[i].Cells["CustomerPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                reader = SQLCommands.myCommand.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                dgvWorks.Rows[i].Cells["Клиент"].Value = table.Rows[0].ItemArray[1] + " " + table.Rows[0].ItemArray[2] + " " + table.Rows[0].ItemArray[3];

                reader.Close();
            }
            dgvWorks.Columns["Status"].HeaderText = "Статус";
            dgvWorks.Columns["DateBegin"].HeaderText = "Дата заказа";
            dgvWorks.Columns["DateEnd"].HeaderText = "Дата завершения заказа";
        }

        private void buttonWorkEnd_Click(object sender, EventArgs e)
        {
            if (dgvWorks.SelectedRows.Count == 0) return;
            if (dgvWorks.SelectedRows[0].Cells["Status"].Value.ToString() == "выполнено") { MessageBox.Show("Работа уже выполнена"); return; }
            string strSQL = "UPDATE Works SET Status='выполнено',DateEnd = @date WHERE WorkPK ="+dgvWorks.SelectedRows[0].Cells["WorkPK"].Value;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            SQLCommands.myCommand.Parameters.Add("@date", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.Date;
            SQLCommands.myCommand.ExecuteNonQuery();
            buttonWorks_Click(sender, e);
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (dgvWorks.SelectedRows.Count == 0) return;
            FormWorkInfo form = new FormWorkInfo();
            form.setWorkPK((int)dgvWorks.SelectedRows[0].Cells["WorkPK"].Value);
            form.ShowDialog();
        }

        private void carsButton_Click(object sender, EventArgs e)
        {
            dgvFreeWorks.Columns.Clear();
            splittersVisibleOff();
            panelFreeWorks.Visible = true;

            DataTable tableWorks = new DataTable();
            {
                string strSQL = "SELECT * FROM Works WHERE stuffPK=-1";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableWorks.Load(reader);
                dgvFreeWorks.DataSource = tableWorks;
            }

            dgvFreeWorks.Columns["Status"].Width = 150;
            dgvFreeWorks.Columns["Status"].HeaderText = "Статус";
            dgvFreeWorks.Columns["DateBegin"].HeaderText = "Дата заказа";
            dgvFreeWorks.Columns["WorkPK"].Visible = false;
            dgvFreeWorks.Columns["TypeWorkPK"].Visible = false;
            dgvFreeWorks.Columns["StuffPK"].Visible = false;
            dgvFreeWorks.Columns["CustomerPK"].Visible = false;
            dgvFreeWorks.Columns["CarPK"].Visible = false;
            dgvFreeWorks.Columns["DateEnd"].Visible = false;

            DataGridViewTextBoxColumn newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Услуга";
            newColumn.Name = "Услуга";
            newColumn.Width = 150;
            newColumn.DisplayIndex = 0;
            dgvFreeWorks.Columns.Add(newColumn);

            newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Автомобиль";
            newColumn.Name = "Автомобиль";
            newColumn.Width = 150;
            newColumn.DisplayIndex = 1;
            dgvFreeWorks.Columns.Add(newColumn);

            newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Клиент";
            newColumn.Name = "Клиент";
            newColumn.Width = 200;
            newColumn.DisplayIndex = 2;
            dgvFreeWorks.Columns.Add(newColumn);

            for (int i = 0; i < dgvFreeWorks.RowCount; i++)
            {
                ///////////NameTypeWork
                string strSQL = "SELECT * FROM TypeWorks WHERE [TypeWorkPK]=" + dgvFreeWorks.Rows[i].Cells["TypeWorkPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                dgvFreeWorks.Rows[i].Cells["Услуга"].Value = table.Rows[0].ItemArray[1].ToString();

                /////////NameCar
                string nameCar = "";
                strSQL = "SELECT * FROM Cars WHERE [CarPK]=" + dgvFreeWorks.Rows[i].Cells["CarPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                reader = SQLCommands.myCommand.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                int CarBrandPK = (int)table.Rows[0].ItemArray[1];
                int CarModelPK = (int)table.Rows[0].ItemArray[2];

                strSQL = "SELECT * FROM CarBrand WHERE [CarBrandPK]=" + CarBrandPK;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                reader = SQLCommands.myCommand.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                nameCar += table.Rows[0].ItemArray[1].ToString() + " ";

                strSQL = "SELECT * FROM CarModel WHERE [CarModelPK]=" + CarModelPK;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                reader = SQLCommands.myCommand.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                nameCar += table.Rows[0].ItemArray[2].ToString();
                dgvFreeWorks.Rows[i].Cells["Автомобиль"].Value = nameCar;

                //////////Имя клиента
                strSQL = "SELECT * FROM Customers WHERE [CustomerPK]=" + dgvFreeWorks.Rows[i].Cells["CustomerPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                reader = SQLCommands.myCommand.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                dgvFreeWorks.Rows[i].Cells["Клиент"].Value = table.Rows[0].ItemArray[1] + " " + table.Rows[0].ItemArray[2] + " " + table.Rows[0].ItemArray[3];

                ///////////////////Проверка
                dgvFreeWorks.Rows[i].Cells["Status"].Value = "ожидается механик";

                strSQL = "SELECT * FROM TypeWorksSpares WHERE [TypeWorkPK]=" + dgvFreeWorks.Rows[i].Cells["TypeWorkPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                reader = SQLCommands.myCommand.ExecuteReader();
                DataTable tableTypeWorksSpares = new DataTable();
                tableTypeWorksSpares.Load(reader);

                for (int j = 0; j < tableTypeWorksSpares.Rows.Count; j++)
                {
                    strSQL = "SELECT * FROM Spares WHERE [SparePK]=" + tableTypeWorksSpares.Rows[j].ItemArray[1];
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    reader = SQLCommands.myCommand.ExecuteReader();
                    DataTable tableSpares = new DataTable();
                    tableSpares.Load(reader);
                    if ((int)tableTypeWorksSpares.Rows[j].ItemArray[2] > (int)tableSpares.Rows[0].ItemArray[2])
                    {
                        dgvFreeWorks.Rows[i].Cells["Status"].Value = "ожидаются запчасти";
                        break;
                    }
                }

                strSQL = "UPDATE Works SET [Status]='" + dgvFreeWorks.Rows[i].Cells["Status"].Value + "' WHERE WorkPK = " + dgvFreeWorks.Rows[i].Cells["WorkPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.ExecuteNonQuery();
                //////
                dgvFreeWorks.CurrentCell = null;
                for (int j = 0; j < dgvFreeWorks.RowCount; j++)
                    if (dgvFreeWorks.Rows[j].Cells["Status"].Value.ToString() == "ожидаются запчасти")
                        dgvFreeWorks.Rows[j].Visible = false;
            }
        }

        private void buttonAddWorks_Click(object sender, EventArgs e)
        {
            if (dgvFreeWorks.SelectedRows.Count == 0) return;
            var result = MessageBox.Show("С склада будут списаны необходимые запчасти.\nВы согласны?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                DataTable tableTypeWorksSpares = new DataTable();
                {
                    string strSQL = "SELECT * FROM TypeWorksSpares WHERE TypeWorkPK="+dgvFreeWorks.SelectedRows[0].Cells["TypeWorkPK"].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                    tableTypeWorksSpares.Load(reader);
                }
                for(int i = 0; i < tableTypeWorksSpares.Rows.Count; i++)
                {
                    DataTable tableSpares = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Spares WHERE SparePK=" + tableTypeWorksSpares.Rows[i].ItemArray[1];
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableSpares.Load(reader);
                    }
                    {
                        string strSQL = "UPDATE Spares SET [Count]="+((int)tableSpares.Rows[0].ItemArray[2]-((int)tableTypeWorksSpares.Rows[i].ItemArray[2]))+" WHERE SparePK="+tableSpares.Rows[0].ItemArray[0];
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        SQLCommands.myCommand.ExecuteNonQuery();
                    }
                }
                {
                    string strSQL = "UPDATE Works SET [Status]='выполняется',StuffPK="+stuffPK+" WHERE WorkPK = " + dgvFreeWorks.SelectedRows[0].Cells["WorkPK"].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();
                }
                carsButton_Click(sender, e);
            }
        }

        private void buttonInfoWorks_Click(object sender, EventArgs e)
        {
            if (dgvFreeWorks.SelectedRows.Count == 0) return;
            FormWorkInfo form = new FormWorkInfo();
            form.setWorkPK((int)dgvFreeWorks.SelectedRows[0].Cells["WorkPK"].Value);
            form.ShowDialog();
        }

        List<int> massId;
        private void TypesCars_Click(object sender, EventArgs e)
        {
            splittersVisibleOff();
            panelTypeCars.Visible = true;
            massId = new List<int>();
            DataTable tableBrand = new DataTable();
            {
                string strSQL = "SELECT * FROM CarBrand";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableBrand.Load(reader);
            }
            if (tableBrand.Rows.Count == 0)
            {
                MessageBox.Show("Список автомобилей пуст","Error");
                buttonWorks_Click(sender, e);
                return;
            }
            for(int i = 0; i < tableBrand.Rows.Count; i++)
            {
                cbBrand.Items.Add(tableBrand.Rows[i].ItemArray[1].ToString());
                massId.Add((int)tableBrand.Rows[i].ItemArray[0]);
            }
            cbBrand.SelectedIndex = 0;
            cbBrand_SelectedIndexChanged(sender, e);
        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tableModel = new DataTable();
            {
                string strSQL = "SELECT * FROM CarModel WHERE CarBrand="+massId[cbBrand.SelectedIndex];
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableModel.Load(reader);
                dgvCars.DataSource = tableModel;
            }
            dgvCars.Columns["CarModelPK"].Visible = false;
            dgvCars.Columns["CarBrand"].Visible = false;
            dgvCars.Columns["Name"].HeaderText = "Название";
            dgvCars.Columns["Name"].Width = 750;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvCars.SelectedRows.Count == 0) return;
            FormSpares form = new FormSpares(cbBrand.Text+" "+dgvCars.SelectedRows[0].Cells["Name"].Value.ToString()
                ,int.Parse(dgvCars.SelectedRows[0].Cells["CarModelPK"].Value.ToString()));
            form.offVisible();
            form.ShowDialog();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Help.chm");
        }
    }
}
