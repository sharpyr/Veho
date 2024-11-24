using System;
using Veho.Matrix;

namespace Veho.Rows {
  public static class Reducer {
    public static TO FoldRow<T, TO>(this T[,] matrix, int x, Func<TO, T, TO> sequence, TO accum) {
      for (var j = 0; j < matrix.Width(); j++) accum = sequence(accum, matrix[x, j]);
      return accum;
    }

    public static TO FoldRow<T, TO>(this T[,] matrix, int x, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[x, 0]);
      for (var j = 0; j < matrix.Width(); j++) accum = sequence(accum, matrix[x, j]);
      return accum;
    }

    public static T ReduceRow<T>(this T[,] matrix, int x, Func<T, T, T> sequence) {
      var accum = matrix[x, 0];
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(accum, matrix[x, j]);
      return accum;
    }

    public static TO ReduceRow<T, TO>(this T[,] matrix, int x, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[x, 0]);
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(accum, indicator(matrix[x, j]));
      return accum;
    }
    
    public static TO FoldRow<T, TO>(this T[,] matrix, int x, Func<int, TO, T, TO> sequence, TO accum) {
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(j, accum, matrix[x, j]);
      return accum;
    }

    public static TO FoldRow<T, TO>(this T[,] matrix, int x, Func<int, TO, T, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[x, 0]);
      for (var j = 0; j < matrix.Width(); j++) accum = sequence(j, accum, matrix[x, j]);
      return accum;
    }

    public static T ReduceRow<T>(this T[,] matrix, int x, Func<int, T, T, T> sequence) {
      var accum = matrix[x, 0];
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(j, accum, matrix[x, j]);
      return accum;
    }

    public static TO ReduceRow<T, TO>(this T[,] matrix, int x, Func<int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[x, 0]);
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(j, accum, indicator(matrix[x, j]));
      return accum;
    }
  }
}