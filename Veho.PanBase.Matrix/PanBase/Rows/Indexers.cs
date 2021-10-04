using System;
using Veho.Matrix;

namespace Veho.PanBase.Rows {
  public static class Indexers {
    public static T[] ZeroOutRow<T>(this T[,] matrix, int x, int w = -1) {
      var row = new T[w < 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) row[j] = matrix[x, j];
      return row;
    }

    public static TO[] ZeroOutRow<T, TO>(this T[,] matrix, int x, Func<T, TO> func, int w = -1) {
      var row = new TO[w < 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) row[j] = func(matrix[x, j]);
      return row;
    }

    public static TO[] ZeroOutRow<T, TO>(this T[,] matrix, int x, Func<int, T, TO> func, int w = -1) {
      var row = new TO[w < 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) row[j] = func(j, matrix[x, j]);
      return row;
    }
  }
}