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
            string folderName = Path.GetFileName(eSelectedFolderPath); 
            if (! (Path.Combine(this.eTargetFolderPath,folderName)).Equals(this.eSelectedFolderPath))
            {
                CreateDirectories(this.eSelectedFolderPath, this.eTargetFolderPath);
                MessageBox.Show("Folders have been created.");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("The destination already contains a folder named" + folderName.ToString() + "\nPlease select a new destination");
            }
            
        }

        private void CreateDirectories(string folderPath, string targetPath)
        {
            string folderName = Path.GetFileName(folderPath);
            string newTargetFolder = Path.Combine(targetPath, folderName);

            string[] subDirectoryFolders = Directory.GetDirectories(folderPath);
            if (subDirectoryFolders.Length > 0)
            {
                foreach (string folder in subDirectoryFolders)
                {
                    CreateDirectories(folder, newTargetFolder);
                }
            }
            Directory.CreateDirectory(newTargetFolder);
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
