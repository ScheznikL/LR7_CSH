namespace LR4_CSH
{
    partial class DilogSubjects
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
            this.dGVSubjData = new System.Windows.Forms.DataGridView();
            this.SubjCaption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hiddengrades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVSubjData)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVSubjData
            // 
            this.dGVSubjData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVSubjData.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dGVSubjData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVSubjData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjCaption,
            this.hiddengrades});
            this.dGVSubjData.Dock = System.Windows.Forms.DockStyle.Top;
            this.dGVSubjData.Location = new System.Drawing.Point(0, 0);
            this.dGVSubjData.Name = "dGVSubjData";
            this.dGVSubjData.Size = new System.Drawing.Size(693, 251);
            this.dGVSubjData.TabIndex = 0;
            this.dGVSubjData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGVSubjData_CellValidating);
            // 
            // SubjCaption
            // 
            this.SubjCaption.DataPropertyName = "Caption";
            this.SubjCaption.HeaderText = "Caption";
            this.SubjCaption.Name = "SubjCaption";
            // 
            // hiddengrades
            // 
            this.hiddengrades.DataPropertyName = "Grade";
            this.hiddengrades.HeaderText = "Grade";
            this.hiddengrades.Name = "hiddengrades";
            this.hiddengrades.Visible = false;
            // 
            // BtCreate
            // 
            this.BtCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtCreate.Location = new System.Drawing.Point(579, 270);
            this.BtCreate.Name = "BtCreate";
            this.BtCreate.Size = new System.Drawing.Size(102, 38);
            this.BtCreate.TabIndex = 1;
            this.BtCreate.Text = "Create";
            this.BtCreate.UseVisualStyleBackColor = true;
            this.BtCreate.Click += new System.EventHandler(this.BtCreate_Click);
            // 
            // DilogSubjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 320);
            this.Controls.Add(this.BtCreate);
            this.Controls.Add(this.dGVSubjData);
            this.Name = "DilogSubjects";
            this.ShowIcon = false;
            this.Text = "Enter nessesary subjects";
            this.Load += new System.EventHandler(this.DilogSubjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVSubjData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVSubjData;
        private System.Windows.Forms.Button BtCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjCaption;
        private System.Windows.Forms.DataGridViewTextBoxColumn hiddengrades;
    }
}