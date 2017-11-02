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
    public partial class FormAddWork : Form
    {
        DataTable tableClient;
        DataTable tableCars;
        DataTable tableTypeWorks;

        public FormAddWork()
        {
            InitializeComponent();
        }
        
        private void FormAddWork_Load(object sender, EventArgs e)
        {
            tableClient = new DataTable();
            {
                string strSQL = "SELECT * FROM Customers";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableClient.Load(reader);
                for (int i = 0; i < tableClient.Rows.Count; i++)
                    cbClient.Items.Add(tableClient.Rows[i].ItemArray[1] + " " + tableClient.Rows[i].ItemArray[2] + " " + tableClient.Rows[i].ItemArray[3]);
                reader.Close();
                if (cbClient.Items.Count > 0)
                {
                    cbClient.SelectedIndex = 0;
                    cbClient_SelectedIndexChanged(sender, e);
                }else
                {
                    cbCars.Enabled = false;
                    cbTypeWorks.Enabled = false;
                }
            }
        }

        private void cbTypeWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cbCars.SelectedIndex==-1 || cbClient.SelectedIndex == -1 || cbTypeWorks.SelectedIndex == -1)
            {
                MessageBox.Show("Все поля должны быть заполненны", "Error");
                return;
            }
            string strSQL = "INSERT INTO [Works] ([DateBegin],[TypeWorkPK],[Status],[StuffPK],[CustomerPK],[CarPK]) " +
                        "VALUES (@date,"+tableTypeWorks.Rows[cbTypeWorks.SelectedIndex].ItemArray[0]+
                        ",' ',-1,"+tableClient.Rows[cbClient.SelectedIndex].ItemArray[0]+
                        ","+tableCars.Rows[cbCars.SelectedIndex].ItemArray[0]+")";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            SQLCommands.myCommand.Parameters.Add("@date", System.Data.OleDb.OleDbType.Date).Value = DateTime.Now.Date;
            SQLCommands.myCommand.ExecuteNonQuery();
            Close();
        }

        private void cbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCars.Items.Clear();
            cbTypeWorks.Items.Clear();

            tableCars = new DataTable();
            string strSQL = "SELECT * FROM Cars WHERE [CustomerPK]="+ tableClient.Rows[cbClient.SelectedIndex].ItemArray[0];
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            tableCars.Load(reader);

            if (tableCars.Rows.Count > 0)
            {
               for(int i = 0; i < tableCars.Rows.Count; i++)
                {
                    string name = "";
                    DataTable tableBrand = new DataTable();
                    strSQL = "SELECT * FROM CarBrand WHERE [CarBrandPK]="+tableCars.Rows[i].ItemArray[1];
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    reader = SQLCommands.myCommand.ExecuteReader();
                    tableBrand.Load(reader);
                    name += tableBrand.Rows[0].ItemArray[1]+" ";

                    DataTable tableModel = new DataTable();
                    strSQL = "SELECT * FROM CarModel WHERE [CarModelPK]=" + tableCars.Rows[i].ItemArray[2];
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    reader = SQLCommands.myCommand.ExecuteReader();
                    tableModel.Load(reader);
                    name += tableModel.Rows[0].ItemArray[2];
                    cbCars.Items.Add(name);
                }
                cbCars.SelectedIndex = 0;
                cbTypeWorks.Enabled = true;
                cbCars_SelectedIndexChanged(sender, e);
            }
            else
            {
                cbTypeWorks.Enabled = false;
            }
        }

        private void cbCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTypeWorks.Items.Clear();
            tableTypeWorks = new DataTable();
            string strSQL = "SELECT * FROM TypeWorks WHERE [CarModelPK]="+tableCars.Rows[cbCars.SelectedIndex].ItemArray[2];
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            tableTypeWorks.Load(reader);
            for (int i = 0; i < tableTypeWorks.Rows.Count; i++)
                cbTypeWorks.Items.Add(tableTypeWorks.Rows[i].ItemArray[1].ToString());
            if (cbTypeWorks.Items.Count > 0)
                cbTypeWorks.SelectedIndex = 0;
        }
    }
}
