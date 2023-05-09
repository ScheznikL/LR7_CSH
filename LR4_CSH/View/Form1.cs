using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace LR7_CSH
{
    public partial class Form1 : Form
    {
        private BindingSource _bsForSubjects, _bsPersonData;
        private BindingList<Subject> _subjBindList;
        private bool _firstDblCklickFlag = true;
        private bool changingGradeOnExistingSub = false;
        private bool addingNewSubj = false;
        private bool subjectNameWasEddited;

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
            _bsForSubjects = new BindingSource();
            _bsPersonData = new BindingSource();
            _subjBindList = new BindingList<Subject>();
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
        private void BtLoadFromDB_Click(object sender, EventArgs e)
        {
            if (StudentsSubjDBA.LoadData())
            {
                panel1.Visible = true;
                SetBindingsToDisplaySortableList();
                Group.ToSubjectsFromFile();
                BtLoadFromDB.Enabled = false;
            }
        }
        private void SetBindingsToDisplaySortableList()
        {
            SortableBindingList<Student> sortableStuds = new SortableBindingList<Student>(Group.Students);
            _bsPersonData.DataSource = sortableStuds;
            dgvPersons.DataSource = _bsPersonData;
            dgvPersonalStudData.DataSource = _bsForSubjects;
        }
        private void DgvPersons_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPersonalStudData.Visible = true;

            if (_subjBindList.Count > 0)
            {
                _subjBindList.Clear();
            }
            if (dgvPersonalStudData.ReadOnly)
            {
                dgvPersonalStudData.ReadOnly = false;
            }
            var chosenstud = _bsPersonData.Current as Student;
            foreach (var sub in chosenstud.Subjects)
            {
                _subjBindList.Add(sub);
            }
            _bsForSubjects.DataSource = _subjBindList;
            _bsForSubjects.ResetBindings(false);
            ForSelectionEnable();
            _firstDblCklickFlag = false;
        }
        private void BtSave_Click(object sender, EventArgs e)
        {
            var chosenlist = _bsPersonData.Current as Student;
            if (MessageBox.Show("Whould you like to save your changes?", "Save",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var stud in Group.Students.Where(x => x.Id == chosenlist.Id))
                {
                    stud.Subjects = _subjBindList.ToList();
                }
            }
            if (MessageBox.Show("Whould you like to save your changes to Data Base?", "Save to DB",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (changingGradeOnExistingSub)
                {                    
                    StudentsSubjDBA.UpdateSubjectsDBModifyGrade(Convert.ToInt32(chosenlist.Id));
                }
                else if (addingNewSubj)
                {
                    StudentsSubjDBA.SubjectsDBAddSubject(Convert.ToInt32(chosenlist.Id));
                }
                if (subjectNameWasEddited)
                {
                    StudentsSubjDBA.UpdateSubjectsDBModifyName(Convert.ToInt32(chosenlist.Id));
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
                BtForSelection.DataBindings.Add("Text", _bsForSubjects, "Caption");
            }
        }
        private void BtForSelection_Click(object sender, EventArgs e)
        {
            DialogChosenStudViaSub newDialog = new DialogChosenStudViaSub();
            newDialog.ProperShowTitle((_bsForSubjects.Current as Subject).Caption);
            if (newDialog.ShowDialog(this) == DialogResult.OK)
            {
                newDialog.Dispose();
            }
        }
        private void BtDeleteChosenSubject_Click(object sender, EventArgs e)
        {
            StudentsSubjDBA.SubjectsDBDeleteSubject(dgvPersons.CurrentRow.Cells["Id"].Value,
                _bsForSubjects.Current as Subject);
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
        private void jSONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (StudentsSubjDBA.SaveDataFromJSON())
            {
                MessageBox.Show("File saved to Students data base", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void sessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Group.Students.Count > 0)
            {
                if (!StudentsSubjDBA.SaveDataFromCurrentSession())
                {
                    MessageBox.Show("Saving failed", "Error");
                }
            }
            else
            {
                MessageBox.Show("Student list is empty", "Error");
            }
            // TODO Block this "button"
        }
        private void OpenFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Group.Students.Count == 0)
            {
                panel1.Visible = true;
                SerializeJSON.DeserializeStudents(FileDialogOpenSave.FileDialogOpenFrom());
                SetBindingsToDisplaySortableList();
                Group.ToSubjectsFromFile();
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
                    OpenFromToolStripMenuItem_Click(sender, e);
                }
                else
                {
                    ResetStudentsData();
                    OpenFromToolStripMenuItem_Click(sender, e);
                }
            }
        }
        private void DgvPersonalStudData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var currentCell = dgvPersonalStudData.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var currentValue = currentCell.Value == null ? string.Empty : currentCell.Value.ToString();
            var editedValue = e.FormattedValue == null ? string.Empty : e.FormattedValue.ToString();
            if (e.ColumnIndex != dgvPersonalStudData.Columns["Grade"].Index)
            {
                ValidateUserString.CellValidatingForLetterWithSpases(sender, e, dgvPersonalStudData, out bool isValid);
                if (!isValid)
                {
                    dgvPersonalStudData.Rows[e.RowIndex].ErrorText = "Subject name mustn't contain any numbers or sumbols.";
                }
            }
            else
            {
                ValidateUserString.CellValidatingForDigitOnly(sender, e, dgvPersonalStudData, out bool isValid);
                if (!isValid)
                {
                    dgvPersonalStudData.Rows[e.RowIndex].ErrorText = "Grade cannot contain any characters.";
                }
            }          
            if (currentCell.IsInEditMode && e.ColumnIndex == dgvPersonalStudData.Columns["Grade"].Index)
            {
                changingGradeOnExistingSub = false;
                if (currentValue != editedValue && currentValue != "0")
                {
                    changingGradeOnExistingSub = true;
                    StudentsSubjDBA.ListOfChangesSubs.Add(new SubjectStatus(_bsForSubjects.Current as Subject,"ForGrade"));
                }
                else
                {
                    addingNewSubj = true;
                    StudentsSubjDBA.ListOfChangesSubs.Add(new SubjectStatus(_bsForSubjects.Current as Subject,"NewSub"));                    
                }
            }
            else if (e.ColumnIndex == dgvPersonalStudData.Columns["Subjects"].Index)
            {
                if (currentValue != editedValue)
                {
                    StudentsSubjDBA.ListOfChangesSubs.Add(new SubjectStatus(_bsForSubjects.Current as Subject,
                        currentValue, editedValue));
                    subjectNameWasEddited = true;
                }
            }
        }
        private void SaveAndResetStudentsData()
        {
            SerializeJSON.SerializeStudents(FileDialogOpenSave.FileDialogSaveTo());
            Group.Students.Clear();
            Group.Subjects.Clear();
            _bsPersonData.ResetBindings(false);
            _bsForSubjects.ResetBindings(false);
            panel1.Visible = false;
            BtDeleteChosenSubject.Visible = false;
            BtForSelection.Text = "";
            dgvPersonalStudData.Visible = false;
        }
        private void clearDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are sure want to delete all data from Students DB?", "?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (StudentsSubjDBA.ClearDataBase())
                {
                    MessageBox.Show("All data deleted succesfully.");
                }
                else
                {
                    MessageBox.Show("Clearing failed.");
                }
            }
        }
        private void ResetStudentsData()
        {
            Group.Students.Clear();
            Group.Subjects.Clear();
            _bsPersonData.ResetBindings(false);
            _bsForSubjects.ResetBindings(false);
            panel1.Visible = false;
            BtForSelection.Text = "";
            BtDeleteChosenSubject.Visible = false;
            dgvPersonalStudData.Visible = false;
        }
    }
}
