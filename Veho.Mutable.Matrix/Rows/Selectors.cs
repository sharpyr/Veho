using System.Collections.Generic;
using Veho.Mutable.Matrix;
using Veho.Sequence;

namespace Veho.Mutable.Rows {
  public static class Selectors {
    public static IEnumerable<List<T>> IntoRowsIter<T>(this IReadOnlyList<IReadOnlyList<T>> matrix, IReadOnlyList<int> columnIndices) {
      var height = matrix.Height();
      for (var i = 0; i < height; i++) {
        yield return matrix[i].SelectBy(columnIndices);
      }
    }
  }
}