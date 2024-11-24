using System;
using Veho.Matrix;

namespace Veho.OneBase.Rows {
  public static class Indexer {
    public static T[] RebaseRow<T>(this T[,] matrix, int x) {
      var wd = matrix.Width();
      var row = new T[wd];
      x++;
      for (var j = 0; j < wd;) row[j++] = matrix[x, j];
      return row;
    }
    public static TO[] RebaseRow<T, TO>(this T[,] matrix, int x, Func<T, TO> func) {
      var wd = matrix.Width();
      var row = new TO[wd];
      x++;
      for (var j = 0; j < wd;) row[j] = func(matrix[x, ++j]);
      return row;
    }
  }
}