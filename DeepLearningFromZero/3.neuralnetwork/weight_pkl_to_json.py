import pickle
import json

def load_weight_pkl(filePath):
    with open(filePath, 'rb') as f:
        obj = pickle.load(f)
    return obj

def save_weight_as_json(obj, filePath):
    with open(filePath, 'w') as f:
        i = 1
        while 1:
            weightIndex = 'W%d' % i
            if weightIndex not in obj:
                break
            weight = obj[weightIndex].tolist()
            bias = obj['b%d' % i].tolist()
    
            w0 = weight[0]
            
            json.dump(weight, f, indent=4, separators='\n')
            json.dump(bias, f)
            i += 1

# numpyのデータ型ではjsonに変換できないらしいので、通常のpythonのデータ型に変換する
def convert_np_weight_to_python_weight(np_weight):
    py_weight = {}
    i = 1
    while 1:
        wi = 'W%d' % i
        if wi not in np_weight:
            break
        bi = 'b%d' % i
        py_weight[wi] = np_weight[wi].tolist()
        py_weight[bi] = np_weight[bi].tolist()
        i += 1
    return py_weight

def save_as_json(obj, filePath):
    with open(filePath, 'w') as f:
            json.dump(obj, f, indent=4)

if __name__ == '__main__':
    weight_pkl = load_weight_pkl("sample_weight.pkl")
    py_weight = convert_np_weight_to_python_weight(weight_pkl)
    save_as_json(py_weight, 'sample_weight.json')
