using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neuralNet
{
    public class neuralNet
    {
       public double [] err;//num of out
       public double[,] synone, syntwo;//#inputs+1, #neurons; #neurons, #outputs
       public double[] input,output; // #n + 1 
       public double[] medin, medout; //#n
       public double[] sigma, sigmoid; //both #n


        public int neurons = 0;
        public int ii,o;
       // public double output;
       // public double weight;
        public double rate;
        
        public Random rand = new Random();

        public neuralNet(int ii, int o, int neurons, double rate)
        {
            this.ii = ii;
            this.o = o;
            this.neurons = neurons;
            this.rate = rate;
            
            err = new double[o];
            synone = new double[ii + 1, neurons];
            syntwo = new double[neurons, o];
            medin = new double[neurons];
            medout = new double[neurons];
            sigma = new double[neurons];
            sigmoid = new double[neurons];
            input = new double[ii + 1];
            output = new double[o];

            for (int i2 = 0; i2 < ii+1; i2++)
            {
                for (int j = 0; j < neurons; j++)
                {
                    synone[i2, j] = (rand.NextDouble() * 0.1);
                    int neg = rand.Next(0, 1);
                    if (neg == 0)
                    {
                        synone[i2, j] = synone[i2, j];
                    }
                }
            }
            for (int i = 0; i < syntwo.GetLength(0); i++)
            {
                for (int j = 0; j < syntwo.GetLength(1); j++)
                {
                    syntwo[i, j] = (rand.NextDouble() * 0.1);
                    int neg = rand.Next(0, 1);
                    if (neg == 0)
                    {
                        syntwo[i,j] = syntwo[i,j];
                    }
                }
            }
        
        }
        public double[] evaluate(double[] d)
        {
            for (int i = 0; i < ii; i++)
            {
                input[i] = d[i];
            }
            input[ii] = 1;//bias
                for (int j = 0; j < neurons; j++)
                {
                    medin[j] = 0;
                    for (int k = 0; k < ii + 1; k++)//k less than #inp + 1
                    {
                        medin[j] = medin[j] + synone[k, j] * input[k];
                    }//
                    medout[j] = Math.Tanh(medin[j]);//tan-sigmoid activator
                }
           for (int j = 0; j < o; j++)//output neurons
            {
                output[j] = 0;
                for (int k = 0; k < neurons; k++)
                {
                    output[j] = output[j] + syntwo[k, j] * medout[k];
                }
           }
            return output;
        }

        public void train2(double[] i, double[] target)
        {
            
            double[] actual = evaluate(i);
            //  Console.WriteLine("Actual =" + actual[0]);
            for (int j = 0; j < o; j++)
            {
                err[j] = target[j] - actual[j];
            }
            //////////////back propigation
            for (int i1 = 0; i1 < o; i1++)
            {
                for (int j = 0; j < neurons; j++)
                {
                    syntwo[j, i1] = syntwo[j, i1] + (rate * medout[j] * err[i1]);//changed err[] from i1
                }
            }
            for (int i2 = 0; i2 < neurons; i2++)
            {
                sigma[i2] = 0;
                for (int j = 0; j < o; j++)
                {
                    sigma[i2] = sigma[i2] + err[j] * syntwo[i2, j];
                }
                sigmoid[i2] = 1 - Math.Pow((medout[i2]), 2);//der of sigmoid
            }
            for (int i3 = 0; i3 < ii + 1; i3++)
            {
                for (int j = 0; j < neurons; j++)
                {
                    double delta = rate * sigmoid[j] * sigma[j] * input[i3];
                    synone[i3, j] = synone[i3, j] + delta; //changes weights
                }
            }
        }

        public void train(double [] i,double [] target)
        {
           // Console.WriteLine("i =" + i[0] + " Target = "+target[0]);

           double[] actual = evaluate(i);
         //  Console.WriteLine("Actual =" + actual[0]);
           for (int j = 0; j < o; j++)
           {
               err[j] = target[j] - actual[j];
           }
            //////////////back propigation
            for (int i1 = 0; i1 < o; i1++)
            {
                for (int j = 0; j < neurons; j++)
                {
                    syntwo[j,i1] = syntwo[j,i1] + (rate * medout[j] * err[i1]);//changed err[] from i1
                }
            }
            for (int i2 = 0; i2 < neurons; i2++)
            {
                sigma[i2] = 0;
                for (int j = 0; j < o; j++)
                {
                    sigma[i2] = sigma[i2] + err[j] * syntwo[i2, j];
                }
                sigmoid[i2] = 1 - Math.Pow((medout[i2]), 2);//der of sigmoid
            }
            for (int i3 = 0; i3 < ii+1; i3++)
            {
                for (int j = 0; j < neurons; j++)
                {
                    double delta = rate * sigmoid[j] * sigma[j] * input[i3];
                    synone[i3, j] = synone[i3, j] + delta; //changes weights
                }
            }
        }
    }
}
