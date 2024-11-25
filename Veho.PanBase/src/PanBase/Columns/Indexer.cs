using System;
using Veho.Matrix;

namespace Veho.PanBase.Columns {
  public static class Indexer {
    public static T[] RebaseColumn<T>(this T[,] matrix, int y = 1) {
      var (xlo, ht) = matrix.XLeap();
      var column = new T[ht];
      for (var i = 0; i < ht; i++) column[i] = matrix[xlo + i, y];
      return column;
    }

    public static TO[] RebaseColumn<T, TO>(this T[,] matrix, Func<T, TO> func, int y = 1) {
      var (xlo, ht) = matrix.XLeap();
      var column = new TO[ht];
      for (var i = 0; i < ht; i++) column[i] = func(matrix[xlo + i, y]);
      return column;
    }

    public static TO[] RebaseColumn<T, TO>(this T[,] matrix, Func<int, T, TO> func, int y = 1) {
      var (xlo, ht) = matrix.XLeap();
      var column = new TO[ht];
      for (var i = 0; i < ht; i++) column[i] = func(i, matrix[xlo + i, y]);
      return column;
    }
  }
}