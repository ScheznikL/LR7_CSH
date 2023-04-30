using System;
using System.Windows.Forms;

namespace LR7_CSH
{
    public partial class DialogGroupCreation : Form
    {
        private bool _editFlag = false;
        private BindingSource _bsGroupData;
        public DialogGroupCreation()
        {
            InitializeComponent();
            DGVStudData.ClearSelection();
            BtDelete.Visible = false;
            _bsGroupData = new BindingSource();
        }

        private void BtAddNewData_Click(object sender, EventArgs e)
        {
            if (!_editFlag)
            {
                if (DGVStudData.Rows.Count <= 1 && DGVStudData.Rows[0].Cells[0].Value == null)
                {                    
                    DialogResult = DialogResult.Cancel;
                    MessageBox.Show("No data to proceed.");
                }
                else
                {
                    Group.CreateNewGroup(DGVStudData.Rows, nUpDGroupNumber.Value);
                }
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
            nUpDGroupNumber.DataBindings.Add("Value", _bsGroupData, "Groupnumber");
        }
        private void BtDelete_Click(object sender, EventArgs e)
        {
            DGVStudData.Rows.Remove(DGVStudData.CurrentRow);
        }
        private void DGVStudData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != DGVStudData.Columns["ID"].Index)
            {
                ValidateUserString.CellValidatingForLetterOnly(sender, e, DGVStudData, out bool isValidContent);
                if (!isValidContent)
                {
                    DGVStudData.Rows[e.RowIndex].ErrorText = "Names mustn't contain any numbers or sumbols.";
                }
            }
            else
            {
                ValidateUserString.CellValidatingForDigitOnly(sender, e, DGVStudData, out bool isValid);
                if (!isValid)
                {
                    DGVStudData.Rows[e.RowIndex].ErrorText = "ID mustn't contain any characters.";
                }
            }
        }
        private void DGVStudData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVStudData.Columns["ID"].Index)
            {
                ValidateUserString.CellValidatingForUniqness(sender, e, DGVStudData, out bool isUniqeContent);
                if (!isUniqeContent)
                {
                    DGVStudData.Rows[e.RowIndex].ErrorText = "Students identification mustn't contain any duplicates.";
                }
            }
        }
    }
}
