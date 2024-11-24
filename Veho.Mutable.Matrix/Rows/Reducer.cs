using System;
using System.Collections.Generic;
using Veho.Mutable.Matrix;

namespace Veho.Mutable.Rows {
  public static partial class Reducer {
    public static TO FoldRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<TO, T, TO> sequence, TO accum) {
      for (var j = 0; j < matrix.Width(); j++) accum = sequence(accum, matrix[x][j]);
      return accum;
    }

    public static TO FoldRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[x][0]);
      for (var j = 0; j < matrix.Width(); j++) accum = sequence(accum, matrix[x][j]);
      return accum;
    }

    public static TO FoldRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<int, TO, T, TO> sequence, TO accum) {
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(j, accum, matrix[x][j]);
      return accum;
    }

    public static TO FoldRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<int, TO, T, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[x][0]);
      for (var j = 0; j < matrix.Width(); j++) accum = sequence(j, accum, matrix[x][j]);
      return accum;
    }
  }

  public static partial class Reducer {
    public static T ReduceRow<T>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<T, T, T> sequence) {
      var accum = matrix[x][0];
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(accum, matrix[x][j]);
      return accum;
    }

    public static TO ReduceRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[x][0]);
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(accum, indicator(matrix[x][j]));
      return accum;
    }

    public static T ReduceRow<T>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<int, T, T, T> sequence) {
      var accum = matrix[x][0];
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(j, accum, matrix[x][j]);
      return accum;
    }

    public static TO ReduceRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(matrix[x][0]);
      for (var j = 1; j < matrix.Width(); j++) accum = sequence(j, accum, indicator(matrix[x][j]));
      return accum;
    }
  }
}