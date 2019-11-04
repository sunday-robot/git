# -*- coding: utf-8 -*-

# softmaxで使用する対数関数で、入力値を1以下の正の数に変換する。

import numpy as np

def exp1(inputs):
    max_input = np.max(inputs)
    return np.exp(inputs - max_input)

if __name__ == '__main__':
    x = np.array([1, 2, 3])
    y = exp1(x)
    print(y)
