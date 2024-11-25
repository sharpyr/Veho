using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.OneBase.Rows {
  public static class Iterator {
    public static IEnumerable<T[]> OffsetRows<T>(this T[,] matrix) {
      var (ht, wd) = matrix.Size();
      for (int i = 1, xhi = ht + 1; i < xhi; i++) {
        var row = new T[ht];
        for (var j = 0; j < wd;) row[j] = matrix[i, ++j];
        yield return row;
      }
      // for (var i = 0; i < ht; i++) yield return matrix.RebaseRow(i, wd);
    }

    public static IEnumerable<TO[]> OffsetRows<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (ht, wd) = matrix.Size();
      for (int i = 1, xhi = ht + 1; i < xhi; i++) {
        var row = new TO[ht];
        for (var j = 0; j < wd;) row[j] = func(matrix[i, ++j]);
        yield return row;
      }
    }

    public static IEnumerable<TO[]> OffsetRows<T, TO>(this T[,] matrix, Func<int, T, TO> func) {
      var (ht, wd) = matrix.Size();
      for (int i = 1, xhi = ht + 1; i < xhi; i++) {
        var row = new TO[ht];
        for (var j = 0; j < wd;) row[j] = func(++j, matrix[i, j]);
        yield return row;
      }
    }

    public static IEnumerable<T> OffsetRowInto<T>(this T[,] matrix, int x = 1) {
      for (int j = 0, wd = matrix.Width(); j < wd;) yield return matrix[x, ++j];
    }

    public static IEnumerable<TO> OffsetIterRow<T, TO>(this T[,] matrix, Func<T, TO> func, int x = 1) {
      for (int j = 0, wd = matrix.Width(); j < wd;) yield return func(matrix[x, ++j]);
    }

    public static IEnumerable<TO> OffsetIterRow<T, TO>(this T[,] matrix, Func<int, T, TO> func, int x = 1) {
      for (int j = 0, wd = matrix.Width(); j < wd;) yield return func(++j, matrix[x, j]);
    }
  }
}