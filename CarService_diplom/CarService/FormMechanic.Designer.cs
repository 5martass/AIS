namespace CarService
{
    partial class FormMechanic
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMechanic));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonWorks = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ToMenuButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.TypesCars = new System.Windows.Forms.Button();
            this.carsButton = new System.Windows.Forms.Button();
            this.panelWorks = new System.Windows.Forms.Panel();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.buttonWorkEnd = new System.Windows.Forms.Button();
            this.dgvWorks = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.panelFreeWorks = new System.Windows.Forms.Panel();
            this.buttonInfoWorks = new System.Windows.Forms.Button();
            this.buttonAddWorks = new System.Windows.Forms.Button();
            this.dgvFreeWorks = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTypeCars = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBrand = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dgvCars = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelWorks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorks)).BeginInit();
            this.panelFreeWorks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFreeWorks)).BeginInit();
            this.panelTypeCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonWorks);
            this.panelMenu.Controls.Add(this.ExitButton);
            this.panelMenu.Controls.Add(this.ToMenuButton);
            this.panelMenu.Controls.Add(this.helpButton);
            this.panelMenu.Controls.Add(this.TypesCars);
            this.panelMenu.Controls.Add(this.carsButton);
            this.panelMenu.Location = new System.Drawing.Point(1, 1);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(228, 518);
            this.panelMenu.TabIndex = 39;
            // 
            // buttonWorks
            // 
            this.buttonWorks.Location = new System.Drawing.Point(0, 312);
            this.buttonWorks.Name = "buttonWorks";
            this.buttonWorks.Size = new System.Drawing.Size(225, 35);
            this.buttonWorks.TabIndex = 9;
            this.buttonWorks.Text = "Ваши работы";
            this.buttonWorks.UseVisualStyleBackColor = true;
            this.buttonWorks.Click += new System.EventHandler(this.buttonWorks_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(0, 482);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(225, 35);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Выйти из программы";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ToMenuButton
            // 
            this.ToMenuButton.Location = new System.Drawing.Point(0, 448);
            this.ToMenuButton.Name = "ToMenuButton";
            this.ToMenuButton.Size = new System.Drawing.Size(225, 35);
            this.ToMenuButton.TabIndex = 2;
            this.ToMenuButton.Text = "Выйти из раздела механика";
            this.ToMenuButton.UseVisualStyleBackColor = true;
            this.ToMenuButton.Click += new System.EventHandler(this.btnExitMec_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(0, 414);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(225, 35);
            this.helpButton.TabIndex = 3;
            this.helpButton.Text = "Справка";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // TypesCars
            // 
            this.TypesCars.Location = new System.Drawing.Point(0, 380);
            this.TypesCars.Name = "TypesCars";
            this.TypesCars.Size = new System.Drawing.Size(225, 35);
            this.TypesCars.TabIndex = 7;
            this.TypesCars.Text = "Типы автомобилей и запчасти";
            this.TypesCars.UseVisualStyleBackColor = true;
            this.TypesCars.Click += new System.EventHandler(this.TypesCars_Click);
            // 
            // carsButton
            // 
            this.carsButton.Location = new System.Drawing.Point(0, 346);
            this.carsButton.Name = "carsButton";
            this.carsButton.Size = new System.Drawing.Size(225, 35);
            this.carsButton.TabIndex = 8;
            this.carsButton.Text = "Незарезервированные работы";
            this.carsButton.UseVisualStyleBackColor = true;
            this.carsButton.Click += new System.EventHandler(this.carsButton_Click);
            // 
            // panelWorks
            // 
            this.panelWorks.BackColor = System.Drawing.Color.White;
            this.panelWorks.Controls.Add(this.buttonInfo);
            this.panelWorks.Controls.Add(this.buttonWorkEnd);
            this.panelWorks.Controls.Add(this.dgvWorks);
            this.panelWorks.Controls.Add(this.label14);
            this.panelWorks.Location = new System.Drawing.Point(226, -9);
            this.panelWorks.Name = "panelWorks";
            this.panelWorks.Size = new System.Drawing.Size(834, 527);
            this.panelWorks.TabIndex = 51;
            // 
            // buttonInfo
            // 
            this.buttonInfo.Location = new System.Drawing.Point(420, 481);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(397, 36);
            this.buttonInfo.TabIndex = 32;
            this.buttonInfo.Text = "Информация о работе";
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonWorkEnd
            // 
            this.buttonWorkEnd.Location = new System.Drawing.Point(14, 481);
            this.buttonWorkEnd.Name = "buttonWorkEnd";
            this.buttonWorkEnd.Size = new System.Drawing.Size(397, 36);
            this.buttonWorkEnd.TabIndex = 31;
            this.buttonWorkEnd.Text = "Работа выполнена";
            this.buttonWorkEnd.UseVisualStyleBackColor = true;
            this.buttonWorkEnd.Click += new System.EventHandler(this.buttonWorkEnd_Click);
            // 
            // dgvWorks
            // 
            this.dgvWorks.AllowUserToAddRows = false;
            this.dgvWorks.AllowUserToDeleteRows = false;
            this.dgvWorks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorks.Location = new System.Drawing.Point(14, 65);
            this.dgvWorks.MultiSelect = false;
            this.dgvWorks.Name = "dgvWorks";
            this.dgvWorks.ReadOnly = true;
            this.dgvWorks.RowTemplate.Height = 25;
            this.dgvWorks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorks.Size = new System.Drawing.Size(803, 410);
            this.dgvWorks.TabIndex = 33;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(6, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(816, 30);
            this.label14.TabIndex = 30;
            this.label14.Text = "Ваши работы";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFreeWorks
            // 
            this.panelFreeWorks.BackColor = System.Drawing.Color.White;
            this.panelFreeWorks.Controls.Add(this.buttonInfoWorks);
            this.panelFreeWorks.Controls.Add(this.buttonAddWorks);
            this.panelFreeWorks.Controls.Add(this.dgvFreeWorks);
            this.panelFreeWorks.Controls.Add(this.label1);
            this.panelFreeWorks.Location = new System.Drawing.Point(226, -9);
            this.panelFreeWorks.Name = "panelFreeWorks";
            this.panelFreeWorks.Size = new System.Drawing.Size(834, 527);
            this.panelFreeWorks.TabIndex = 52;
            // 
            // buttonInfoWorks
            // 
            this.buttonInfoWorks.Location = new System.Drawing.Point(420, 481);
            this.buttonInfoWorks.Name = "buttonInfoWorks";
            this.buttonInfoWorks.Size = new System.Drawing.Size(397, 36);
            this.buttonInfoWorks.TabIndex = 34;
            this.buttonInfoWorks.Text = "Информация о работе";
            this.buttonInfoWorks.UseVisualStyleBackColor = true;
            this.buttonInfoWorks.Click += new System.EventHandler(this.buttonInfoWorks_Click);
            // 
            // buttonAddWorks
            // 
            this.buttonAddWorks.Location = new System.Drawing.Point(14, 481);
            this.buttonAddWorks.Name = "buttonAddWorks";
            this.buttonAddWorks.Size = new System.Drawing.Size(397, 36);
            this.buttonAddWorks.TabIndex = 33;
            this.buttonAddWorks.Text = "Взяться за работу";
            this.buttonAddWorks.UseVisualStyleBackColor = true;
            this.buttonAddWorks.Click += new System.EventHandler(this.buttonAddWorks_Click);
            // 
            // dgvFreeWorks
            // 
            this.dgvFreeWorks.AllowUserToAddRows = false;
            this.dgvFreeWorks.AllowUserToDeleteRows = false;
            this.dgvFreeWorks.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFreeWorks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFreeWorks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFreeWorks.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFreeWorks.Location = new System.Drawing.Point(14, 65);
            this.dgvFreeWorks.MultiSelect = false;
            this.dgvFreeWorks.Name = "dgvFreeWorks";
            this.dgvFreeWorks.ReadOnly = true;
            this.dgvFreeWorks.RowTemplate.Height = 25;
            this.dgvFreeWorks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFreeWorks.Size = new System.Drawing.Size(803, 410);
            this.dgvFreeWorks.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(816, 30);
            this.label1.TabIndex = 30;
            this.label1.Text = "Незарезервированные работы";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTypeCars
            // 
            this.panelTypeCars.BackColor = System.Drawing.Color.White;
            this.panelTypeCars.Controls.Add(this.label3);
            this.panelTypeCars.Controls.Add(this.cbBrand);
            this.panelTypeCars.Controls.Add(this.button2);
            this.panelTypeCars.Controls.Add(this.dgvCars);
            this.panelTypeCars.Controls.Add(this.label2);
            this.panelTypeCars.Location = new System.Drawing.Point(226, -9);
            this.panelTypeCars.Name = "panelTypeCars";
            this.panelTypeCars.Size = new System.Drawing.Size(834, 527);
            this.panelTypeCars.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Марка автомобиля:";
            // 
            // cbBrand
            // 
            this.cbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbBrand.FormattingEnabled = true;
            this.cbBrand.Location = new System.Drawing.Point(187, 88);
            this.cbBrand.Name = "cbBrand";
            this.cbBrand.Size = new System.Drawing.Size(630, 28);
            this.cbBrand.TabIndex = 32;
            this.cbBrand.SelectedIndexChanged += new System.EventHandler(this.cbBrand_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 481);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(803, 36);
            this.button2.TabIndex = 31;
            this.button2.Text = "Совместимые запчасти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgvCars
            // 
            this.dgvCars.AllowUserToAddRows = false;
            this.dgvCars.AllowUserToDeleteRows = false;
            this.dgvCars.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCars.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCars.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCars.Location = new System.Drawing.Point(14, 125);
            this.dgvCars.MultiSelect = false;
            this.dgvCars.Name = "dgvCars";
            this.dgvCars.ReadOnly = true;
            this.dgvCars.RowTemplate.Height = 25;
            this.dgvCars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCars.Size = new System.Drawing.Size(803, 350);
            this.dgvCars.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(816, 30);
            this.label2.TabIndex = 30;
            this.label2.Text = "Типы автомобилей и совместимые запчасти";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMechanic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1056, 518);
            this.Controls.Add(this.panelTypeCars);
            this.Controls.Add(this.panelFreeWorks);
            this.Controls.Add(this.panelWorks);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMechanic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "АИС «Автосервис»";
            this.Load += new System.EventHandler(this.FormMechanic_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelWorks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorks)).EndInit();
            this.panelFreeWorks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFreeWorks)).EndInit();
            this.panelTypeCars.ResumeLayout(false);
            this.panelTypeCars.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCars)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonWorks;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ToMenuButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button TypesCars;
        private System.Windows.Forms.Button carsButton;
        private System.Windows.Forms.Panel panelWorks;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.Button buttonWorkEnd;
        private System.Windows.Forms.DataGridView dgvWorks;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panelFreeWorks;
        private System.Windows.Forms.Button buttonInfoWorks;
        private System.Windows.Forms.Button buttonAddWorks;
        private System.Windows.Forms.DataGridView dgvFreeWorks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTypeCars;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvCars;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBrand;
    }
}