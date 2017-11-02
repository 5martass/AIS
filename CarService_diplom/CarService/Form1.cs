using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CarService
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            KeyPreview = true;
            AcceptButton = btnEnter;
        }

        void refreshMechanic()
        {
            string strSQL = "SELECT StuffPK, (LastName + ' ' + FirstName + ' ' + MiddleName + ' [+7' + Phone + ']') AS FIO " +
            " FROM Stuff";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            cbAccountMc.DataSource = dt;
            cbAccountMc.ValueMember = "StuffPK";
            cbAccountMc.DisplayMember = "FIO";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if ((cbAccount.SelectedIndex >= 0) && (tbPassword.TextLength > 0))
            {
                string strSQL = "SELECT AccessName FROM Access WHERE AccessName = " + (cbAccount.SelectedIndex + 1) + 
                    " AND Password = '" + tbPassword.Text +  "'";
                SQLCommands.myCommand = new OleDbCommand(strSQL, SQLCommands.cn);
                object value = SQLCommands.myCommand.ExecuteScalar();
                if (value == null)
                {
                    MessageBox.Show("Пароль введен неверно. Повторите ввод.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tbPassword.Clear();
                    Data.access = Convert.ToByte(cbAccount.SelectedIndex + 1);
                    if (Data.access == 1)
                    {
                        AdminForm form = new AdminForm();
                        Hide();
                        form.ShowDialog();
                        Visible = true;
                        refreshMechanic();
                        
                    }
                    if (Data.access == 2)
                    {
                        ManagerForm form = new ManagerForm();
                        Hide();
                        form.ShowDialog();
                        Visible = true;
                        refreshMechanic();

                    }
                    if (Data.access == 3)
                    {
                        FormMechanic form = new FormMechanic(cbAccountMc.SelectedValue.ToString());
                        Hide();
                        form.ShowDialog();
                        Visible = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите свою учетную запись и введите пароль", 
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbAccount.SelectedIndex = 0;
            try
            {
                SQLCommands.OpenConnection();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.Filter = "All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;



                var result = MessageBox.Show("Желаете загрузить резервную копию?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    do
                    {
                        if (openFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            if (openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4) == ".mdb")
                            {
                                SQLCommands.CloseConnection();
                                File.Delete("CarService.mdb");
                                File.Copy(openFileDialog1.FileName, "CarService.mdb");
                                SQLCommands.OpenConnection();
                            }
                            else
                            {
                                MessageBox.Show("Файл не является базой данных");
                            }
                        }
                        else
                        {
                            Close();
                        }
                    } while (openFileDialog1.FileName.Substring(openFileDialog1.FileName.Length - 4) != ".mdb");
                }else
                {
                    Close();
                }

            }
            refreshMechanic();
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAccount.SelectedIndex == 2)
            {
                if (cbAccountMc.Items.Count == 0)
                {
                    MessageBox.Show("Список механиков пуст", "Error");
                    cbAccount.SelectedIndex = 0;
                    return;
                }
                label5.Visible = true;
                cbAccountMc.Visible = true;
            }
            else {
                label5.Visible = false;
                cbAccountMc.Visible = false;
            }
        }


    }
    public abstract class SQLCommands
    {
        public static OleDbConnection cn = new OleDbConnection();
        public static OleDbConnectionStringBuilder connect = new OleDbConnectionStringBuilder();
        public static OleDbCommand myCommand;
        public static void OpenConnection()
        {
            connect.Provider = "Microsoft.Jet.OLEDB.4.0";
            connect.DataSource = @"CarService.mdb";
            cn.ConnectionString = connect.ConnectionString + ";Jet OLEDB:Database Password=admin";
            cn.Open();
        }     
        public static void CloseConnection()
        {
            cn.Close();
        }
    }

    public static class Data
    {
        public static byte access { get; set; } 
    }
}
