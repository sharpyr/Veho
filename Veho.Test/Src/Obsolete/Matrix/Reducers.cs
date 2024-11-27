using System;
using Veho.Matrix;

namespace Veho.Test.Obsolete.Matrix {
  public static class MatrixReducers {
    public static TO Fold<T, TO>(this T[,] matrix, Func<TO, T, TO> fold, TO tar) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          tar = fold(tar, matrix[i, j]);
      return tar;
    }
    public static TO Fold<T, TO>(this T[,] matrix, Func<TO, T, TO> fold, Func<T, TO> to) {
      var (h, w) = matrix.Size();
      var tar = to(matrix[0, 0]);
      for (var j = 1; j < w; j++) tar = fold(tar, matrix[0, j]);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          tar = fold(tar, matrix[i, j]);
      return tar;
    }
    public static T Reduce<T>(this T[,] matrix, Func<T, T, T> fold) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var tar = matrix[0, 0];
      for (var j = 1; j < w; j++) tar = fold(tar, matrix[0, j]);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          tar = fold(tar, matrix[i, j]);
      return tar;
    }
    public static TO Reduce<T, TO>(this T[,] matrix, Func<TO, TO, TO> fold, Func<T, TO> to) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var tar = to(matrix[0, 0]);
      for (var j = 1; j < w; j++) tar = fold(tar, to(matrix[0, j]));
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          tar = fold(tar, to(matrix[i, j]));
      return tar;
    }

    #region Indexed
    public static TO Fold<T, TO>(this T[,] matrix, Func<int, int, TO, T, TO> fold, TO tar) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          tar = fold(i, j, tar, matrix[i, j]);
      return tar;
    }
    public static TO Fold<T, TO>(this T[,] matrix, Func<int, int, TO, T, TO> fold, Func<T, TO> to) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var tar = to(matrix[0, 0]);
      for (var j = 1; j < w; j++) tar = fold(0, j, tar, matrix[0, j]);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          tar = fold(i, j, tar, matrix[i, j]);
      return tar;
    }
    public static T Reduce<T>(this T[,] matrix, Func<int, int, T, T, T> fold) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var tar = matrix[0, 0];
      for (var j = 1; j < w; j++) tar = fold(0, j, tar, matrix[0, j]);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          tar = fold(i, j, tar, matrix[i, j]);
      return tar;
    }
    public static TO Reduce<T, TO>(this T[,] matrix, Func<int, int, TO, TO, TO> fold, Func<T, TO> to) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var tar = to(matrix[0, 0]);
      for (var j = 1; j < w; j++) tar = fold(0, j, tar, to(matrix[0, j]));
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          tar = fold(i, j, tar, to(matrix[i, j]));
      return tar;
    }
    #endregion
  }
}