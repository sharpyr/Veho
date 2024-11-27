using System;

namespace Veho.Matrix {
  public static class Reducer {
    public static TO Fold<T, TO>(this T[,] matrix, Func<TO, T, TO> fold, TO acc) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          acc = fold(acc, matrix[i, j]);
      return acc;
    }
    public static TO Fold<T, TO>(this T[,] matrix, Func<TO, T, TO> fold, Func<T, TO> to) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = to(matrix.First());
      size.RestOf((0, 0), (i, j) => acc = fold(acc, matrix[i, j]));
      return acc;
    }
    public static T Reduce<T>(this T[,] matrix, Func<T, T, T> fold) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = matrix.First();
      size.RestOf((0, 0), (i, j) => acc = fold(acc, matrix[i, j]));
      return acc;
    }
    public static TO Reduce<T, TO>(this T[,] matrix, Func<TO, TO, TO> fold, Func<T, TO> to) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = to(matrix.First());
      size.RestOf((0, 0), (i, j) => acc = fold(acc, to(matrix[i, j])));
      return acc;
    }

    #region Indexed
    public static TO Fold<T, TO>(this T[,] matrix, Func<int, int, TO, T, TO> fold, TO acc) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          acc = fold(i, j, acc, matrix[i, j]);
      return acc;
    }
    public static TO Fold<T, TO>(this T[,] matrix, Func<int, int, TO, T, TO> fold, Func<T, TO> to) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = to(matrix.First());
      size.RestOf((0, 0), (i, j) => acc = fold(i, j, acc, matrix[i, j]));
      return acc;
    }
    public static T Reduce<T>(this T[,] matrix, Func<int, int, T, T, T> fold) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = matrix.First();
      size.RestOf((0, 0), (i, j) => acc = fold(i, j, acc, matrix[i, j]));
      return acc;
    }
    public static TO Reduce<T, TO>(this T[,] matrix, Func<int, int, TO, TO, TO> fold, Func<T, TO> to) {
      var size = matrix.Size();
      if (!size.Any()) return default;
      var acc = to(matrix.First());
      size.RestOf((0, 0), (i, j) => acc = fold(i, j, acc, to(matrix[i, j])));
      return acc;
    }
    #endregion
  }
}