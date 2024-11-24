using System.Collections.Generic;

namespace Veho.Mutable.Matrix {
  public static class Info {
    public static bool Any<T>(this IReadOnlyList<IReadOnlyList<T>> rows) => rows.Count > 0 && rows[0].Count > 0;
    public static (int height, int width) Size<T>(this IReadOnlyList<IReadOnlyList<T>> rows) {
      var h = rows.Count;
      return (h, h == 0 ? 0 : rows[0].Count);
    }
    public static int Height<T>(this IReadOnlyList<IReadOnlyList<T>> rows) => rows.Count;
    public static int Width<T>(this IReadOnlyList<IReadOnlyList<T>> rows) => rows.Count == 0 ? 0 : rows[0].Count;
    public static int TotalCount<T>(this IReadOnlyList<IReadOnlyList<T>> rows) {
      var total = 0;
      Sequence.Mapper.Iterate(rows, row => total += row.Count);
      return total;
    }
  }
}