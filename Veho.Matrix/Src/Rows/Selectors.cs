using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.Rows {
  public static class Selectors {
    public static T[,] SelectRows<T>(this T[,] rows, IReadOnlyList<int> rowIndices) {
      int h = rowIndices.Count, w = rows.Width();
      var target = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = rows[rowIndices[i], j];
      return target;
    }

    public static IEnumerable<T[]> IntoRowsIter<T>(this T[,] matrix, IReadOnlyList<int> columnIndices) {
      var height = matrix.Height();
      var width = columnIndices.Count;
      for (var i = 0; i < height; i++) {
        var row = new T[width];
        for (var j = 0; j < width; j++) row[j] = matrix[i, columnIndices[j]];
        yield return row;
      }
    }
    // public static List<int> FilterRowIndices<T>(this T[,] matrix, Predicate<IEnumerable<T>> criteria) {
    //   var hi = matrix.Count;
    //   return matrix.Fold((i, indexes, x) => {
    //     if (criteria(x)) indexes.Add(i);
    //   }, new List<int>(hi));
    // }
    // public static List<int> FilterRowIndices<T>(this T[,] matrix, Func<int, IEnumerable<T>, bool> criteria) {
    //   var hi = matrix.Count;
    //   return matrix.Fold((i, indexes, x) => {
    //     if (criteria(i, x)) indexes.Add(i);
    //   }, new List<int>(hi));
    // }
  }
}