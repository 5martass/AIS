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
    public partial class AddTypeWorksSpares : Form
    {
        int idTypeWork;
        int idCar;
        public AddTypeWorksSpares(int idCar,int idTypeWork)
        {
            InitializeComponent();
            this.idTypeWork = idTypeWork;
            this.idCar = idCar;

            DataTable tableTypeSpares = new DataTable();
            {
                string strSQL = "SELECT * FROM TypeSpares";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableTypeSpares.Load(reader);
                reader.Close();
            }
            for (int i = 0; i < tableTypeSpares.Rows.Count; i++)
                cbCateg.Items.Add(tableTypeSpares.Rows[i].ItemArray[0]);

            cbCateg.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
           string strSQL = "INSERT INTO TypeWorksSpares ([TypeWorkPK], [SparePK], [Count]) " +
                        "VALUES ("+ idTypeWork+","+dgv.SelectedRows[0].Cells["SparePK"].Value+","+numericUpDown1.Value+")";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            SQLCommands.myCommand.ExecuteNonQuery();
            Close();
        }

        private void cbCateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv.Columns.Clear();
            DataTable tableSpares = new DataTable();
            {
                string strSQL = "SELECT * FROM Spares WHERE [CarModelPK]=" + idCar+" AND [TypeSpareName]='"+cbCateg.Text+"'";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableSpares.Load(reader);
                dgv.DataSource = tableSpares;
                reader.Close();
            }
            DataTable tableTypeWorksSpares = new DataTable();
            {
                string strSQL = "SELECT * FROM TypeWorksSpares WHERE TypeWorkPK=" + idTypeWork;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableTypeWorksSpares.Load(reader);
                reader.Close();
            }
            dgv.CurrentCell = null;
            for (int i = 0; i < dgv.RowCount; i++)
                for (int j = 0; j < tableTypeWorksSpares.Rows.Count; j++)
                    if (int.Parse(dgv.Rows[i].Cells["SparePK"].Value.ToString()) ==
                        int.Parse(tableTypeWorksSpares.Rows[j].ItemArray[1].ToString()))
                        dgv.Rows[i].Visible = false;
            dgv.Columns["SparePK"].Visible = false;
            dgv.Columns["SpareName"].HeaderText = "Название";
            dgv.Columns["SpareName"].Width = 200;
            dgv.Columns["Count"].Visible = false;
            dgv.Columns["Price"].HeaderText = "Цена";
            dgv.Columns["Price"].Width = 150;
            dgv.Columns["CarModelPK"].Visible = false;
            dgv.Columns["TypeSpareName"].Visible = false;
        }

        private void AddTypeWorksSpares_Load(object sender, EventArgs e)
        {
            cbCateg_SelectedIndexChanged(sender, e);
        }
    }
}
