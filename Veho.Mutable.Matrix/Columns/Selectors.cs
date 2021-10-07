using System;
using System.Collections.Generic;
using Veho.Mutable.Matrix;
using Veho.Sequence;

namespace Veho.Mutable.Columns {
  public static class Selectors {
    public static List<List<T>> SelectColumnsBy<T>(this IReadOnlyList<IReadOnlyList<T>> rows, IReadOnlyList<int> columnIndices) {
      return columnIndices.Map(rows.Column);
    }
    public static List<List<T>> SelectByColumnIndices<T>(this IReadOnlyList<IReadOnlyList<T>> rows, IReadOnlyList<int> columnIndices) {
      return rows.Map(row => row.SelectBy(columnIndices));
    }

    public static IEnumerable<List<T>> SelectColumnsIntoIter<T>(this IReadOnlyList<IReadOnlyList<T>> matrix, IReadOnlyList<int> rowIndices) {
      var width = matrix.Width();
      var height = rowIndices.Count;
      for (var j = 0; j < width; j++) {
        var column = new List<T>(height);
        for (var i = 0; i < height; i++) column.Add(matrix[rowIndices[i]][j]);
        yield return column;
      }
    }

    [Obsolete("use SelectRowsIntoIter instead")]
    public static IEnumerable<List<T>> IntoColumnsIter<T>(this IReadOnlyList<IReadOnlyList<T>> matrix, IReadOnlyList<int> rowIndices) {
      var width = matrix.Width();
      var height = rowIndices.Count;
      for (var j = 0; j < width; j++) {
        var column = new List<T>(height);
        for (var i = 0; i < height; i++) column.Add(matrix[rowIndices[i]][j]);
        yield return column;
      }
    }
  }
}