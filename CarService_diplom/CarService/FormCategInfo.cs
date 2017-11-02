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
    public partial class FormCategInfo : Form
    {
        public FormCategInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string typeSpareName = "";
        public void zapol(string typeSpareName)
        {
            this.typeSpareName = typeSpareName;
            lblSparesFor.Text = "Редактирование названия категории\n[" + typeSpareName + "]";
            btnAddCateg.Text = "Изменить";
        }
        private void btnAddCateg_Click(object sender, EventArgs e)
        {
            if (tbCategName.TextLength > 0)
            {
                string strSQL = "SELECT * FROM TypeSpares WHERE TypeSpareName = '" + tbCategName.Text + "'";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                object value = SQLCommands.myCommand.ExecuteScalar();
                if (value == null)
                {
                    if (btnAddCateg.Text == "Добавить")
                    {
                        strSQL = "INSERT INTO TypeSpares (TypeSpareName) VALUES (@TypeSpareName)";
                    }
                    else
                    {
                        strSQL = "UPDATE TypeSpares SET TypeSpareName = @TypeSpareName WHERE TypeSpareName = '" + 
                            typeSpareName + "'";
                    }
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    SQLCommands.myCommand.Parameters.AddWithValue("@TypeSpareName", tbCategName.Text);
                    SQLCommands.myCommand.ExecuteNonQuery();
                    Close();
                }
                else
                {
                    MessageBox.Show("Категория с таким названием уже существует", "Внимание", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } 
            else
            {
                MessageBox.Show("Введите название категории", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
