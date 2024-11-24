using System;
using System.Collections.Generic;

namespace Veho.Matrix {
  public static class Iterator {
    public static IEnumerable<T> IntoIter<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          yield return matrix[i, j];
    }

    public static IEnumerable<TO> IntoIter<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          yield return func(matrix[i, j]);
    }

    public static IEnumerable<TO> IntoIter<T, TO>(this T[,] matrix, Func<int, int, T, TO> func) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          yield return func(i, j, matrix[i, j]);
    }
  }
}