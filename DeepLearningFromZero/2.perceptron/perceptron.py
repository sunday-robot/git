# -*- coding: utf-8 -*-

def calc(w1, w2, bias, x1, x2):
    tmp = bias + w1 * x1 + w2 * x2
    if (tmp >= 0):
        return 1
    else:
        return 0

def AND(x1, x2):
    return calc(0.5, 0.5, -0.9, x1, x2)

def OR(x1, x2):
    return calc(0.5, 0.5, -0.5, x1, x2)

def NAND(x1, x2):
    return calc(-0.5, -0.5, 0.9, x1, x2)
        
def XOR(x1, x2):
    return AND(OR(x1, x2), NAND(x1, x2))        
        
print(AND(0, 0));
print(AND(0, 1));
print(AND(1, 0));
print(AND(1, 1))
print("")

print(OR(0, 0));
print(OR(0, 1));
print(OR(1, 0));
print(OR(1, 1));
print("")

print(NAND(0, 0));
print(NAND(0, 1));
print(NAND(1, 0));
print(NAND(1, 1));
print("")

print(XOR(0, 0));
print(XOR(0, 1));
print(XOR(1, 0));
print(XOR(1, 1));
print("")

