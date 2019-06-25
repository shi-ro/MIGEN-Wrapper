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
    public partial class SpriteMaker : Form
    {
        public List<SingularSprite> loadedSprites = new List<SingularSprite>();
        SingularSprite selectedSprite;
        public SpriteMaker()
        {
            InitializeComponent();
            toolTip1.SetToolTip(label2, "Sprite compression method for 5-bit sprites (32 color)");
            toolTip1.SetToolTip(label3, "Sprite compression method for 8-bit sprites (256 color)");
            toolTip1.SetToolTip(label4, "Sprite compression method for 24-bit sprites (true color)"); 
            toolTip1.SetToolTip(checkBox1, "Sprites are to be decompressed when loaded from disk");
            toolTip1.SetToolTip(checkBox2, "More thorough comparison of sprite files; actual bytes are compared");
            toolTip1.SetToolTip(checkBox3, "Automatically crop sprites before adding to them the SFF file");
            toolTip1.SetToolTip(checkBox4, "Automatically crop sprites before adding to them the SFF file");
            toolTip1.SetToolTip(checkBox5, "More thorough comparison of palette files; actual bytes are compared");
            toolTip1.SetToolTip(checkBox6, "Discard any duplicate palettes that are detected, instead of linking them");
            toolTip1.SetToolTip(checkBox7, "Reverse the order of colors in the palette when loading from an ACT file");
            toolTip1.SetToolTip(checkBox8, "Reverse the order of colors when loading from a PNG file");
        }

        private void EditOptionsRaw()
        {
            string a = "";
            a += $"sprite.compress.5 = {domainUpDown1.Text}\n";
            a += $"sprite.compress.8 = {domainUpDown2.Text}\n";
            a += $"sprite.compress.24 = {domainUpDown3.Text}\n";
            a += $"sprite.decompressonload = {(checkBox1.Checked ? 1 : 0)}\n";
            a += $"sprite.detectduplicates = {(checkBox2.Checked ? 1 : 0)}\n";
            a += $"sprite.autocrop = {(checkBox3.Checked ? 1 : 0)}\n";
            a += $"pal.detectduplicates = {(checkBox4.Checked ? 1 : 0)}\n";
            a += $"pal.discardduplicates = {(checkBox5.Checked ? 1 : 0)}\n";
            a += $"pal.reverseact = {(checkBox6.Checked ? 1 : 0)}\n";
            a += $"pal.reversepng = {(checkBox7.Checked ? 1 : 0)}\n";
            richTextBox1.Text = a;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void SpriteMaker_Load(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "image files (*.png)|*.png|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            EditOptionsRaw();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void domainUpDown3_SelectedItemChanged(object sender, EventArgs e)
        {
            EditOptionsRaw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add image to list
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach(String file in openFileDialog1.FileNames)
                    {
                        SingularSprite ss = new SingularSprite()
                        {
                            image = (Bitmap)Image.FromFile(file),
                            imagePath = file
                        };
                        string name = file.Split('\\')[file.Split('\\').Length - 1];
                        ss.name = name;
                        listBox1.Items.Add(name);
                        loadedSprites.Add(ss);
                        selectedSprite = ss;
                        LoadInformation();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }

        private void LoadInformation()
        {
            pictureBox1.Image = selectedSprite.image;
            richTextBox2.Text = $"P : {selectedSprite.imagePath}\nW : {selectedSprite.image.Width}\nH : {selectedSprite.image.Height}";
            numericUpDown1.Value = selectedSprite.group;
            numericUpDown2.Value = selectedSprite.item;

            if (selectedSprite.colisions.Count>0)
            {
                button3.Enabled = false;
                button4.Enabled = true;
                checkBox8.Enabled = true;
                checkBox9.Enabled = true;
            } else
            {
                button3.Enabled = true;
                button4.Enabled = false;
                checkBox8.Enabled = false;
                checkBox9.Enabled = false;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSprite = loadedSprites[listBox1.SelectedIndex];
            LoadInformation();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //edit colisions
            AddCollision AC = new AddCollision(loadedSprites,selectedSprite);
            AC.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //add collision
            AddCollision AC = new AddCollision(loadedSprites,selectedSprite);
            AC.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            selectedSprite.group = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            selectedSprite.item = (int)numericUpDown2.Value;
        }
    }
}
