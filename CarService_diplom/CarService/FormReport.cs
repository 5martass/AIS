using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace CarService
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "report.pdf";
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document,
             new FileStream(fileName, FileMode.Create));
            document.Open();

            BaseFont baseFont = BaseFont.CreateFont("arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Отчет о работах", new
                iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
            { Size = 20 }));
            cell.PaddingBottom = 5;
            cell.BorderWidth = 0;
            cell.BorderWidthBottom = 2;
            table.AddCell(cell);
            document.Add(table);

            ///////////////////////////////////////Ожидают поставки
            DataTable tableWorks = new DataTable();
            {
                string strSQL = "SELECT * FROM Works WHERE [Status]='ожидаются запчасти' AND [DateBegin]>=@dateStart";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.Parameters.Add("@dateStart", System.Data.OleDb.OleDbType.Date).Value = monthCalendar.SelectionRange.Start;
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableWorks.Load(reader);
            }

            if (tableWorks.Rows.Count > 0)
            {
                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(new Phrase("Ожидаются запчасти", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 14 }));
                cell.PaddingTop = 5;
                cell.BorderWidth = 0;
                table.AddCell(cell);
                document.Add(table);

                table = new PdfPTable(5);
                table.WidthPercentage = 100;
                float[] widths = new float[] { 1f, 3f, 3f, 3f, 2f };
                table.SetWidths(widths);
                cell = new PdfPCell(new Phrase("№", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Машина", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Услуга", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Клиент", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Дата заказа", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                for (int i = 0; i < tableWorks.Rows.Count; i++)
                {
                    cell = new PdfPCell(new Phrase(tableWorks.Rows[i].ItemArray[0].ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    string nameCar = "";
                    DataTable tableCars = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Cars WHERE [CarPK]=" + tableWorks.Rows[i].ItemArray[7].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableCars.Load(reader);
                    }
                    DataTable tableBrand = new DataTable();
                    {
                        string strSQL = "SELECT * FROM CarBrand WHERE [CarBrandPK]=" + tableCars.Rows[0].ItemArray[1].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableBrand.Load(reader);
                    }
                    DataTable tableModel = new DataTable();
                    {
                        string strSQL = "SELECT * FROM CarModel WHERE [CarModelPK]=" + tableCars.Rows[0].ItemArray[2].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableModel.Load(reader);
                    }
                    nameCar += tableBrand.Rows[0].ItemArray[1].ToString() + " " + tableModel.Rows[0].ItemArray[2].ToString();

                    cell = new PdfPCell(new Phrase(nameCar, new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    DataTable tableTypeWorks = new DataTable();
                    {
                        string strSQL = "SELECT * FROM TypeWorks WHERE [TypeWorkPK]=" + tableWorks.Rows[i].ItemArray[3].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableTypeWorks.Load(reader);
                    }

                    cell = new PdfPCell(new Phrase(tableTypeWorks.Rows[0].ItemArray[1].ToString(), new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);



                    string clientName = "";
                    DataTable tableCustomers = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Customers WHERE [CustomerPK]=" + tableWorks.Rows[i].ItemArray[6].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableCustomers.Load(reader);
                    }

                    clientName += tableCustomers.Rows[0].ItemArray[1].ToString() + " " + tableCustomers.Rows[0].ItemArray[2].ToString() + " " + tableCustomers.Rows[0].ItemArray[3].ToString();

                    cell = new PdfPCell(new Phrase(clientName, new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(((DateTime)tableWorks.Rows[i].ItemArray[1]).ToString("dd.MM.yyyy"), new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);
                }
                document.Add(table);
            }

            ///////////////////////////////////Ожидается механик
            tableWorks = new DataTable();
            {
                string strSQL = "SELECT * FROM Works WHERE [Status]='ожидается механик' AND [DateBegin]>=@dateStart";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.Parameters.Add("@dateStart", System.Data.OleDb.OleDbType.Date).Value = monthCalendar.SelectionRange.Start;
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableWorks.Load(reader);
            }

            if (tableWorks.Rows.Count > 0)
            {
                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(new Phrase("Ожидается механик", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 14 }));
                cell.PaddingTop = 5;
                cell.BorderWidth = 0;
                table.AddCell(cell);
                document.Add(table);

                table = new PdfPTable(5);
                table.WidthPercentage = 100;
                float[] widths = new float[] { 1f, 3f, 3f, 3f, 2f };
                table.SetWidths(widths);
                cell = new PdfPCell(new Phrase("№", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Машина", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Услуга", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Клиент", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Дата заказа", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                for (int i = 0; i < tableWorks.Rows.Count; i++)
                {
                    cell = new PdfPCell(new Phrase(tableWorks.Rows[i].ItemArray[0].ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    string nameCar = "";
                    DataTable tableCars = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Cars WHERE [CarPK]=" + tableWorks.Rows[i].ItemArray[7].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableCars.Load(reader);
                    }
                    DataTable tableBrand = new DataTable();
                    {
                        string strSQL = "SELECT * FROM CarBrand WHERE [CarBrandPK]=" + tableCars.Rows[0].ItemArray[1].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableBrand.Load(reader);
                    }
                    DataTable tableModel = new DataTable();
                    {
                        string strSQL = "SELECT * FROM CarModel WHERE [CarModelPK]=" + tableCars.Rows[0].ItemArray[2].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableModel.Load(reader);
                    }
                    nameCar += tableBrand.Rows[0].ItemArray[1].ToString() + " " + tableModel.Rows[0].ItemArray[2].ToString();

                    cell = new PdfPCell(new Phrase(nameCar, new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    DataTable tableTypeWorks = new DataTable();
                    {
                        string strSQL = "SELECT * FROM TypeWorks WHERE [TypeWorkPK]=" + tableWorks.Rows[i].ItemArray[3].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableTypeWorks.Load(reader);
                    }

                    cell = new PdfPCell(new Phrase(tableTypeWorks.Rows[0].ItemArray[1].ToString(), new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);



                    string clientName = "";
                    DataTable tableCustomers = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Customers WHERE [CustomerPK]=" + tableWorks.Rows[i].ItemArray[6].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableCustomers.Load(reader);
                    }

                    clientName += tableCustomers.Rows[0].ItemArray[1].ToString() + " " + tableCustomers.Rows[0].ItemArray[2].ToString() + " " + tableCustomers.Rows[0].ItemArray[3].ToString();

                    cell = new PdfPCell(new Phrase(clientName, new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(((DateTime)tableWorks.Rows[i].ItemArray[1]).ToString("dd.MM.yyyy"), new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);
                }
                document.Add(table);
            }
            ///////////////////////////////////////////////////Выполняется

            tableWorks = new DataTable();
            {
                string strSQL = "SELECT * FROM Works WHERE [Status]='выполняется' AND [DateBegin]>=@dateStart";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.Parameters.Add("@dateStart", System.Data.OleDb.OleDbType.Date).Value = monthCalendar.SelectionRange.Start;
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableWorks.Load(reader);
            }

            if (tableWorks.Rows.Count > 0)
            {
                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(new Phrase("Заказ выполняется", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 14 }));
                cell.PaddingTop = 5;
                cell.BorderWidth = 0;
                table.AddCell(cell);
                document.Add(table);

                table = new PdfPTable(6);
                table.WidthPercentage = 100;
                float[] widths = new float[] { 1f, 3f, 3f, 3f, 3f, 2f };
                table.SetWidths(widths);
                cell = new PdfPCell(new Phrase("№", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Машина", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Услуга", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Клиент", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Работник", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Дата заказа", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                for (int i = 0; i < tableWorks.Rows.Count; i++)
                {
                    cell = new PdfPCell(new Phrase(tableWorks.Rows[i].ItemArray[0].ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    string nameCar = "";
                    DataTable tableCars = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Cars WHERE [CarPK]=" + tableWorks.Rows[i].ItemArray[7].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableCars.Load(reader);
                    }
                    DataTable tableBrand = new DataTable();
                    {
                        string strSQL = "SELECT * FROM CarBrand WHERE [CarBrandPK]=" + tableCars.Rows[0].ItemArray[1].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableBrand.Load(reader);
                    }
                    DataTable tableModel = new DataTable();
                    {
                        string strSQL = "SELECT * FROM CarModel WHERE [CarModelPK]=" + tableCars.Rows[0].ItemArray[2].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableModel.Load(reader);
                    }
                    nameCar += tableBrand.Rows[0].ItemArray[1].ToString() + " " + tableModel.Rows[0].ItemArray[2].ToString();

                    cell = new PdfPCell(new Phrase(nameCar, new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    DataTable tableTypeWorks = new DataTable();
                    {
                        string strSQL = "SELECT * FROM TypeWorks WHERE [TypeWorkPK]=" + tableWorks.Rows[i].ItemArray[3].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableTypeWorks.Load(reader);
                    }

                    cell = new PdfPCell(new Phrase(tableTypeWorks.Rows[0].ItemArray[1].ToString(), new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);



                    string clientName = "";
                    DataTable tableCustomers = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Customers WHERE [CustomerPK]=" + tableWorks.Rows[i].ItemArray[6].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableCustomers.Load(reader);
                    }

                    clientName += tableCustomers.Rows[0].ItemArray[1].ToString() + " " + tableCustomers.Rows[0].ItemArray[2].ToString() + " " + tableCustomers.Rows[0].ItemArray[3].ToString();

                    cell = new PdfPCell(new Phrase(clientName, new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    string stuffName = "";
                    DataTable tableStuff = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Stuff WHERE [StuffPK]=" + tableWorks.Rows[i].ItemArray[5].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableStuff.Load(reader);
                    }

                    stuffName += tableStuff.Rows[0].ItemArray[1].ToString() + " " + tableStuff.Rows[0].ItemArray[2].ToString() + " " + tableStuff.Rows[0].ItemArray[3].ToString();

                    cell = new PdfPCell(new Phrase(stuffName, new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(((DateTime)tableWorks.Rows[i].ItemArray[1]).ToString("dd.MM.yyyy"), new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);
                }
                document.Add(table);
            }
            //////////////////////////////////Выполнено

            int summ = 0;

            tableWorks = new DataTable();
            {
                string strSQL = "SELECT * FROM Works WHERE [Status]='выполнено' AND [DateBegin]>=@dateStart AND [DateEnd]<=@dateEnd";
                SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                SQLCommands.myCommand.Parameters.Add("@dateStart", System.Data.OleDb.OleDbType.Date).Value = monthCalendar.SelectionRange.Start;
                SQLCommands.myCommand.Parameters.Add("@dateEnd", System.Data.OleDb.OleDbType.Date).Value = monthCalendar.SelectionRange.End;
                System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                tableWorks.Load(reader);
            }

            if (tableWorks.Rows.Count > 0)
            {
                table = new PdfPTable(1);
                table.WidthPercentage = 100;
                cell = new PdfPCell(new Phrase("Заказ выполнено", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 14 }));
                cell.PaddingTop = 5;
                cell.BorderWidth = 0;
                table.AddCell(cell);
                document.Add(table);

                table = new PdfPTable(7);
                table.WidthPercentage = 100;
                float[] widths = new float[] { 1f, 3f, 3f, 3f, 3f, 2f, 2f };
                table.SetWidths(widths);
                cell = new PdfPCell(new Phrase("№", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Машина", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Услуга", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Клиент", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Работник", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Дата заказа", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Дата завершения заказа", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
                for (int i = 0; i < tableWorks.Rows.Count; i++)
                {
                    cell = new PdfPCell(new Phrase(tableWorks.Rows[i].ItemArray[0].ToString(), new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    string nameCar = "";
                    DataTable tableCars = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Cars WHERE [CarPK]=" + tableWorks.Rows[i].ItemArray[7].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableCars.Load(reader);
                    }
                    DataTable tableBrand = new DataTable();
                    {
                        string strSQL = "SELECT * FROM CarBrand WHERE [CarBrandPK]=" + tableCars.Rows[0].ItemArray[1].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableBrand.Load(reader);
                    }
                    DataTable tableModel = new DataTable();
                    {
                        string strSQL = "SELECT * FROM CarModel WHERE [CarModelPK]=" + tableCars.Rows[0].ItemArray[2].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableModel.Load(reader);
                    }
                    nameCar += tableBrand.Rows[0].ItemArray[1].ToString() + " " + tableModel.Rows[0].ItemArray[2].ToString();

                    cell = new PdfPCell(new Phrase(nameCar, new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    DataTable tableTypeWorks = new DataTable();
                    {
                        string strSQL = "SELECT * FROM TypeWorks WHERE [TypeWorkPK]=" + tableWorks.Rows[i].ItemArray[3].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableTypeWorks.Load(reader);
                    }

                    summ += int.Parse(tableTypeWorks.Rows[0].ItemArray[3].ToString());

                    cell = new PdfPCell(new Phrase(tableTypeWorks.Rows[0].ItemArray[1].ToString(), new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);



                    string clientName = "";
                    DataTable tableCustomers = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Customers WHERE [CustomerPK]=" + tableWorks.Rows[i].ItemArray[6].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableCustomers.Load(reader);
                    }

                    clientName += tableCustomers.Rows[0].ItemArray[1].ToString() + " " + tableCustomers.Rows[0].ItemArray[2].ToString() + " " + tableCustomers.Rows[0].ItemArray[3].ToString();

                    cell = new PdfPCell(new Phrase(clientName, new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    string stuffName = "";
                    DataTable tableStuff = new DataTable();
                    {
                        string strSQL = "SELECT * FROM Stuff WHERE [StuffPK]=" + tableWorks.Rows[i].ItemArray[5].ToString();
                        SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                        System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                        tableStuff.Load(reader);
                    }

                    stuffName += tableStuff.Rows[0].ItemArray[1].ToString() + " " + tableStuff.Rows[0].ItemArray[2].ToString() + " " + tableStuff.Rows[0].ItemArray[3].ToString();

                    cell = new PdfPCell(new Phrase(stuffName, new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(((DateTime)tableWorks.Rows[i].ItemArray[1]).ToString("dd.MM.yyyy"), new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);

                    cell = new PdfPCell(new Phrase(((DateTime)tableWorks.Rows[i].ItemArray[2]).ToString("dd.MM.yyyy"), new
                   iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 10 }));
                    table.AddCell(cell);
                }
                document.Add(table);
            }
            /////////////////////Сумма
            {
                table = new PdfPTable(2);
                table.WidthPercentage = 100;
                float[] widths = new float[] { 10f,1f };
                table.SetWidths(widths);
                cell = new PdfPCell(new Phrase("Прибыль за выполненные работы:", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                { Size = 10 }));
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(summ.ToString()+"р", new
                    iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                { Size = 10 }));
                cell.Border = 0;
                table.AddCell(cell);
                document.Add(table);
            }

            ////////////////////////////////Статистика работников
            {
                DataTable tableStuff = new DataTable();
                {
                    string strSQL = "SELECT * FROM Stuff";
                    SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                    System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                    tableStuff.Load(reader);
                }

                if (tableStuff.Rows.Count > 0)
                {
                    table = new PdfPTable(1);
                    table.WidthPercentage = 100;
                    cell = new PdfPCell(new Phrase("Статистика сотрудников", new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 20 }));
                    cell.PaddingTop = 10;
                    cell.PaddingBottom = 5;
                    cell.BorderWidth = 0;
                    cell.BorderWidthBottom = 2;
                    table.AddCell(cell);
                    document.Add(table);


                    table = new PdfPTable(1);
                    table.WidthPercentage = 100;
                    cell = new PdfPCell(new Phrase("", new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                    { Size = 14 }));
                    cell.PaddingTop = 5;
                    cell.BorderWidth = 0;
                    table.AddCell(cell);
                    document.Add(table);


                    table = new PdfPTable(4);
                    table.WidthPercentage = 100;
                    float[] widths = new float[] { 1f, 3f, 2f, 2f };
                    table.SetWidths(widths);
                    cell = new PdfPCell(new Phrase("№", new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                    { Size = 10 }));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Имя сотрудника", new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                    { Size = 10 }));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Выполняет заказов", new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                    { Size = 10 }));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase("Выполнил заказов", new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.BOLD)
                    { Size = 10 }));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);


                    for (int i = 0; i < tableStuff.Rows.Count; i++)
                    {
                        cell = new PdfPCell(new Phrase(tableStuff.Rows[i].ItemArray[0].ToString(), new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                        { Size = 10 }));
                        table.AddCell(cell);

                        cell = new PdfPCell(new Phrase(tableStuff.Rows[i].ItemArray[1] + " " + tableStuff.Rows[i].ItemArray[2] + " " + tableStuff.Rows[i].ItemArray[3], new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                        { Size = 10 }));
                        table.AddCell(cell);

                        DataTable tableWork = new DataTable();
                        {
                            string strSQL = "SELECT * FROM Works WHERE [Status]='выполняется' AND [StuffPK]=" + tableStuff.Rows[i].ItemArray[0].ToString() + " AND [DateBegin]>=@dateStart";
                            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                            SQLCommands.myCommand.Parameters.Add("@dateStart", System.Data.OleDb.OleDbType.Date).Value = monthCalendar.SelectionRange.Start;
                            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                            tableWork.Load(reader);
                        }

                        cell = new PdfPCell(new Phrase(tableWork.Rows.Count.ToString(), new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                        { Size = 10 }));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);

                        tableWork = new DataTable();
                        {
                            string strSQL = "SELECT * FROM Works WHERE [Status]='выполнено' AND [StuffPK]=" + tableStuff.Rows[i].ItemArray[0].ToString() + " AND[DateBegin] >= @dateStart AND[DateEnd] <= @dateEnd";
                            SQLCommands.myCommand = new System.Data.OleDb.OleDbCommand(strSQL, SQLCommands.cn);
                            SQLCommands.myCommand.Parameters.Add("@dateStart", System.Data.OleDb.OleDbType.Date).Value = monthCalendar.SelectionRange.Start;
                            SQLCommands.myCommand.Parameters.Add("@dateEnd", System.Data.OleDb.OleDbType.Date).Value = monthCalendar.SelectionRange.End;
                            System.Data.OleDb.OleDbDataReader reader = SQLCommands.myCommand.ExecuteReader();
                            tableWork.Load(reader);
                        }

                        cell = new PdfPCell(new Phrase(tableWork.Rows.Count.ToString(), new
                        iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL)
                        { Size = 10 }));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }


                    document.Add(table);
                }
            }



            document.Close();
            writer.Close();
            System.Diagnostics.Process.Start(fileName);

            this.Close();
        }
    }
}
