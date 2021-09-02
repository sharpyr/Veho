using System;
using System.Collections.Generic;
using Veho.Sequence;

namespace Veho.Mutable.LinearAlgebra {
  public static class SymmetricMatrix {
    public static List<List<T>> SelectBy<T>(IReadOnlyList<IReadOnlyList<T>> rows, IReadOnlyList<int> indices) {
      return rows.SelectBy(indices).Map(row => row.SelectBy(indices));
    }
    public static List<List<T>> UpperTriangular<T>(IReadOnlyList<IReadOnlyList<T>> rows) {
      var target = new List<List<T>>(rows.Count);
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        var tRow = new List<T>(row.Count);
        target.Add(tRow);
        for (var j = 0; j < i; j++) tRow.Add(default);
        for (int j = i, w = row.Count; j < w; j++) tRow.Add(row[j]);
      }
      return target;
    }
    public static List<List<T>> LowerTriangular<T>(IReadOnlyList<IReadOnlyList<T>> rows) {
      var target = new List<List<T>>(rows.Count);
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        var tRow = new List<T>(row.Count);
        target.Add(tRow);
        for (var j = 0; j <= i; j++) tRow.Add(row[j]);
        for (int j = i + 1, w = row.Count; j < w; j++) tRow.Add(default);
      }
      return target;
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