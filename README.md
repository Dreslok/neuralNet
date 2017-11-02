# ANN-RPROP-Example-CSharp

This ANN demonstration was originally an assignment during my undergrad. After coding the example from 'The (New) Turing Omnibus' book,
I modified it to show the difference in performance when the original backpropagation algorithm is swapped with Resilient Backpropagation.

One problem with the original algorithm is that the partial derivatives’ magnitudes are usually too large or too small to be efficient.
Also, a global training value is less efficient than the RPROP method of assigning and adjusting the training value for each neuron. 
In other words, Rprop takes into account only the sign of the partial derivative over all patterns (not the magnitude), and acts independently on each "weight". 
For each weight, if there was a sign change of the partial derivative of the total error function compared to the last iteration, the update value for that weight is multiplied by a factor η−, where η− < 1.

Issue: Output[0] may be incorrect.

Gradient-Descent Backpropagation - 10 Trainings/Tick
![Control 10 Trainings](https://raw.github.com/Dreslok/neuralNet/master/BackpropDemo.gif)

Resilient Backpropagation - 10 Trainings/Tick

![RPROP 10 Trainings](https://raw.github.com/Dreslok/neuralNet/master/RpropDemo.gif)

RPROP - 1 Training/Tick

![RPROP 1 Tick](https://raw.github.com/Dreslok/neuralNet/master/RpropDemo2.gif)
