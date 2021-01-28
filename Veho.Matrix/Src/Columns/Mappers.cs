using System;

namespace Veho.Matrix.Columns {
  public static class Mappers {
    public static TO[] Columns<T, TO>(this T[,] matrix, Func<T[], TO> colTo) {
      var (h, w) = matrix.Size();
      var horizon = new TO[w];
      for (var j = 0; j < w; j++) horizon[j] = colTo(matrix.Column(j, h));
      return horizon;
    }
  }
}