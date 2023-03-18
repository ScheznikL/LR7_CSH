using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR4_CSH
{
    public partial class DilogSubjects : Form
    {
        private bool flagEdit = false;
        private BindingSource _bs;
        public DilogSubjects()
        {
            InitializeComponent();

            // _bs = new BindingSource();
            //_bs.DataSource = Group.Subjects;
            //dGVSubjData.DataSource = _bs;
        }

        private void BtCreate_Click(object sender, EventArgs e)
        {
            if(!flagEdit)
            {
                Group.CreateNewSubjectsList(dGVSubjData.Rows);
                DialogGroupCreation newDialog = new DialogGroupCreation();
                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (newDialog.ShowDialog(this) == DialogResult.OK) //BtAddNewData
                {
                    newDialog.Dispose();
                    Dispose();
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
    }
}
