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
    public partial class Form1 : Form
    {
        private BindingSource _bs, _bsPersonData;
        private BindingList<Subject> _bindSublist;
        private bool _clicksave = false;
        private bool _firstdblcklickflag = true;

        public Form1()
        {
            InitializeComponent();
            BtForSelection.Visible = false;
            BtSave.Visible = false;
            BtSave.Dock = DockStyle.Fill;
            dgvPersons.AutoGenerateColumns = false;
            dgvPersonalStudData.ReadOnly = true;
            dgvPersonalStudData.Visible = false;
            panel1.Visible = false;
            _bs = new BindingSource();
            _bsPersonData = new BindingSource();
            _bindSublist = new BindingList<Subject>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //thisform = new Form1();
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

                    BtSave.Visible = true;
                    _bsPersonData.ResetBindings(false);
                    ClearSelection();
                    panel1.Visible = true;
                }
                SortableBindingList<Student> sortablestuds = new SortableBindingList<Student>(Group.Students);
                _bsPersonData.DataSource = sortablestuds;
                dgvPersons.DataSource = _bsPersonData;
                dgvPersonalStudData.DataSource = _bs;
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
            }
        }

        private void BtLoadFromFile_Click(object sender, EventArgs e)
        {
            if (Group.Students.Count == 0)
            {
                panel1.Visible = true;
                SerializeJSON.DeserializeStudents(FileDialogOpenSave.FileDialogOpenFrom());
                /************Twice*************/
                SortableBindingList<Student> sortablestuds = new SortableBindingList<Student>(Group.Students);
                _bsPersonData.DataSource = sortablestuds;
                dgvPersons.DataSource = _bsPersonData;
                dgvPersonalStudData.DataSource = _bs;
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
            }

        }

        private void dgvPersons_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dgvPersons_MouseDoubleClick(object sender, MouseEventArgs e)
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
                _bindSublist.Add(sub); // changes saves in bs possible ? 10/03
            }
            _bs.DataSource = _bindSublist;
            _bs.ResetBindings(false);
            _clicksave = false;
            ForSelectionEnable();
            _firstdblcklickflag = false;
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
                _clicksave = true;
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
                // _bsPersonData.ResetBindings(false);
            }
        }

        private void EditstudentsMenuI_Click(object sender, EventArgs e)
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

        private void ForSelectionEnable()
        {
            if (_firstdblcklickflag)
            {
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
                //Group.ChooseViaSubject((_bs.Current as Subject).Caption);
            }
        }

        private void ClearSelection()
        {
            if (dgvPersons.SelectedRows.Count > 0)
            {
                dgvPersons.ClearSelection();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) //TODO SAVE&FILENAME
        {

        }

        private void SaveAndResetStudentsData()
        {
            SerializeJSON.SerializeStudents(FileDialogOpenSave.FileDialogSaveTo());
            Group.Students.Clear();
            _bsPersonData.ResetBindings(false);
            _bs.ResetBindings(false);
            panel1.Visible = false;
            dgvPersonalStudData.Visible = false;
        }       
    }
}
