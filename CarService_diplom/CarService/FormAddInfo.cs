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
    public partial class FormAddInfo : Form
    {
        public FormAddInfo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        int stuffPK;
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if ((tbFirstName.TextLength > 0) && (tbLastName.TextLength > 0) && (tbMiddleName.TextLength > 0)
                && (cbGender.SelectedIndex >= 0))
            {
                string strSQL = "";
                if (btnEnter.Text != "Изменить")
                {
                    strSQL = "INSERT INTO Stuff (LastName, FirstName, MiddleName, Gender, Phone) " +
                        "VALUES (@LastName, @FirstName, @MiddleName, @Gender, @Phone)";
                }
                else
                {
                    strSQL = "UPDATE Stuff SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, " + 
                        "Gender = @Gender, Phone = @Phone WHERE StuffPK = " + stuffPK;
                }
                
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.Parameters.AddWithValue("@LastName", tbLastName.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@MiddleName", tbMiddleName.Text);
                string gender = Convert.ToString(cbGender.Text[0]).ToUpper();
                SQLCommands.myCommand.Parameters.AddWithValue("@Gender", gender);
                SQLCommands.myCommand.Parameters.AddWithValue("@Phone", tbPhone.Text);
                SQLCommands.myCommand.ExecuteNonQuery();
                Close();
            } 
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void zapol(string lastName, string firstName, string middleName, string gedner, string phone, int stuffPK)
        {
            tbLastName.Text = lastName;
            tbFirstName.Text = firstName;
            tbMiddleName.Text = middleName;
            tbPhone.Text = phone;
            if (gedner == "М")
            {
                cbGender.SelectedIndex = 0;
            } 
            else
            {
                cbGender.SelectedIndex = 1;
            }
            label1.Text = "Редактирование информации о сотруднике";
            btnEnter.Text = "Изменить";
            this.stuffPK = stuffPK;
        }

        public void setStuffPK(int stuffPK)
        {
            string strSQL = "SELECT * FROM Stuff WHERE StuffPK = " + stuffPK;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            reader.Read();
            tbFirstName.Text = reader["FirstName"].ToString();
            tbLastName.Text = reader["LastName"].ToString();
            tbMiddleName.Text = reader["MiddleName"].ToString();
            tbPhone.Text = reader["Phone"].ToString();
            if (reader["Gender"].ToString() == "М")
            {
                cbGender.SelectedIndex = 0;
            }
            else
            {
                cbGender.SelectedIndex = 1;
            }
            label1.Text = "Редактирование информации о сотруднике";
            btnEnter.Text = "Изменить";
            reader.Close();
        }

        public void hideForm()
        {
            btnEnter.Visible = false;
            btnExit.Text = "ОК";
            btnExit.Location=new Point(btnExit.Location.X-70, btnExit.Location.Y);
            label1.Text = "Информация о сотруднике";
            cbGender.Enabled = false;
            tbFirstName.Enabled = false;
            tbLastName.Enabled = false;
            tbMiddleName.Enabled = false;
            tbPhone.Enabled = false;
        }

        private void FormAddInfo_Load(object sender, EventArgs e)
        {
            if (Data.access == 2)
            {
                btnEnter.Enabled = false;
            }
        }

        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            int position = ((TextBox)sender).SelectionStart;
            string buffer = ((TextBox)sender).Text;
            ((TextBox)sender).Text = new string(((TextBox)sender).Text.ToCharArray().Where(n => !char.IsDigit(n)).ToArray());
            if (buffer != ((TextBox)sender).Text)
                ((TextBox)sender).SelectionStart = position - 1;
        }

        private void tbFirstName_TextChanged(object sender, EventArgs e)
        {
            int position = ((TextBox)sender).SelectionStart;
            string buffer = ((TextBox)sender).Text;
            ((TextBox)sender).Text = new string(((TextBox)sender).Text.ToCharArray().Where(n => !char.IsDigit(n)).ToArray());
            if (buffer != ((TextBox)sender).Text)
                ((TextBox)sender).SelectionStart = position - 1;
        }

        private void tbMiddleName_TextChanged(object sender, EventArgs e)
        {
            int position = ((TextBox)sender).SelectionStart;
            string buffer = ((TextBox)sender).Text;
            ((TextBox)sender).Text = new string(((TextBox)sender).Text.ToCharArray().Where(n => !char.IsDigit(n)).ToArray());
            if (buffer != ((TextBox)sender).Text)
                ((TextBox)sender).SelectionStart = position - 1;
        }
    }
}
