using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.Columns {
  public static class Selectors {
    public static T[,] SelectColumns<T>(this T[,] rows, IReadOnlyList<int> columnIndices) {
      int h = rows.Height(), w = columnIndices.Count;
      var target = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = rows[i, columnIndices[j]];
      return target;
    }
  }
}