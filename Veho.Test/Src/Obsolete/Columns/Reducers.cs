using System;
using Veho.Matrix;

namespace Veho.Test.Obsolete.Columns {
  public static class Reducers {
    public static TO FoldColumn<T, TO>(this T[,] matrix, int y, Func<TO, T, TO> sequence, TO accum) {
      for (var i = 0; i < matrix.Height(); i++) accum = sequence(accum, matrix[i, y]);
      return accum;
    }

    public static TO FoldColumn<T, TO>(this T[,] matrix, int y, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[0, y]);
      for (var i = 0; i < matrix.Height(); i++) accum = sequence(accum, matrix[i, y]);
      return accum;
    }

    public static T ReduceColumn<T>(this T[,] matrix, int y, Func<T, T, T> sequence) {
      var accum = matrix[0, y];
      for (var i = 1; i < matrix.Height(); i++) accum = sequence(accum, matrix[i, y]);
      return accum;
    }

    public static TO ReduceColumn<T, TO>(this T[,] matrix, int y, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[0, y]);
      for (var i = 1; i < matrix.Height(); i++) accum = sequence(accum, indicator(matrix[i, y]));
      return accum;
    }

    #region Indexed
    public static TO FoldColumn<T, TO>(this T[,] matrix, int y, Func<int, TO, T, TO> sequence, TO accum) {
      for (var i = 1; i < matrix.Height(); i++) accum = sequence(i, accum, matrix[i, y]);
      return accum;
    }

    public static TO FoldColumn<T, TO>(this T[,] matrix, int y, Func<int, TO, T, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[0, y]);
      for (var i = 0; i < matrix.Height(); i++) accum = sequence(i, accum, matrix[i, y]);
      return accum;
    }

    public static T ReduceColumn<T>(this T[,] matrix, int y, Func<int, T, T, T> sequence) {
      var accum = matrix[0, y];
      for (var i = 1; i < matrix.Height(); i++) accum = sequence(i, accum, matrix[i, y]);
      return accum;
    }

    public static TO ReduceColumn<T, TO>(this T[,] matrix, int y, Func<int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[0, y]);
      for (var i = 1; i < matrix.Height(); i++) accum = sequence(i, accum, indicator(matrix[i, y]));
      return accum;
    }
    #endregion
  }
}