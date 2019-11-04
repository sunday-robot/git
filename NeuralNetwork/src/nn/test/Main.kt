package nn.test

import nn.Neuron
import nn.NeuralLayer
import nn.NeuralNetworks


val layers = {NeuralLayer({Neuron(3), Neuron(3)}), NeuroList<Neuron>()
val nn = NewralNetworks(layers)
val output = nn.infer({0,1,2,3})
