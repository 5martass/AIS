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
    public partial class AddEditModel : Form
    {
        int id = -1;
        DataTable tableMark;  
        public AddEditModel()
        {
            InitializeComponent();
            string strSQL = "SELECT * FROM CarBrand ";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            tableMark = new DataTable();
            tableMark.Load(reader);
            reader.Close();
            for (int i = 0; i < tableMark.Rows.Count; i++)
                comboBox1.Items.Add(tableMark.Rows[i].ItemArray[1].ToString());
            comboBox1.SelectedIndex = 0;
            button1.Text = "Добавить";
        }

        public AddEditModel(int id,int idMark,string Name)
        {
            InitializeComponent();
            this.id = id;
            string strSQL = "SELECT * FROM CarBrand ";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            tableMark = new DataTable();
            tableMark.Load(reader);
            reader.Close();
            for (int i = 0; i < tableMark.Rows.Count; i++)
            {
                comboBox1.Items.Add(tableMark.Rows[i].ItemArray[1].ToString());
                if (int.Parse(tableMark.Rows[i].ItemArray[0].ToString()) == idMark)
                    comboBox1.SelectedIndex = i;
            }
            textBox1.Text = Name; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSQL = "";
            if (id == -1) {
                strSQL = "INSERT INTO CarModel(CarBrand,Name) " +
                        "VALUES ("+tableMark.Rows[comboBox1.SelectedIndex].ItemArray[0].ToString()+",'"+textBox1.Text+"')";
            }
            else
            {
                strSQL = "UPDATE CarModel SET CarBrand="+tableMark.Rows[comboBox1.SelectedIndex].ItemArray[0].ToString()+",Name='" + textBox1.Text +
                    "' WHERE CarModelPK = " + id;
            }
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            SQLCommands.myCommand.ExecuteNonQuery();
            this.Close();
        }
    }
}
