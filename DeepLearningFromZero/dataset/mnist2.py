# -*- coding: utf-8 -*-

import gzip
import numpy as np
import os
import pickle
import urllib.request

MNIST_TRAN_IMAGE_FILE_NAME = 'train-images-idx3-ubyte.gz'
MNIST_TRAN_LABEL_FILE_NAME = 'train-labels-idx1-ubyte.gz'
MNIST_TEST_IMAGE_FILE_NAME = 't10k-images-idx3-ubyte.gz'
MNIST_TEST_LABEL_FILE_NAME = 't10k-labels-idx1-ubyte.gz'

TRAIN_IMAGE_FILE_NAME = 'train_image.pkl'
TRAIN_LABEL_FILE_NAME = 'train_label.pkl'
TEST_IMAGE_FILE_NAME = 'test_image.pkl'
TEST_LABEL_FILE_NAME = 'test_label.pkl'

IMAGE_SIZE = 784

DATA_SET_DIRECTORY = os.path.dirname(os.path.abspath(__file__))

# MNISTサイトから、ファイルをダウンロードする
def _download_mnist_file(file_name):
    print("Downloading " + file_name + " ... ")
    url = 'http://yann.lecun.com/exdb/mnist/' + file_name
    download_path = DATA_SET_DIRECTORY + '/' + file_name
    urllib.request.urlretrieve(url, download_path)

# MNIST画像ファイルをロードする
# (gzipファイルを展開、ロードし、要素数28x28のbyte配列のリストを返す)
def _load_mnist_image_file(file_name):
    print("loading(unzipping) " + file_name + " ... ")
    with gzip.open(DATA_SET_DIRECTORY + '/' + file_name, 'rb') as f:
            data = np.frombuffer(f.read(), np.uint8, offset=16)
    data = data.reshape(-1, IMAGE_SIZE)
    return data

# MNISTラベル(数字画像の正解を示すもの)ファイルをロードする
# (gzipファイルを展開、ロードし、要素数28x28のbyte配列の配列を返す)
def _load_mnist_label_file(file_name):
    print("loading(unzipping) " + file_name + " ... ")
    with gzip.open(DATA_SET_DIRECTORY + '/' + file_name, 'rb') as f:
            labels = np.frombuffer(f.read(), np.uint8, offset=8)
    return labels

# オブジェクトをpickleファイルとして保存する
def _save_as_pickle_file(obj, file_name):
    with open(DATA_SET_DIRECTORY + '/' + file_name, 'wb') as f:
        pickle.dump(obj, f, -1)

# MNIST画像ファイルをpickleファイルに変換する
def _convert_mnist_image_file_to_pickle_file(mnist_file_name, pickle_file_name):
    images = _load_mnist_image_file(mnist_file_name)
    _save_as_pickle_file(images, pickle_file_name)
    
# MNIST画像ファイルをpickleファイルに変換する
def _convert_mnist_label_file_to_pickle_file(mnist_file_name, pickle_file_name):
    labels = _load_mnist_label_file(mnist_file_name)
    _save_as_pickle_file(labels, pickle_file_name)
    
def _download_mnist_files():
    _download_mnist_file(MNIST_TRAN_IMAGE_FILE_NAME)
    _download_mnist_file(MNIST_TRAN_LABEL_FILE_NAME)
    _download_mnist_file(MNIST_TEST_IMAGE_FILE_NAME)
    _download_mnist_file(MNIST_TEST_LABEL_FILE_NAME)

def _convert_mnist_files_to_pickle_files():
    _convert_mnist_image_file_to_pickle_file(MNIST_TRAN_IMAGE_FILE_NAME, TRAIN_IMAGE_FILE_NAME)
    _convert_mnist_label_file_to_pickle_file(MNIST_TRAN_LABEL_FILE_NAME, TRAIN_LABEL_FILE_NAME)
    _convert_mnist_image_file_to_pickle_file(MNIST_TEST_IMAGE_FILE_NAME, TEST_IMAGE_FILE_NAME)
    _convert_mnist_label_file_to_pickle_file(MNIST_TEST_LABEL_FILE_NAME, TEST_LABEL_FILE_NAME)

def _get_mnist_object(file_name):
    with open(DATA_SET_DIRECTORY + '/' + file_name, 'rb') as f:
        return pickle.load(f)

def get_train_images():
    return pickle.load(TRAIN_IMAGE_FILE_NAME)
    
def get_train_labels():
    return pickle.load(TRAIN_LABEL_FILE_NAME)

def get_test_images():
    return _get_mnist_object(TEST_IMAGE_FILE_NAME)

def get_test_labels():
    return _get_mnist_object(TEST_LABEL_FILE_NAME)

# 指定されたフォルダにpickle形式で保存済みのMNINSTの訓練データセットをロードする。
# return (28x28x1の8bit輝度データ配列の配列と、各画像のラベル(0~9))
def get_train_data_set():
    return (get_train_images(), get_train_labels())

# 指定されたフォルダにpickle形式で保存済みのMNINSTのテスト(評価)データセットをロードする。
# return (28x28x1の8bit輝度データ配列の配列と、各画像のラベル(0~9))
def get_test_data_set(data_set_directory):
    return (get_test_images(), get_test_labels())

if __name__ == '__main__':
    import sys
    print(sys.argv)
    print(len(sys.argv))
    if (len(sys.argv) <= 1) or (sys.argv[1] != 'download'):
        print("specify 'download'")
        exit(1)
    _download_mnist_files()
    _convert_mnist_files_to_pickle_files()
