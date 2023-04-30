using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LR7_CSH
{
    public partial class DialogChosenStudViaSub : Form
    {
        private string chosensubjname;
        public DialogChosenStudViaSub()
        {
            InitializeComponent();
            DGVStudData.AutoGenerateColumns = false;
        }

        public void ProperShowTitle(string subCap)
        {
            Text += " " + subCap;
            chosensubjname = subCap;
        }

        private void DialogChosenStudViaSub_Load(object sender, EventArgs e)
        {
            SortableBindingList<Student> chosenones = new SortableBindingList<Student>();
            foreach (var stud in Group.Students)
            {
                foreach(var sub in stud.Subjects)
                {
                    if(sub.Caption == chosensubjname)
                    {
                        chosenones.Add(stud);
                    }
                }                
            }
            BindingSource binding = new BindingSource();
            binding.DataSource = chosenones;
            DGVStudData.DataSource = binding;
        }

        private void DGVStudData_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {            
                string newLine = Environment.NewLine;
            if (e.RowIndex > -1)
            {
                DataGridViewRow neededrow = DGVStudData.Rows[e.RowIndex];
                var i = ((Student)neededrow.DataBoundItem);
                try
                {
                    e.ToolTipText = $"Subjects:{newLine}{string.Join(newLine,((List<Subject>)neededrow?.Cells["Subjects"].Value)?.Select(x => x.Caption))}";
                }
                catch(Exception ex)
                {
                    var mes = ex.Message;
                    e.ToolTipText = "";
                }                  
            }
            
        }       
    }
}
