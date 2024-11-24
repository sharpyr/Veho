using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.PanBase.Rows {
  public static class Iterator {
    public static IEnumerable<T[]> OffsetRows<T>(this T[,] matrix) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      for (var i = 0; i < ht; i++) {
        var row = new T[wd];
        for (int j = 0, xa = xlo + i; j < wd; j++) row[j] = matrix[xa, ylo + j];
        yield return row;
      }
    }

    public static IEnumerable<TO[]> OffsetRows<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      for (var i = 0; i < ht; i++) {
        var row = new TO[wd];
        for (int j = 0, xa = xlo + i; j < wd; j++) row[j] = func(matrix[xa, ylo + j]);
        yield return row;
      }
    }

    public static IEnumerable<TO[]> OffsetRows<T, TO>(this T[,] matrix, Func<int, T, TO> func) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      for (var i = 0; i < ht; i++) {
        var row = new TO[wd];
        for (int j = 0, xa = xlo + i; j < wd; j++) row[j] = func(ylo + j, matrix[xa, ylo + j]);
        yield return row;
      }
    }

    public static IEnumerable<T> OffsetRowInto<T>(this T[,] matrix, int x) {
      var (xlo, xhi, ylo, yhi) = matrix.Bounds();
      for (int j = ylo, xa = xlo + x; j <= yhi; j++) yield return matrix[xa, j];
    }

    public static IEnumerable<TO> OffsetRowInto<T, TO>(this T[,] matrix, int x, Func<T, TO> func) {
      var (xlo, xhi, ylo, yhi) = matrix.Bounds();
      for (int j = ylo, xa = xlo + x; j <= yhi; j++) yield return func(matrix[xa, j]);
    }

    public static IEnumerable<TO> OffsetRowInto<T, TO>(this T[,] matrix, int x, Func<int, T, TO> func) {
      var (xlo, xhi, ylo, yhi) = matrix.Bounds();
      for (int j = ylo, xa = xlo + x; j <= yhi; j++) yield return func(j, matrix[xa, j]);
    }
  }
}