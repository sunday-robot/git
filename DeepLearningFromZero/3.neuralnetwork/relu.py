# -*- coding: utf-8 -*-
import numpy as np

def relu(x):
    return np.maximum(x, 0)

if __name__ == '__main__':
    x = np.array([-1.0, 1.0, 2.0])
    y = relu(x)
    print(x)
    print(y)

    import matplotlib.pyplot as plt
    x = np.arange(-5.0, 5.0, 0.1)
    y = relu(x)
    plt.plot(x, y)
    plt.ylim(-0.1, 1.1)
    plt.show()
