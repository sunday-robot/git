using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Rotate {
    class Program {
        static void Main(string[] args) {
            TestCase[] testCases = readInputFile(args[0]);
            for (int i = 0; i < testCases.Length; i++) {
                var testCase = testCases[i];
                var rotatedBoard = rotateBoard(testCase);
                var result = judge(testCase.n, testCase.k, rotatedBoard);

                System.Console.WriteLine("Case #{0}: {1}", i +1, result);
            }
            System.Console.ReadLine();
        }

        static TestCase[] readInputFile(string filePath) {
            using (var sr = new StreamReader(filePath)) {
                int t = int.Parse(sr.ReadLine());
                var testCases = new TestCase[t];
                for (int i = 0; i < t; i++) {
                    var testCase = new TestCase();
                    var f = sr.ReadLine().Split();
                    testCase.n = int.Parse(f[0]);
                    testCase.k = int.Parse(f[1]);
                    testCase.board = new char[testCase.n][];
                    for (int j = 0; j < testCase.n; j++) {
                        testCase.board[j] = sr.ReadLine().ToCharArray();
                    }
                    testCases[i] = testCase;
                }
                return testCases;
            }
        }

        // ボードを時計回りに90度回転させる。(実際に回転させる必要はないので、駒を右に寄せて済ます。)
        static char[][] rotateBoard(TestCase testCase) {
            var rotatedBoard = new char[testCase.n][];
            for (int i = 0; i < testCase.n; i++) {
                rotatedBoard[i] = new char[testCase.n];
                int column = testCase.n - 1;
                for (int j = testCase.n - 1; j >= 0; j--) {
                    var c = testCase.board[i][j];
                    if (c == 'R' || c == 'B') {
                        rotatedBoard[i][column] = c;
                        column--;
                    }
                }
            }
            return rotatedBoard;
        }

        static void getMaximumRanLength(int n, char [][]board, int x0, int y0, int dx, int dy, out int redLength, out int blueLength)        {
            redLength = 0;
            blueLength = 0;
            char previousC;
            char currentC;

            previousC = '\0';
            int x;
            int y;
            for (x = x0, y = y0; x < n && y < n; x += dx; y += dy) {
                currentC = board[x][y];
                if (currentC != previousC)
        }

        static string judge(int n, int k, char[][] board) {
            bool blueWon = false;
            bool redWon = false;

            int ranLength;
            char previousC;
            char currentC;

            #region horizontal
            // 横方向にk個並んでいないかチェック
            for (int i = 0; i < n; i++) {
                ranLength = 0;
                previousC = '\0';  // 初期値は'R', 'B', '.'以外ならなんでも良い
                for (int j = 0; j < n; j++) {
                    currentC = board[i][j];
                    if (currentC == previousC) {
                        ranLength++;
                        if (ranLength >= k) {
                            if (previousC == 'R')
                                redWon = true;
                            else
                                blueWon = true;
                        }
                    } else {
                        previousC = currentC;
                        ranLength = 0;
                    }
                }
            }
            #endregion horizontal

            #region vertical
            // 縦方向にk個並んでいないかチェック
            for (int i = 0; i < n; i++) {
                ranLength = 0;
                previousC = '\0';  // 初期値は'R', 'B', '.'以外ならなんでも良い
                for (int j = 0; j < n; j++) {
                    currentC = board[j][i];
                                        if (currentC == previousC) {
                        ranLength++;
                        if (ranLength >= k) {
                            if (previousC == 'R')
                                redWon = true;
                            else
                                blueWon = true;
                        }
                    } else {
                        previousC = currentC;
                        ranLength = 0;
                    }
                }
            }
            #endregion vertical

            #region lower-left to upper-right
            // 右肩上がり斜めにK個並んでいないかチェック
            // 右下から左に探していく
            for (int i = n - k; i >= 0; i--) {
                ranLength = 0;
                previousC = '\0';  // 初期値は'R', 'B', '.'以外ならなんでも良い
                for (int j = 0; i + j < n; j++) {
                    currentC = board[n - 1 - j][i + j];
                    
            // 左下から上に探していく

            #endregion lower-left to upper-right


            #region upper-left to lower-right
            // 右肩下がり斜めにK個並んでいないかチェック
            #endregion upper-left to lower-right

            if (redWon)
                if (blueWon)
                    return "Both";
                else
                    return "Red";
            else
                if (blueWon)
                    return "Blue";
                else
                    return "Neither";
        }
    }

    class TestCase {
        public int n;
        public int k;
        public char[][] board;
    }

}
