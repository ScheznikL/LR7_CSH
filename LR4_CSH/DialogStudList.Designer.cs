namespace LR4_CSH
{
    partial class DialogStudList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Bt_OK = new System.Windows.Forms.Button();
            this.Bt_CANCEL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(822, 238);
            this.dataGridView1.TabIndex = 0;
            // 
            // Bt_OK
            // 
            this.Bt_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Bt_OK.Location = new System.Drawing.Point(701, 281);
            this.Bt_OK.Name = "Bt_OK";
            this.Bt_OK.Size = new System.Drawing.Size(121, 23);
            this.Bt_OK.TabIndex = 1;
            this.Bt_OK.Text = "OK";
            this.Bt_OK.UseVisualStyleBackColor = true;
            this.Bt_OK.Click += new System.EventHandler(this.Bt_OK_Click);
            // 
            // Bt_CANCEL
            // 
            this.Bt_CANCEL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Bt_CANCEL.Location = new System.Drawing.Point(0, 281);
            this.Bt_CANCEL.Name = "Bt_CANCEL";
            this.Bt_CANCEL.Size = new System.Drawing.Size(121, 23);
            this.Bt_CANCEL.TabIndex = 2;
            this.Bt_CANCEL.Text = "Cancel";
            this.Bt_CANCEL.UseVisualStyleBackColor = true;
            // 
            // DialogStudList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 321);
            this.Controls.Add(this.Bt_CANCEL);
            this.Controls.Add(this.Bt_OK);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DialogStudList";
            this.ShowIcon = false;
            this.Text = "Edit Student List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Bt_OK;
        private System.Windows.Forms.Button Bt_CANCEL;
    }
}