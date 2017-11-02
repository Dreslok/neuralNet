using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace neuralNet
{
    public partial class Form1 : Form
    {
        public int numN = 100;
        public double rate = 0.1;
        public int trainings = 1000;
        public double goal = 0;
        double radius = 0.8;
        Stopwatch stopwatch = new Stopwatch();
        public rpropNet rnet = null;
        public neuralNet net = null;
        private DateTime _start = DateTime.Now;

        public float heightScale, WidthScale, xtoShow = (float)(2*Math.PI);
        public float minY = 100;
        public float maxY = -100;
        public int width, height;
        public double incrX; 
        public Random r = new Random();
     

        double[] input = new double[2];
        double[] output = new double[1];

        public Form1()
        {
            InitializeComponent();
            
        }
        public double cone(double x, double y)
        {
            double d = Math.Sqrt(x * x + y * y) / radius;
            return Math.Max(0, 1 - d);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (net != null)
            {
                //This code is for drawing sine wave
                //    for (int i = 0; i < pictureBox1.Width; i += 5)
                //    {
                        
                //        double x = ((double)i) / pictureBox1.Width * 2 * Math.PI;
                //        double yExp = Math.Sin(x);
                //        input[0] = x;
                //        double radius = 0.8;
                //        double height = 1;
                //        double yAct = net.evaluate(input)[0];
                //        int yExpPix = (int)((yExp + 1.5) / 3 * pictureBox1.Height);//1.5
                //        int yActPix = (int)((yAct + 1.5) / 3 * pictureBox1.Height);

                //        SolidBrush br = new SolidBrush(Color.White);
                //        g.FillRectangle(br, i, yActPix, 5, 5);

                //        br.Color = Color.Red;
                //        g.FillRectangle(br, i, yExpPix, 5, 5);
                //}
                for (int j = 0; j < 100; j++)// j < 50?
                {
                    for (int k = 0; k < 100; k++)
                    {
                        double xx = (j - 50.0) / 50;
                        double yy = (k - 50.0) / 50;
                        input[0] = xx;
                        input[1] = yy;
                        if (checkBox1.Checked == true)
                        {
                            double zAct = rnet.evaluate(input)[0];
                            double zExp = cone(xx, yy);
                            int c = (int)(zExp * 255);
                            int c1 = (int)(zAct * 255);
                            c1 = Math.Max(0, Math.Min(c1, 255));
                            Brush b1 = new SolidBrush(Color.FromArgb(255, c, c1, c));
                            g.FillRectangle(b1, j * 5, k * 5, 5, 5);
                        }
                        else
                        {
                            double zAct1 = net.evaluate(input)[0];

                            double zExp1 = cone(xx, yy);
                            int c1 = (int)(zExp1 * 255);
                            int c2 = (int)(zAct1 * 255);
                            c2 = Math.Max(0, Math.Min(c2, 255));
                            Brush b1 = new SolidBrush(Color.FromArgb(255, c1, c2, c1));
                            g.FillRectangle(b1, j * 5, k * 5, 5, 5);
                        }
                    }
                }
            }
        }
      
        public void init()//creates neuralNet obj
        {
           
            error.Clear();
            xval.Clear();
            trainings = hTrain.Value;
           
            incrX = 0;
            int inputLayerSize = 2;
            int outputLayerSize = 1;
         
            
              this.rnet = new rpropNet(inputLayerSize, outputLayerSize, numN,trainings);
             this.net = new neuralNet(inputLayerSize, outputLayerSize, numN, rate);
            
        }
        public double getRandom()
        {
            return r.NextDouble() * ((2 * Math.PI));
        }
        public double getRandomCone()
        {
            return r.Next(-1,1);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            stopwatch.Start();
            for (int i = 0; i < trainings; i++)
            {
              
                input[0] = getRandomCone();
                input[1] = getRandomCone();
                output[0] = cone(input[0],input[1]);//cone

                if (checkBox1.Checked == true)
                {
                    //net.train2(input, output);//Standard BackProp
                    rnet.train2(input, output); //
                }
                else net.train2(input,output);
                
            }
                
                    pictureBox1.Refresh();
                    //if (net.err[0] == goal)
                    //{
                    //   timer1.Enabled = !timer1.Enabled;
                    //    MessageBox.Show("Error Goal Reached");
                    //}

                    stopwatch.Stop();
                incrX++;
                error.Text = rnet.err[0].ToString();
                xval.Text = incrX.ToString();
                if (checkBox1.Checked == true)
                {
                    yval.Text = rnet.output[0].ToString();
                }
                else yval.Text = net.output[0].ToString();
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
            double.TryParse(tRate.Text, out rate);
        }

        private void reset_Click(object sender, EventArgs e)
        {
            init();
        }

        private void hTrain_Scroll(object sender, ScrollEventArgs e)
        {
            trainings = hTrain.Value;
            trainLabel.Text ="Trainings: "+ hTrain.Value.ToString();
        }

        private void hNeurons_Scroll(object sender, ScrollEventArgs e)
        {
            numNeuron.Text = hNeurons.Value.ToString();
            numN = hNeurons.Value;
        }

        private void hNoise_Scroll(object sender, ScrollEventArgs e)
        {
            noiseLabel.Text = "Initial Noise: " +hNoise.Value.ToString();
        }

        private void hLearn_Scroll(object sender, ScrollEventArgs e)
        {
            tRate.Text = hLearn.Value.ToString();
            rate = (double)hLearn.Value * .001;
        }

        private void tGoal_TextChanged(object sender, EventArgs e)
        {
            Double.TryParse(tGoal.Text, out goal);
        }

        
    }
}
