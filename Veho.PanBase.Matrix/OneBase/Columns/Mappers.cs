using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.OneBase.Columns {
  public static class Mappers {
    public static IEnumerable<T[]> ZeroizeColumnsIntoIter<T>(this T[,] matrix) {
      var (height, width) = matrix.Size();
      for (var j = 0; j < width; j++) {
        yield return matrix.ZeroizeColumn(j, height);
      }
    }
    public static void ZeroizeIterColumn<T>(this T[,] matrix, int y, Action<T> action, int height = -1) {
      if (height < 0) height = matrix.Height();
      y++;
      for (var i = 0; i < height;) action(matrix[++i, y]);
    }
    public static void ZeroizeIterColumn<T>(this T[,] matrix, int y, Action<int, T> action, int height = -1) {
      if (height < 0) height = matrix.Height();
      y++;
      for (var i = 0; i < height;) action(i, matrix[++i, y]);
    }
  }
}