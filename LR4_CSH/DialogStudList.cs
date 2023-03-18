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
    public partial class DialogStudList : Form
    {
        public DialogStudList()
        {
            InitializeComponent();
        }

        private void Bt_OK_Click(object sender, EventArgs e)
        {
            //DialogResult.OK == true;
            Dispose();
        }
    }
}
