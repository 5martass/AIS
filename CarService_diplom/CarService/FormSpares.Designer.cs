namespace CarService
{
    partial class FormSpares
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.cbCateg = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblSparesFor = new System.Windows.Forms.Label();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnDeleteSpare = new System.Windows.Forms.Button();
            this.btnEditCar = new System.Windows.Forms.Button();
            this.btnAddSpare = new System.Windows.Forms.Button();
            this.btnDeleteCateg = new System.Windows.Forms.Button();
            this.btnEditCateg = new System.Windows.Forms.Button();
            this.btnAddCateg = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.cbCateg);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.lblSparesFor);
            this.panel1.Controls.Add(this.btnMinus);
            this.panel1.Controls.Add(this.btnPlus);
            this.panel1.Controls.Add(this.btnDeleteSpare);
            this.panel1.Controls.Add(this.btnEditCar);
            this.panel1.Controls.Add(this.btnAddSpare);
            this.panel1.Controls.Add(this.btnDeleteCateg);
            this.panel1.Controls.Add(this.btnEditCateg);
            this.panel1.Controls.Add(this.btnAddCateg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 482);
            this.panel1.TabIndex = 2;
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonOK.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOK.Location = new System.Drawing.Point(22, 440);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(535, 30);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Visible = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // cbCateg
            // 
            this.cbCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCateg.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbCateg.FormattingEnabled = true;
            this.cbCateg.Location = new System.Drawing.Point(154, 59);
            this.cbCateg.Name = "cbCateg";
            this.cbCateg.Size = new System.Drawing.Size(148, 28);
            this.cbCateg.TabIndex = 6;
            this.cbCateg.SelectedIndexChanged += new System.EventHandler(this.cbCateg_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(18, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Выберите категорию:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(22, 103);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(535, 312);
            this.dataGridView1.TabIndex = 10;
            // 
            // lblSparesFor
            // 
            this.lblSparesFor.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSparesFor.Location = new System.Drawing.Point(22, 22);
            this.lblSparesFor.Name = "lblSparesFor";
            this.lblSparesFor.Size = new System.Drawing.Size(535, 37);
            this.lblSparesFor.TabIndex = 2;
            this.lblSparesFor.Text = "Запчасти для";
            this.lblSparesFor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMinus.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMinus.Location = new System.Drawing.Point(516, 429);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(41, 30);
            this.btnMinus.TabIndex = 5;
            this.btnMinus.Text = " -";
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPlus.Font = new System.Drawing.Font("Arial Narrow", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPlus.Location = new System.Drawing.Point(469, 429);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(41, 30);
            this.btnPlus.TabIndex = 4;
            this.btnPlus.Text = " +";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnDeleteSpare
            // 
            this.btnDeleteSpare.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteSpare.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteSpare.Location = new System.Drawing.Point(320, 430);
            this.btnDeleteSpare.Name = "btnDeleteSpare";
            this.btnDeleteSpare.Size = new System.Drawing.Size(143, 30);
            this.btnDeleteSpare.TabIndex = 3;
            this.btnDeleteSpare.Text = " Удаление запчасти";
            this.btnDeleteSpare.UseVisualStyleBackColor = false;
            this.btnDeleteSpare.Click += new System.EventHandler(this.btnDeleteSpare_Click);
            // 
            // btnEditCar
            // 
            this.btnEditCar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditCar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditCar.Location = new System.Drawing.Point(171, 430);
            this.btnEditCar.Name = "btnEditCar";
            this.btnEditCar.Size = new System.Drawing.Size(143, 30);
            this.btnEditCar.TabIndex = 2;
            this.btnEditCar.Text = " Редактирование";
            this.btnEditCar.UseVisualStyleBackColor = false;
            this.btnEditCar.Click += new System.EventHandler(this.btnEditCar_Click);
            // 
            // btnAddSpare
            // 
            this.btnAddSpare.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddSpare.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddSpare.Location = new System.Drawing.Point(22, 430);
            this.btnAddSpare.Name = "btnAddSpare";
            this.btnAddSpare.Size = new System.Drawing.Size(143, 30);
            this.btnAddSpare.TabIndex = 1;
            this.btnAddSpare.Text = " Добавление запчасти";
            this.btnAddSpare.UseVisualStyleBackColor = false;
            this.btnAddSpare.Click += new System.EventHandler(this.btnAddSpare_Click);
            // 
            // btnDeleteCateg
            // 
            this.btnDeleteCateg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteCateg.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDeleteCateg.Location = new System.Drawing.Point(478, 59);
            this.btnDeleteCateg.Name = "btnDeleteCateg";
            this.btnDeleteCateg.Size = new System.Drawing.Size(79, 28);
            this.btnDeleteCateg.TabIndex = 9;
            this.btnDeleteCateg.Text = "Удалить";
            this.btnDeleteCateg.UseVisualStyleBackColor = false;
            this.btnDeleteCateg.Click += new System.EventHandler(this.btnDeleteCateg_Click);
            // 
            // btnEditCateg
            // 
            this.btnEditCateg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditCateg.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditCateg.Location = new System.Drawing.Point(393, 59);
            this.btnEditCateg.Name = "btnEditCateg";
            this.btnEditCateg.Size = new System.Drawing.Size(79, 28);
            this.btnEditCateg.TabIndex = 8;
            this.btnEditCateg.Text = "Изменить";
            this.btnEditCateg.UseVisualStyleBackColor = false;
            this.btnEditCateg.Click += new System.EventHandler(this.btnEditCateg_Click);
            // 
            // btnAddCateg
            // 
            this.btnAddCateg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddCateg.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCateg.Location = new System.Drawing.Point(308, 59);
            this.btnAddCateg.Name = "btnAddCateg";
            this.btnAddCateg.Size = new System.Drawing.Size(79, 28);
            this.btnAddCateg.TabIndex = 7;
            this.btnAddCateg.Text = "Добавить";
            this.btnAddCateg.UseVisualStyleBackColor = false;
            this.btnAddCateg.Click += new System.EventHandler(this.btnAddCateg_Click);
            // 
            // FormSpares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(582, 482);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormSpares";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "АИС «Автосервис»";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbCateg;
        private System.Windows.Forms.Button btnDeleteSpare;
        private System.Windows.Forms.Button btnEditCar;
        private System.Windows.Forms.Button btnAddSpare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblSparesFor;
        private System.Windows.Forms.Button btnDeleteCateg;
        private System.Windows.Forms.Button btnEditCateg;
        private System.Windows.Forms.Button btnAddCateg;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button buttonOK;
    }
}