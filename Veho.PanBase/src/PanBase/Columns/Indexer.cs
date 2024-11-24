using System;
using Veho.Matrix;

namespace Veho.PanBase.Columns {
  public static class Indexer {
    public static T[] RebaseColumn<T>(this T[,] matrix, int y) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      var column = new T[ht];
      for (var i = 0; i < ht; i++) column[i] = matrix[xlo + i, ylo + y];
      return column;
    }

    public static TO[] RebaseColumn<T, TO>(this T[,] matrix, int y, Func<T, TO> func) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      var column = new TO[ht];
      for (var i = 0; i < ht; i++) column[i] = func(matrix[xlo + i, ylo + y]);
      return column;
    }

    public static TO[] RebaseColumn<T, TO>(this T[,] matrix, int y, Func<int, T, TO> func) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      var column = new TO[ht];
      for (var i = 0; i < ht; i++) column[i] = func(i, matrix[xlo + i, ylo + y]);
      return column;
    }
  }
}