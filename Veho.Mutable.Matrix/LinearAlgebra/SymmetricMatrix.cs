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

    public static IEnumerable<HashSet<int>> IntersectionalIndices<T>(this IReadOnlyList<IReadOnlyList<T>> rows,
                                                                     T signal) where T : IEquatable<T> {
      var rowSkipper = Skipper<IReadOnlyList<T>>.Build(rows);
      foreach (var index in rowSkipper.IntoIndexIter()) {
        var intersectionalIndices = rows.FindIntersectional(index, signal);
        rowSkipper.AcquireIndices(intersectionalIndices);
        if (intersectionalIndices.Count <= 1) continue;
        yield return intersectionalIndices;
      }
    }
  }
}