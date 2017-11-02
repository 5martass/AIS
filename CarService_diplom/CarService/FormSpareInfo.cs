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
    public partial class FormSpareInfo : Form
    {
        public FormSpareInfo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int sparePK;
        private int carPK;
        private string typeSpareName;

        public void zapol(int sparePK, int carPK, string typeSpareName, string spareName, int count, decimal price)
        {
            this.sparePK = sparePK;
            this.carPK = carPK;
            this.typeSpareName = typeSpareName;
            tbSpareName.Text = spareName;
            tbCount.Value = count;
            tbCost.Value = price;
            lblMain.Text = "Редактирование информации";
            btnEnter.Text = "Изменить";
        }

        public void zapol(string typeSpareName, int carPK)
        {
            this.typeSpareName = typeSpareName;
            this.carPK = carPK;
        }
        
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (tbSpareName.TextLength > 0)
            {
                string strSQL = "";
                if (btnEnter.Text == "Добавить")
                {
                    strSQL = "INSERT INTO Spares (SpareName, [Count], [Price], CarModelPK, TypeSpareName) VALUES " +
                        "(@SpareName, @Count, @Price, @CarPK, @TypeSpareName)";
                }
                else
                {
                    strSQL = "UPDATE Spares SET SpareName = @SpareName, [Count] = @Count, [Price] = @Price, CarModelPK = @CarPK, " + 
                        "TypeSpareName = @TypeSpareName WHERE SparePK = " + sparePK;
                }
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.Parameters.AddWithValue("@SpareName", tbSpareName.Text);
                SQLCommands.myCommand.Parameters.AddWithValue("@Count", tbCount.Value);
                SQLCommands.myCommand.Parameters.AddWithValue("@Price", tbCost.Value.ToString());
                SQLCommands.myCommand.Parameters.AddWithValue("@CarPK", carPK);
                SQLCommands.myCommand.Parameters.AddWithValue("@TypeSpareName", typeSpareName);
                SQLCommands.myCommand.ExecuteNonQuery();
                Close();
            }
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
