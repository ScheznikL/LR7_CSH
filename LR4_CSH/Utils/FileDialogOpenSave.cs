using System.Windows.Forms;

namespace LR7_CSH
{
    static class FileDialogOpenSave
    {
        public static string FileDialogOpenFrom()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "json files (*.json)|*.json";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var temp = openFileDialog.SafeFileName;
                    return openFileDialog.FileName;
                }
                else
                {
                    return "";
                }
            }
        }
        public static string FileDialogSaveTo()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "json files (*.json)|*.json";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {               
                MessageBox.Show($"File will be saved to {saveFileDialog1.FileName}");
                return saveFileDialog1.FileName;
            }
            else
            {
                return "";
            }
        }
    }
}
