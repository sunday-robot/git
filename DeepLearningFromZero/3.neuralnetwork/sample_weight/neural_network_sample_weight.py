# -*- coding: utf-8 -*-
import pickle
import numpy as np

import sys, os
sys.path.append(os.pardir)
from dataset import mnist2
from common.sigmoid import sigmoid
from common.identity import identity
from common.exp1 import exp1


class Layer:

    def __init__(self, w, b):
        self.weight = np.array(w)
        self.bias = np.array(b)


def load_sample_weight():
    with open("sample_weight.pkl", 'rb') as f:
        obj = pickle.load(f)
#     print(obj)
    
    return [
        Layer(obj['W1'], obj['b1']),
        Layer(obj['W2'], obj['b2']),
        Layer(obj['W3'], obj['b3'])]


def forward(nw, x):
    tmp = np.dot(x, nw[0].weight) + nw[0].bias
    tmp = sigmoid(tmp)
    print("first layer[0] = ", tmp[0])
    tmp = np.dot(tmp, nw[1].weight) + nw[1].bias
    tmp = sigmoid(tmp)
    print("second layer[0] = ", tmp[0])
    tmp = np.dot(tmp, nw[2].weight) + nw[2].bias
    print("third layer[0] = ", tmp[0])
    return tmp


def get_max_index(a):
    index = 0
    for i in range(1, a.size):
        if (a[i] > a[index]):
            index = i
    return index


nw = load_sample_weight()
test_images = np.divide(mnist2.get_test_images(), 255.0)
correct_numbers = mnist2.get_test_labels()
for i in range(test_images.shape[0]):    
    forward_result = forward(nw, test_images[i])
    print(forward_result)
    max_index = get_max_index(forward_result)
    print(correct_numbers[i], max_index)
