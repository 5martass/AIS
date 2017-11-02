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
    struct Brand
    {
        public int id;
        public String Name;
    }

    struct Model
    {
        public int id;
        public String name;
    }

    public partial class FormCarInfo : Form
    {
        DataTable dt;
        List<int> list;
        List<Model> listModel;
        List<Brand> listBrand;

        public FormCarInfo()
        {
            InitializeComponent();
            string strSQL = "SELECT CustomerPK, (LastName + ' ' + FirstName + ' ' + MiddleName) AS FIO " +
            " FROM Customers";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            cbCustomers.DataSource = dt;
            cbCustomers.ValueMember = "CustomerPK";
            cbCustomers.DisplayMember = "FIO";
            if (cbCustomers.Items.Count == 0) { MessageBox.Show("Для продолжения добавьте клиента", "Error"); Close(); }

            listBrand=new List<Brand>();
            strSQL = "SELECT * FROM CarBrand";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            reader = SQLCommands.myCommand.ExecuteReader();
            DataTable tableBrand = new DataTable();
            tableBrand.Load(reader);
            reader.Close();
            for (int i = 0; i < tableBrand.Rows.Count; i++)
            {
                Brand brand;
                brand.id = Convert.ToInt32(tableBrand.Rows[i].ItemArray[0]);
                brand.Name = tableBrand.Rows[i].ItemArray[1].ToString();
                listBrand.Add(brand);
            }
            for (int i = 0; i < listBrand.Count; i++)
                cbCarName.Items.Add(listBrand[i].Name);
            try
            {
                cbCarName.SelectedIndex = 0;
            }
            catch { cbCarName.SelectedIndex = -1; }
            

            strSQL = "SELECT CustomerPK" +
             " FROM Customers";
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            reader = SQLCommands.myCommand.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            list = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
                list.Add(Convert.ToInt32(dt.Rows[i][0].ToString()));
            cbCateg.SelectedIndex = 0;
            cbChassis.SelectedIndex = 0;
            cbCustomers.SelectedIndex = 0;
            cbTypeMotor.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int carPK;
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (//(tbCarName.TextLength > 0) && (tbDateOfRelease.Value > 1900) && (tbModel.TextLength > 0) &&
                (tbModelMotor.TextLength > 0) && (tbModification.TextLength > 0) && (cbCateg.SelectedIndex >= 0) &&
                (cbTypeMotor.SelectedIndex >= 0) && (tbEngineNumber.TextLength > 0) && (tbVIN.TextLength>0) && (tbStateNumber.TextLength>0))
            {
                string strSQL = "";
                if (btnEnter.Text == "Добавить")
                {
                    strSQL = "INSERT INTO Cars (CarBrandPK, CarModelPK, DateOfRelease, Modification, TypeMotor, ModelMotor, TypeName, CustomerPK,EngineNumber,Chassis,VIN,StateNumber,BodyNumber) " +
                        "VALUES (@CarBrandPK, @CarModelPK, @DateOfRelease, @Modification, @TypeMotor, @ModelMotor, @TypeName, @CustomerPK,@EngineNumber,@Chassis,@VIN,@StateNumber,@BodyNumber)";
                }
                else
                {
                    strSQL = "UPDATE Cars SET CarBrandPK = @CarBrandPK, CarModelPK = @CarModelPK, DateOfRelease = @DateOfRelease, " + 
                        "Modification = @Modification, TypeMotor = @TypeMotor, ModelMotor = @ModelMotor, TypeName = @TypeName " +
                        ", CustomerPK=@CustomerPK, EngineNumber=@EngineNumber, Chassis=@Chassis, VIN=@VIN, StateNumber=@StateNumber, BodyNumber=@BodyNumber " +
                        "WHERE CarPK = " + carPK;
                }
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.Parameters.AddWithValue("@CarBrandPK", listBrand[cbCarName.SelectedIndex].id);
                SQLCommands.myCommand.Parameters.AddWithValue("@CarModelPK", listModel[cbModel.SelectedIndex].id);
                SQLCommands.myCommand.Parameters.AddWithValue("@DateOfRelease", tbDateOfRelease.Value);
                SQLCommands.myCommand.Parameters.AddWithValue("@Modification", tbModification.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@TypeMotor", cbTypeMotor.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@ModelMotor", tbModelMotor.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@TypeName", cbCateg.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@CustomerPK", list[cbCustomers.SelectedIndex]);
                SQLCommands.myCommand.Parameters.AddWithValue("@EngineNumber", tbEngineNumber.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@Chassis", cbChassis.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@VIN", tbVIN.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@StateNumber", tbStateNumber.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@BodyNumber", tbBodyNumber.Text);              
                SQLCommands.myCommand.ExecuteNonQuery();
                Close();
            }
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void zapol(int carPK, int carBrand, int carModel, int dateOfRelease, string modification, string typeMotor, 
            string modelMotor, string typeName, int CustomerPK,string EngineNumber,string Chassis,string VIN,string StateNumber,string BodyNumber)
        {
            this.carPK = carPK;
            for (int i = 0; i < listBrand.Count; i++)
                if (listBrand[i].id == carBrand) { cbCarName.SelectedIndex = i; break; }
            for(int i=0;i<listModel.Count;i++)
                if(listModel[i].id==carModel) { cbModel.SelectedIndex = i;break; }
            tbDateOfRelease.Value = dateOfRelease;
            tbModification.Text = modification;
            cbCateg.SelectedIndex = cbCateg.Items.IndexOf(typeName);
            cbTypeMotor.SelectedIndex = cbTypeMotor.Items.IndexOf(typeMotor);
            tbModelMotor.Text = modelMotor;
            for (int i = 0; i < list.Count; i++)
                if (list[i] == CustomerPK) { cbCustomers.SelectedIndex = i; break; }
            tbEngineNumber.Text = EngineNumber;
            cbChassis.Text = Chassis;
            tbVIN.Text = VIN;
            tbStateNumber.Text = StateNumber;
            tbBodyNumber.Text = BodyNumber;
            label1.Text = "Редактирование информации об автомобиле";
            btnEnter.Text = "Изменить";
        }

        private void FormCarInfo_Load(object sender, EventArgs e)
        {
            
        }

        private void cbCarName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbModel.Items.Clear();
            listModel = new List<Model>();
            String strSQL = "SELECT * FROM CarModel WHERE CarBrand=" + listBrand[cbCarName.SelectedIndex].id;
            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            reader.Close();
            for(int i=0;i<table.Rows.Count;i++)
            {
                Model model;
                model.id = Convert.ToInt32(table.Rows[i].ItemArray[0]);
                model.name = table.Rows[i].ItemArray[2].ToString();
                listModel.Add(model);
            }
            for (int i = 0; i < listModel.Count; i++)
                cbModel.Items.Add(listModel[i].name);
            try
            {
                cbModel.SelectedIndex = 0;
            }catch { cbModel.SelectedIndex = -1; }
        }
    }
}
