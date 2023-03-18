namespace LR4_CSH
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtCreateNewGroup = new System.Windows.Forms.Button();
            this.BtLoadFromFile = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPersons = new System.Windows.Forms.DataGridView();
            this.dgvPersonalStudData = new System.Windows.Forms.DataGridView();
            this.Subjects = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtSave = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditstudentsMenuI = new System.Windows.Forms.ToolStripMenuItem();
            this.EditsubjectsMenuI = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtForSelection = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalStudData)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtCreateNewGroup);
            this.groupBox1.Controls.Add(this.BtLoadFromFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(290, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(369, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Secect nessesary group";
            // 
            // BtCreateNewGroup
            // 
            this.BtCreateNewGroup.Location = new System.Drawing.Point(282, 19);
            this.BtCreateNewGroup.Name = "BtCreateNewGroup";
            this.BtCreateNewGroup.Size = new System.Drawing.Size(75, 26);
            this.BtCreateNewGroup.TabIndex = 1;
            this.BtCreateNewGroup.Text = "Create new";
            this.BtCreateNewGroup.UseVisualStyleBackColor = true;
            this.BtCreateNewGroup.Click += new System.EventHandler(this.BtCreateNewGroup_Click);
            // 
            // BtLoadFromFile
            // 
            this.BtLoadFromFile.Location = new System.Drawing.Point(6, 19);
            this.BtLoadFromFile.Name = "BtLoadFromFile";
            this.BtLoadFromFile.Size = new System.Drawing.Size(75, 26);
            this.BtLoadFromFile.TabIndex = 0;
            this.BtLoadFromFile.Text = "From File";
            this.BtLoadFromFile.UseVisualStyleBackColor = true;
            this.BtLoadFromFile.Click += new System.EventHandler(this.BtLoadFromFile_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvPersons);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(290, 361);
            this.panel2.TabIndex = 2;
            // 
            // dgvPersons
            // 
            this.dgvPersons.AllowUserToAddRows = false;
            this.dgvPersons.AllowUserToDeleteRows = false;
            this.dgvPersons.AllowUserToResizeRows = false;
            this.dgvPersons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3});
            this.dgvPersons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersons.Location = new System.Drawing.Point(0, 0);
            this.dgvPersons.MultiSelect = false;
            this.dgvPersons.Name = "dgvPersons";
            this.dgvPersons.ReadOnly = true;
            this.dgvPersons.RowHeadersVisible = false;
            this.dgvPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersons.Size = new System.Drawing.Size(290, 361);
            this.dgvPersons.TabIndex = 4;
            this.dgvPersons.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvPersons_MouseClick);
            this.dgvPersons.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvPersons_MouseDoubleClick);
            // 
            // dgvPersonalStudData
            // 
            this.dgvPersonalStudData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonalStudData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Subjects,
            this.Grade});
            this.dgvPersonalStudData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonalStudData.Location = new System.Drawing.Point(0, 0);
            this.dgvPersonalStudData.MultiSelect = false;
            this.dgvPersonalStudData.Name = "dgvPersonalStudData";
            this.dgvPersonalStudData.Size = new System.Drawing.Size(369, 231);
            this.dgvPersonalStudData.TabIndex = 3;
            // 
            // Subjects
            // 
            this.Subjects.DataPropertyName = "Caption";
            this.Subjects.HeaderText = "Subjects";
            this.Subjects.Name = "Subjects";
            // 
            // Grade
            // 
            this.Grade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Grade.DataPropertyName = "Grade";
            this.Grade.HeaderText = "Grades";
            this.Grade.MaxInputLength = 3;
            this.Grade.Name = "Grade";
            this.Grade.Width = 66;
            // 
            // BtSave
            // 
            this.BtSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtSave.Location = new System.Drawing.Point(499, 317);
            this.BtSave.Name = "BtSave";
            this.BtSave.Size = new System.Drawing.Size(160, 44);
            this.BtSave.TabIndex = 4;
            this.BtSave.Text = "Save";
            this.BtSave.UseVisualStyleBackColor = true;
            this.BtSave.Click += new System.EventHandler(this.BtSave_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(290, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(369, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditstudentsMenuI,
            this.EditsubjectsMenuI});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // EditstudentsMenuI
            // 
            this.EditstudentsMenuI.Name = "EditstudentsMenuI";
            this.EditstudentsMenuI.Size = new System.Drawing.Size(180, 22);
            this.EditstudentsMenuI.Text = "Students";
            this.EditstudentsMenuI.Click += new System.EventHandler(this.EditstudentsMenuI_Click);
            // 
            // EditsubjectsMenuI
            // 
            this.EditsubjectsMenuI.Name = "EditsubjectsMenuI";
            this.EditsubjectsMenuI.Size = new System.Drawing.Size(180, 22);
            this.EditsubjectsMenuI.Text = "Add Subjects";
            this.EditsubjectsMenuI.Click += new System.EventHandler(this.EditsubjectsMenuI_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.dgvPersonalStudData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(290, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 231);
            this.panel1.TabIndex = 5;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 43;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LastName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Lastname";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // BtForSelection
            // 
            this.BtForSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtForSelection.BackColor = System.Drawing.Color.Transparent;
            this.BtForSelection.Location = new System.Drawing.Point(290, 317);
            this.BtForSelection.Name = "BtForSelection";
            this.BtForSelection.Size = new System.Drawing.Size(160, 44);
            this.BtForSelection.TabIndex = 6;
            this.BtForSelection.UseVisualStyleBackColor = false;
            this.BtForSelection.Click += new System.EventHandler(this.BtForSelection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 361);
            this.Controls.Add(this.BtSave);
            this.Controls.Add(this.BtForSelection);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Students marks";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalStudData)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtCreateNewGroup;
        private System.Windows.Forms.Button BtLoadFromFile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvPersonalStudData;
        private System.Windows.Forms.DataGridView dgvPersons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.Button BtSave;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditstudentsMenuI;
        private System.Windows.Forms.ToolStripMenuItem EditsubjectsMenuI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button BtForSelection;
    }
}

