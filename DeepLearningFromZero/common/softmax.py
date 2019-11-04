# -*- coding: utf-8 -*-

# 文字認識などの分類型のNNの学習時に有益なものらしい。
# 学習時ではなく推論時には何の意味もない。

import numpy as np
from activationfunction import exp1


def softmax(inputs):
    exp1_inputs = exp1(inputs)
    sum_exp1_inputs = np.sum(exp1_inputs)
    y = exp1_inputs / sum_exp1_inputs
    return y


if __name__ == '__main__':
    x = np.array([1, 2, 3])
    y = softmax(x)
    print(y)
