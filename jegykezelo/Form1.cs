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
        public Form1()
        {
            InitializeComponent();
            
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

        private void button5_Click(object sender, EventArgs e)
        {
            
            if(listBox1.SelectedItem == null)
            {
                MessageBox.Show("Nem választottál ki semmit!");
            }
            else
            {
                listBox2.Items.Add(listBox1.SelectedItem);
                osszar = osszar + ar[nev.IndexOf(listBox1.SelectedItem.ToString())];
                label10.Text =osszar.ToString();
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
    }
}
