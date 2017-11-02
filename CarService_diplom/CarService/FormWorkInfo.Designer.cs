namespace CarService
{
    partial class FormWorkInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSpares = new System.Windows.Forms.DataGridView();
            this.lblPriceWork = new System.Windows.Forms.Label();
            this.lblResultPrice = new System.Windows.Forms.Label();
            this.lblCar = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnStuffInfo = new System.Windows.Forms.Button();
            this.btnCustomerInfo = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTypeWork = new System.Windows.Forms.Label();
            this.lblDateEnd = new System.Windows.Forms.Label();
            this.lblDateBegin = new System.Windows.Forms.Label();
            this.lblWorkPK = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpares)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSpares);
            this.panel1.Controls.Add(this.lblPriceWork);
            this.panel1.Controls.Add(this.lblResultPrice);
            this.panel1.Controls.Add(this.lblCar);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnStuffInfo);
            this.panel1.Controls.Add(this.btnCustomerInfo);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.lblTypeWork);
            this.panel1.Controls.Add(this.lblDateEnd);
            this.panel1.Controls.Add(this.lblDateBegin);
            this.panel1.Controls.Add(this.lblWorkPK);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 561);
            this.panel1.TabIndex = 0;
            // 
            // dgvSpares
            // 
            this.dgvSpares.AllowUserToAddRows = false;
            this.dgvSpares.AllowUserToDeleteRows = false;
            this.dgvSpares.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSpares.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSpares.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSpares.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSpares.Location = new System.Drawing.Point(12, 263);
            this.dgvSpares.MultiSelect = false;
            this.dgvSpares.Name = "dgvSpares";
            this.dgvSpares.ReadOnly = true;
            this.dgvSpares.RowTemplate.Height = 25;
            this.dgvSpares.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpares.Size = new System.Drawing.Size(602, 212);
            this.dgvSpares.TabIndex = 3;
            // 
            // lblPriceWork
            // 
            this.lblPriceWork.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPriceWork.Location = new System.Drawing.Point(13, 140);
            this.lblPriceWork.Name = "lblPriceWork";
            this.lblPriceWork.Size = new System.Drawing.Size(601, 23);
            this.lblPriceWork.TabIndex = 43;
            this.lblPriceWork.Text = "Стоимость работы:  ";
            this.lblPriceWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultPrice
            // 
            this.lblResultPrice.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResultPrice.Location = new System.Drawing.Point(46, 478);
            this.lblResultPrice.Name = "lblResultPrice";
            this.lblResultPrice.Size = new System.Drawing.Size(535, 23);
            this.lblResultPrice.TabIndex = 42;
            this.lblResultPrice.Text = "Общая стоимость:  ";
            this.lblResultPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCar
            // 
            this.lblCar.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCar.Location = new System.Drawing.Point(12, 159);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new System.Drawing.Size(601, 23);
            this.lblCar.TabIndex = 41;
            this.lblCar.Text = "Автомобиль:  ";
            this.lblCar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBack.Location = new System.Drawing.Point(233, 524);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(158, 29);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnStuffInfo
            // 
            this.btnStuffInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStuffInfo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStuffInfo.Location = new System.Drawing.Point(316, 228);
            this.btnStuffInfo.Name = "btnStuffInfo";
            this.btnStuffInfo.Size = new System.Drawing.Size(158, 29);
            this.btnStuffInfo.TabIndex = 2;
            this.btnStuffInfo.Text = "Информация о сотруднике";
            this.btnStuffInfo.UseVisualStyleBackColor = false;
            this.btnStuffInfo.Click += new System.EventHandler(this.btnStuffInfo_Click);
            // 
            // btnCustomerInfo
            // 
            this.btnCustomerInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCustomerInfo.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCustomerInfo.Location = new System.Drawing.Point(152, 228);
            this.btnCustomerInfo.Name = "btnCustomerInfo";
            this.btnCustomerInfo.Size = new System.Drawing.Size(158, 29);
            this.btnCustomerInfo.TabIndex = 1;
            this.btnCustomerInfo.Text = "Информация о клиенте";
            this.btnCustomerInfo.UseVisualStyleBackColor = false;
            this.btnCustomerInfo.Click += new System.EventHandler(this.btnCustomerInfo_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.Location = new System.Drawing.Point(12, 189);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(601, 23);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "Статус:  ";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTypeWork
            // 
            this.lblTypeWork.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTypeWork.Location = new System.Drawing.Point(12, 121);
            this.lblTypeWork.Name = "lblTypeWork";
            this.lblTypeWork.Size = new System.Drawing.Size(601, 23);
            this.lblTypeWork.TabIndex = 24;
            this.lblTypeWork.Text = "Тип работы:  ";
            this.lblTypeWork.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateEnd
            // 
            this.lblDateEnd.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDateEnd.Location = new System.Drawing.Point(12, 101);
            this.lblDateEnd.Name = "lblDateEnd";
            this.lblDateEnd.Size = new System.Drawing.Size(601, 23);
            this.lblDateEnd.TabIndex = 23;
            this.lblDateEnd.Text = "Дата окончания работы:  ";
            this.lblDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateBegin
            // 
            this.lblDateBegin.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDateBegin.Location = new System.Drawing.Point(12, 81);
            this.lblDateBegin.Name = "lblDateBegin";
            this.lblDateBegin.Size = new System.Drawing.Size(601, 23);
            this.lblDateBegin.TabIndex = 22;
            this.lblDateBegin.Text = "Дата начала работы:  ";
            this.lblDateBegin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkPK
            // 
            this.lblWorkPK.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWorkPK.Location = new System.Drawing.Point(12, 61);
            this.lblWorkPK.Name = "lblWorkPK";
            this.lblWorkPK.Size = new System.Drawing.Size(601, 23);
            this.lblWorkPK.TabIndex = 21;
            this.lblWorkPK.Text = "Код работы:  ";
            this.lblWorkPK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Подробная информация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormWorkInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(626, 561);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWorkInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "АИС «Автосервис»";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpares)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWorkPK;
        private System.Windows.Forms.Label lblDateBegin;
        private System.Windows.Forms.Label lblDateEnd;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTypeWork;
        private System.Windows.Forms.Button btnStuffInfo;
        private System.Windows.Forms.Button btnCustomerInfo;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblCar;
        private System.Windows.Forms.Label lblResultPrice;
        private System.Windows.Forms.Label lblPriceWork;
        private System.Windows.Forms.DataGridView dgvSpares;
    }
}