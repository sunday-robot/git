'''
Created on 2018/09/24

@author: sgx03
'''
import json

if __name__ == '__main__':
    l = []
    l += [1]
    d = {}
    d['abc'] = 1
    print(json.dumps(l))
    print(json.dumps(d))
    with open('jsondump.json', 'w') as f:
        json.dump(l, f)
        json.dump(d, f)
