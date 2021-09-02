using System;
using System.Collections.Generic;
using Veho.Sequence;

namespace Veho.Mutable.LinearAlgebra {
  public static class SymmetricMatrix {
    public static List<List<T>> SelectBy<T>(IReadOnlyList<IReadOnlyList<T>> rows, IReadOnlyList<int> indices) {
      return rows.SelectBy(indices).Map(row => row.SelectBy(indices));
    }
    public static HashSet<int> FindIntersectional<T>(this IReadOnlyList<IReadOnlyList<T>> rows,
                                                     int startIndex,
                                                     T signal,
                                                     HashSet<int> indices = null) where T : IEquatable<T> {
      var row = rows[startIndex];
      indices = indices ?? new HashSet<int>();
      indices.Add(startIndex);
      foreach (var i in row.FilterIndices(x => x.Equals(signal))) {
        if (indices.Contains(i)) continue;
        indices.UnionWith(FindIntersectional(rows, i, signal, indices));
      }
      return indices;
    }
  }
}