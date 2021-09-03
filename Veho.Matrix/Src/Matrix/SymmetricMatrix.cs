using System;
using System.Collections.Generic;
using Veho.Enumerable;
using Veho.Rows;

namespace Veho.Matrix {
  public static class SymmetricMatrix {
    public static T[,] SelectBy<T>(T[,] matrix, IReadOnlyList<int> indices) {
      return matrix.SelectBy(indices, indices);
    }
    public static T[,] UpperTriangular<T>(T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      for (var i = 0; i < h; i++) {
        for (var j = 0; j < i; j++) target[i, j] = default;
        for (var j = i; j < w; j++) target[i, j] = matrix[i, j];
      }
      return target;
    }
    public static T[,] LowerTriangular<T>(T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      for (var i = 0; i < h; i++) {
        for (var j = 0; j <= i; j++) target[i, j] = matrix[i, j];
        for (var j = i + 1; j < w; j++) target[i, j] = default;
      }
      return target;
    }
    public static HashSet<int> FindIntersectional<T>(this T[,] matrix,
                                                     int startIndex,
                                                     T signal,
                                                     HashSet<int> indices = null) where T : IEquatable<T> {
      var row = matrix.RowIntoIter(startIndex);
      indices = indices ?? new HashSet<int>();
      indices.Add(startIndex);
      foreach (var i in row.FilterIndices(x => x.Equals(signal))) {
        if (indices.Contains(i)) continue;
        indices.UnionWith(FindIntersectional(matrix, i, signal, indices));
      }
      return indices;
    }

    public static IEnumerable<HashSet<int>> IntersectionalIndices<T>(this T[,] matrix,
                                                                     T signal) where T : IEquatable<T> {
      var rowIndexRange = SkipRange.Build(matrix.Height());
      foreach (var rowIndex in rowIndexRange.IntoIter()) {
        var intersectionalIndices = matrix.FindIntersectional(rowIndex, signal);
        rowIndexRange.AcquireIndices(intersectionalIndices);
        if (intersectionalIndices.Count <= 1) continue;
        yield return intersectionalIndices;
      }
    }
  }
}