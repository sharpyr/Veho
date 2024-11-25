using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.PanBase.Columns {
  public static class Iterator {
    public static IEnumerable<T[]> OffsetColumns<T>(this T[,] matrix) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      for (var j = 0; j < wd; j++) {
        var column = new T[ht];
        for (var i = 0; i < ht; i++) column[i] = matrix[xlo + i, ylo + j];
        yield return column;
      }
    }

    public static IEnumerable<TO[]> OffsetColumns<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      for (var j = 0; j < wd; j++) {
        var column = new TO[ht];
        for (var i = 0; i < ht; i++) column[i] = func(matrix[xlo + i, ylo + j]);
        yield return column;
      }
    }

    public static IEnumerable<TO[]> OffsetColumns<T, TO>(this T[,] matrix, Func<int, T, TO> func) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      for (var j = 0; j < wd; j++) {
        var column = new TO[ht];
        for (var i = 0; i < ht; i++) column[i] = func(xlo + i, matrix[xlo + i, ylo + j]);
        yield return column;
      }
    }

    public static IEnumerable<T> OffsetColumnInto<T>(this T[,] matrix, int y = 1) {
      var (xlo, xhi) = matrix.XBound();
      for (var i = xlo; i <= xhi; i++) yield return matrix[i, y];
    }

    public static IEnumerable<TO> OffsetColumnInto<T, TO>(this T[,] matrix, Func<T, TO> func, int y = 1) {
      var (xlo, xhi) = matrix.XBound();
      for (var i = xlo; i <= xhi; i++) yield return func(matrix[i, y]);
    }

    public static IEnumerable<TO> OffsetColumnInto<T, TO>(this T[,] matrix, Func<int, T, TO> func, int y = 1) {
      var (xlo, xhi) = matrix.XBound();
      for (var i = xlo; i <= xhi; i++) yield return func(i, matrix[i, y]);
    }
  }
}