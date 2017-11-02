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
    public partial class EditStatus : Form
    {
        int id;
        DataTable tableStuff;
        public EditStatus(int id)
        {
            InitializeComponent();
            this.id = id;

            string strSQL = "SELECT * FROM Works WHERE [WorkPK]=" + id;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            DataTable tableWorks = new DataTable();
            tableWorks.Load(reader);

            strSQL = "SELECT * FROM Stuff";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            reader = SQLCommands.myCommand.ExecuteReader();
            tableStuff = new DataTable();
            tableStuff.Load(reader);

            for (int i = 0; i < tableStuff.Rows.Count; i++)
            {
                comboBox2.Items.Add(tableStuff.Rows[i].ItemArray[1] + " " + tableStuff.Rows[i].ItemArray[2] + " " + tableStuff.Rows[i].ItemArray[3]);
                if ((int)tableStuff.Rows[i].ItemArray[0] == (int)tableWorks.Rows[0].ItemArray[5]) comboBox2.SelectedIndex = i;
            }

            if (comboBox2.SelectedIndex == -1)
                comboBox2.SelectedIndex = 0;

            if (tableWorks.Rows[0].ItemArray[4].ToString() == "выполнено")
            {
                comboBox1.SelectedIndex = 2;
                DateTime date = new DateTime();
                DateTime.TryParse(tableWorks.Rows[0].ItemArray[2].ToString(), out date);
                monthCalendar1.SetDate(date);
            }else
            {
                if (tableWorks.Rows[0].ItemArray[4].ToString() == "выполняется")
                    comboBox1.SelectedIndex = 1;
                else
                    comboBox1.SelectedIndex = 0;
            }
            comboBox1_SelectedIndexChanged(new object(),new EventArgs());
        }

        public EditStatus(int id,string status)
        {
            InitializeComponent();
            this.id = id;
            if (status != "выполнено")
            {
                comboBox1.Items.RemoveAt(2);
            }

            string strSQL = "SELECT * FROM Works WHERE [WorkPK]=" + id;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            DataTable tableWorks = new DataTable();
            tableWorks.Load(reader);

            strSQL = "SELECT * FROM Stuff";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            reader = SQLCommands.myCommand.ExecuteReader();
            tableStuff = new DataTable();
            tableStuff.Load(reader);

            for (int i = 0; i < tableStuff.Rows.Count; i++)
            {
                comboBox2.Items.Add(tableStuff.Rows[i].ItemArray[1] + " " + tableStuff.Rows[i].ItemArray[2] + " " + tableStuff.Rows[i].ItemArray[3]);
                if ((int)tableStuff.Rows[i].ItemArray[0] == (int)tableWorks.Rows[0].ItemArray[5]) comboBox2.SelectedIndex = i;
            }

            if (comboBox2.SelectedIndex == -1)
                comboBox2.SelectedIndex = 0;

            if (tableWorks.Rows[0].ItemArray[4].ToString() == "выполнено")
            {
                comboBox1.SelectedIndex = 2;
                DateTime date = new DateTime();
                DateTime.TryParse(tableWorks.Rows[0].ItemArray[2].ToString(), out date);
                monthCalendar1.SetDate(date);
            }
            else
            {
                if (tableWorks.Rows[0].ItemArray[4].ToString() == "выполняется")
                    comboBox1.SelectedIndex = 1;
                else
                    comboBox1.SelectedIndex = 0;
            }
            comboBox1_SelectedIndexChanged(new object(), new EventArgs());
        }

        private void EditStatus_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Enabled = false;
                monthCalendar1.Enabled = false;
            }
            if(comboBox1.SelectedIndex == 1)
            {
                comboBox2.Enabled = true;
                monthCalendar1.Enabled = false;
            }
            if(comboBox1.SelectedIndex == 2)
            {
                comboBox2.Enabled = true;
                monthCalendar1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                string strSQL = "UPDATE Works SET [StuffPK]=-1,DateEnd=null WHERE WorkPK = " + id;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.ExecuteNonQuery();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                if(comboBox2.SelectedIndex==-1)
                {
                    MessageBox.Show("Выберите работника", "Error");
                    return;
                }
                string strSQL = "UPDATE Works SET [Status]='выполняется',[StuffPK]="+tableStuff.Rows[comboBox2.SelectedIndex].ItemArray[0]+",[DateEnd]=null WHERE WorkPK = " + id;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.ExecuteNonQuery();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите работника", "Error");
                    return;
                }
                string strSQL = "UPDATE Works SET [Status]='выполнено',[StuffPK]=" + tableStuff.Rows[comboBox2.SelectedIndex].ItemArray[0] + ",[DateEnd]=@date WHERE WorkPK = " + id;
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.Parameters.Add("@date", System.Data.OleDb.OleDbType.Date).Value = monthCalendar1.SelectionRange.Start;
                SQLCommands.myCommand.ExecuteNonQuery();
            }
            Close();
        }
    }
}
