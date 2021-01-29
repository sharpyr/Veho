using System;

namespace Veho.Matrix.Columns {
  public static class Mappers {
    public static TO[] MapColumns<T, TO>(this T[,] matrix, Func<T[], TO> colTo) {
      var (h, w) = matrix.Size();
      var horizon = new TO[w];
      for (var j = 0; j < w; j++) horizon[j] = colTo(matrix.Column(j, h));
      return horizon;
    }

    public static T[,] ColumnsToMatrix<T>(this T[][] columns) {
      if (columns.Length == 0) return Inits.Empty<T>();
      var (h, w) = (columns[0].Length, columns.Length);
      var matrix = new T[h, w];
      for (var j = 0; j < w; j++) {
        var column = columns[j];
        for (var i = 0; i < h; i++) matrix[i, j] = column[i];
      }
      return matrix;
    }
  }
}