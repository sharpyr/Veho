using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.Rows {
  public static class Selector {
    public static T[,] SelectRows<T>(this T[,] rows, IReadOnlyList<int> rowIndices) {
      int h = rowIndices.Count, w = rows.Width();
      var target = new T[h, w];
      for (var i = 0; i < h; i++)
        for (int j = 0, rowIndex; j < w; j++) {
          target[i, j] = (rowIndex = rowIndices[i]) < 0 ? default : rows[rowIndex, j];
        }
      return target;
    }

    [Obsolete("use SelectRowsIntoIter instead")]
    public static IEnumerable<T[]> IntoRowsIter<T>(this T[,] matrix, IReadOnlyList<int> columnIndices) {
      return matrix.SelectRowsIntoIter(columnIndices);
    }

    public static IEnumerable<T[]> SelectRowsIntoIter<T>(this T[,] matrix, IReadOnlyList<int> columnIndices) {
      int height = matrix.Height(), width = columnIndices.Count;
      for (var i = 0; i < height; i++) {
        var row = new T[width];
        for (int j = 0, colIndex; j < width; j++) {
          row[j] = (colIndex = columnIndices[j]) < 0 ? default : matrix[i, colIndex];
        }
        yield return row;
      }
    }

    // public static IEnumerable<T[]> IntoRowsIter2<T>(this T[,] matrix, IReadOnlyList<int> columnIndices) {
    //   var height = matrix.Height();
    //   var width = columnIndices.Count;
    //   for (var i = 0; i < height; i++) {
    //     var row = new T[width];
    //     for (var j = 0; j < width; j++) row[j] = null;
    //     yield return row;
    //   }
    // }
  }
}