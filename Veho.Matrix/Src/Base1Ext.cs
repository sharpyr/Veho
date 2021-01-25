using System;

namespace Veho.Matrix {
  public static class Base1Ext {
    public static T[,] ZeroOut<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      Array.Copy(matrix, matrix.XLo(), target, 0, matrix.Length);
      return target;
    }

    public static TO[,] ZeroOutMap<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (h, w) = matrix.Size();
      var (xlo, ylo) = (matrix.XLo(), matrix.YLo());
      if (xlo == 0 && ylo == 0) return matrix.Map(func);
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = func(matrix[xlo + i, ylo + j]);
      return target;
    }

    public static TO[,] ZeroOutMap<T, TO>(this T[,] matrix, Func<int, int, T, TO> func) {
      var (h, w) = matrix.Size();
      var (xlo, ylo) = (matrix.XLo(), matrix.YLo());
      if (xlo == 0 && ylo == 0) return matrix.Map(func);
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = func(i, j, matrix[xlo + i, ylo + j]);
      return target;
    }
  }
}