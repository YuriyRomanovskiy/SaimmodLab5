using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saimmod5
{
    public partial class Form1 : Form
    {
        const float LAMBDA_DEFAULT = 0.2f;
        const float U_DEFAULT = 0.2f;
        const int ITERRATIONS_COUNT = 12000000;

        Manager mg = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            float lambda = LAMBDA_DEFAULT;
            float u = U_DEFAULT;
            int iterrationsCount = ITERRATIONS_COUNT;

            if (!float.TryParse(textBox1.Text, out lambda))
            {
                lambda = LAMBDA_DEFAULT; ;
            }

            if (!float.TryParse(textBox2.Text, out u))
            {
                u = U_DEFAULT; ;
            }

            if (!int.TryParse(textBox3.Text, out iterrationsCount))
            {
                iterrationsCount = ITERRATIONS_COUNT;
            }


            float.TryParse(textBox1.Text, out lambda);

            mg = new Manager();
            mg.OnResultReady += Mg_OnResultReady;

            mg.Process(lambda, u, iterrationsCount);
        }



        void Mg_OnResultReady(String res)
        {
            richTextBox1.Text += res;
            richTextBox1.Text += "\n";
        }
    }
}
