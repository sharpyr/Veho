using System;
using Veho.Matrix;

namespace Veho.OneBase.Columns {
  public static class Indexer {
    public static T[] RebaseColumn<T>(this T[,] matrix, int y = 1) {
      var ht = matrix.Height();
      var col = new T[ht];
      for (var i = 0; i < ht;) col[i] = matrix[++i, y];
      return col;
    }

    public static TO[] RebaseColumn<T, TO>(this T[,] matrix, Func<T, TO> func, int y = 1) {
      var ht = matrix.Height();
      var col = new TO[ht];
      for (var i = 0; i < ht;) col[i] = func(matrix[++i, y]);
      return col;
    }

    public static TO[] RebaseColumn<T, TO>(this T[,] matrix, Func<int, T, TO> func, int y = 1) {
      var ht = matrix.Height();
      var col = new TO[ht];
      for (var i = 0; i < ht;) col[i] = func(++i, matrix[i, y]);
      return col;
    }
  }
}