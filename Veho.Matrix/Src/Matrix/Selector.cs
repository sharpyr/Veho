using System.Collections.Generic;

namespace Veho.Matrix {
  public static class Selector {
    public static T[,] SelectBy<T>(this T[,] rows, IReadOnlyList<int> sideIndices, IReadOnlyList<int> headIndices) {
      int h = sideIndices.Count, w = headIndices.Count;
      var target = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = rows[sideIndices[i], headIndices[j]];
      return target;
    }
  }
}