using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neuralNet
{
    public class neuralNet
    {
       public int[] err;//num of out
       public double[,] synone, syntwo;//#inputs+1, #neurons; #neurons, #outputs
       public double[] input,output; // #n + 1 
       public double[] medin, medout; //#n
       public double[] sigma, sigmoid; //both #n


        public int neurons = 0;
        public double i,o;
       // public double output;
       // public double weight;
        public double rate;
        
        public Random rand = new Random();

        public neuralNet(double i, double o, int neurons, double rate)
        {
            this.i = i;
            this.o = o;
            this.neurons = neurons;
            this.rate = rate;
            
        }
        public double[] evaluate(double[] j)//LogSigmoid
        {

            return new double [0];
        }
        public void train(double [] i,double [] eo)
        {//takes sample input, runs through neural net
            //calls evaluate
            //'what does nn think answer is?
            //comp error: how far off answer from expected ans?
            //change val synone,syntwo
            double target = 0; 
            double output = 0;
            for (int j = 1; j < neurons; j++)
            {
                medin[j] = 0;
                for (int k = 1; k < 3; k++)
                {
                    medin[j] = medin[j] + synone[j, k] * i[k];
                }//
                medout[j] = hyperT(medin[j]);//graph this
            }
            for (int j = 1; j < 2; j++)
            {
               // evaluate();
                err[j] = (int)getErr(i[j], eo[j]);
            }
               

           // double error = getErr(target,output);
            //err[j] = err[error];
            //
        }
        public double hyperT(double a)
        {
            if (a < -45.0) return -1.0;
            else if (a > 45.0) return 1.0;
            else return Math.Tanh(a);
            
        }
        public double getErr(double target, double output)
        {
            return target - output;
            
        }
    }
}
