# -*- coding: utf-8 -*-
import numpy as np


def sigmoid(x):
    return 1 / (1 + np.exp(-x))


if __name__ == '__main__':
    x = np.array([-1.0, 1.0, 2.0])
    y = sigmoid(x)
    print(x)
    print(y)

    import matplotlib.pyplot as plt
    x = np.arange(-5.0, 5.0, 0.1)
    y = sigmoid(x)
    plt.plot(x, y)
    plt.ylim(-0.1, 1.1)
    plt.show()
