using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neuralNet
{
    public partial class Form1 : Form
    {
        public int numN = 30;
        public int rate = 3;


        public neuralNet net = null;
        private DateTime _start = DateTime.Now;
        

        public Form1()
        {
            InitializeComponent();
            init();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.White);
            Graphics g = pictureBox1.CreateGraphics();
            
        }
        public void init()//creates neuralNet obj
        {
            double inputLayerSize = 1.0;
            double outputLayerSize = 1.0;
            neuralNet net = new neuralNet(inputLayerSize, outputLayerSize, numN, rate);
            net.err = new int[(int)net.o];
            net.synone = new double[(int)net.i + 1, net.neurons];
            net.syntwo = new double[net.neurons, (int)net.o];
            net.medin = new double[net.neurons];
            net.medout = new double[net.neurons];
            net.sigma = new double[net.neurons];
            net.sigmoid = new double[net.neurons];

            for (int i = 0; i < net.synone.GetLength(0); i++)
            {
                for (int j = 0; j < net.synone.GetLength(1); j++)
                {
                    net.synone[i, j] = (net.rand.NextDouble() * 0.1);
                }
            }
            for (int i = 0; i < net.syntwo.GetLength(0); i++)
            {
                for (int j = 0; j < net.syntwo.GetLength(1); j++)
                {
                    net.syntwo[i, j] = (net.rand.NextDouble() * 0.1);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //interval = 100ms

            pictureBox1.Refresh();
            time.Text = (DateTime.Now - _start).ToString();
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (net == null)
            {
                init();
            }
            timer1.Enabled = !timer1.Enabled;
            _start = DateTime.Now;
        }

        private void numNeuron_TextChanged(object sender, EventArgs e)
        {  
        int.TryParse(numNeuron.Text, out numN);
        
        }

        private void tRate_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(tRate.Text, out rate);
        }

        private void reset_Click(object sender, EventArgs e)
        {
            init();
        }

        
    }
}
