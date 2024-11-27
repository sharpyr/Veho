using System;
using System.Collections.Generic;
using Typen;
using Veho.Sequence;

namespace Veho.Mutable.Matrix {
  public static partial class Mappers {
    public static void Iterate<T>(this IEnumerable<IReadOnlyList<T>> rows, Action<T> func) {
      foreach (var row in rows) {
        foreach (var cell in row) {
          func(cell);
        }
      }
    }
    public static void Iterate<T>(this IReadOnlyList<IReadOnlyList<T>> rows, Action<int, int, T> func) {
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) {
          func(i, j, row[j]);
        }
      }
    }
  }

  public static partial class Mappers {
    public static List<List<TO>> Map<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<T, TO> func) {
      return rows.Map(row => row.Map(func));
    }
    public static List<List<TO>> Map<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Func<int, int, T, TO> func) {
      return rows.Map((i, row) => row.Map((j, cell) => func(i, j, cell)));
    }
    public static List<List<T>> Mutate<T>(this List<List<T>> rows, Func<T, T> func) {
      foreach (var row in rows) {
        for (int j = 0, w = row.Count; j < w; j++) {
          row[j] = func(row[j]);
        }
      }
      return rows;
    }
    public static List<List<T>> Mutate<T>(this List<List<T>> rows, Func<int, int, T, T> func) {
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++)
          row[j] = func(i, j, row[j]);
      }
      return rows;
    }
    public static List<List<TO>> CastTo<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows) => rows.Map(Conv.Cast<T, TO>);
    public static List<List<TO>> CastTo<T, TO>(this IReadOnlyList<IReadOnlyList<T>> rows, Converter<T, TO> converter) => rows.Map(x => converter(x));
  }

  public static partial class Mappers {
    public static void RestOf<T>(this IReadOnlyList<IReadOnlyList<T>> rows, (int x, int y) start, Action<T> action) {
      var (x, y) = start;
      if (x >= rows.Count) return;
      var row = rows[x];
      for (int j = y + 1, w = row.Count; j < w; j++) action(row[j]);
      for (int i = x + 1, h = rows.Count; i < h; i++) {
        row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) action(row[j]);
      }
    }
    public static void RestOf<T>(this IReadOnlyList<IReadOnlyList<T>> rows, (int x, int y) start, Action<int, int, T> action) {
      var (x, y) = start;
      if (x >= rows.Count) return;
      var row = rows[x];
      for (int j = y + 1, w = row.Count; j < w; j++) action(x, j, row[j]);
      for (int i = x + 1, h = rows.Count; i < h; i++) {
        row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) action(i, j, row[j]);
      }
    }
  }
}