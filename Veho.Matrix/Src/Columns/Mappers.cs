using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.Columns {
  public static class Mappers {
    public static IEnumerable<T[]> ColumnsIter<T>(this T[,] matrix) {
      var (height, width) = matrix.Size();
      for (var j = 0; j < width; j++) {
        var column = new T[height];
        for (var i = 0; i < height; i++) column[i] = matrix[i, j];
        yield return column;
      }
    }

    // [Obsolete("ColumnIntoIter is deprecated, please use ColumnIter instead")]
    public static IEnumerable<T> ColumnIntoIter<T>(this T[,] matrix, int y) {
      for (int i = 0, h = matrix.Height(); i < h; i++) yield return matrix[i, y];
    }

    public static TO[] MapColumns<T, TO>(this T[,] matrix, Func<T[], TO> colTo) {
      var (h, w) = matrix.Size();
      var horizon = new TO[w];
      for (var j = 0; j < w; j++) horizon[j] = colTo(matrix.Column(j, h));
      return horizon;
    }

    public static TO[] MapColumns<T, TO>(this T[,] matrix, Func<int, T[], TO> colTo) {
      var (h, w) = matrix.Size();
      var horizon = new TO[w];
      for (var j = 0; j < w; j++) horizon[j] = colTo(j, matrix.Column(j, h));
      return horizon;
    }

    public static T[,] ColumnsToMatrix<T>(this T[][] columns) {
      if (columns.Length == 0) return Mat.Empty<T>();
      var (h, w) = (columns[0].Length, columns.Length);
      var matrix = new T[h, w];
      for (var j = 0; j < w; j++) {
        var column = columns[j];
        for (var i = 0; i < h; i++) matrix[i, j] = column[i];
      }
      return matrix;
    }
  }
}