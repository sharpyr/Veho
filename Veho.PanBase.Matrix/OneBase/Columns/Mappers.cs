using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.OneBase.Columns {
  public static class Mappers {
    public static IEnumerable<T[]> ColumnsIter<T>(this T[,] matrix) {
      var (height, width) = matrix.Size();
      for (var j = 0; j < width; j++) {
        yield return matrix.ZeroizeColumn(j, height);
      }
    }
  }
}