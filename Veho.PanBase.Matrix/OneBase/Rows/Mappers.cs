using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.OneBase.Rows {
  public static class Mappers {
    public static IEnumerable<T[]> RowsIter<T>(this T[,] matrix) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++) {
        yield return matrix.ZeroizeRow(i, width);
      }
    }
  }
}