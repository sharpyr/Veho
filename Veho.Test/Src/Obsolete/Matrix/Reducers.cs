using System;
using Veho.Matrix;

namespace Veho.Test.Obsolete.Matrix {
  public static class MatrixReducers {
    public static TO Fold<T, TO>(this T[,] matrix, Func<TO, T, TO> sequence, TO accum) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(accum, matrix[i, j]);
      return accum;
    }
    public static TO Fold<T, TO>(this T[,] matrix, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
      var (h, w) = matrix.Size();
      var accum = indicator(matrix[0, 0]);
      for (var j = 1; j < w; j++) accum = sequence(accum, matrix[0, j]);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(accum, matrix[i, j]);
      return accum;
    }
    public static T Reduce<T>(this T[,] matrix, Func<T, T, T> sequence) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = matrix[0, 0];
      for (var j = 1; j < w; j++) accum = sequence(accum, matrix[0, j]);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(accum, matrix[i, j]);
      return accum;
    }
    public static TO Reduce<T, TO>(this T[,] matrix, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = indicator(matrix[0, 0]);
      for (var j = 1; j < w; j++) accum = sequence(accum, indicator(matrix[0, j]));
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(accum, indicator(matrix[i, j]));
      return accum;
    }

    #region Indexed
    public static TO Fold<T, TO>(this T[,] matrix, Func<int, int, TO, T, TO> sequence, TO accum) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(i, j, accum, matrix[i, j]);
      return accum;
    }
    public static TO Fold<T, TO>(this T[,] matrix, Func<int, int, TO, T, TO> sequence, Func<T, TO> indicator) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = indicator(matrix[0, 0]);
      for (var j = 1; j < w; j++) accum = sequence(0, j, accum, matrix[0, j]);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(i, j, accum, matrix[i, j]);
      return accum;
    }
    public static T Reduce<T>(this T[,] matrix, Func<int, int, T, T, T> sequence) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = matrix[0, 0];
      for (var j = 1; j < w; j++) accum = sequence(0, j, accum, matrix[0, j]);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(i, j, accum, matrix[i, j]);
      return accum;
    }
    public static TO Reduce<T, TO>(this T[,] matrix, Func<int, int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = indicator(matrix[0, 0]);
      for (var j = 1; j < w; j++) accum = sequence(0, j, accum, indicator(matrix[0, j]));
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(i, j, accum, indicator(matrix[i, j]));
      return accum;
    }
    #endregion
  }
}