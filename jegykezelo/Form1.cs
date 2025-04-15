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
        public static List<int> ar = new List<int>();
        public static List<string> hely = new List<string>();
        public static List<int> datum = new List<int>();
        public Form1()
        {
            InitializeComponent();
            string allomany = "jegyek.txt";
            try
            {
                using (StreamReader reader = new StreamReader(allomany))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null))
                    {

                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Hiba");
            }
        }
    }
}
