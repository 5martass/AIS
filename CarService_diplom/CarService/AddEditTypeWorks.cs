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
    public partial class AddEditTypeWorks : Form
    {
        List<int> massId;
        int id = -1;
        public AddEditTypeWorks(int index)
        {
            InitializeComponent();
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
                        name += tableBrand.Rows[j].ItemArray[1].ToString() + " ";
                        break;
                    }
                name += tableModel.Rows[i].ItemArray[2].ToString();
                comboBox1.Items.Add(name);
                massId.Add(Convert.ToInt32(tableModel.Rows[i].ItemArray[0]));
            }
            comboBox1.SelectedIndex = index;
            numericUpDown1.Value = 100;
        }
        public AddEditTypeWorks(int index,int id,string name,int price)
        {
            InitializeComponent();
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
                string nname = "";
                for (int j = 0; j < tableBrand.Rows.Count; j++)
                    if ((int)tableBrand.Rows[j].ItemArray[0] == (int)tableModel.Rows[i].ItemArray[1])
                    {
                        nname += tableBrand.Rows[j].ItemArray[1].ToString() + " ";
                        break;
                    }
                nname += tableModel.Rows[i].ItemArray[2].ToString();
                comboBox1.Items.Add(nname);
                massId.Add(Convert.ToInt32(tableModel.Rows[i].ItemArray[0]));
            }
            comboBox1.SelectedIndex = index;
            textBox1.Text = name;
            this.id = id;
            numericUpDown1.Value = price;
            button1.Text = "Изменить";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) { MessageBox.Show("Заполните все поля", "Error");return; }
            if (id == -1)
            {
                string strSQL= "INSERT INTO TypeWorks (TypeWorkName,CarModelPK,Price) " +
                        "VALUES ('"+textBox1.Text+"',"+massId[comboBox1.SelectedIndex]+","+numericUpDown1.Value+")";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.ExecuteNonQuery();
            }
            else
            {
                string strSQL = "UPDATE TypeWorks SET TypeWorkName='" + textBox1.Text + "',CarModelPK=" + massId[comboBox1.SelectedIndex] +
                    ",Price=" + numericUpDown1.Value + " WHERE TypeWorkPK=" + id;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.ExecuteNonQuery();
            }
            this.Close();
        }
    }
}
