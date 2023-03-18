using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR4_CSH
{
    public partial class DialogGroupCreation : Form
    {
        private bool _editFlag = false;
        private BindingSource _bsGroupData;
        //  private List<Person> _puplsList;
        public DialogGroupCreation()
        {
            InitializeComponent();
            BtDelete.Visible = false;
            _bsGroupData = new BindingSource();
        }

        private void BtAddNewData_Click(object sender, EventArgs e)
        {
            if (!_editFlag)
            {
                Group.CreateNewGroup(DGVStudData.Rows, nUpDGroupNumber.Value);
                //DilogSubjects newDialog = new DilogSubjects();
                //// Show testDialog as a modal dialog and determine if DialogResult = OK.
                //if (newDialog.ShowDialog(this) == DialogResult.OK) //BtAddNewData
                //{
                //    newDialog.Dispose();
                //    Dispose();
                //}
            }
            else
            {
                Group.EditStudentList();
            }
        }
        public void FromStudentEdit()
        {
            Text = "Edit students data";
            _editFlag = true;
            BtDelete.Visible = true;
            nUpDGroupNumber.ReadOnly = true;
            nUpDGroupNumber.Enabled = false;
            DGVStudData.AutoGenerateColumns = false;
            _bsGroupData.DataSource = Group.Students;
            DGVStudData.DataSource = _bsGroupData;
            nUpDGroupNumber.DataBindings.Add("Value", _bsGroupData, "Groupnumber"); //Students.
        }
        private void BtDelete_Click(object sender, EventArgs e)
        {
            DGVStudData.Rows.Remove(DGVStudData.CurrentRow);
        }
    }
}
