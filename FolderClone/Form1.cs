using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderClone
{
    public partial class Form1 : Form
    {
        private FolderBrowserDialog eFolderBrowserDialog;
        private string eSelectedFolderPath;
        private string eTargetFolderPath;
        private List<string> folders;

        public Form1()
        {
            InitializeComponent();

            this.Width = 418;
            this.Height = 440;
            this.eFolderBrowserDialog = new FolderBrowserDialog();

            button1.Width = button2.Width = 50;
            button1.Height = button2.Height = 30;
         
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            eFolderBrowserDialog.Description = "Select the directory that you want to clone";
            eFolderBrowserDialog.ShowNewFolderButton = false;
            eFolderBrowserDialog.SelectedPath = @"c:\";
            
            DialogResult result = eFolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.eSelectedFolderPath = label1.Text = eFolderBrowserDialog.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = eFolderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.eTargetFolderPath = label5.Text = eFolderBrowserDialog.SelectedPath; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateDirectories(this.eSelectedFolderPath, this.eTargetFolderPath);
            MessageBox.Show("Folders have been created.");
            this.Dispose();
        }

        private void CreateDirectories(string folderPath, string targetPath)
        {
            string folderName = Path.GetFileName(folderPath);
            string newTargetFolder = Path.Combine(targetPath, folderName);
            Directory.CreateDirectory(newTargetFolder);

            string[] subDirectoryFolders = Directory.GetDirectories(folderPath);
            if (subDirectoryFolders.Length > 0) { 
                foreach (string folder in subDirectoryFolders)
                {
                    CreateDirectories(folder, newTargetFolder);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
