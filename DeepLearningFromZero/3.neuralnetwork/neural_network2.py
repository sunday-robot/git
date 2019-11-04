# -*- coding: utf-8 -*-
import numpy as np

class Layer:
    def __init__(self, w, b):
        self.weight = np.array(w)
        self.bias = np.array(b)

    def forward(self, x):
        a = np.dot(x, self.weight) + self.bias
        y = sigmoid(a)
        return y

def create_network():
    nw = [
          Layer([[0.1, 0.3, 0.5], [0.2, 0.4, 0.6]],
                [0.1, 0.2, 0.3]),
          Layer([[0.1, 0.4], [0.2, 0.5], [0.3, 0.6]],
                [0.1, 0.2]),
          Layer([[0.1, 0.3], [0.2, 0.4]],
                [0.1, 0.2])]
    return nw

def forward(nw, x):
    y = nw[0].forward(x)
    for l in nw[1:]:
        y = l.forward(y)
    return identity_function(y)

nw = create_network()
x = np.array([1.0, 0.5])
y = forward(nw, x)
print(y)
