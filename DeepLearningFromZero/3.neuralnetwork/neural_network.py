# -*- coding: utf-8 -*-
import numpy as np

def create_network():
    nw = {}
    nw['w1'] = np.array([[0.1, 0.3, 0.5], [0.2, 0.4, 0.6]])
    nw['b1'] = np.array([0.1, 0.2, 0.3])
    nw['w2'] = np.array([[0.1, 0.4], [0.2, 0.5], [0.3, 0.6]])
    nw['b2'] = np.array([0.1, 0.2])
    nw['w3'] = np.array([[0.1, 0.3], [0.2, 0.4]])
    nw['b3'] = np.array([0.1, 0.2])
    return nw

def forward(nw, x):
    from sigmoid_function import sigmoid
    a1 = np.dot(x, nw['w1']) + nw['b1']
    z1 = sigmoid(a1)
    a2 = np.dot(z1, nw['w2']) + nw['b2']
    z2 = sigmoid(a2)
    a3 = np.dot(z2, nw['w3']) + nw['b3']
    y = sigmoid(a3)
    return y

nw = create_network()
x = np.array([1.0, 0.5])
y = forward(nw, x)
print(y)
