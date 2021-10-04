using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.OneBase.Rows {
  public static class Indexers {
    public static IEnumerable<T> ZeroizeRowIntoIter<T>(this T[,] matrix, int x, int width = -1) {
      if (width < 0) width = matrix.Width();
      x++;
      for (var j = 0; j < width;) yield return matrix[x, ++j];
    }
    public static T[] ZeroizeRow<T>(this T[,] matrix, int x, int width = -1) {
      if (width < 0) width = matrix.Width();
      var row = new T[width];
      x++;
      for (var j = 0; j < width;) row[j++] = matrix[x, j];
      return row;
    }
    public static TO[] ZeroizeRow<T, TO>(this T[,] matrix, int x, Func<T, TO> func, int width = -1) {
      if (width < 0) width = matrix.Width();
      var row = new TO[width];
      x++;
      for (var j = 0; j < width;) row[j] = func(matrix[x, ++j]);
      return row;
    }
    public static TO[] ZeroizeRow<T, TO>(this T[,] matrix,  int x,Func<int, T, TO> func, int width = -1) {
      if (width < 0) width = matrix.Width();
      var row = new TO[width];
      x++;
      for (var j = 0; j < width;) row[j] = func(j, matrix[x, ++j]);
      return row;
    }
  }
}