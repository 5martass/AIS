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
    public partial class FormChange : Form
    {
        public FormChange()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if ((tbOldPass.TextLength > 0) && (tbNewPass.TextLength > 0) && (tbPassAgain.TextLength > 0))
            {
                if (tbNewPass.Text == tbPassAgain.Text)
                {
                    int access = cbParam.SelectedIndex + 1;
                    string strSQL = "SELECT Password FROM Access WHERE AccessName = " + access;
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    object value = SQLCommands.myCommand.ExecuteScalar();
                    if (Convert.ToString(value) == tbOldPass.Text)
                    {
                        strSQL = "UPDATE Access SET [Password] = '" + tbNewPass.Text + "' WHERE AccessName = " + access;
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        SQLCommands.myCommand.ExecuteNonQuery();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Старый пароль введен неверно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } 
                else
                {
                    MessageBox.Show("Пароли не сходятся", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            } 
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormChange_Load(object sender, EventArgs e)
        {
            cbParam.SelectedIndex = 0;
        }
    }
}
