using System;
using Veho.Matrix;

namespace Veho.Columns {
  public static class Indexer {
    public static T[] Column<T>(this T[,] matrix, int y, int h = 0) {
      var col = new T[h == 0 ? h = matrix.Height() : h];
      for (var i = 0; i < h; i++) col[i] = matrix[i, y];
      return col;
    }

    public static TO[] Column<T, TO>(this T[,] matrix, int y, Func<T, TO> fn, int h = 0) {
      var col = new TO[h == 0 ? h = matrix.Height() : h];
      for (var i = 0; i < h; i++) col[i] = fn(matrix[i, y]);
      return col;
    }

    public static TO[] Column<T, TO>(this T[,] matrix, int y, Func<int, T, TO> fn, int h = 0) {
      var col = new TO[h == 0 ? h = matrix.Height() : h];
      for (var i = 0; i < h; i++) col[i] = fn(i, matrix[i, y]);
      return col;
    }

    public static T[,] MatrixColumn<T>(this T[,] matrix, int y = 0, int h = 0) {
      var vec = new T[h == 0 ? h = matrix.Height() : h, 1];
      for (var i = 0; i < h; i++) vec[i, 0] = matrix[i, y];
      return vec;
    }

    public static TO[,] MatrixColumn<T, TO>(this T[,] matrix, int y, Func<T, TO> fn, int h = 0) {
      var vec = new TO[h == 0 ? h = matrix.Height() : h, 1];
      for (var i = 0; i < h; i++) vec[i, 0] = fn(matrix[i, y]);
      return vec;
    }

    public static TO[,] MatrixColumn<T, TO>(this T[,] matrix, int y, Func<int, T, TO> fn, int h = 0) {
      var vec = new TO[h == 0 ? h = matrix.Height() : h, 1];
      for (var i = 0; i < h; i++) vec[i, 0] = fn(i, matrix[i, y]);
      return vec;
    }
  }
}