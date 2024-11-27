using System;
using System.Collections.Generic;

namespace Veho.Mutable.Columns {
  public static class Reducer {
    public static TO FoldColumn<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<TO, T, TO> fold, TO tar) {
      for (var i = 0; i < rows.Count; i++) tar = fold(tar, rows[i][y]);
      return tar;
    }

    public static TO FoldColumn<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<TO, T, TO> fold, Func<T, TO> to) {
      var tar = to(rows[0][y]);
      for (var i = 0; i < rows.Count; i++) tar = fold(tar, rows[i][y]);
      return tar;
    }

    public static TO FoldColumn<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<int, TO, T, TO> fold, TO tar) {
      for (var i = 1; i < rows.Count; i++) tar = fold(i, tar, rows[i][y]);
      return tar;
    }

    public static TO FoldColumn<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<int, TO, T, TO> fold, Func<T, TO> to) {
      var tar = to(rows[0][y]);
      for (var i = 0; i < rows.Count; i++) tar = fold(i, tar, rows[i][y]);
      return tar;
    }

    public static T ReduceColumn<T>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<T, T, T> fold) {
      var tar = rows[0][y];
      for (var i = 1; i < rows.Count; i++) tar = fold(tar, rows[i][y]);
      return tar;
    }

    public static TO ReduceColumn<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<TO, TO, TO> fold, Func<T, TO> to) {
      var tar = to(rows[0][y]);
      for (var i = 1; i < rows.Count; i++) tar = fold(tar, to(rows[i][y]));
      return tar;
    }

    public static T ReduceColumn<T>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<int, T, T, T> fold) {
      var tar = rows[0][y];
      for (var i = 1; i < rows.Count; i++) tar = fold(i, tar, rows[i][y]);
      return tar;
    }

    public static TO ReduceColumn<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, int y, Func<int, TO, TO, TO> fold, Func<T, TO> to) {
      var tar = to(rows[0][y]);
      for (var i = 1; i < rows.Count; i++) tar = fold(i, tar, to(rows[i][y]));
      return tar;
    }
  }
}