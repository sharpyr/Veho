using System;
using System.Collections.Generic;
using Veho.Matrix;

// var (lo, size) = matrix.YLeap();

namespace Veho.OneBase.Columns {
  public static class Indexers {
    public static IEnumerable<T> ZeroizeColumnIntoIter<T>(this T[,] matrix, int y, int height = -1) {
      if (height < 0) height = matrix.Height();
      y++;
      for (var i = 0; i < height;) yield return matrix[++i, y];
    }
    public static T[] ZeroizeColumn<T>(this T[,] matrix, int y, int height = -1) {
      if (height < 0) height = matrix.Height();
      var column = new T[height];
      y++;
      for (var i = 0; i < height;) column[i++] = matrix[i, y];
      return column;
    }
    public static TO[] ZeroizeColumn<T, TO>(this T[,] matrix, int y, Func<T, TO> func, int height = -1) {
      if (height < 0) height = matrix.Height();
      var column = new TO[height];
      y++;
      for (var i = 0; i < height;) column[i] = func(matrix[++i, y]);
      return column;
    }
    public static TO[] ZeroizeColumn<T, TO>(this T[,] matrix, int y, Func<int, T, TO> func, int height = -1) {
      if (height < 0) height = matrix.Height();
      var column = new TO[height];
      y++;
      for (var i = 0; i < height;) column[i] = func(i, matrix[++i, y]);
      return column;
    }
  }
}