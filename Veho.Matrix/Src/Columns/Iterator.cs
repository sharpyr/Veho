using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.Columns {
  public static class Iterator {
    public static IEnumerable<T[]> Columns<T>(this T[,] matrix) {
      var (height, width) = matrix.Size();
      for (var j = 0; j < width; j++) {
        var column = new T[height];
        for (var i = 0; i < height; i++) column[i] = matrix[i, j];
        yield return column;
      }
    }

    public static IEnumerable<TO[]> Columns<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (height, width) = matrix.Size();
      for (var j = 0; j < width; j++) {
        var column = new TO[height];
        for (var i = 0; i < height; i++) column[i] = func(matrix[i, j]);
        yield return column;
      }
    }

    public static IEnumerable<TO[]> Columns<T, TO>(this T[,] matrix, Func<int, int, T, TO> func) {
      var (height, width) = matrix.Size();
      for (var j = 0; j < width; j++) {
        var column = new TO[height];
        for (var i = 0; i < height; i++) column[i] = func(i, j, matrix[i, j]);
        yield return column;
      }
    }

    public static IEnumerable<T> ColumnInto<T>(this T[,] matrix, int y) {
      for (int i = 0, h = matrix.Height(); i < h; i++) yield return matrix[i, y];
    }

    public static IEnumerable<TO> ColumnInto<T, TO>(this T[,] matrix, int y, Func<T, TO> func) {
      for (int i = 0, h = matrix.Height(); i < h; i++) yield return func(matrix[i, y]);
    }

    public static IEnumerable<TO> ColumnInto<T, TO>(this T[,] matrix, int y, Func<int, T, TO> func) {
      for (int i = 0, h = matrix.Height(); i < h; i++) yield return func(i, matrix[i, y]);
    }


    public static IEnumerable<T[]> ColumnsIter<T>(this T[,] matrix) => matrix.Columns();

    public static IEnumerable<T> ColumnIntoIter<T>(this T[,] matrix, int y) => matrix.ColumnInto(y);
  }
}