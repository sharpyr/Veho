using System;
using Veho.Matrix;

namespace Veho.Columns {
  public static class Reducer {
    public static TO FoldColumn<T, TO>(this T[,] matrix, int y, Func<TO, T, TO> fold, TO tar) {
      for (var i = 0; i < matrix.Height(); i++) tar = fold(tar, matrix[i, y]);
      return tar;
    }

    public static TO FoldColumn<T, TO>(this T[,] matrix, int y, Func<TO, T, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[0, y]);
      for (var i = 0; i < matrix.Height(); i++) tar = fold(tar, matrix[i, y]);
      return tar;
    }

    public static T ReduceColumn<T>(this T[,] matrix, int y, Func<T, T, T> fold) {
      var tar = matrix[0, y];
      for (var i = 1; i < matrix.Height(); i++) tar = fold(tar, matrix[i, y]);
      return tar;
    }

    public static TO ReduceColumn<T, TO>(this T[,] matrix, int y, Func<TO, TO, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[0, y]);
      for (var i = 1; i < matrix.Height(); i++) tar = fold(tar, to(matrix[i, y]));
      return tar;
    }
    
    public static TO FoldColumn<T, TO>(this T[,] matrix, int y, Func<int, TO, T, TO> fold, TO tar) {
      for (var i = 1; i < matrix.Height(); i++) tar = fold(i, tar, matrix[i, y]);
      return tar;
    }

    public static TO FoldColumn<T, TO>(this T[,] matrix, int y, Func<int, TO, T, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[0, y]);
      for (var i = 0; i < matrix.Height(); i++) tar = fold(i, tar, matrix[i, y]);
      return tar;
    }

    public static T ReduceColumn<T>(this T[,] matrix, int y, Func<int, T, T, T> fold) {
      var tar = matrix[0, y];
      for (var i = 1; i < matrix.Height(); i++) tar = fold(i, tar, matrix[i, y]);
      return tar;
    }

    public static TO ReduceColumn<T, TO>(this T[,] matrix, int y, Func<int, TO, TO, TO> fold, Func<T, TO> to) {
      var tar = to(matrix[0, y]);
      for (var i = 1; i < matrix.Height(); i++) tar = fold(i, tar, to(matrix[i, y]));
      return tar;
    }
  }
}