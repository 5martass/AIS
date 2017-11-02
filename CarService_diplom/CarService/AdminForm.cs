using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace CarService
{
    public partial class AdminForm : Form
    {
        DataTable tableCars;
        public AdminForm()
        {
            InitializeComponent();
            splittersVisibleOff();
            string strSQL = "SELECT * FROM TypeCars";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            while (reader.Read())
            {
                cbCateg.Items.Add(reader[0]);
            }
            reader.Close();
            cbCateg.SelectedIndex = 0; 
        }

        void splittersVisibleOff()
        {
            for (int i = 0; i < this.Controls.Count; i++)
                if (Controls[i].GetType() == typeof(Panel))
                    if(Controls[i].Name!="panelMenu")
                    Controls[i].Visible = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из программы?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void ToMenuButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти из раздела администратора?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               
                Close();
            }
        }

        private void carsButton_Click(object sender, EventArgs e)
        {
            splittersVisibleOff();
            panelCars.Visible = true;
            tbSearch_TextChanged(new object(),new EventArgs());
        }

        private void buttonWorks_Click(object sender, EventArgs e)
        {
            splittersVisibleOff();
            panelWorks.Visible = true;
            dgvWorks.Columns.Clear();
            DataTable tableWorks = new DataTable();
            {
                string strSQL = "SELECT * FROM Works";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableWorks.Load(reader);
                dgvWorks.DataSource = tableWorks;
            }

            dgvWorks.Columns["Status"].HeaderText = "Статус";
            dgvWorks.Columns["DateBegin"].HeaderText = "Дата заказа";
            dgvWorks.Columns["DateEnd"].HeaderText = "Дата завершения заказа";
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
            newColumn.DisplayIndex = 1;
            dgvWorks.Columns.Add(newColumn);

            newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Клиент";
            newColumn.Name = "Клиент";
            newColumn.Width = 130;
            newColumn.DisplayIndex = 2;
            dgvWorks.Columns.Add(newColumn);

            newColumn = new DataGridViewTextBoxColumn();
            newColumn.HeaderText = "Работник";
            newColumn.Name = "Работник";
            newColumn.Width = 130;
            newColumn.DisplayIndex = 3;
            dgvWorks.Columns.Add(newColumn);

            for(int i = 0; i < dgvWorks.RowCount; i++)
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

                //////////Имя работника
                if ((int)dgvWorks.Rows[i].Cells["StuffPK"].Value == -1)
                {
                    dgvWorks.Rows[i].Cells["Работник"].Value = "Не выбранно";

                    dgvWorks.Rows[i].Cells["Status"].Value = "ожидается механик";

                    strSQL = "SELECT * FROM TypeWorksSpares WHERE [TypeWorkPK]=" + dgvWorks.Rows[i].Cells["TypeWorkPK"].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    reader = SQLCommands.myCommand.ExecuteReader();
                    DataTable tableTypeWorksSpares = new DataTable();
                    tableTypeWorksSpares.Load(reader);

                    for (int j = 0; j < tableTypeWorksSpares.Rows.Count; j++)
                    {
                        strSQL = "SELECT * FROM Spares WHERE [SparePK]="+tableTypeWorksSpares.Rows[j].ItemArray[1];
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        reader = SQLCommands.myCommand.ExecuteReader();
                        DataTable tableSpares = new DataTable();
                        tableSpares.Load(reader);
                        if ((int)tableTypeWorksSpares.Rows[j].ItemArray[2] > (int)tableSpares.Rows[0].ItemArray[2])
                        {
                            dgvWorks.Rows[i].Cells["Status"].Value = "ожидаются запчасти";
                            break;
                        }
                    }

                    strSQL = "UPDATE Works SET [Status]='"+dgvWorks.Rows[i].Cells["Status"].Value+"' WHERE WorkPK = " + dgvWorks.Rows[i].Cells["WorkPK"].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();
                }
                else
                {
                    strSQL = "SELECT * FROM Stuff WHERE [StuffPK]=" + dgvWorks.Rows[i].Cells["StuffPK"].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    reader = SQLCommands.myCommand.ExecuteReader();
                    table = new DataTable();
                    table.Load(reader);
                    dgvWorks.Rows[i].Cells["Работник"].Value = table.Rows[0].ItemArray[1] + " " + table.Rows[0].ItemArray[2] + " " + table.Rows[0].ItemArray[3];
                }

                reader.Close();
            }          
        }

        private void buttonAddWork_Click(object sender, EventArgs e)
        {
            FormAddWork form = new FormAddWork();
            form.ShowDialog();
            buttonWorks_Click(sender, e);
        }

        private void buttonEditWork_Click(object sender, EventArgs e)
        {
            if (dgvWorks.SelectedRows.Count == 0) return;
            EditStatus form = new EditStatus((int)dgvWorks.SelectedRows[0].Cells["WorkPK"].Value);
            form.ShowDialog();
            buttonWorks_Click(sender, e);
        }

        private void buttonDeleteWork_Click(object sender, EventArgs e)
        {
            if (dgvWorks.SelectedRows.Count == 0) return;
            var result = MessageBox.Show("Вы действительно хотите удалить выбранную работу?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string strSQL = "DELETE FROM Works WHERE WorkPK=" + dgvWorks.SelectedRows[0].Cells["WorkPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.ExecuteNonQuery();
            }
            buttonWorks_Click(sender, e);
        }

        private void buttonInfoClient_Click(object sender, EventArgs e)
        {
            if (dgvWorks.SelectedRows.Count == 0) return;
            FormAddCustomer form = new FormAddCustomer();
            form.setCustomerPK((int)dgvWorks.SelectedRows[0].Cells["CustomerPK"].Value);
            form.hideButtons();
            form.Show();
        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            if (dgvWorks.SelectedRows.Count == 0) return;
            if ((int)dgvWorks.SelectedRows[0].Cells["StuffPK"].Value == -1)
            {
                MessageBox.Show("Этот заказ ещё не выбрал механик","Error");
                return;
            }
            FormAddInfo form = new FormAddInfo();
            form.setStuffPK((int)dgvWorks.SelectedRows[0].Cells["StuffPK"].Value);
            form.hideForm();
            form.ShowDialog();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            buttonWorks_Click(sender, e);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            string strSQL = "SELECT * FROM Cars WHERE TypeName = '" + cbCateg.Text + "'";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            tableCars = new DataTable();
            tableCars.Load(reader);
            dataGridView1.DataSource = tableCars;

            strSQL = "SELECT * FROM CarModel";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            reader = SQLCommands.myCommand.ExecuteReader();
            DataTable tableModels = new DataTable();
            tableModels.Load(reader);


            strSQL = "SELECT * FROM CarBrand";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            reader = SQLCommands.myCommand.ExecuteReader();
            DataTable tableBrand = new DataTable();
            tableBrand.Load(reader);
            reader.Close();

            DataGridViewTextBoxColumn ColumnBrand = new DataGridViewTextBoxColumn();
            ColumnBrand.HeaderText = "Марка";
            ColumnBrand.Name = "Марка";
            ColumnBrand.DisplayIndex = 0;
            dataGridView1.Columns.Add(ColumnBrand);

            DataGridViewTextBoxColumn ColumnModel = new DataGridViewTextBoxColumn();
            ColumnModel.HeaderText = "Модель";
            ColumnModel.Name = "Модель";
            ColumnModel.DisplayIndex = 1;
            dataGridView1.Columns.Add(ColumnModel);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["Марка"].Value = Convert.ToString(tableBrand.Select("CarBrandPK=" + dataGridView1.Rows[i].Cells["CarBrandPK"].Value)[0].ItemArray[1].ToString());
                dataGridView1.Rows[i].Cells["Модель"].Value = Convert.ToString(tableModels.Select("CarModelPK=" + dataGridView1.Rows[i].Cells["CarModelPK"].Value)[0].ItemArray[2].ToString());
            }

            dataGridView1.Columns["CarPK"].Visible = false;
            dataGridView1.Columns["TypeName"].Visible = false;
            
            dataGridView1.Columns["CustomerPK"].Visible = false;
            dataGridView1.Columns["CarBrandPK"].Visible = false;
            dataGridView1.Columns["CarModelPK"].Visible = false;
            dataGridView1.Columns["DateOfRelease"].HeaderText = "Год выпуска";
            dataGridView1.Columns["Modification"].HeaderText = "Модификация";
            dataGridView1.Columns["TypeMotor"].HeaderText = "Тип двигателя";
            dataGridView1.Columns["ModelMotor"].HeaderText = "Модель двигателя";
            dataGridView1.Columns["VIN"].HeaderText = "ВИН";
            dataGridView1.Columns["EngineNumber"].HeaderText = "Номер двигателя";
            dataGridView1.Columns["Chassis"].HeaderText = "Шасси";
            dataGridView1.Columns["StateNumber"].HeaderText = "Гос.номер";
            dataGridView1.Columns["BodyNumber"].HeaderText = "Номер кузова";

            dataGridView1.CurrentCell = null;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (!dataGridView1.Rows[i].Cells["Марка"].Value.ToString().Contains(tbSearch.Text)
                    && !dataGridView1.Rows[i].Cells["Модель"].Value.ToString().Contains(tbSearch.Text))
                    dataGridView1.Rows[i].Visible = false;
            }
        }

        private void addCars_Click(object sender, EventArgs e)
        {
            FormCarInfo form = new FormCarInfo();
            form.ShowDialog();
            tbSearch_TextChanged(sender, e);
        }

        private void deleteCar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить выбранный автомобиль?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string strSQL = "DELETE FROM Cars WHERE CarPK = " +
                        dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();
                    tbSearch_TextChanged(sender, e);
                }
            }
        }

        private void editCar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //int carPK = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                //MessageBox.Show(table.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[0].ToString());
                int carPK = Convert.ToInt32(tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[0].ToString());
                //int carName = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString());
                int carName = Convert.ToInt32(tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[1].ToString());
                //MessageBox.Show(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[4].Value.ToString());
                //int model = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString());
                int model = Convert.ToInt32(tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[2].ToString());
                //int dateOfRelease = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[3].Value.ToString());
                int dateOfRelease = Convert.ToInt32(tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[3].ToString());
                //string modification = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[4].Value.ToString();
                string modification = tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[4].ToString();
                //string typeMotor = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[5].Value.ToString();
                string typeMotor = tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[5].ToString();
                //string modelMotor = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[6].Value.ToString();
                string modelMotor = tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[6].ToString();
                //string typeName = cbCateg.Text;
                string typeName = cbCateg.Text;
                //int CustomerPK = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[13].Value.ToString());
                int CustomerPK = Convert.ToInt32(tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[13].ToString());
                //string EngineNumber = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[7].Value.ToString();
                string EngineNumber = tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[7].ToString();
                //string Chassis = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[8].Value.ToString();
                string Chassis = tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[8].ToString();
                //string VIN = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[9].Value.ToString();
                string VIN = tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[9].ToString();
                //string StateNumber = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[10].Value.ToString();
                string StateNumber = tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[10].ToString();
                //string BodyNumber = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[11].Value.ToString();
                string BodyNumber = tableCars.Rows[dataGridView1.SelectedRows[0].Index].ItemArray[11].ToString();
                FormCarInfo form = new FormCarInfo();
                form.zapol(carPK, carName, model, dateOfRelease, modification, typeMotor, modelMotor, typeName, CustomerPK, EngineNumber, Chassis, VIN, StateNumber, BodyNumber);
                form.ShowDialog();
                tbSearch_TextChanged(sender, e);
            }
        }

        private void TypesCars_Click(object sender, EventArgs e)
        {
            splittersVisibleOff();
            panelTypeCars.Visible = true;
            refreshTvTypeCars();
        }

        void refreshTvTypeCars()
        {
            tvTypeCars.Nodes.Clear();
            DataTable tableCarBrand = new DataTable();
            {
                string strSQL = "SELECT * FROM CarBrand ";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableCarBrand.Load(reader);
                dataGridView1.DataSource = tableCarBrand;
                reader.Close();
            }
            DataTable tableCarModel = new DataTable();
            {
                string strSQL = "SELECT * FROM CarModel ";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableCarModel.Load(reader);
                dataGridView1.DataSource = tableCarModel;
                reader.Close();
            }
            for(int i = 0; i < tableCarBrand.Rows.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = tableCarBrand.Rows[i].ItemArray[1].ToString();
                node.Tag = new int[] { int.Parse(tableCarBrand.Rows[i].ItemArray[0].ToString()) };
                for (int j = 0; j < tableCarModel.Rows.Count; j++)
                {
                    if (int.Parse(tableCarBrand.Rows[i].ItemArray[0].ToString()) == int.Parse(tableCarModel.Rows[j].ItemArray[1].ToString()))
                        node.Nodes.Add(new TreeNode(tableCarModel.Rows[j].ItemArray[2].ToString()) { Tag = new int[] { int.Parse(tableCarModel.Rows[j].ItemArray[0].ToString()),
                            int.Parse(tableCarModel.Rows[j].ItemArray[1].ToString()) } });
                }
                tvTypeCars.Nodes.Add(node);
            }
            tvTypeCars.ExpandAll();
        }

        private void buttonAddBrand_Click(object sender, EventArgs e)
        {
            AddEditMark form = new AddEditMark();
            form.ShowDialog();
            refreshTvTypeCars();
        }

        private void editTypeCars_Click(object sender, EventArgs e)
        {
            if (tvTypeCars.SelectedNode == null)
            {
                MessageBox.Show("Выберите модель или марку", "Error");
                return;
            }
            if (((int[])tvTypeCars.SelectedNode.Tag).Length == 1)
            {
                AddEditMark form = new AddEditMark(((int[])tvTypeCars.SelectedNode.Tag)[0], tvTypeCars.SelectedNode.Text.ToString());
                form.ShowDialog();
                refreshTvTypeCars();
            }else
            {
                AddEditModel form = new AddEditModel(((int[])tvTypeCars.SelectedNode.Tag)[0], ((int[])tvTypeCars.SelectedNode.Tag)[1], tvTypeCars.SelectedNode.Text);
                form.ShowDialog();
                refreshTvTypeCars();
            }

        }

        private void addModel_Click(object sender, EventArgs e)
        {
            DataTable tableCarBrand = new DataTable();
                string strSQL = "SELECT * FROM CarBrand ";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableCarBrand.Load(reader);
                dataGridView1.DataSource = tableCarBrand;
                reader.Close();
            if (tableCarBrand.Rows.Count == 0)
                MessageBox.Show("Добавьте хотя бы одну марку автомобиля", "Error");
            else
            {
                AddEditModel form = new AddEditModel();
                form.ShowDialog();
            }
            refreshTvTypeCars();
        }

        private void buttonDeleteTypeCars_Click(object sender, EventArgs e)
        {
            if (tvTypeCars.SelectedNode == null)
            {
                MessageBox.Show("Выберите модель или марку", "Error");
                return;
            }
            if (((int[])tvTypeCars.SelectedNode.Tag).Length == 1)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить выбранную марку?\nБудут удалены все модели и автомобили связанные с данной маркой.", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string strSQL = "DELETE FROM CarBrand WHERE CarBrandPK=" + ((int[])tvTypeCars.SelectedNode.Tag)[0];
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();
                }
                else { return; }
            }else
            {
                var result = MessageBox.Show("Вы действительно хотите удалить выбранную модель?\nБудут удалены все автомобили связанные с данной моделью.", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string strSQL = "DELETE FROM CarModel WHERE CarModelPK=" + ((int[])tvTypeCars.SelectedNode.Tag)[0];
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();
                }
                else { return; }
            }
            refreshTvTypeCars();
        }

        private void buttonTypeCarsSpares_Click(object sender, EventArgs e)
        {
            if (tvTypeCars.SelectedNode == null || ((int[])tvTypeCars.SelectedNode.Tag).Length==1)
            {
                MessageBox.Show("Выберите модель", "Error");
                return;
            }else{

                string strSQL = "SELECT * FROM CarBrand WHERE CarBrandPK = " + ((int[])tvTypeCars.SelectedNode.Tag)[1];
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                DataTable tableCarBrand = new DataTable();
                tableCarBrand.Load(reader);

                FormSpares form = new FormSpares(tableCarBrand.Rows[0].ItemArray[1].ToString()+" "+tvTypeCars.SelectedNode.Text, ((int[])tvTypeCars.SelectedNode.Tag)[0]);
                form.ShowDialog();
            }
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            splittersVisibleOff();
            panelClient.Visible = true;
            cbParamSearchStuff.SelectedIndex = 0;
            tbClient_TextChanged(new object(), new EventArgs());
            if (dgvClient.Rows.Count > 0) dgvClient_CellClick(new object(),new DataGridViewCellEventArgs(0,0));
        }

        private void tbClient_TextChanged(object sender, EventArgs e)
        {
            string param = "";
            if (cbParamSearchStuff.SelectedIndex == 0)
                param = "LastName";
            if (cbParamSearchStuff.SelectedIndex == 1)
                param = "FirstName";
            if (cbParamSearchStuff.SelectedIndex == 2)
                param = "MiddleName";

            string strSQL = "SELECT * FROM Customers WHERE " + param + " LIKE '" + tbClient.Text + "%'";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            dgvClient.DataSource = dt;

            dgvClient.Columns["CustomerPK"].Visible = false;
            dgvClient.Columns["PassportSeries"].Visible = false;
            dgvClient.Columns["PassportNumber"].Visible = false;
            dgvClient.Columns["LastName"].HeaderText = "Фамилия";
            dgvClient.Columns["FirstName"].HeaderText = "Имя";
            dgvClient.Columns["MiddleName"].HeaderText = "Отчество";
            dgvClient.Columns["Gender"].HeaderText = "Пол";
            dgvClient.Columns["Gender"].Width = 50;
            dgvClient.Columns["Phone"].Width = 90;
            dgvClient.Columns["Address"].Width = 230;
            dgvClient.Columns["Phone"].HeaderText = "Телефон";
            dgvClient.Columns["Address"].HeaderText = "Адрес";

            if (dgvClient.Rows.Count > 0)
            {
                dgvClient.Rows[0].Cells[1].Selected = true;
                lblPassportSeries.ForeColor = Color.Black;
                lblPassportNumber.ForeColor = Color.Black;
                if(lblPassportSeries.Text == "Клиент не выбран!")
                    dgvClient_CellClick(new object(), new DataGridViewCellEventArgs(0, 0));
            }
            else
            {
                lblPassportSeries.ForeColor = Color.Red;
                lblPassportNumber.ForeColor = Color.Red;
                lblPassportSeries.Text = "Клиент не выбран!";
                lblPassportNumber.Text = "Клиент не выбран!";
            }
        }

        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblPassportSeries.Text = dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells["PassportSeries"].Value.ToString();
            lblPassportNumber.Text = dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells["PassportNumber"].Value.ToString();
        }

        private void btnAddCustomers_Click(object sender, EventArgs e)
        {
            FormAddCustomer form = new FormAddCustomer();
            form.ShowDialog();
            tbClient_TextChanged(new object(), new EventArgs());
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (dgvClient.Rows.Count > 0)
            {
                FormAddCustomer form = new FormAddCustomer();
                if (btnEditCustomer.Text != "Редактирование информации")
                {
                    form.hideButtons();
                }
                int CustomerPK = Convert.ToInt32(dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[0].Value);
                string lName = dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[1].Value.ToString();
                string fName = dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[2].Value.ToString();
                string mName = dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[3].Value.ToString();
                string gender = dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[4].Value.ToString();
                string phone = dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[5].Value.ToString();
                string address = dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[6].Value.ToString();
                int pSeries = Convert.ToInt32(dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[7].Value);
                int pNumber = Convert.ToInt32(dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[8].Value);
                form.zamen(CustomerPK, lName, fName, mName, gender, phone, address, pSeries, pNumber);
                form.ShowDialog();
                tbClient_TextChanged(sender, e);
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (lblPassportNumber.Text != "Клиент не выбран!")
            {
                var result = MessageBox.Show("Вы действительно хотите удалить выбранного клиента?\nБудут удалены все автомобили и работы,\nкоторые связаны с выбранным клиентом", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string strSQL = "DELETE FROM Customers WHERE CustomerPK = " +
                        dgvClient.Rows[dgvClient.CurrentCell.RowIndex].Cells[0].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();
                    tbClient_TextChanged(sender, e);

                    if (dgvClient.Rows.Count > 0)
                    {
                            dgvClient_CellClick(new object(), new DataGridViewCellEventArgs(0, 0));
                    }
                    else
                    {
                        lblPassportSeries.ForeColor = Color.Red;
                        lblPassportNumber.ForeColor = Color.Red;
                        lblPassportSeries.Text = "Клиент не выбран!";
                        lblPassportNumber.Text = "Клиент не выбран!";
                    }

                }
            }
        }

        private void staffButton_Click(object sender, EventArgs e)
        {
            splittersVisibleOff();
            panelStuff.Visible = true;
            cbStuff.SelectedIndex = 0;
            tbStuff_TextChanged(sender, e);
        }

        private void tbStuff_TextChanged(object sender, EventArgs e)
        {
            string param = "";
            if (cbStuff.SelectedIndex == 0)
                param = "LastName";
            if (cbStuff.SelectedIndex == 1)
                param = "FirstName";
            if (cbStuff.SelectedIndex == 2)
                param = "MiddleName";
            string strSQL = "SELECT * FROM Stuff WHERE " + param + " LIKE '" + tbStuff.Text + "%'";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            dgvStuff.DataSource = table;
            dgvStuff.Columns[0].Visible = false;
            dgvStuff.Columns[1].HeaderText = "Фамилия";
            dgvStuff.Columns[2].HeaderText = "Имя";
            dgvStuff.Columns[3].HeaderText = "Отчество";
            dgvStuff.Columns[4].HeaderText = "Пол";
            dgvStuff.Columns[5].HeaderText = "Телефон";

            dgvStuff.Columns[1].Width = 150;
            dgvStuff.Columns[2].Width = 150;
            dgvStuff.Columns[3].Width = 150;
        }

        private void btnAddStuff_Click(object sender, EventArgs e)
        {
            FormAddInfo form = new FormAddInfo();
            form.ShowDialog();
            tbStuff_TextChanged(sender, e);
        }

        private void btnEditStuff_Click(object sender, EventArgs e)
        {
            if (dgvStuff.SelectedRows.Count>0)
            {
                FormAddInfo form = new FormAddInfo();
                string lastName = dgvStuff.Rows[dgvStuff.SelectedRows[0].Index].Cells[1].Value.ToString();
                string firstName = dgvStuff.Rows[dgvStuff.SelectedRows[0].Index].Cells[2].Value.ToString();
                string middleName = dgvStuff.Rows[dgvStuff.SelectedRows[0].Index].Cells[3].Value.ToString();
                string gender = dgvStuff.Rows[dgvStuff.SelectedRows[0].Index].Cells[4].Value.ToString();
                string phone = dgvStuff.Rows[dgvStuff.SelectedRows[0].Index].Cells[5].Value.ToString();
                int stuffPK = Convert.ToInt32(dgvStuff.Rows[dgvStuff.SelectedRows[0].Index].Cells[0].Value);
                form.zapol(lastName, firstName, middleName, gender, phone, stuffPK);
                form.ShowDialog();
                tbStuff_TextChanged(sender, e);
            }
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            if (dgvStuff.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить выбранного сотрудника?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string strSQL = "DELETE FROM Stuff WHERE StuffPK = " +
                       dgvStuff.SelectedRows[0].Cells["StuffPK"].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();
                    

                    strSQL = "UPDATE Works SET [StuffPK]=-1 WHERE Status='выполняется' AND StuffPK = " + dgvStuff.SelectedRows[0].Cells["StuffPK"].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();

                    strSQL = "DELETE FROM Works WHERE Status='выполнено' AND StuffPK=" + dgvStuff.SelectedRows[0].Cells["StuffPK"].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();

                    tbStuff_TextChanged(sender, e);
                }
            }
        }

        List<int> massId;
        private void buttonTypeWorks_Click(object sender, EventArgs e)
        {
            cbTypeWorksCars.Items.Clear();
            splittersVisibleOff();
            panelTypeWorks.Visible = true;
            DataTable tableModel = new DataTable();
            {
                string strSQL = "SELECT * FROM CarModel";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableModel.Load(reader);
                reader.Close();
            }
            DataTable tableBrand = new DataTable();
            {
                string strSQL = "SELECT * FROM CarBrand";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableBrand.Load(reader);
                reader.Close();
            }
            massId = new List<int>();
            for (int i = 0; i < tableModel.Rows.Count; i++)
            {
                string name = "";
                for (int j = 0; j < tableBrand.Rows.Count; j++)
                    if ((int)tableBrand.Rows[j].ItemArray[0] == (int)tableModel.Rows[i].ItemArray[1])
                    {
                        name += tableBrand.Rows[j].ItemArray[1].ToString()+" ";
                        break;
                    }
                name += tableModel.Rows[i].ItemArray[2].ToString();
                cbTypeWorksCars.Items.Add(name);
                massId.Add(Convert.ToInt32(tableModel.Rows[i].ItemArray[0]));
            }
            cbTypeWorksCars.SelectedIndex = 0;     
            cbTypeWorksCars_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void cbTypeWorksCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tableTypeWorks = new DataTable();
            string strSQL = "SELECT * FROM TypeWorks WHERE CarModelPK="+massId[cbTypeWorksCars.SelectedIndex];
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            tableTypeWorks.Load(reader);
            reader.Close();
            dgvTypeWorks.DataSource = tableTypeWorks;
            dgvTypeWorks.Columns["TypeWorkPK"].Visible = false;
            dgvTypeWorks.Columns["CarModelPK"].Visible = false;
            dgvTypeWorks.Columns["TypeWorkName"].Width = 250;
            dgvTypeWorks.Columns["TypeWorkName"].HeaderText = "Название услуги";
            dgvTypeWorks.Columns["Price"].HeaderText = "Цена";
            if (dgvTypeWorks.RowCount > 0)
                dgvTypeWorks_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
            else {
                dgvTypeWorksSpares.CurrentCell = null;
                for (int i = 0; i < dgvTypeWorksSpares.Rows.Count; i++)
                    dgvTypeWorksSpares.Rows[i].Visible = false;
            }
        }

        private void dgvTypeWorks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTypeWorksSpares.Columns.Clear();
            DataTable tableTypeWorksSpares = new DataTable();
            {
                string strSQL = "SELECT * FROM TypeWorksSpares";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableTypeWorksSpares.Load(reader);
                reader.Close();
                dgvTypeWorksSpares.DataSource = tableTypeWorksSpares;
            }
            DataTable tableSpares = new DataTable();
            {
                string strSQL = "SELECT * FROM Spares";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableSpares.Load(reader);
                reader.Close();
            }

            dgvTypeWorksSpares.CurrentCell = null;
            dgvTypeWorksSpares.Columns["TypeWorkPK"].Visible = false;
            dgvTypeWorksSpares.Columns["SparePK"].Visible = false;
            dgvTypeWorksSpares.Columns["Count"].Width = 150;
            dgvTypeWorksSpares.Columns["Count"].HeaderText = "Колличество";

            DataGridViewTextBoxColumn ColumnModel = new DataGridViewTextBoxColumn();
            ColumnModel.HeaderText = "Название";
            ColumnModel.Name = "Название";
            ColumnModel.DisplayIndex = 0;
            ColumnModel.Width = 200;
            dgvTypeWorksSpares.Columns.Add(ColumnModel);

            for (int i = 0; i < dgvTypeWorksSpares.RowCount; i++)
                for (int j = 0; j < tableSpares.Rows.Count; j++)
                    if ((int)dgvTypeWorksSpares.Rows[i].Cells["SparePK"].Value == (int)tableSpares.Rows[j].ItemArray[0]) {
                        dgvTypeWorksSpares.Rows[i].Cells["Название"].Value = tableSpares.Rows[j].ItemArray[1].ToString();
                        break;
                     }

            for (int i = 0; i < dgvTypeWorksSpares.RowCount; i++)
                if ((int)dgvTypeWorks.SelectedRows[0].Cells["TypeWorkPK"].Value != (int)dgvTypeWorksSpares.Rows[i].Cells["TypeWorkPK"].Value)
                    dgvTypeWorksSpares.Rows[i].Visible = false;


        }

        private void buttonAddTypeWorks_Click(object sender, EventArgs e)
        {
            if (cbTypeWorksCars.Items.Count == 0) { MessageBox.Show("Добавьте хотя бы одну машину","Error");return; }
            AddEditTypeWorks form = new AddEditTypeWorks(cbTypeWorksCars.SelectedIndex);
            form.ShowDialog();
            cbTypeWorksCars_SelectedIndexChanged(sender, e);
        }

        private void buttonEditTypeWorks_Click(object sender, EventArgs e)
        {
            if (dgvTypeWorks.SelectedRows.Count == 0) { return; }
            AddEditTypeWorks form = new AddEditTypeWorks(cbTypeWorksCars.SelectedIndex,Convert.ToInt32(dgvTypeWorks.SelectedRows[0].Cells["TypeWorkPK"].Value),
                dgvTypeWorks.SelectedRows[0].Cells["TypeWorkName"].Value.ToString(), Convert.ToInt32(dgvTypeWorks.SelectedRows[0].Cells["Price"].Value));
            form.ShowDialog();
            cbTypeWorksCars_SelectedIndexChanged(sender, e);
        }

        private void buttonDeleteTypeWorks_Click(object sender, EventArgs e)
        {
            if (dgvTypeWorks.SelectedRows.Count == 0) { MessageBox.Show("Выберите услугу","Error");return; }
            var result = MessageBox.Show("Вы действительно хотите удалить выбранную услугу?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string strSQL = "DELETE FROM TypeWorks WHERE TypeWorkPK=" + (int)dgvTypeWorks.SelectedRows[0].Cells["TypeWorkPK"].Value;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.ExecuteNonQuery();
                cbTypeWorksCars_SelectedIndexChanged(sender, e);
            }
            else { return; }
        }

        private void buttonAddTypeWorksSpares_Click(object sender, EventArgs e)
        {
            if(dgvTypeWorks.SelectedRows.Count==0) { MessageBox.Show("Выберите услугу", "Error"); return; }
            AddTypeWorksSpares form = new AddTypeWorksSpares(massId[cbTypeWorksCars.SelectedIndex],(int)dgvTypeWorks.SelectedRows[0].Cells["TypeWorkPK"].Value);
            //if (form.massId.Count == 0) { MessageBox.Show("Все возможные запчасти уже добавлены", "Error"); return; }
            form.ShowDialog();
            dgvTypeWorks_CellClick(sender, new DataGridViewCellEventArgs(0,dgvTypeWorks.SelectedRows[0].Index));
        }

        private void buttonDeleteTypeWorksSpares_Click(object sender, EventArgs e)
        {
            if(dgvTypeWorksSpares.SelectedRows.Count==0) { MessageBox.Show("Выберите запчасть", "Error"); return; }
            string strSQL = "DELETE FROM TypeWorksSpares WHERE TypeWorkPK=" +
                        (int)dgvTypeWorksSpares.SelectedRows[0].Cells["TypeWorkPK"].Value +
                        " AND SparePK=" + (int)dgvTypeWorksSpares.SelectedRows[0].Cells["SparePK"].Value;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            SQLCommands.myCommand.ExecuteNonQuery();
            dgvTypeWorks_CellClick(sender, new DataGridViewCellEventArgs(0, dgvTypeWorks.SelectedRows[0].Index));
        }

        private void buttonTypeWorksSparesPlus_Click(object sender, EventArgs e)
        {
            if (dgvTypeWorksSpares.SelectedRows.Count == 0) return;
            int index = dgvTypeWorksSpares.SelectedRows[0].Index;
            if (dgvTypeWorksSpares.SelectedRows.Count == 0) { MessageBox.Show("Выберите запчасть", "Error"); return; }
            string strSQL = "UPDATE TypeWorksSpares SET [Count]="+ (((int)dgvTypeWorksSpares.SelectedRows[0].Cells["Count"].Value)+1) +
                        " WHERE [TypeWorkPK]=" + dgvTypeWorksSpares.SelectedRows[0].Cells["TypeWorkPK"].Value.ToString() +" AND [SparePK]="+ dgvTypeWorksSpares.SelectedRows[0].Cells["SparePK"].Value.ToString();
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            SQLCommands.myCommand.ExecuteNonQuery();
            dgvTypeWorks_CellClick(sender, new DataGridViewCellEventArgs(0, dgvTypeWorks.SelectedRows[0].Index));
            dgvTypeWorksSpares.Rows[index].Selected = true;
        }

        private void buttonTypeWorksSparesMinus_Click(object sender, EventArgs e)
        {
            if (dgvTypeWorksSpares.SelectedRows.Count == 0) return;
            int index = dgvTypeWorksSpares.SelectedRows[0].Index;
            if (dgvTypeWorksSpares.SelectedRows.Count == 0) { MessageBox.Show("Выберите запчасть", "Error"); return; }
            if ((int)dgvTypeWorksSpares.SelectedRows[0].Cells["Count"].Value == 1) return;
            string strSQL = "UPDATE TypeWorksSpares SET [Count]=" + (((int)dgvTypeWorksSpares.SelectedRows[0].Cells["Count"].Value) - 1) +
                        " WHERE [TypeWorkPK]=" + dgvTypeWorksSpares.SelectedRows[0].Cells["TypeWorkPK"].Value.ToString() + " AND [SparePK]=" + dgvTypeWorksSpares.SelectedRows[0].Cells["SparePK"].Value.ToString();
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            SQLCommands.myCommand.ExecuteNonQuery();
            dgvTypeWorks_CellClick(sender, new DataGridViewCellEventArgs(0, dgvTypeWorks.SelectedRows[0].Index));
            dgvTypeWorksSpares.Rows[index].Selected = true;
        }

        private void buttonTicket_Click(object sender, EventArgs e)
        {
            if (dgvWorks.SelectedRows.Count == 0) return;

            string fileName = "result.pdf";
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document,
             new FileStream(fileName, FileMode.Create));
            document.Open();

            BaseFont baseFont = BaseFont.CreateFont("arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Заказ-наряд №" + dgvWorks.SelectedRows[0].Cells["WorkPK"].Value
                + " от " + ((DateTime)dgvWorks.SelectedRows[0].Cells["DateBegin"].Value).ToString("dd.MM.yyyy"), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 20 }));
            cell.PaddingBottom = 5;
            cell.BorderWidth = 0;
            cell.BorderWidthBottom = 2;
            table.AddCell(cell);
            document.Add(table);

            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" ", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 20 }));
            cell.Border = 0;
            table.AddCell(cell);
            document.Add(table);

            table = new PdfPTable(2);
            table.WidthPercentage = 100;
            float[] widths = new float[] { 1.2f, 5f }; 
            table.SetWidths(widths);
            cell = new PdfPCell(new Phrase("Исполнитель:", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 14 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase(dgvWorks.SelectedRows[0].Cells["Работник"].Value.ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 14 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Заказчик:", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 14 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase(dgvWorks.SelectedRows[0].Cells["Клиент"].Value.ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 14 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);
            document.Add(table);

            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" ", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 20 }));
            cell.Border = 0;
            table.AddCell(cell);
            document.Add(table);


            string strSQL = "SELECT * FROM Cars WHERE [CarPK]=" + dgvWorks.SelectedRows[0].Cells["CarPK"].Value;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            DataTable tableCar = new DataTable();
            tableCar.Load(reader);


            table = new PdfPTable(4);
            table.WidthPercentage = 100;
            widths = new float[] { 0.5f,0.5f,1f,1f };
            table.SetWidths(widths);
            cell = new PdfPCell(new Phrase("Модель", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase(dgvWorks.SelectedRows[0].Cells["Автомобиль"].Value.ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Двигатель №", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase(tableCar.Rows[0].ItemArray[7].ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Гос №", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase(tableCar.Rows[0].ItemArray[10].ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Кузов №", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase(tableCar.Rows[0].ItemArray[11].ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("VIN", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase(tableCar.Rows[0].ItemArray[9].ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Год выпуска", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase(tableCar.Rows[0].ItemArray[3].ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Модель двигателя", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase(tableCar.Rows[0].ItemArray[4].ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = 0;
            table.AddCell(cell);
            cell.Phrase = new Phrase("", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 });
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cell);

            document.Add(table);


            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" ", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 20 }));
            cell.Border = 0;
            table.AddCell(cell);
            document.Add(table);



            strSQL = "SELECT * FROM TypeWorks WHERE [TypeWorkPK]=" + dgvWorks.SelectedRows[0].Cells["TypeWorkPK"].Value;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            reader = SQLCommands.myCommand.ExecuteReader();
            DataTable tableTypeWork = new DataTable();
            tableTypeWork.Load(reader);



            table = new PdfPTable(3);
            table.WidthPercentage = 100;
            widths = new float[] { 1f,3f,1f };
            table.SetWidths(widths);
            cell = new PdfPCell(new Phrase("Работа №", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Наименование", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase("Сумма", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(dgvWorks.SelectedRows[0].Cells["TypeWorkPK"].Value.ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));           
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(tableTypeWork.Rows[0].ItemArray[1].ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            table.AddCell(cell);
            cell = new PdfPCell(new Phrase(tableTypeWork.Rows[0].ItemArray[3].ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            document.Add(table);

            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" ", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 20 }));
            cell.Border = 0;
            table.AddCell(cell);
            document.Add(table);


            strSQL = "SELECT * FROM TypeWorksSpares WHERE [TypeWorkPK]=" + dgvWorks.SelectedRows[0].Cells["TypeWorkPK"].Value;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            reader = SQLCommands.myCommand.ExecuteReader();
            DataTable tableTypeWorkSpares = new DataTable();
            tableTypeWorkSpares.Load(reader);

            int price = 0;

            if (tableTypeWorkSpares.Rows.Count > 0)
            {
                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(new Phrase("Перечень замененных запчастей", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.Border = 0;
                table.AddCell(cell);
                document.Add(table);

                table = new PdfPTable(6);
                table.WidthPercentage = 100;
                widths = new float[] { 1f, 1f, 3f, 1f,1f,1f };
                table.SetWidths(widths);
                cell = new PdfPCell(new Phrase("№", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Код", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Наименование", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Количество", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Цена", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Сумма", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                for(int i = 0; i < tableTypeWorkSpares.Rows.Count; i++)
                {
                    strSQL = "SELECT * FROM Spares WHERE [SparePK]=" + tableTypeWorkSpares.Rows[i].ItemArray[1];
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    reader = SQLCommands.myCommand.ExecuteReader();
                    DataTable tableSpares = new DataTable();
                    tableSpares.Load(reader);

                    cell = new PdfPCell(new Phrase((i+1).ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(tableTypeWorkSpares.Rows[i].ItemArray[1].ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(tableSpares.Rows[0].ItemArray[1].ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(tableTypeWorkSpares.Rows[i].ItemArray[2].ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(tableSpares.Rows[0].ItemArray[3].ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase((int.Parse(tableSpares.Rows[0].ItemArray[3].ToString())*int.Parse(tableTypeWorkSpares.Rows[i].ItemArray[2].ToString())).ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);

                    price += (int.Parse(tableSpares.Rows[0].ItemArray[3].ToString()) * int.Parse(tableTypeWorkSpares.Rows[i].ItemArray[2].ToString()));
                }
                document.Add(table);


                table = new PdfPTable(2);
                table.WidthPercentage = 100;
                widths = new float[] { 7f, 1f };
                table.SetWidths(widths);

                cell = new PdfPCell(new Phrase("Сумма:", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                cell.BorderWidthBottom = 0;
                cell.BorderWidthLeft = 0;
                table.AddCell(cell);

                cell = new PdfPCell(new Phrase(price.ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);

                document.Add(table);

                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(new Phrase(" ", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 20 }));
                cell.Border = 0;
                table.AddCell(cell);
                document.Add(table);
            }

            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase("Расчет стоимости", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.Border = 0;
            table.AddCell(cell);
            document.Add(table);

            table = new PdfPTable(2);
            table.WidthPercentage = 100;
            widths = new float[] { 7f, 1f };
            table.SetWidths(widths);

            cell = new PdfPCell(new Phrase("Наименование", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("К оплате", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Работа", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(tableTypeWork.Rows[0].ItemArray[3].ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Запчасти", new
               iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(price.ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Итого:", new
               iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.BorderWidthBottom = 0;
            cell.BorderWidthLeft = 0;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase((price+int.Parse(tableTypeWork.Rows[0].ItemArray[3].ToString())).ToString(), new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);

            document.Add(table);

            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" ", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 20 }));
            cell.Border = 0;
            cell.BorderWidthBottom = 2;
            table.AddCell(cell);
            document.Add(table);

            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" ", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 20 }));
            cell.Border = 0;
            table.AddCell(cell);
            document.Add(table);

            table = new PdfPTable(2);
            table.WidthPercentage = 100;
            widths = new float[] { 1f, 1f };
            table.SetWidths(widths);

            cell = new PdfPCell(new Phrase("Исполнитель  ________________________________", new
               iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.BorderWidth = 0;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase("Заказчик  ________________________________", new
               iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
            { Size = 10 }));
            cell.BorderWidth = 0;
            table.AddCell(cell);

            document.Add(table);

            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            cell = new PdfPCell(new Phrase(" ", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 50 }));
            cell.Border = 0;
            table.AddCell(cell);
            table.AddCell(cell);
            document.Add(table);

            Bitmap bitmap = new Bitmap(Properties.Resources.imgonline,520,100);

            iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);

            document.Add(pic);

            document.Close();
            writer.Close();
            System.Diagnostics.Process.Start(fileName);
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            FormChange form = new FormChange();
            form.ShowDialog();
        }

        private void buttonLoadDB_MouseMove(object sender, MouseEventArgs e)
        {
            //ToolTip t = new ToolTip();
            //t.SetToolTip(buttonLoadDB, "Загрузить резервную копию базы данных");
        }

        private void buttonChange_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(buttonChange, "Изменить пароль");
        }

        private void buttonSaveDB_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(buttonSaveDB, "Создать резервную копию базы данных");
        }

        private void buttonLoadDB_MouseHover(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(buttonLoadDB, "Загрузить резервную копию базы данных");
        }

        private void buttonSaveDB_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")+".mdb";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if(saveFileDialog.FileName.Substring(saveFileDialog.FileName.Length-4)!=".mdb")
                File.Copy("CarService.mdb", saveFileDialog.FileName+".mdb");
                else File.Copy("CarService.mdb", saveFileDialog.FileName);
            }
        }

        private void buttonLoadDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4) == ".mdb")
                {
                    SQLCommands.CloseConnection();
                    File.Delete("CarService.mdb");
                    File.Copy(openFileDialog1.FileName,"CarService.mdb");
                    SQLCommands.OpenConnection();
                    buttonWorks_Click(sender, e);
                }else
                {
                    MessageBox.Show("Файл не является базой данных");
                    buttonLoadDB_Click(sender, e);
                }
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Help.chm");
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            buttonWorks_Click(sender, e);
            FormReport form = new FormReport();
            form.ShowDialog();
        }
    }
}
