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
    public partial class FormAddCustomer : Form
    {
        public FormAddCustomer()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbPassportSeries_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }
        int customerPK;
        public void zamen(int customerPK, string lName, string fName, string mName, string gender, string phone, string address, 
            int pSeries, int pNumber)
        {
            this.customerPK = customerPK;
            tbFirstName.Text = fName;
            tbLastName.Text = lName;
            tbMiddleName.Text = mName;
            if (gender == "М")
            {
                cbGender.SelectedIndex = 0;
            } 
            else
            {
                cbGender.SelectedIndex = 1;
            }
            tbPhone.Text = phone;
            tbAddress.Text = address;
            tbPassportSeries.Text = Convert.ToString(pSeries);
            tbPassportNumber.Text = Convert.ToString(pNumber);
            if (label1.Text != "Подробрная информация о клиенте")
                label1.Text = "Редактирование информации о клиенте";
            btnEnter.Text = "Изменить";
        }



        public void setCustomerPK(int customerPK)
        {
            this.customerPK = customerPK;
            string strSQL = "SELECT * FROM Customers WHERE CustomerPK = " + customerPK;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            reader.Read();
            tbAddress.Text = reader["Address"].ToString();
            tbFirstName.Text = reader["FirstName"].ToString();
            tbLastName.Text = reader["LastName"].ToString();
            tbMiddleName.Text = reader["MiddleName"].ToString();
            tbPassportNumber.Text = reader["PassportNumber"].ToString();
            tbPassportSeries.Text = reader["PassportSeries"].ToString();
            tbPhone.Text = reader["Phone"].ToString();
            if (reader["Gender"].ToString() == "М")
            {
                cbGender.SelectedIndex = 0;
            }
            else 
            {
                cbGender.SelectedIndex = 1;
            }
            if (label1.Text != "Подробрная информация о клиенте")
                label1.Text = "Редактирование информации о клиенте";
            btnEnter.Text = "Изменить";
            reader.Close();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if ((tbFirstName.TextLength > 0) && (tbLastName.TextLength > 0) && 
                (tbPassportNumber.TextLength > 0) && (tbPassportSeries.TextLength > 0) && (cbGender.SelectedIndex >= 0) &&
                (tbAddress.TextLength > 0)) 
            {
                string strSQL = "";
                if (btnEnter.Text == "Добавить")
                {
                    strSQL = "INSERT INTO Customers (LastName, FirstName, MiddleName, Gender, Phone, Address, " +
                        "PassportSeries, PassportNumber) VALUES (@LastName, @FirstName, @MiddleName, @Gender, @Phone, @Address, " +
                        "@PassportSeries, @PassportNumber)";
                }
                else
                {
                    strSQL = "UPDATE Customers SET LastName = @LastName, FirstName = @FirstName, MiddleName = @MiddleName, " + 
                        "Gender = @Gender, Phone = @Phone, Address = @Address, PassportSeries = @PassportSeries, " + 
                        "PassportNumber = @PassportNumber WHERE CustomerPK = " + customerPK;
                }
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.Parameters.AddWithValue("@LastName", tbLastName.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@FirstName", tbFirstName.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@MiddleName", tbMiddleName.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@Gender", cbGender.Text[0].ToString().ToUpper());
                SQLCommands.myCommand.Parameters.AddWithValue("@Phone", tbPhone.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@Address", tbAddress.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@PassportSeries", tbPassportSeries.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@PassportNumber", tbPassportNumber.Text);
                SQLCommands.myCommand.ExecuteNonQuery();
                Close();
            }
            else
            {
                MessageBox.Show("Все обязательные поля не заполнены.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void hideButtons()
        {
            tbAddress.Enabled = false;
            tbFirstName.Enabled = false;
            tbLastName.Enabled = false;
            tbMiddleName.Enabled = false;
            tbPassportNumber.Enabled = false;
            tbPassportSeries.Enabled = false;
            tbPhone.Enabled = false;
            cbGender.Enabled = false;
            btnEnter.Visible = false;
            btnExit.Text = "OK";
            btnExit.Left -= 60;
            label1.Text = "Подробрная информация о клиенте";
        }
        private void FormAddCustomer_Load(object sender, EventArgs e)
        {
            
        }

        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            int position = ((TextBox)sender).SelectionStart;
            string buffer = ((TextBox)sender).Text;
            ((TextBox)sender).Text=new string(((TextBox)sender).Text.ToCharArray().Where(n => !char.IsDigit(n)).ToArray());
            if(buffer!= ((TextBox)sender).Text)
            ((TextBox)sender).SelectionStart = position-1;
        }

        private void tbLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
           
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
