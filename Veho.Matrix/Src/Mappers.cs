using System;

namespace Veho.Matrix {
  public static class Mapper {
    public static T[] Row<T>(this T[,] matrix, int r, int w = 0) {
      if (w == 0) w = matrix.GetLength(1);
      var row = new T[w];
      for (var j = 0; j < w; j++) row[j] = matrix[r, j];
      return row;
    }

    public static T[] Column<T>(this T[,] matrix, int c, int h = 0) {
      if (h == 0) h = matrix.GetLength(0);
      var col = new T[h];
      for (var i = 0; i < h; i++) col[i] = matrix[i, c];
      return col;
    }

    public static P[] MapOnColumn<T, P>(this T[,] matrix, int c, Func<T, P> fn) {
      var h = matrix.GetLength(0);
      var col = new P[h];
      for (var i = 0; i < h; i++) col[i] = fn(matrix[i, c]);
      return col;
    }

    public static P[] MapOnRow<T, P>(this T[,] matrix, int r, Func<T, P> fn) {
      var w = matrix.GetLength(1);
      var row = new P[w];
      for (var j = 0; j < w; j++) row[j] = fn(matrix[r, j]);
      return row;
    }

    public static P[] MapByColumns<T, P>(this T[,] matrix, Func<T[], P> colTo) {
      var (h, w) = matrix.Size();
      var horizon = new P[w];
      for (var j = 0; j < w; j++) horizon[j] = colTo(matrix.Column(j, h));
      return horizon;
    }

    public static P[] MapByRows<T, P>(this T[,] matrix, Func<T[], P> rowTo) {
      var (h, w) = matrix.Size();
      var vertica = new P[h];
      for (var i = 0; i < w; i++) vertica[i] = rowTo(matrix.Row(i, w));
      return vertica;
    }


    public static void Iterate<T>(this T[,] matrix, Action<T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          fn(matrix[i, j]);
    }

    public static P[,] Map<T, P>(this T[,] matrix, Func<T, P> fn) {
      var (height, width) = matrix.Size();
      var result = new P[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          result[i, j] = fn(matrix[i, j]);
      return result;
    }

    public static T[,] Mutate<T>(this T[,] matrix, Func<T, T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(matrix[i, j]);
      return matrix;
    }

    public static void IndexedIterate<T>(this T[,] matrix, Action<int, int, T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          fn(i, j, matrix[i, j]);
    }

    public static P[,] IndexedMap<T, P>(this T[,] matrix, Func<int, int, T, P> fn) {
      var (height, width) = matrix.Size();
      var result = new P[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          result[i, j] = fn(i, j, matrix[i, j]);
      return result;
    }

    public static T[,] IndexedMutate<T>(this T[,] matrix, Func<int, int, T, T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(i, j, matrix[i, j]);
      return matrix;
    }
  }
}