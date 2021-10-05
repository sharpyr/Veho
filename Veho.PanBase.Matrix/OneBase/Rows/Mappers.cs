using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.OneBase.Rows {
  public static class Mappers {
    public static IEnumerable<T[]> ZeroizeRowsIntoIter<T>(this T[,] matrix) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++) {
        yield return matrix.ZeroizeRow(i, width);
      }
    }
    public static void ZeroizeIterRow<T>(this T[,] matrix, int x, Action<T> action, int width = -1) {
      if (width < 0) width = matrix.Width();
      x++;
      for (var j = 0; j < width;) action(matrix[x, ++j]);
    }
    public static void ZeroizeIterRow<T>(this T[,] matrix, int x, Action<int, T> action, int width = -1) {
      if (width < 0) width = matrix.Width();
      x++;
      for (var j = 0; j < width;) action(j, matrix[x, ++j]);
    }
  }
}