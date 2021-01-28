using System;

namespace Veho.Matrix.Rows {
  public static class Mappers {
    public static TO[] MapRows<T, TO>(this T[,] matrix, Func<T[], TO> rowTo) {
      var (h, w) = matrix.Size();
      var vertica = new TO[h];
      for (var i = 0; i < h; i++) vertica[i] = rowTo(matrix.Row(i, w));
      return vertica;
    }
  }
}