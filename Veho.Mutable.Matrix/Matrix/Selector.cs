using System.Collections.Generic;
using Veho.Sequence;

namespace Veho.Mutable.Matrix {
  public static class Selector {
    public static List<List<T>> SelectBy<T>(IReadOnlyList<IReadOnlyList<T>> rows, IReadOnlyList<int> sideIndices, IReadOnlyList<int> headIndices) {
      return rows.SelectListBy(sideIndices).Map(row => row.SelectListBy(headIndices));
    }
  }
}