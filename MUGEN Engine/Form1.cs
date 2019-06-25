using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUGEN_Engine
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void NewProject()
        {
            NewProject newProject = new NewProject(this);
            newProject.Show();
        }

        public void CreateNewProject(string path, string name)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void progectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProject();
        }
    }
}
