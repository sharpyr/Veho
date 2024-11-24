using System;
using Veho.Matrix;

namespace Veho.OneBase.Columns {
  public static class Indexer {
    public static T[] RebaseColumn<T>(this T[,] matrix, int y) {
      var ht = matrix.Height();
      var col = new T[ht];
      y++;
      for (var i = 0; i < ht;) col[i] = matrix[++i, y];
      return col;
    }

    public static TO[] RebaseColumn<T, TO>(this T[,] matrix, int y, Func<T, TO> func) {
      var ht = matrix.Height();
      var col = new TO[ht];
      y++;
      for (var i = 0; i < ht;) col[i] = func(matrix[++i, y]);
      return col;
    }
  }
}