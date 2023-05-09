using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR7_CSH
{
    public static class FileReader
    {

        public static string ReadFromJSON()
        {
            string jsonString = "";
            string path = FileDialogOpenSave.FileDialogOpenFrom();
            try
            {
                using (StreamReader r = new StreamReader(path))
                {
                    jsonString = r.ReadToEnd();
                    return jsonString;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return jsonString;
        }

    }
}
