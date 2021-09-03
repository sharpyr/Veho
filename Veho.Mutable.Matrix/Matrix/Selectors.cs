using System.Collections.Generic;
using Veho.Sequence;

namespace Veho.Mutable.Matrix {
  public static class Selectors {
    public static List<List<T>> SelectBy<T>(IReadOnlyList<IReadOnlyList<T>> rows, IReadOnlyList<int> sideIndices, IReadOnlyList<int> headIndices) {
      return rows.SelectBy(sideIndices).Map(row => row.SelectBy(headIndices));
    }
  }
}