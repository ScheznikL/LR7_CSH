﻿namespace LR4_CSH
{
    partial class DialogGroupCreation
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
            this.label1 = new System.Windows.Forms.Label();
            this.DGVStudData = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Firstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nUpDGroupNumber = new System.Windows.Forms.NumericUpDown();
            this.BtAddNewData = new System.Windows.Forms.Button();
            this.BtDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDGroupNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group number";
            // 
            // DGVStudData
            // 
            this.DGVStudData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVStudData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStudData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Lastname,
            this.Firstname});
            this.DGVStudData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGVStudData.Location = new System.Drawing.Point(0, 79);
            this.DGVStudData.Name = "DGVStudData";
            this.DGVStudData.Size = new System.Drawing.Size(545, 178);
            this.DGVStudData.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ID.DataPropertyName = "Id";
            this.ID.HeaderText = "ID";
            this.ID.MaxInputLength = 4;
            this.ID.Name = "ID";
            this.ID.Width = 43;
            // 
            // Lastname
            // 
            this.Lastname.DataPropertyName = "LastName";
            this.Lastname.HeaderText = "Lastname";
            this.Lastname.Name = "Lastname";
            // 
            // Firstname
            // 
            this.Firstname.DataPropertyName = "Name";
            this.Firstname.HeaderText = "Name";
            this.Firstname.Name = "Firstname";
            // 
            // nUpDGroupNumber
            // 
            this.nUpDGroupNumber.Location = new System.Drawing.Point(110, 19);
            this.nUpDGroupNumber.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nUpDGroupNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUpDGroupNumber.Name = "nUpDGroupNumber";
            this.nUpDGroupNumber.Size = new System.Drawing.Size(120, 20);
            this.nUpDGroupNumber.TabIndex = 3;
            this.nUpDGroupNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BtAddNewData
            // 
            this.BtAddNewData.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtAddNewData.Location = new System.Drawing.Point(459, 21);
            this.BtAddNewData.Name = "BtAddNewData";
            this.BtAddNewData.Size = new System.Drawing.Size(74, 23);
            this.BtAddNewData.TabIndex = 4;
            this.BtAddNewData.Text = "OK";
            this.BtAddNewData.UseVisualStyleBackColor = true;
            this.BtAddNewData.Click += new System.EventHandler(this.BtAddNewData_Click);
            // 
            // BtDelete
            // 
            this.BtDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtDelete.Location = new System.Drawing.Point(310, 21);
            this.BtDelete.Name = "BtDelete";
            this.BtDelete.Size = new System.Drawing.Size(74, 23);
            this.BtDelete.TabIndex = 5;
            this.BtDelete.Text = "Delete";
            this.BtDelete.UseVisualStyleBackColor = true;
            this.BtDelete.Click += new System.EventHandler(this.BtDelete_Click);
            // 
            // DialogGroupCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 257);
            this.Controls.Add(this.BtDelete);
            this.Controls.Add(this.BtAddNewData);
            this.Controls.Add(this.nUpDGroupNumber);
            this.Controls.Add(this.DGVStudData);
            this.Controls.Add(this.label1);
            this.Name = "DialogGroupCreation";
            this.ShowIcon = false;
            this.Text = "Enter students data";
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDGroupNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVStudData;
        private System.Windows.Forms.NumericUpDown nUpDGroupNumber;
        private System.Windows.Forms.Button BtAddNewData;
        private System.Windows.Forms.Button BtDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Firstname;
    }
}