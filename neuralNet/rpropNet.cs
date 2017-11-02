using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neuralNet
{
   public class rpropNet
    {
        public double[] err;//num of out
        public double[,] synone, syntwo;//#inputs+1, #neurons; #neurons, #outputs
        public double[] input, output; // #n + 1 
        public double[] medin, medout; //#n
        public double[] sigma, sigmoid; //both #n

        public int neurons = 0;
        public int ii, o;
        public int trainings;

        public double etaPlus = 1.2; //n+
        public double etaMinus = 0.5; //n-
        public double deltaMax = 50.0;
        public double deltaMin = 1.0E-6;

        public Random rand = new Random();

        public double[,] ihWeights;//in-hidden
        public  double[] hBiases;
        public  double[] hOutputs;

        public double[,] hoWeights; // hidden-output
        public double[] oBiases;

        //double[,] hoWeightGradsAcc;
        //double[,] ihWeightGradsAcc;
        //double[] oBiasGradsAcc;
        //double[] hBiasGradsAcc;

        public rpropNet(int ii, int o, int neurons, int trainings)
        {
            this.ii = ii;
            this.o = o;
            this.neurons = neurons;
            this.trainings = trainings;
            
            //ihWeightGradsAcc = new double[ii, neurons];//synoneGrad
            //hoWeightGradsAcc = new double[neurons,o]; //syntwoGrad
            //hBiasGradsAcc = new double[neurons];
            //oBiasGradsAcc = new double[o];

            hBiases = new double[neurons];
            oBiases = new double[o];
            err = new double[o];
            synone = new double[ii + 1, neurons];
            syntwo = new double[neurons, o];
            medin = new double[neurons]; //i-h 
            medout = new double[neurons];
            sigma = new double[neurons];
            sigmoid = new double[neurons];
            input = new double[ii + 1];
            output = new double[o];

            for (int i2 = 0; i2 < ii + 1; i2++)
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
                        syntwo[i, j] = syntwo[i, j];
                    }
                }
            }

        }
        public static void ZeroOut(double[,] d2array)
        {
            for (int i = 0; i < d2array.GetLength(0); ++i)
            {
                for (int j = 0; j < d2array.GetLength(1); ++j)
                {
                    d2array[i, j] = 0.0;
                }
            }
        }
        public static void ZeroOut(double[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = 0.0;
            }
        }
        public double[] evaluate(double[] d)
        {
            for (int i = 0; i < ii; i++)
            {
                input[i] = d[i];
            }
            input[ii] = 1;//bias
            for (int j = 0; j < neurons; j++)//hidden
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
        public int Sign(double v)
        {
            if (Math.Abs(v) < .00000001)
            {
                return 0;
            }
            if (v > 0)
            {
                return 1;
            }
            return -1;
        }
        public static void deltaOut(double[,] d2array) //"zeros out" delta values to .01
        {
            for (int i = 0; i < d2array.GetLength(0); ++i)
            {
                for (int j = 0; j < d2array.GetLength(1); ++j)
                {
                    d2array[i, j] = 0.01;
                }
            }
        }
        public static void deltaOut(double[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = 0.01;
            }
        }
       


        public void train2(double[] i, double[] target)
        {
      // there is an accumulated gradient and a previous gradient for each weight and bias
      double[] hGradTerms = new double[neurons]; // intermediate val for h-o weight gradients
      double[] oGradTerms = new double[o]; // output gradients

      double[,] hoWeightGradsAcc = new double[neurons, o]; // accumulated over all training data
      double[,] ihWeightGradsAcc = new double[ii+1, neurons]; //MakeMatrix(numInput, numHidden, 0.0);
      double[] oBiasGradsAcc = new double[o];
      double[] hBiasGradsAcc = new double[neurons];
      ZeroOut(ihWeightGradsAcc);
      ZeroOut(hoWeightGradsAcc);
      ZeroOut(hBiasGradsAcc);
      ZeroOut(oBiasGradsAcc);

      double[,] hoPrevWeightGradsAcc = new double[neurons,o]; // accumulated, previous iteration
      double[,] ihPrevWeightGradsAcc = new double[ii+1,neurons];//MakeMatrix(numInput, numHidden, 0.0);
      double[] oPrevBiasGradsAcc = new double[o];
      double[] hPrevBiasGradsAcc = new double[neurons];

      // must save previous weight deltas
      double[,] hoPrevWeightDeltas =  new double[neurons,o]; //MakeMatrix(numHidden, numOutput, 0.01);
      double[,] ihPrevWeightDeltas = new double[ii+1,neurons];//MakeMatrix(numInput, numHidden, 0.01);
      double[] oPrevBiasDeltas = new double[o];
      double[] hPrevBiasDeltas =new double[neurons];//0.01 delta
      deltaOut(hoPrevWeightDeltas);
      deltaOut(ihPrevWeightDeltas);
      deltaOut(oPrevBiasDeltas);
      deltaOut(hPrevBiasDeltas);


            double[] actual = evaluate(i);
            //  Console.WriteLine("Actual =" + actual[0]);
            for (int j = 0; j < o; j++)
            {
                err[j] = target[j] - actual[j];
            }
            for (int d = 0; d < o; ++d)
            {
                double derivative = (1 - output[d]) * output[d];
                oGradTerms[d] = derivative * (output[d] - target[d]);
            }
            for (int d = 0; d < neurons; ++d)
            {
                double derivative = (1-medout[d])*(1+medout[d]);
                double sum = 0.0;
                for (int j = 0; j < o; ++j) // each hidden delta is the sum of numOutput terms
                {
                double x = oGradTerms[j] * syntwo[d,j];
                sum += x;
                }
            hGradTerms[d] = derivative * sum;
            }

          // add input to h-o component to make h-o weight gradients, and accumulate
          for (int d = 0; d < neurons; ++d)
          {
            for (int j = 0; j < o; ++j)
            {
              double grad = oGradTerms[j] * medout[d];
              hoWeightGradsAcc[d,j] += grad;
            }
          }

          // the (hidden-to-) output bias gradients
          for (int d = 0; d < o; ++d)
          {
            double grad = oGradTerms[d] * 1.0; // dummy input
            oBiasGradsAcc[d] += grad;
          }

          // add input term to i-h component to make i-h weight gradients and accumulate
          for (int d = 0; d < ii; ++d)//may be ii+1
          {
            for (int j = 0; j < neurons; ++j)
            {
              double grad = hGradTerms[j] * input[d];
              ihWeightGradsAcc[d,j] += grad;
            }
          }

          // the (input-to-) hidden bias gradient
          for (int d = 0; d < neurons; ++d)
          {
            double grad = hGradTerms[d] * 1.0;
            hBiasGradsAcc[d] += grad;
          }
            
                //////////////back propigation
            //    for (int i1 = 0; i1 < o; i1++)
            //    {
            //        for (int j = 0; j < neurons; j++)
            //        {
            //            syntwo[j, i1] = syntwo[j, i1] + (medout[j] * err[i1]);//gradient
            //        }
            //    }
            //for (int i2 = 0; i2 < neurons; i2++)
            //{
            //    sigma[i2] = 0;
            //    for (int j = 0; j < o; j++)
            //    {
            //        sigma[i2] = sigma[i2] + err[j] * syntwo[i2, j];
            //    }
            //    sigmoid[i2] = 1 - Math.Pow((medout[i2]), 2);//der of sigmoid
            //}
            double delta = 0.0;
            for (int i3 = 0; i3 < ii + 1; i3++)
            {
                for (int j = 0; j < neurons; j++)
                {
                    if(ihPrevWeightGradsAcc[i3,j] * ihWeightGradsAcc[i3,j] > 0) //no sign change, ++delta
                    {
                       delta = ihPrevWeightDeltas[i3,j] * etaPlus; // compute delta
                    if (delta > deltaMax) delta = deltaMax; // keep it in range
                    double tmp = -Math.Sign(ihWeightGradsAcc[i3,j]) * delta; // determine direction and magnitude
                    synone[i3,j] += tmp; // update weights
                    }
                     else if (ihPrevWeightGradsAcc[i3,j] * ihWeightGradsAcc[i3,j] < 0) // grad changed sign, decrease delta
                    {
                     delta = ihPrevWeightDeltas[i3,j] * etaMinus; // the delta (not used, but saved for later)
                        if (delta < deltaMin) delta = deltaMin; // keep it in range
                    synone[i3,j] -= ihPrevWeightDeltas[i3,j]; // revert to previous weight
                     ihWeightGradsAcc[i3,j] = 0; // forces next if-then branch, next iteration
                    }
                     else // this happens next iteration after 2nd branch above (just had a change in gradient)
            {
              delta = ihPrevWeightDeltas[i3,j]; // no change to delta
              // no way should delta be 0 . . . 
              double tmp = -Math.Sign(ihWeightGradsAcc[i3,j]) * delta; // determine direction
              synone[i3,j] += tmp; // update
            }
            //Console.WriteLine(ihPrevWeightGradsAcc[i][j] + " " + ihWeightGradsAcc[i][j]); Console.ReadLine();

            ihPrevWeightDeltas[i3,j] = delta; // save delta
            ihPrevWeightGradsAcc[i3,j] = ihWeightGradsAcc[i3,j]; // save the (accumulated) gradient
          } // j
        } // i

        // update (input-to-) hidden biases
        for (int i4 = 0; i4 < neurons; ++i4)
        {
          if (hPrevBiasGradsAcc[i4] * hBiasGradsAcc[i4] > 0) // no sign change, increase delta
          {
            delta = hPrevBiasDeltas[i4] * etaPlus; // compute delta
            if (delta > deltaMax) delta = deltaMax;
            double tmp = -Math.Sign(hBiasGradsAcc[i4]) * delta; // determine direction
            hBiases[i4] += tmp; // update
          }
          else if (hPrevBiasGradsAcc[i4] * hBiasGradsAcc[i4] < 0) // grad changed sign, decrease delta
          {
            delta = hPrevBiasDeltas[i4] * etaMinus; // the delta (not used, but saved later)
            if (delta < deltaMin) delta = deltaMin;
            hBiases[i4] -= hPrevBiasDeltas[i4]; // revert to previous weight
            hBiasGradsAcc[i4] = 0; // forces next branch, next iteration
          }
          else // this happens next iteration after 2nd branch above (just had a change in gradient)
          {
            delta = hPrevBiasDeltas[i4]; // no change to delta

            if (delta > deltaMax) delta = deltaMax;
            else if (delta < deltaMin) delta = deltaMin;
            // no way should delta be 0 . . . 
            double tmp = -Math.Sign(hBiasGradsAcc[i4]) * delta; // determine direction
            hBiases[i4] += tmp; // update
          }
          hPrevBiasDeltas[i4] = delta;
          hPrevBiasGradsAcc[i4] = hBiasGradsAcc[i4];
        }

        // update hidden-to-output weights
        for (int i5 = 0; i5 < neurons; ++i5)
        {
          for (int j = 0; j < o; ++j)
          {
            if (hoPrevWeightGradsAcc[i5,j] * hoWeightGradsAcc[i5,j] > 0) // no sign change, increase delta
            {
              delta = hoPrevWeightDeltas[i5,j] * etaPlus; // compute delta
              if (delta > deltaMax) delta = deltaMax;
              double tmp = -Math.Sign(hoWeightGradsAcc[i5,j]) * delta; // determine direction
              syntwo[i5,j] += tmp; // update from hoWeights
            }
            else if (hoPrevWeightGradsAcc[i5,j] * hoWeightGradsAcc[i5,j] < 0) // grad changed sign, decrease delta
            {
              delta = hoPrevWeightDeltas[i5,j] * etaMinus; // the delta (not used, but saved later)
              if (delta < deltaMin) delta = deltaMin;
              syntwo[i5,j] -= hoPrevWeightDeltas[i5,j]; // revert to previous weight//syntwo
              hoWeightGradsAcc[i5,j] = 0; // forces next branch, next iteration
            }
            else // this happens next iteration after 2nd branch above (just had a change in gradient)
            {
              delta = hoPrevWeightDeltas[i5,j]; // no change to delta
              // no way should delta be 0 . . . 
              double tmp = -Math.Sign(hoWeightGradsAcc[i5,j]) * delta; // determine direction
              syntwo[i5,j] += tmp; // update
            }
            hoPrevWeightDeltas[i5,j] = delta; // save delta
            hoPrevWeightGradsAcc[i5,j] = hoWeightGradsAcc[i5,j]; // save the (accumulated) gradients
          } // j
        } // i

        // update (hidden-to-) output biases
        for (int i6 = 0; i6 < o; ++i6)
        {
          if (oPrevBiasGradsAcc[i6] * oBiasGradsAcc[i6] > 0) // no sign change, increase delta
          {
            delta = oPrevBiasDeltas[i6] * etaPlus; // compute delta
            if (delta > deltaMax) delta = deltaMax;
            double tmp = -Math.Sign(oBiasGradsAcc[i6]) * delta; // determine direction
            oBiases[i6] += tmp; // update
          }
          else if (oPrevBiasGradsAcc[i6] * oBiasGradsAcc[i6] < 0) // grad changed sign, decrease delta
          {
            delta = oPrevBiasDeltas[i6] * etaMinus; // the delta (not used, but saved later)
            if (delta < deltaMin) delta = deltaMin;
            oBiases[i6] -= oPrevBiasDeltas[i6]; // revert to previous weight
            oBiasGradsAcc[i6] = 0; // forces next branch, next iteration
          }
          else // this happens next iteration after 2nd branch above (just had a change in gradient)
          {
            delta = oPrevBiasDeltas[i6]; // no change to delta
            // no way should delta be 0 . . . 
            double tmp = -Math.Sign(hBiasGradsAcc[i6]) * delta; // determine direction
            oBiases[i6] += tmp; // update
          }
          oPrevBiasDeltas[i6] = delta;
          oPrevBiasGradsAcc[i6] = oBiasGradsAcc[i6];
        }
      } // while  
                    

                   // synone[i3, j] = synone[i3, j] + delta; //changes weights

        //public float resilientPropagation(int i, int j)
        //{
        //    float gradientSignChange = sign(prevGradient[i][j] * gradient[i][j]);
        //    float delta = 0;
        //    if (gradientSignChange > 0)
        //    {
        //        float change = Math.min((prevChange[i][j] * increaseFactor), maxDelta);
        //        delta = Sign(gradient[i][j]) * change;
        //        prevChange[i][j] = change;
        //        prevGradient[i][j] = gradient[i][j];
        //    }
        //    else if (gradientSignChange < 0)
        //    {
        //        float change = Math.max((prevChange[i][j] * decreaseFactor), minDelta);
        //        prevChange[i][j] = change;
        //        delta = -prevDelta[i][j];
        //        prevGradient[i][j] = 0;
        //    }
        //    else if (gradientSignChange == 0)
        //    {
        //        float change = prevChange[i][j];
        //        delta = sign(gradient[i][j]) * change;
        //        prevGradient[i][j] = gradient[i][j];
        //    }
        //    prevDelta[i][j] = delta;
        //    return delta;
        //}             
    } 
}
