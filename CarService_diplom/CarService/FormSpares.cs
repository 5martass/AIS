using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarService
{
    public partial class FormSpares : Form
    {
        private int CarModelPK;
        public FormSpares(string name,int id)
        {
            InitializeComponent();
            lblSparesFor.Text = "Запчасти для " + name;
            CarModelPK = id;
            refreshCbCateg();
        }


        public void offVisible()
        {
            btnAddCateg.Visible = false;
            btnAddSpare.Visible = false;
            btnDeleteCateg.Visible = false;
            btnDeleteSpare.Visible = false;
            btnEditCar.Visible = false;
            btnEditCateg.Visible = false;
            btnMinus.Visible = false;
            btnPlus.Visible = false;
            buttonOK.Visible = true;
            cbCateg.Width = 400;
        } 

        void refreshCbCateg()
        {
            cbCateg.Items.Clear();
            string strSQL = "SELECT * FROM TypeSpares";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            while (reader.Read())
            {
                cbCateg.Items.Add(reader[0]);
            }
            reader.Close();
            cbCateg.SelectedIndex = 0;
        }

        private void btnDeleteCateg_Click(object sender, EventArgs e)
        {
            if (cbCateg.SelectedIndex >= 0)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить выбранную категорию?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string strSQL = "DELETE FROM TypeSpares WHERE TypeSpareName = '" + cbCateg.Text + "'";
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();
                    refreshCbCateg();
                }
            }
        }

        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            FormCategInfo form = new FormCategInfo();
            form.ShowDialog();
            refreshCbCateg();
        }

        private void btnEditCateg_Click(object sender, EventArgs e)
        {
            if (cbCateg.SelectedIndex >= 0)
            {
                FormCategInfo form = new FormCategInfo();
                form.zapol(cbCateg.Text);
                form.ShowDialog();
                refreshCbCateg();
            }
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            string spareName = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["SpareName"].Value.ToString();
            int count = Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Count"].Value);
            decimal price = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Price"].Value);
            int sparePK = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
            FormSpareInfo form = new FormSpareInfo();
            form.zapol(sparePK, CarModelPK, cbCateg.Text, spareName, count, price);
            form.ShowDialog();
            refreshCbCateg();
        }

        public void hideButtons()
        {
            btnAddCateg.Visible = false;
            btnDeleteCateg.Visible = false;
            btnEditCateg.Visible = false;
            dataGridView1.Top = 140;
            dataGridView1.Height = 390;
        }

        private void cbCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM Spares WHERE TypeSpareName = '" + cbCateg.Text + "' AND CarModelPK = " + CarModelPK;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["SparePK"].Visible = false;
            dataGridView1.Columns["CarModelPK"].Visible = false;
            dataGridView1.Columns["TypeSpareName"].Visible = false;
            dataGridView1.Columns["SpareName"].HeaderText = "Наименование";
            dataGridView1.Columns["Count"].HeaderText = "Количество";
            dataGridView1.Columns["Price"].HeaderText = "Цена";
            dataGridView1.Columns["SpareName"].Width = 250;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Cells[1].Selected = true;
            }
        }

        private void btnDeleteSpare_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                var result = MessageBox.Show("Вы действительно хотите удалить выбранную запчасть?", "Подтверждение", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string strSQL = "DELETE FROM Spares WHERE SparePK = " + 
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.ExecuteNonQuery();
                    cbCateg_SelectedIndexChanged(sender, e);
                }
            }
        }

        private void btnAddSpare_Click(object sender, EventArgs e)
        {
            FormSpareInfo form = new FormSpareInfo();
            form.zapol(cbCateg.Text, CarModelPK);
            form.ShowDialog();
            cbCateg_SelectedIndexChanged(sender, e);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            string strSQL = "UPDATE Spares SET [Count] = ([Count] + 1) WHERE SparePK = " +
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            SQLCommands.myCommand.ExecuteNonQuery();
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Count"].Value =
                Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Count"].Value) + 1;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            string strSQL = "UPDATE Spares SET [Count] = ([Count] - 1) WHERE SparePK = " +
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            SQLCommands.myCommand.ExecuteNonQuery();
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Count"].Value =
                Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Count"].Value) - 1;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
