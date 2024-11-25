using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.OneBase.Columns {
  public static class Iterator {
    public static IEnumerable<T[]> OffsetColumns<T>(this T[,] matrix) {
      var (ht, wd) = matrix.Size();
      for (int j = 1, yhi = wd + 1; j < yhi; j++) {
        var col = new T[ht];
        for (var i = 0; i < ht;) col[i] = matrix[++i, j];
        yield return col;
      }
      // for (var j = 0; j < wd; j++) yield return matrix.RebaseColumn(j);
    }

    public static IEnumerable<TO[]> OffsetColumns<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (ht, wd) = matrix.Size();
      for (int j = 1, yhi = wd + 1; j < yhi; j++) {
        var col = new TO[ht];
        for (var i = 0; i < ht;) col[i] = func(matrix[++i, j]);
        yield return col;
      }
      // for (var j = 0; j < wd; j++) yield return matrix.RebaseColumn(j, x => x);
    }

    public static IEnumerable<TO[]> OffsetColumns<T, TO>(this T[,] matrix, Func<int, T, TO> func) {
      var (ht, wd) = matrix.Size();
      for (int j = 1, yhi = wd + 1; j < yhi; j++) {
        var col = new TO[ht];
        for (var i = 0; i < ht;) col[i] = func(++i, matrix[i, j]);
        yield return col;
      }
    }

    public static IEnumerable<T> OffsetColumnInto<T>(this T[,] matrix, int y = 1) {
      for (int i = 0, ht = matrix.Height(); i < ht;) yield return matrix[++i, y];
    }

    public static IEnumerable<TO> OffsetColumnInto<T, TO>(this T[,] matrix, Func<T, TO> func, int y = 1) {
      for (int i = 0, ht = matrix.Height(); i < ht;) yield return func(matrix[++i, y]);
    }

    public static IEnumerable<TO> OffsetColumnInto<T, TO>(this T[,] matrix, Func<int, T, TO> func, int y = 1) {
      for (int i = 0, ht = matrix.Height(); i < ht;) yield return func(++i, matrix[i, y]);
    }
  }
}