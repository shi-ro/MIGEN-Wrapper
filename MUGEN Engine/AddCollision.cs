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
    public partial class AddCollision : Form
    {
        public int curBox = 0;
        Bitmap loaded;
        List<ColisionBox> boxes = new List<ColisionBox>();
        ColisionBox currentlyIndexed;
        Color col1 = Color.Blue;
        Color col2 = Color.Red;
        List<SingularSprite> frames;
        SingularSprite currentFrame;
        public AddCollision()
        {
            InitializeComponent();
            button6.Enabled = false;
            button7.Enabled = false;
        }

        public AddCollision(List<SingularSprite> frames, SingularSprite currentFrame)
        {
            this.frames = frames;
            this.currentFrame = currentFrame;
            InitializeComponent();
            UpdateButtonStates();
        }

        private void KeyPressHandler(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
        }

        private void UpdateButtonStates()
        {
            if(frames.IndexOf(currentFrame) == 0)
            {
                button7.Enabled = false;
            } else
            {
                button7.Enabled = true;
            }
            if (frames.IndexOf(currentFrame) == frames.Count - 1)
            {
                button6.Enabled = false;
            }
            else
            {
                button6.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (curBox == 0)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                curBox = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (curBox == 1)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                curBox = 0;
            }
        }
        private void LoadSingularSprite(SingularSprite sp)
        {
            if(sp.colisions.Count>0)
            {
                boxes = sp.colisions;
            }
            Bitmap image = sp.image;
            loaded = image;
            pictureBox1.Image = image;
            trackBar1.Maximum = image.Width - 1;
            trackBar2.Maximum = image.Width - 1;
            trackBar3.Maximum = image.Height - 1;
            trackBar4.Maximum = image.Height - 1;
            trackBar3.Value = image.Height - 1;
            trackBar4.Value = image.Height - 1;
            numericUpDown1.Maximum = image.Width - 1;
            numericUpDown2.Maximum = image.Height - 1;
            numericUpDown4.Maximum = image.Width - 1;
            numericUpDown3.Maximum = image.Height - 1;

            if (sp.colisions.Count>0)
            {
                foreach(ColisionBox cb in sp.colisions.ToList())
                {
                    boxes.Add(cb);
                }
                currentlyIndexed = sp.colisions[0];
            }else
            {
                ColisionBox add = new ColisionBox();
                add.type = curBox == 0 ? 2 : 1;
                boxes.Add(add);
                currentlyIndexed = add;
            }
            textBox1.Text = sp.imagePath;
            numericUpDown2.Value = currentlyIndexed.topY;
            numericUpDown3.Value = currentlyIndexed.botY;
            numericUpDown1.Value = currentlyIndexed.topX;
            numericUpDown4.Value = currentlyIndexed.botX;
        }
        private void LoadFrame(Bitmap image1)
        {
            loaded = image1;
            pictureBox1.Image = image1;
            trackBar1.Maximum = image1.Width - 1;
            trackBar2.Maximum = image1.Width - 1;
            trackBar3.Maximum = image1.Height - 1;
            trackBar4.Maximum = image1.Height - 1;
            trackBar3.Value = image1.Height - 1;
            trackBar4.Value = image1.Height - 1;
            ColisionBox add = new ColisionBox();
            add.type = curBox == 0 ? 2 : 1;
            boxes.Add(add);
            currentlyIndexed = add;
            numericUpDown1.Maximum = image1.Width - 1;
            numericUpDown2.Maximum = image1.Height - 1;
            numericUpDown4.Maximum = image1.Width - 1;
            numericUpDown3.Maximum = image1.Height - 1;
            numericUpDown2.Value = currentlyIndexed.topY;
            numericUpDown3.Value = currentlyIndexed.botY;
            numericUpDown1.Value = currentlyIndexed.topX;
            numericUpDown4.Value = currentlyIndexed.botX;
            string inst = "";
            inst = curBox == 0 ? "Col2" : "Col1";
            listBox1.Items.Add($"{listBox1.Items.Count} {inst}");
            DrawBoxes();
        }
        private void LoadImage(string img)
        {
            LoadFrame((Bitmap)Image.FromFile(img));
        }

        private void AddCollision_Load(object sender, EventArgs e)
        {
            //testload 
            //C:\Users\usagi\Desktop\Self\M.U.G.E.N\mugen\work\kfm\palm05.png 

            KeyPreview = true;
            KeyPress += new KeyPressEventHandler(KeyPressHandler);
            if (curBox==0)
            {
                button1.Enabled = false;
                curBox = 1;
            } 
            else
            {
                button2.Enabled = false;
                curBox = 0;
            }
            if (currentFrame != null)
            {
                LoadSingularSprite(currentFrame);
            }
            else
            {
                LoadImage(@"C:\Users\usagi\Desktop\Self\M.U.G.E.N\mugen\work\kfm\palm05.png");
            }
        }

        private void DrawBoxes()
        {
            Bitmap cop = loaded.Duplicate();
            if (!checkBox1.Checked)
            {
                // draw lines
            }
            if(checkBox3.Checked)
            {
                try
                {

                    Bitmap b = new Bitmap(currentlyIndexed.botX - currentlyIndexed.topX, currentlyIndexed.botY - currentlyIndexed.topY);
                    for (int x = 0; x < b.Width; x++)
                    {
                        for (int y = 0; y < b.Height; y++)
                        {
                            b.SetPixel(x, y, cop.GetPixel(x + currentlyIndexed.topX, y + currentlyIndexed.topY));
                        }
                    }
                    pictureBox2.Image = b;
                }
                catch { }
            }
            if (checkBox1.Checked)
            {
                for (int x = 0; x < cop.Width; x += 3)
                {
                    cop.SetPixel(x, currentlyIndexed.topY, Color.Black);
                    cop.SetPixel(x, currentlyIndexed.botY, Color.Black);
                }
                for (int y = 0; y < cop.Height; y += 3)
                {
                    cop.SetPixel(currentlyIndexed.topX, y, Color.Black);
                    cop.SetPixel(currentlyIndexed.botX, y, Color.Black);
                }
            }
            if (checkBox2.Checked)
            {
                // draw all boxes
                foreach(ColisionBox cb in boxes)
                {
                    if(cb!=currentlyIndexed)
                    {
                        DrawBox(cop, cb, cb.type==1?Color.DarkBlue:Color.DarkRed);
                    }
                }
            }
            DrawBox(cop, currentlyIndexed, currentlyIndexed.type==1?Color.Blue:Color.Red);
            pictureBox1.Image = cop;
        }

        private void DrawBox(Bitmap b, ColisionBox cb, Color c)
        {
            for(int x = cb.topX; x < cb.botX; x++)
            {
                b.SetPixel(x, cb.topY, c);
                b.SetPixel(x, cb.botY, c);
            }
            for(int y = cb.topY; y < cb.botY; y++)
            {
                b.SetPixel(cb.topX, y, c);
                b.SetPixel(cb.botX,y, c);
            }
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            currentlyIndexed.topY = Math.Abs(trackBar3.Maximum-1 - trackBar3.Value);
            numericUpDown2.Value = currentlyIndexed.topY;
            DrawBoxes();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            currentlyIndexed.botY = Math.Abs(trackBar4.Maximum-1 - trackBar4.Value);
            numericUpDown3.Value = currentlyIndexed.botY;
            DrawBoxes();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            currentlyIndexed.topX = trackBar1.Value;
            numericUpDown1.Value = currentlyIndexed.topX;
            DrawBoxes();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            currentlyIndexed.botX = trackBar2.Value;
            numericUpDown4.Value = currentlyIndexed.botX;
            DrawBoxes();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex>-1)
            {
                currentlyIndexed = boxes[listBox1.SelectedIndex];
                numericUpDown2.Value = currentlyIndexed.topY;
                numericUpDown3.Value = currentlyIndexed.botY;
                numericUpDown1.Value = currentlyIndexed.topX;
                numericUpDown4.Value = currentlyIndexed.botX;
                trackBar1.Value = currentlyIndexed.topX;
                trackBar2.Value = currentlyIndexed.botX;
                trackBar3.Value = trackBar3.Maximum - 1 - currentlyIndexed.topY;
                trackBar4.Value = trackBar4.Maximum - 1 - currentlyIndexed.botY;
                DrawBoxes();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColisionBox add = new ColisionBox();
            add.type = curBox == 0 ? 2 : 1;
            boxes.Add(add);
            currentlyIndexed = add;
            numericUpDown2.Value = currentlyIndexed.topY;
            numericUpDown3.Value = currentlyIndexed.botY;
            numericUpDown1.Value = currentlyIndexed.topX;
            numericUpDown4.Value = currentlyIndexed.botX;
            trackBar1.Value = currentlyIndexed.topX;
            trackBar2.Value = currentlyIndexed.botX;
            trackBar3.Value = trackBar3.Maximum - currentlyIndexed.topY;
            trackBar4.Value = trackBar4.Maximum - currentlyIndexed.botY;
            string inst = "";
            inst = curBox == 0 ? "Col2" : "Col1";
            listBox1.Items.Add($"{listBox1.Items.Count} {inst}");
            DrawBoxes();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            DrawBoxes();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DrawBoxes();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            DrawBoxes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                boxes.Remove(currentlyIndexed);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.SelectedIndex = -1;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //back one image
            int idx = frames.IndexOf(currentFrame);
            frames[frames.IndexOf(currentFrame)].colisions = boxes;
            boxes.Clear();
            currentFrame = frames[idx - 1];
            UpdateButtonStates();
            LoadSingularSprite(currentFrame);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //forwards one image
            int idx = frames.IndexOf(currentFrame);
            frames[frames.IndexOf(currentFrame)].colisions = boxes;
            boxes.Clear();
            currentFrame = frames[idx + 1];
            UpdateButtonStates();
            LoadSingularSprite(currentFrame);
        }
    }
}
