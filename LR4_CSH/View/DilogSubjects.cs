using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7_CSH
{
    public partial class DilogSubjects : Form
    {
        private bool flagEdit = false;
        private BindingSource _bs;
        public DilogSubjects()
        {
            InitializeComponent();
        }

        private void BtCreate_Click(object sender, EventArgs e)
        {
            if(!flagEdit)
            {
                if (dGVSubjData.Rows.Count > 1 && dGVSubjData.Rows[0].Cells[0].Value != null)
                {
                    Group.CreateNewSubjectsList(dGVSubjData.Rows);
                    DialogGroupCreation newDialog = new DialogGroupCreation();
                    if (newDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        newDialog.Dispose();
                        Dispose();
                    }
                    else
                    {
                        DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    DialogResult = DialogResult.Cancel;
                }
            }
            else
            {
                Group.EditSubjectList(dGVSubjData.Rows);
            }
        }

        private void DilogSubjects_Load(object sender, EventArgs e)
        {

        }

        public void FromEditList()
        {
            flagEdit = true;
            BtCreate.Text = "OK";
            _bs = new BindingSource();
            _bs.DataSource = Group.Subjects;
            dGVSubjData.DataSource = _bs;
        }

        private void DGVSubjData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {  
            ValidateUserString.CellValidatingForLetterWithSpases(sender, e, dGVSubjData, out bool isValid);
            if (!isValid)
            {
                dGVSubjData.Rows[e.RowIndex].ErrorText = "Subject name mustn't contain any numbers or sumbols.";
            }                
        }
    }
}
