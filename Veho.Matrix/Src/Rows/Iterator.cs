using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.Rows {
  public static class Iterator {
    public static IEnumerable<T[]> Rows<T>(this T[,] matrix) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++) {
        var row = new T[width];
        for (var j = 0; j < width; j++) row[j] = matrix[i, j];
        yield return row;
      }
    }

    public static IEnumerable<TO[]> Rows<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++) {
        var row = new TO[width];
        for (var j = 0; j < width; j++) row[j] = func(matrix[i, j]);
        yield return row;
      }
    }

    public static IEnumerable<TO[]> Rows<T, TO>(this T[,] matrix, Func<int, int, T, TO> func) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++) {
        var row = new TO[width];
        for (var j = 0; j < width; j++) row[j] = func(i, j, matrix[i, j]);
        yield return row;
      }
    }

    public static IEnumerable<T> RowTo<T>(this T[,] matrix, int x) {
      for (int j = 0, w = matrix.Width(); j < w; j++) yield return matrix[x, j];
    }


    public static IEnumerable<TO> RowTo<T, TO>(this T[,] matrix, int x, Func<T, TO> func) {
      for (int j = 0, w = matrix.Width(); j < w; j++) yield return func(matrix[x, j]);
    }

    public static IEnumerable<TO> RowTo<T, TO>(this T[,] matrix, int x, Func<int, T, TO> func) {
      for (int j = 0, w = matrix.Width(); j < w; j++) yield return func(j, matrix[x, j]);
    }

    public static IEnumerable<T[]> RowsIter<T>(this T[,] matrix) => matrix.Rows();
    public static IEnumerable<T> RowIntoIter<T>(this T[,] matrix, int x) => matrix.RowTo(x);
  }
}