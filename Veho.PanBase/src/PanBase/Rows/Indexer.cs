using System;
using Veho.Matrix;

namespace Veho.PanBase.Rows {
  public static class Indexer {
    public static T[] RebaseRow<T>(this T[,] matrix, int x, int w = -1) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      var row = new T[wd];
      for (var j = 0; j < wd; j++) row[j] = matrix[xlo + x, ylo + j];
      return row;
    }

    public static TO[] RebaseRow<T, TO>(this T[,] matrix, int x, Func<T, TO> func) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      var row = new TO[wd];
      for (var j = 0; j < wd; j++) row[j] = func(matrix[xlo + x, ylo + j]);
      return row;
    }

    public static TO[] RebaseRow<T, TO>(this T[,] matrix, int x, Func<int, T, TO> func) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      var row = new TO[wd];
      for (var j = 0; j < wd; j++) row[j] = func(j, matrix[xlo + x, ylo + j]);
      return row;
    }
  }
}