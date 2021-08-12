using System;

namespace Veho.Matrix {
  public static class Reducers {
    public static TO Fold<T, TO>(this T[,] matrix, Func<TO, T, TO> sequence, TO acc) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          acc = sequence(acc, matrix[i, j]);
      return acc;
    }
    public static TO Fold<T, TO>(this T[,] matrix, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = indicator(matrix.First());
      size.RestOf((0, 0), (i, j) => acc = sequence(acc, matrix[i, j]));
      return acc;
    }
    public static T Reduce<T>(this T[,] matrix, Func<T, T, T> sequence) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = matrix.First();
      size.RestOf((0, 0), (i, j) => acc = sequence(acc, matrix[i, j]));
      return acc;
    }
    public static TO Reduce<T, TO>(this T[,] matrix, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = indicator(matrix.First());
      size.RestOf((0, 0), (i, j) => acc = sequence(acc, indicator(matrix[i, j])));
      return acc;
    }

    #region Indexed
    public static TO Fold<T, TO>(this T[,] matrix, Func<int, int, TO, T, TO> sequence, TO acc) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          acc = sequence(i, j, acc, matrix[i, j]);
      return acc;
    }
    public static TO Fold<T, TO>(this T[,] matrix, Func<int, int, TO, T, TO> sequence, Func<T, TO> indicator) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = indicator(matrix.First());
      size.RestOf((0, 0), (i, j) => acc = sequence(i, j, acc, matrix[i, j]));
      return acc;
    }
    public static T Reduce<T>(this T[,] matrix, Func<int, int, T, T, T> sequence) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = matrix.First();
      size.RestOf((0, 0), (i, j) => acc = sequence(i, j, acc, matrix[i, j]));
      return acc;
    }
    public static TO Reduce<T, TO>(this T[,] matrix, Func<int, int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = indicator(matrix.First());
      size.RestOf((0, 0), (i, j) => acc = sequence(i, j, acc, indicator(matrix[i, j])));
      return acc;
    }
    #endregion
  }
}