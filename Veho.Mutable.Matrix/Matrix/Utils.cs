using System.Collections.Generic;

namespace Veho.Mutable.Matrix {
  public static class Utils {
    public static List<List<T>> Transpose<T>(this List<List<T>> rows) {
      var columns = rows.Size().Init<T>();
      rows.Iterate((i, j, cell) => { columns[j][i] = cell; });
      return columns;
    }
  }
}