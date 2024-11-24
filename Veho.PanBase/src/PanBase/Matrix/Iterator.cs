using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.PanBase.Matrix {
  public static class Iterator {
    public static IEnumerable<T> OffsetInto<T>(this T[,] matrix) {
      var (xlo, xhi, ylo, yhi) = matrix.Bounds();
      for (var i = xlo; i <= xhi; i++)
        for (var j = ylo; j <= yhi; j++)
          yield return matrix[i, j];
    }

    public static IEnumerable<TO> OffsetInto<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (xlo, xhi, ylo, yhi) = matrix.Bounds();
      for (var i = xlo; i <= xhi; i++)
        for (var j = ylo; j <= yhi; j++)
          yield return func(matrix[i, j]);
    }

    public static IEnumerable<TO> OffsetInto<T, TO>(this T[,] matrix, Func<int, int, T, TO> func) {
      var (xlo, xhi, ylo, yhi) = matrix.Bounds();
      for (var i = xlo; i <= xhi; i++)
        for (var j = ylo; j <= yhi; j++)
          yield return func(i, j, matrix[i, j]);
    }
  }
}