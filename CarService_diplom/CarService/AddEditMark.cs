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
    public partial class AddEditMark : Form
    {
        int id = -1;
        public AddEditMark()
        {
            InitializeComponent();
            button1.Text = "Добавить";
        }

        public AddEditMark(int id,string name)
        {
            InitializeComponent();
            this.id = id;
            textBox1.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strSQL="";
            if (textBox1.Text.Length > 0) {
                if (id == -1)
                {
                    strSQL = "INSERT INTO CarBrand (Name) " +
                        "VALUES ('"+textBox1.Text+"')";
                }
                else {
                    strSQL = "UPDATE CarBrand SET Name='"+ textBox1.Text +
                        "' WHERE CarBrandPK = " + id;
                }
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.ExecuteNonQuery();
                this.Close();
            }
            else { MessageBox.Show("Заполните поле", "Error"); }
        }

        private void AddEditMark_Load(object sender, EventArgs e)
        {

        }
    }
}
