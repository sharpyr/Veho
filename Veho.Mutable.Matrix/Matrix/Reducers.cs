using System;
using System.Collections.Generic;
using Veho.Sequence;
using SEQ = Veho.Sequence;

namespace Veho.Mutable.Matrix {
  public static partial class Reducers {
    public static List<T> Flat<T>(this List<List<T>> rows) {
      var (h, w) = rows.Size();
      return SEQ::Reducers.Fold(rows, (accum, row) => {
        accum.AddRange(row);
        return accum;
      }, new List<T>(h * w));
    }
    public static List<TO> FlatMap<T, TO>(this List<List<T>> rows, Func<T, TO> func) {
      var (h, w) = rows.Size();
      return SEQ::Reducers.Fold(rows, (accum, row) => {
        accum.AddRange(row.Map(func));
        return accum;
      }, new List<TO>(h * w));
    }
    public static List<TO> FlatMap<T, TO>(this List<List<T>> rows, Func<int, T, TO> func) {
      var (h, w) = rows.Size();
      var i = 0;
      return SEQ::Reducers.Fold(rows, (accum, row) => {
        row.Iterate(x => accum.Add(func(i++, x)));
        return accum;
      }, new List<TO>(h * w));
    }

    public static TO Fold<T, TO>(this List<List<T>> rows, Func<TO, T, TO> sequence, TO acc) {
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) acc = sequence(acc, row[j]);
      }
      return acc;
    }
    public static TO Fold<T, TO>(this List<List<T>> rows, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
      if (!rows.Any()) return default;
      var acc = indicator(rows.First());
      rows.RestOf((0, 0), cell => acc = sequence(acc, cell));
      return acc;
    }
    public static TO Fold<T, TO>(this List<List<T>> rows, Func<int, int, TO, T, TO> sequence, TO acc) {
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) acc = sequence(i, j, acc, row[j]);
      }
      return acc;
    }
    public static TO Fold<T, TO>(this List<List<T>> rows, Func<int, int, TO, T, TO> sequence, Func<T, TO> indicator) {
      if (!rows.Any()) return default;
      var acc = indicator(rows.First());
      rows.RestOf((0, 0), (i, j, cell) => acc = sequence(i, j, acc, cell));
      return acc;
    }
  }

  public static partial class Reducers {
    public static T Reduce<T>(this List<List<T>> rows, Func<T, T, T> sequence) {
      if (!rows.Any()) return default;
      var acc = rows.First();
      rows.RestOf((0, 0), cell => acc = sequence(acc, cell));
      return acc;
    }
    public static TO Reduce<T, TO>(this List<List<T>> rows, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      if (!rows.Any()) return default;
      var acc = indicator(rows.First());
      rows.RestOf((0, 0), cell => acc = sequence(acc, indicator(cell)));
      return acc;
    }
    public static T Reduce<T>(this List<List<T>> rows, Func<int, int, T, T, T> sequence) {
      if (!rows.Any()) return default;
      var acc = rows.First();
      rows.RestOf((0, 0), (i, j, cell) => acc = sequence(i, j, acc, cell));
      return acc;
    }
    public static TO Reduce<T, TO>(this List<List<T>> rows, Func<int, int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      if (!rows.Any()) return default;
      var acc = indicator(rows.First());
      rows.RestOf((0, 0), (i, j, cell) => acc = sequence(i, j, acc, indicator(cell)));
      return acc;
    }
  }
}