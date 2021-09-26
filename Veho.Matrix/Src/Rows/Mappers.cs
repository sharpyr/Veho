using System;
using System.Collections.Generic;
using System.Linq;
using Veho.Matrix;

namespace Veho.Rows {
  public static class Mappers {
    public static IEnumerable<T> RowIntoIter<T>(this T[,] matrix, int x) {
      for (int j = 0, w = matrix.Width(); j < w; j++) yield return matrix[x, j];
    }
    public static TO[] MapRows<T, TO>(this T[,] matrix, Func<T[], TO> rowTo) {
      var (h, w) = matrix.Size();
      var vertica = new TO[h];
      for (var i = 0; i < h; i++) vertica[i] = rowTo(matrix.Row(i, w));
      return vertica;
    }

    public static TO[] MapRows<T, TO>(this T[,] matrix, Func<int, T[], TO> rowTo) {
      var (h, w) = matrix.Size();
      var vertica = new TO[h];
      for (var i = 0; i < h; i++) vertica[i] = rowTo(i, matrix.Row(i, w));
      return vertica;
    }

    public static T[,] RowsToMatrix<T>(this T[][] rows) {
      if (rows.Length == 0) return Mat.Empty<T>();
      var (h, w) = (rows.Length, rows[0].Length);
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++) {
        var row = rows[i];
        for (var j = 0; j < w; j++) matrix[i, j] = row[j];
      }
      return matrix;
    }
  }
}