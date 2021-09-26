using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.Columns {
  public static class Selectors {
    public static T[,] SelectColumns<T>(this T[,] rows, IReadOnlyList<int> columnIndices) {
      int h = rows.Height(), w = columnIndices.Count;
      var target = new T[h, w];
      for (var i = 0; i < h; i++)
        for (int j = 0, colIndex; j < w; j++)
          target[i, j] = (colIndex = columnIndices[j]) < 0 ? default : rows[i, colIndex];
      return target;
    }
    public static IEnumerable<T[]> IntoColumnsIter<T>(this T[,] matrix, IReadOnlyList<int> rowIndices) {
      var width = matrix.Width();
      var height = rowIndices.Count;
      for (var j = 0; j < width; j++) {
        var column = new T[height];
        for (int i = 0, rowIndex; i < height; i++)
          column[i] = (rowIndex = rowIndices[i]) < 0 ? default : matrix[rowIndex, j];
        yield return column;
      }
    }
  }
}