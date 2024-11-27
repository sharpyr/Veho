using System;
using System.Threading.Tasks;
using Generic.Math;

// ReSharper disable All

namespace Veho.Matrix {
  public static class LinearOperators {
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
    public static T[,] Multiply<T>(this T[,] aX, T[,] bX) {
      return LinearCross(aX, bX, GenericMath.Multiply, GenericMath.Add);
    }
    public static T[,] LinearCross<T>(this T[,] aX, T[,] bX, Func<T, T, T> zipper, Func<T, T, T> reducer) {
      int height = aX.Height(), interim = aX.Width(), width = bX.Width();
      return height + width >= 12 && interim >= 6
        ? LinearCrossParrallel(aX, bX, zipper, reducer)
        : LinearCrossClassic(aX, bX, zipper, reducer);
    }
    private static TO[,] LinearCrossClassic<T, TO>(T[,] aX, T[,] bX, Func<T, T, TO> zipper, Func<TO, TO, TO> reducer) {
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
    private static TO[,] LinearCrossParrallel<T, TO>(T[,] aX, T[,] bX, Func<T, T, TO> zipper, Func<TO, TO, TO> reducer) {
      int height = aX.Height(), interim = aX.Width(), width = bX.Width();
      var matrix = new TO[height, width];
      if (interim == 0) return matrix;
      Parallel.For(0, height, i => {
        Parallel.For(0, width, j => {
          var tar = zipper(aX[i, 0], bX[0, j]);
          for (var k = 0; k < interim; k++) tar = reducer(tar, zipper(aX[i, k], bX[k, j]));
          matrix[i, j] = tar;
        });
      });
      return matrix;
    }
  }
}