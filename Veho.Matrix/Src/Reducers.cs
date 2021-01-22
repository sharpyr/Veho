using System;

namespace Veho.Matrix {
  public static class Reducers {
    public static TO Flat<T, TO>(this T[,] matrix, Func<TO, T, TO> func, TO accum) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = func(accum, matrix[i, j]);
      return accum;
    }

    public static T ReduceOnRow<T>(this T[,] matrix, Func<T, T, T> func, int x) {
      var accum = matrix[x, 0];
      for (var j = 1; j < matrix.Width(); j++) accum = func(accum, matrix[x, j]);
      return accum;
    }

    public static T ReduceOnColumn<T>(this T[,] matrix, Func<T, T, T> func, int y) {
      var accum = matrix[0, y];
      for (var i = 1; i < matrix.Height(); i++) accum = func(accum, matrix[i, y]);
      return accum;
    }

    public static T Reduce<T>(this T[,] matrix, Func<T, T, T> func) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = matrix[0, 0];
      for (var j = 1; j < matrix.Width(); j++) accum = func(accum, matrix[0, j]);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = func(accum, matrix[i, j]);
      return accum;
    }

    public static TO Reduce<T, TO>(this T[,] matrix, Func<TO, TO, TO> func, Func<T, TO> indicator) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = indicator(matrix[0, 0]);
      for (var j = 1; j < matrix.Width(); j++) accum = func(accum, indicator(matrix[0, j]));
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = func(accum, indicator(matrix[i, j]));
      return accum;
    }
  }
}