using System;
using System.Collections.Generic;

namespace Veho.Mutable.Columns {
  public static class Indexers {
    public static List<T> Column<T>(this IReadOnlyList<IReadOnlyList<T>> rows, int y) {
      var h = rows.Count;
      var col = new List<T>(rows.Count);
      for (var i = 0; i < h; i++) col.Add(rows[i][y]);
      return col;
    }
    public static List<TO> Column<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<T, TO> func) {
      var h = rows.Count;
      var col = new List<TO>(rows.Count);
      for (var i = 0; i < h; i++) col.Add(func(rows[i][y]));
      return col;
    }
    public static List<TO> Column<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<int, T, TO> func) {
      var h = rows.Count;
      var col = new List<TO>(rows.Count);
      for (var i = 0; i < h; i++) col.Add(func(i, rows[i][y]));
      return col;
    }
  }
}