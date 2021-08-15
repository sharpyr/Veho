using System;
using System.Collections.Generic;

namespace Veho.Mutable.Columns {
  public static class Indexers {
    public static List<T> Column<T>(this List<List<T>> rows, int y) {
      var h = rows.Count;
      var col = new List<T>(rows.Count);
      for (var i = 0; i < h; i++) col[i] = rows[i][y];
      return col;
    }
    public static List<TO> Column<T, TO>(this List<List<T>> rows, int y, Func<T, TO> fn) {
      var h = rows.Count;
      var col = new List<TO>(rows.Count);
      for (var i = 0; i < h; i++) col[i] = fn(rows[i][y]);
      return col;
    }
    public static List<TO> Column<T, TO>(this List<List<T>> rows, int y, Func<int, T, TO> fn) {
      var h = rows.Count;
      var col = new List<TO>(rows.Count);
      for (var i = 0; i < h; i++) col[i] = fn(i, rows[i][y]);
      return col;
    }
  }
}