using System;
using System.Collections.Generic;
using Veho.Mutable.Matrix;

namespace Veho.Mutable.Rows {
  public static partial class Reducer {
    public static TO FoldRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<TO, T, TO> fold, TO tar) {
      for (var j = 0; j < matrix.Width(); j++) tar = fold(tar, matrix[x][j]);
      return tar;
    }

    public static TO FoldRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<TO, T, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[x][0]);
      for (var j = 0; j < matrix.Width(); j++) tar = fold(tar, matrix[x][j]);
      return tar;
    }

    public static TO FoldRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<int, TO, T, TO> fold, TO tar) {
      for (var j = 1; j < matrix.Width(); j++) tar = fold(j, tar, matrix[x][j]);
      return tar;
    }

    public static TO FoldRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<int, TO, T, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[x][0]);
      for (var j = 0; j < matrix.Width(); j++) tar = fold(j, tar, matrix[x][j]);
      return tar;
    }
  }

  public static partial class Reducer {
    public static T ReduceRow<T>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<T, T, T> fold) {
      var tar = matrix[x][0];
      for (var j = 1; j < matrix.Width(); j++) tar = fold(tar, matrix[x][j]);
      return tar;
    }

    public static TO ReduceRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<TO, TO, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[x][0]);
      for (var j = 1; j < matrix.Width(); j++) tar = fold(tar, to(matrix[x][j]));
      return tar;
    }

    public static T ReduceRow<T>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<int, T, T, T> fold) {
      var tar = matrix[x][0];
      for (var j = 1; j < matrix.Width(); j++) tar = fold(j, tar, matrix[x][j]);
      return tar;
    }

    public static TO ReduceRow<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<int, TO, TO, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[x][0]);
      for (var j = 1; j < matrix.Width(); j++) tar = fold(j, tar, to(matrix[x][j]));
      return tar;
    }
  }
}