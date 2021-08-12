using System;

namespace Veho.Rows {
  public static partial class Indexers {
    public static T[] Row<T>(this T[,] matrix, int x, int w = 0) {
      var row = new T[w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) row[j] = matrix[x, j];
      return row;
    }

    public static TO[] Row<T, TO>(this T[,] matrix, int x, Func<T, TO> fn, int w = 0) {
      var row = new TO[w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) row[j] = fn(matrix[x, j]);
      return row;
    }

    public static TO[,] MatrixRow<T, TO>(this T[,] matrix, int x, Func<T, TO> fn, int w = 0) {
      var vec = new TO[1, w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) vec[0, j] = fn(matrix[x, j]);
      return vec;
    }

    #region Indexed
    public static TO[] Row<T, TO>(this T[,] matrix, int x, Func<int, T, TO> fn, int w = 0) {
      var row = new TO[w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) row[j] = fn(j, matrix[x, j]);
      return row;
    }

    public static TO[,] MatrixRow<T, TO>(this T[,] matrix, int x, Func<int, T, TO> fn, int w = 0) {
      var vec = new TO[1, w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) vec[0, j] = fn(j, matrix[x, j]);
      return vec;
    }
    #endregion
  }
}