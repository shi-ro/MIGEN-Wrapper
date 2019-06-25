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

namespace MUGEN_Engine
{
    public partial class NewProject : Form
    {
        Form1 mainform;
        string projectPath = "";
        string name = "";
        public NewProject(Form1 mainform)
        {
            this.mainform = mainform;
            this.FormClosed += enc;
            InitializeComponent();
            mainform.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                projectPath = folderBrowserDialog1.SelectedPath;
                textBox1.Text = projectPath;
            }
        }

        private void StartLoading()
        {
            LoadAssitant.LoadProjectBase(projectPath,name);
        }

        private void enc(object sender, EventArgs e)
        {
            mainform.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(projectPath))
            {
                if(name.Length>0)
                {
                    StartLoading();
                    Close();
                }
                else
                {
                    MessageBox.Show($"Specify a name for the project.");
                }
            } else
            {
                MessageBox.Show($"Specified project path \"{textBox1.Text}\" does not exist.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            name = textBox2.Text;
        }
    }
}
