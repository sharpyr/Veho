using System;

namespace Veho.Matrix {
  public static class LinearOperator {
        public static T[,] Cross<T>(this T[,] aX, T[,] bX, Func<T, T, T> func, int interimIndex = 0) {
          int height = aX.Height(), width = bX.Width();
          var matrix = new T[height, width];
          for (var i = 0; i < height; i++) {
            for (var j = 0; j < width; j++) {
              matrix[i, j] = func(aX[i, interimIndex], bX[interimIndex, j]);
            }
          }
          return matrix;
        }
        public static TOut[,] Cross<TA, TB, TOut>(this TA[,] aX, TB[,] bX, Func<TA, TB, TOut> func, int interimIndex = 0) {
          int height = aX.Height(), width = bX.Width();
          var matrix = new TOut[height, width];
          for (var i = 0; i < height; i++) {
            for (var j = 0; j < width; j++) {
              matrix[i, j] = func(aX[i, interimIndex], bX[interimIndex, j]);
            }
          }
          return matrix;
        }
        public static TO[,] LinearCross<T, TO>(T[,] aX, T[,] bX, Func<T, T, TO> zipper, Func<TO, TO, TO> reducer) {
          int height = aX.Height(), interim = aX.Width(), width = bX.Width();
          var matrix = new TO[height, width];
          if (interim == 0) return matrix;
          for (var i = 0; i < height; i++) {
            for (var j = 0; j < width; j++) {
              var tar = zipper(aX[i, 0], bX[0, j]);
              for (var k = 0; k < interim; k++) tar = reducer(tar, zipper(aX[i, k], bX[k, j]));
              matrix[i, j] = tar;
            }
          }
          return matrix;
        }
  }
}