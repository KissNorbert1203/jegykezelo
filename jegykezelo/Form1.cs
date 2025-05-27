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

namespace jegykezelo
{
    public partial class Form1 : Form
    {
        public static List<string> nev = new List<string>();
        public static List<string> tipus = new List<string>();
        public static List<string> egyediTipus = new List<string>();
        public static List<int> ar = new List<int>();
        public static List<string> hely = new List<string>();
        public static List<string> datum = new List<string>();

        public static int osszar  = 0;
        public static int fo = 0;


        public Form1()
        {
            InitializeComponent();
            DateTimePicker dateTimePicker1 = new DateTimePicker();
            //számformátum beállítása
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new System.Drawing.Point(10, 10);
            Convert.ToInt32(numericUpDown4.Value);
            listBox1.Sorted = true;
            listBox3.Sorted = true;
            
            
            string allomany = "jegyek.txt";
            try
            {
                using (StreamReader reader = new StreamReader(allomany))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] adatok = line.Split(';');
                        nev.Add(adatok[0]);
                        tipus.Add(adatok[1]);

                        
                        ar.Add(Convert.ToInt32(adatok[2]));
                        hely.Add(adatok[3]);
                        datum.Add(adatok[4]);
                    }
                }
                for (int i = 0; i < tipus.Count; i++)
                {
                    if (!egyediTipus.Contains(tipus[i]))
                    {
                        egyediTipus.Add(tipus[i]);
                        comboBox1.Items.Add(tipus[i]);
                        comboBox2.Items.Add(tipus[i]);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Hiba");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < nev.Count; i++)
            {
                listBox1.Items.Add($"{nev[i]}");
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < tipus.Count; i++)
            {
                if (tipus[i] == comboBox1.SelectedItem.ToString())
                {
                    listBox1.Items.Add(nev[i]);
                }
            }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < nev.Count; i++)
            {
                if (nev[i].Contains(textBox1.Text))
                {
                    listBox1.Items.Add(nev[i]);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int felso = Convert.ToInt32(numericUpDown1.Value);
            int also = Convert.ToInt32(numericUpDown2.Value);
            for(int i = 0;i < ar.Count; i++)
            {
                if (ar[i] > also && ar[i] < felso)
                {
                    listBox1.Items.Add(nev[i]);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label12.Text = hely[nev.IndexOf(listBox1.SelectedItem.ToString())];
            label11.Text = ar[nev.IndexOf(listBox1.SelectedItem.ToString())].ToString() + " Ft";
            label21.Text = datum[nev.IndexOf(listBox1.SelectedItem.ToString())];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            for (int i = 0; i < nev.Count; i++)
            {
                listBox3.Items.Add($"{nev[i]}");

            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            fo = Convert.ToInt32(numericUpDown3.Value);
            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Nem választottad ki a rendezvényt!");
            }
            else if (radioButton4.Checked == false && radioButton5.Checked == false && radioButton6.Checked == false)
            {
                MessageBox.Show("Válaszd ki a helyszínt!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Nem írtál nevet!");
            }
            else
            {
                if (radioButton6.Checked == true)
                {
                    osszar += 1000;
                }
                if (checkBox3.Checked == true)
                {
                    osszar += 990;
                }
                if (checkBox4.Checked == true)
                {
                    osszar += 590;
                }
                listBox2.Items.Add($"{fo} főre {listBox3.SelectedItem}, {textBox2.Text} néven, {datum[nev.IndexOf(listBox3.SelectedItem.ToString())]}");
                osszar = fo * (osszar + ar[nev.IndexOf(listBox3.SelectedItem.ToString())]);
                label10.Text = $"{osszar.ToString()} Ft";
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string filePath = "meglevoJegyek.txt";

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    writer.WriteLine($"{listBox2.Items[i]};{label10.Text}; ");
                }
            }
            MessageBox.Show("Sikeresen lefoglaltad a jegyet és naplóztam is");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void betűttípusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //változóba bekerül a kiválasztott szín neve vagy RGB kódja
                Color selectedColor = colorDialog1.Color;
                MessageBox.Show($"A választott szín: {selectedColor}", "Betűszín kiválasztva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ForeColor = selectedColor;
            }
        }

        private void betűtípusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = fontDialog1.Font;
                MessageBox.Show($"A választott betűtípus: {selectedFont.Name}, { selectedFont.Size}pt", "Betűtípus kiválasztva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label1.Font = selectedFont;
                label2.Font = selectedFont;
                label3.Font = selectedFont;
                label4.Font = selectedFont;
                label5.Font = selectedFont;
                label7.Font = selectedFont;
                label8.Font = selectedFont;
                label9.Font = selectedFont;
                label10.Font = selectedFont;
                label11.Font = selectedFont;
                label12.Font = selectedFont;
                label13.Font = selectedFont;
                label14.Font = selectedFont;
                label15.Font = selectedFont;
                label16.Font = selectedFont;
                label17.Font = selectedFont;
                label18.Font = selectedFont;
                label19.Font = selectedFont;
                label20.Font = selectedFont;
                label21.Font = selectedFont;
                radioButton4.Font = selectedFont;
                radioButton5.Font = selectedFont;
                radioButton6.Font = selectedFont;
                checkBox3.Font = selectedFont;
                checkBox4.Font = selectedFont;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fajl = "jegyek.txt";
            if (textBox3.Text == "")
            {
                MessageBox.Show("Nem adtál meg nevet!");
            }
            else if(numericUpDown4.Value == 0)
            {
                MessageBox.Show("Nem adtál meg árat!");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Nem adtál meg helyet!");
            }
            else if(comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Nem adtál meg típust");
            }
            else
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(fajl, append: true))
                    {
                        writer.WriteLine($"{textBox3.Text};{comboBox2.SelectedItem.ToString()};{numericUpDown4.Value};{textBox4.Text};{dateTimePicker1.Value.ToShortDateString()}");
                        MessageBox.Show("A rendezvény hozzá lett adva a listához");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba", ex.Message);
                }
            }
            
        }
    }
}
