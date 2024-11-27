using System;
using System.Collections.Generic;
using Veho.Sequence;
using SEQ = Veho.Sequence;

namespace Veho.Mutable.Matrix {
  public static partial class Reducer {
    public static List<T> Flat<T>(this IReadOnlyList<IReadOnlyList<T>> rows) {
      var (h, w) = rows.Size();
      return SEQ::Reducer.FoldList(rows, (tar, row) => {
        tar.AddRange(row);
        return tar;
      }, new List<T>(h * w));
    }
    public static List<TO> FlatMap<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<T, TO> func) {
      var (h, w) = rows.Size();
      return SEQ::Reducer.FoldList(rows, (tar, row) => {
        tar.AddRange(row.Map(func));
        return tar;
      }, new List<TO>(h * w));
    }
    public static List<TO> FlatMap<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<int, T, TO> func) {
      var (h, w) = rows.Size();
      var i = 0;
      return SEQ::Reducer.FoldList(rows, (tar, row) => {
        row.IterateList(x => tar.Add(func(i++, x)));
        return tar;
      }, new List<TO>(h * w));
    }

    public static TO Fold<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<TO, T, TO> fold, TO acc) {
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) acc = fold(acc, row[j]);
      }
      return acc;
    }
    public static TO Fold<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<TO, T, TO> fold, Func<T, TO> to) {
      if (!rows.Any()) return default;
      var acc = to(rows.First());
      rows.RestOf((0, 0), cell => acc = fold(acc, cell));
      return acc;
    }
    public static TO Fold<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<int, int, TO, T, TO> fold, TO acc) {
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) acc = fold(i, j, acc, row[j]);
      }
      return acc;
    }
    public static TO Fold<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<int, int, TO, T, TO> fold, Func<T, TO> to) {
      if (!rows.Any()) return default;
      var acc = to(rows.First());
      rows.RestOf((0, 0), (i, j, cell) => acc = fold(i, j, acc, cell));
      return acc;
    }
  }

  public static partial class Reducer {
    public static T Reduce<T>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<T, T, T> fold) {
      if (!rows.Any()) return default;
      var acc = rows.First();
      rows.RestOf((0, 0), cell => acc = fold(acc, cell));
      return acc;
    }
    public static TO Reduce<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<TO, TO, TO> fold, Func<T, TO> to) {
      if (!rows.Any()) return default;
      var acc = to(rows.First());
      rows.RestOf((0, 0), cell => acc = fold(acc, to(cell)));
      return acc;
    }
    public static T Reduce<T>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<int, int, T, T, T> fold) {
      if (!rows.Any()) return default;
      var acc = rows.First();
      rows.RestOf((0, 0), (i, j, cell) => acc = fold(i, j, acc, cell));
      return acc;
    }
    public static TO Reduce<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<int, int, TO, TO, TO> fold, Func<T, TO> to) {
      if (!rows.Any()) return default;
      var acc = to(rows.First());
      rows.RestOf((0, 0), (i, j, cell) => acc = fold(i, j, acc, to(cell)));
      return acc;
    }
  }
}