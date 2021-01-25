using System;

namespace Veho.Matrix {
  public static class Mapper {
    public static T[] Row<T>(this T[,] matrix, int x, int w = 0) {
      if (w == 0) w = matrix.GetLength(1);
      var row = new T[w];
      for (var j = 0; j < w; j++) row[j] = matrix[x, j];
      return row;
    }

    public static T[] Column<T>(this T[,] matrix, int y, int h = 0) {
      if (h == 0) h = matrix.GetLength(0);
      var col = new T[h];
      for (var i = 0; i < h; i++) col[i] = matrix[i, y];
      return col;
    }

    public static T[,] MatrixRow<T>(this T[,] matrix, int x = 0, int w = 0) {
      if (w == 0) w = matrix.GetLength(1);
      var vec = new T[1, w];
      for (var j = 0; j < w; j++) vec[0, j] = matrix[x, j];
      return vec;
    }
    public static T[,] MatrixColumn<T>(this T[,] matrix, int y = 0, int h = 0) {
      if (h == 0) h = matrix.GetLength(0);
      var vec = new T[h, 1];
      for (var i = 0; i < h; i++) vec[i, 0] = matrix[i, y];
      return vec;
    }

    public static TO[] MapOnColumn<T, TO>(this T[,] matrix, int y, Func<T, TO> fn) {
      var h = matrix.GetLength(0);
      var col = new TO[h];
      for (var i = 0; i < h; i++) col[i] = fn(matrix[i, y]);
      return col;
    }

    public static TO[] MapOnRow<T, TO>(this T[,] matrix, int x, Func<T, TO> fn) {
      var w = matrix.GetLength(1);
      var row = new TO[w];
      for (var j = 0; j < w; j++) row[j] = fn(matrix[x, j]);
      return row;
    }

    public static TO[] MapColumns<T, TO>(this T[,] matrix, Func<T[], TO> colTo) {
      var (h, w) = matrix.Size();
      var horizon = new TO[w];
      for (var j = 0; j < w; j++) horizon[j] = colTo(matrix.Column(j, h));
      return horizon;
    }

    public static TO[] MapRows<T, TO>(this T[,] matrix, Func<T[], TO> rowTo) {
      var (h, w) = matrix.Size();
      var vertica = new TO[h];
      for (var i = 0; i < h; i++) vertica[i] = rowTo(matrix.Row(i, w));
      return vertica;
    }


    public static void Iterate<T>(this T[,] matrix, Action<T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          fn(matrix[i, j]);
    }


    public static void Iterate<T>(this T[,] matrix, Action<int, int, T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          fn(i, j, matrix[i, j]);
    }


    public static TO[,] Map<T, TO>(this T[,] matrix, Func<T, TO> fn) {
      var (height, width) = matrix.Size();
      var result = new TO[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          result[i, j] = fn(matrix[i, j]);
      return result;
    }

    public static TO[,] Map<T, TO>(this T[,] matrix, Func<int, int, T, TO> fn) {
      var (height, width) = matrix.Size();
      var result = new TO[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          result[i, j] = fn(i, j, matrix[i, j]);
      return result;
    }

    public static T[,] Mutate<T>(this T[,] matrix, Func<T, T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(matrix[i, j]);
      return matrix;
    }

    public static T[,] Mutate<T>(this T[,] matrix, Func<int, int, T, T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(i, j, matrix[i, j]);
      return matrix;
    }

    // Func<tIn, tOut> conv = Operator.Convert<tIn, tOut>;
    public static TO[,] CastTo<T, TO>(this T[,] matrix) => matrix.Map(value => (TO) Convert.ChangeType(value, typeof(TO)));
    public static TO[,] CastTo<T, TO>(this T[,] matrix, Converter<T, TO> converter) => matrix.Map(x => converter(x));
  }
}