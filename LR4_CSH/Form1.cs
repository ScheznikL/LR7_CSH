using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace LR4_CSH
{
    public partial class Form1 : Form
    {
        private BindingSource _bs, _bsPersonData;
        private BindingList<Subject> _bindSublist;
        private bool _firstDblCklickFlag = true;

        public Form1()
        {
            InitializeComponent();
            BtForSelection.Visible = false;
            BtSave.Visible = false;
            BtDeleteChosenSubject.Visible = false;
            BtSave.Dock = DockStyle.Fill;
            dgvPersons.AutoGenerateColumns = false;
            dgvPersonalStudData.ReadOnly = true;
            dgvPersonalStudData.Visible = false;
            panel1.Visible = false;
            _bs = new BindingSource();
            _bsPersonData = new BindingSource();
            _bindSublist = new BindingList<Subject>();
        }
        private void BtCreateNewGroup_Click(object sender, EventArgs e)
        {
            if (Group.Students.Count == 0)
            {
                DilogSubjects newDialog = new DilogSubjects();
                if (newDialog.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show(this, "Now you can edit the grades of a student or add specific subjects for students.",
                    "Add grades",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);                  
                    ClearSelection();
                    panel1.Visible = true;
                }
                SetBindingsToDisplaySortableList();
            }
            else
            {
                if (
                MessageBox.Show(this, "Whould you like to save current list to file?",
                   "Save",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveAndResetStudentsData();
                    BtCreateNewGroup_Click(sender, e);
                    panel1.Visible = true;
                }
                else
                {
                    ResetStudentsData();
                    BtCreateNewGroup_Click(sender, e);
                }
            }
        }
        private void BtLoadFromFile_Click(object sender, EventArgs e)
        {
            if (Group.Students.Count == 0)
            {
                panel1.Visible = true;
                SerializeJSON.DeserializeStudents(FileDialogOpenSave.FileDialogOpenFrom());       
                SetBindingsToDisplaySortableList();
                Group.ToSubjectsFromDeser();
            }
            else
            {
                if (
                MessageBox.Show(this, "Whould you like to save current list to file?",
                   "Save",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveAndResetStudentsData();
                    BtLoadFromFile_Click(sender, e);
                }
                else
                {
                    ResetStudentsData();
                    BtLoadFromFile_Click(sender, e);
                }
            }

        }
        private void SetBindingsToDisplaySortableList()
        {
            SortableBindingList<Student> sortableStuds = new SortableBindingList<Student>(Group.Students);
            _bsPersonData.DataSource = sortableStuds;
            dgvPersons.DataSource = _bsPersonData;
            dgvPersonalStudData.DataSource = _bs;
        }
        private void DgvPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPersonalStudData.Visible = true;

            if (_bindSublist.Count > 0)
            {
                _bindSublist.Clear();
            }
            if (dgvPersonalStudData.ReadOnly)
            {
                dgvPersonalStudData.ReadOnly = false;
            }
            var chosenstud = _bsPersonData.Current as Student;
            foreach (var sub in chosenstud.Subjects)
            {
                _bindSublist.Add(sub);
            }
            _bs.DataSource = _bindSublist;
            _bs.ResetBindings(false);
            ForSelectionEnable();
            _firstDblCklickFlag = false;
        }
        private void BtSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Whould you like to save your changes?", "Save",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var chosenlist = _bsPersonData.Current as Student;
                foreach (var stud in Group.Students.Where(x => x.Id == chosenlist.Id))
                {
                    stud.Subjects = _bindSublist.ToList();
                }
            }
        }
        private void EditsubjectsMenuI_Click(object sender, EventArgs e)
        {
            DilogSubjects newDialog = new DilogSubjects();
            newDialog.FromEditList();
            if (newDialog.ShowDialog(this) == DialogResult.OK)
            {
                newDialog.Dispose();
                MessageBox.Show(this, "Changes saved.",
                "Chages to subject list",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                BtSave.Visible = true;
                DgvPersons_CellDoubleClick(dgvPersons, new DataGridViewCellEventArgs(dgvPersons.CurrentCell.ColumnIndex, dgvPersons.CurrentRow.Index));
            }
        }
        private void EditstudentsMenuI_Click(object sender, EventArgs e)
        {
            if (Group.Students.Count != 0)
            {
                DialogGroupCreation newDialog = new DialogGroupCreation();
                newDialog.FromStudentEdit();
                if (newDialog.ShowDialog(this) == DialogResult.OK)
                {
                    newDialog.Dispose();
                    MessageBox.Show(this, "Changes saved.",
                    "Chages to student list",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                    BtSave.Visible = true;
                    _bsPersonData.ResetBindings(false);
                }
            }
            else
            {
                MessageBox.Show("Create group or load from file.");
            }
        }
        private void ForSelectionEnable()
        {
            if (_firstDblCklickFlag)
            {
                BtSave.Visible = true;
                BtDeleteChosenSubject.Visible = true;
                BtSave.Visible = true;
                BtSave.Dock = DockStyle.None;
                BtForSelection.Visible = true;
                BtForSelection.DataBindings.Add("Text", _bs, "Caption");
            }
        }
        private void BtForSelection_Click(object sender, EventArgs e)
        {
            DialogChosenStudViaSub newDialog = new DialogChosenStudViaSub();
            newDialog.ProperShowTitle((_bs.Current as Subject).Caption);
            if (newDialog.ShowDialog(this) == DialogResult.OK)
            {
                newDialog.Dispose();
            }
        }
        private void BtDeleteChosenSubject_Click(object sender, EventArgs e)
        {
            dgvPersonalStudData.Rows.Remove(dgvPersonalStudData.CurrentRow);
        }
        private void ClearSelection()
        {
            if (dgvPersons.SelectedRows.Count > 0)
            {
                dgvPersons.ClearSelection();
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Group.Subjects.Count > 0)
            {
                SaveAndResetStudentsData();
            }
        }
        private void OpenFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BtLoadFromFile_Click(sender, e);
        }
        private void DgvPersonalStudData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            bool isValid;
            if (e.ColumnIndex != dgvPersonalStudData.Columns["Grade"].Index)
            {
                ValidateUserString.CellValidatingForLetterWithSpases(sender, e, dgvPersonalStudData, out isValid);
                if (!isValid)
                {
                    dgvPersonalStudData.Rows[e.RowIndex].ErrorText = "Subject name mustn't contain any numbers or sumbols.";
                }
            }
            else
            {
                ValidateUserString.CellValidatingForDigitOnly(sender, e, dgvPersonalStudData, out isValid);
                if (!isValid)
                {
                    dgvPersonalStudData.Rows[e.RowIndex].ErrorText = "Grade cannot contain any characters.";
                }
            }
        }
        private void SaveAndResetStudentsData()
        {
            SerializeJSON.SerializeStudents(FileDialogOpenSave.FileDialogSaveTo());
            Group.Students.Clear();
            Group.Subjects.Clear();
            _bsPersonData.ResetBindings(false);
            _bs.ResetBindings(false);
            panel1.Visible = false;
            BtDeleteChosenSubject.Visible = false;
            BtForSelection.Text = "";
            dgvPersonalStudData.Visible = false;
        }
        private void ResetStudentsData()
        {
            Group.Students.Clear();
            Group.Subjects.Clear();
            _bsPersonData.ResetBindings(false);
            _bs.ResetBindings(false);
            panel1.Visible = false;
            BtForSelection.Text = "";
            BtDeleteChosenSubject.Visible = false;
            dgvPersonalStudData.Visible = false;
        }
    }
}
