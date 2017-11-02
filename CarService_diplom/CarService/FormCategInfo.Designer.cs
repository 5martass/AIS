namespace CarService
{
    partial class FormCategInfo
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
            this.lblSparesFor = new System.Windows.Forms.Label();
            this.tbCategName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddCateg = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSparesFor
            // 
            this.lblSparesFor.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSparesFor.Location = new System.Drawing.Point(12, 21);
            this.lblSparesFor.Name = "lblSparesFor";
            this.lblSparesFor.Size = new System.Drawing.Size(345, 61);
            this.lblSparesFor.TabIndex = 3;
            this.lblSparesFor.Text = "Добавление категории";
            this.lblSparesFor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCategName
            // 
            this.tbCategName.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCategName.Location = new System.Drawing.Point(16, 117);
            this.tbCategName.MaxLength = 20;
            this.tbCategName.Name = "tbCategName";
            this.tbCategName.Size = new System.Drawing.Size(341, 25);
            this.tbCategName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Введите название:";
            // 
            // btnAddCateg
            // 
            this.btnAddCateg.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddCateg.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddCateg.Location = new System.Drawing.Point(33, 158);
            this.btnAddCateg.Name = "btnAddCateg";
            this.btnAddCateg.Size = new System.Drawing.Size(142, 30);
            this.btnAddCateg.TabIndex = 0;
            this.btnAddCateg.Text = "Добавить";
            this.btnAddCateg.UseVisualStyleBackColor = false;
            this.btnAddCateg.Click += new System.EventHandler(this.btnAddCateg_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.Location = new System.Drawing.Point(191, 158);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Отмена";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormCategInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(369, 215);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddCateg);
            this.Controls.Add(this.tbCategName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSparesFor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCategInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "АИС «Автосервис»";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSparesFor;
        private System.Windows.Forms.TextBox tbCategName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddCateg;
        private System.Windows.Forms.Button btnClose;
    }
}