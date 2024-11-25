using System;
using Veho.Matrix;

namespace Veho.PanBase.Rows {
  public static class Indexer {
    public static T[] RebaseRow<T>(this T[,] matrix, int x = 1) {
      var (ylo, wd) = matrix.YLeap();
      var row = new T[wd];
      for (var j = 0; j < wd; j++) row[j] = matrix[x, ylo + j];
      return row;
    }

    public static TO[] RebaseRow<T, TO>(this T[,] matrix, Func<T, TO> func, int x = 1) {
      var (ylo, wd) = matrix.YLeap();
      var row = new TO[wd];
      for (var j = 0; j < wd; j++) row[j] = func(matrix[x, ylo + j]);
      return row;
    }

    public static TO[] RebaseRow<T, TO>(this T[,] matrix, Func<int, T, TO> func, int x = 1) {
      var (ylo, wd) = matrix.YLeap();
      var row = new TO[wd];
      for (var j = 0; j < wd; j++) row[j] = func(j, matrix[x, ylo + j]);
      return row;
    }
  }
}