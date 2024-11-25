using System;
using Veho.Matrix;

namespace Veho.OneBase.Rows {
  public static class Indexer {
    public static T[] RebaseRow<T>(this T[,] matrix, int x = 1) {
      var wd = matrix.Width();
      var row = new T[wd];
      for (var j = 0; j < wd;) row[j] = matrix[x, ++j];
      return row;
    }

    public static TO[] RebaseRow<T, TO>(this T[,] matrix, Func<T, TO> func, int x = 1) {
      var wd = matrix.Width();
      var row = new TO[wd];
      for (var j = 0; j < wd;) row[j] = func(matrix[x, ++j]);
      return row;
    }

    public static TO[] RebaseRow<T, TO>(this T[,] matrix, Func<int, T, TO> func, int x = 1) {
      var wd = matrix.Width();
      var row = new TO[wd];
      for (var j = 0; j < wd;) row[j] = func(++j, matrix[x, j]);
      return row;
    }
  }
}