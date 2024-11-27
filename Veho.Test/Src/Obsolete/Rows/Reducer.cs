using System;
using Veho.Matrix;

namespace Veho.Test.Obsolete.Rows {
  public static class Reducer {
    #region Basic
    public static TO FoldRow<T, TO>(this T[,] matrix, int x, Func<TO, T, TO> fold, TO tar) {
      for (var j = 0; j < matrix.Width(); j++) tar = fold(tar, matrix[x, j]);
      return tar;
    }

    public static TO FoldRow<T, TO>(this T[,] matrix, int x, Func<TO, T, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[x, 0]);
      for (var j = 0; j < matrix.Width(); j++) tar = fold(tar, matrix[x, j]);
      return tar;
    }

    public static T ReduceRow<T>(this T[,] matrix, int x, Func<T, T, T> fold) {
      var tar = matrix[x, 0];
      for (var j = 1; j < matrix.Width(); j++) tar = fold(tar, matrix[x, j]);
      return tar;
    }

    public static TO ReduceRow<T, TO>(this T[,] matrix, int x, Func<TO, TO, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[x, 0]);
      for (var j = 1; j < matrix.Width(); j++) tar = fold(tar, to(matrix[x, j]));
      return tar;
    }
    #endregion

    #region Indexed
    public static TO FoldRow<T, TO>(this T[,] matrix, int x, Func<int, TO, T, TO> fold, TO tar) {
      for (var j = 1; j < matrix.Width(); j++) tar = fold(j, tar, matrix[x, j]);
      return tar;
    }

    public static TO FoldRow<T, TO>(this T[,] matrix, int x, Func<int, TO, T, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[x, 0]);
      for (var j = 0; j < matrix.Width(); j++) tar = fold(j, tar, matrix[x, j]);
      return tar;
    }

    public static T ReduceRow<T>(this T[,] matrix, int x, Func<int, T, T, T> fold) {
      var tar = matrix[x, 0];
      for (var j = 1; j < matrix.Width(); j++) tar = fold(j, tar, matrix[x, j]);
      return tar;
    }

    public static TO ReduceRow<T, TO>(this T[,] matrix, int x, Func<int, TO, TO, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[x, 0]);
      for (var j = 1; j < matrix.Width(); j++) tar = fold(j, tar, to(matrix[x, j]));
      return tar;
    }
    #endregion
  }
}