using System;
using System.Collections.Generic;
using Typen;
using Veho.Sequence;

namespace Veho.Mutable.Matrix {
  public static partial class Mappers {
    public static void Iterate<T>(this List<List<T>> rows, Action<T> fn) {
      foreach (var row in rows) {
        foreach (var cell in row) {
          fn(cell);
        }
      }
    }
    public static void Iterate<T>(this List<List<T>> rows, Action<int, int, T> fn) {
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) {
          fn(i, j, row[j]);
        }
      }
    }
  }

  public static partial class Mappers {
    public static List<List<TO>> Map<T, TO>(this List<List<T>> rows, Func<T, TO> fn) {
      return rows.Map(row => row.Map(fn));
    }
    public static List<List<TO>> Map<T, TO>(this List<List<T>> rows, Func<int, int, T, TO> fn) {
      return rows.Map((i, row) => row.Map((j, cell) => fn(i, j, cell)));
    }
    public static List<List<T>> Mutate<T>(this List<List<T>> rows, Func<T, T> fn) {
      foreach (var row in rows) {
        for (int j = 0, w = row.Count; j < w; j++) {
          row[j] = fn(row[j]);
        }
      }
      return rows;
    }
    public static List<List<T>> Mutate<T>(this List<List<T>> rows, Func<int, int, T, T> fn) {
      for (int i = 0, h = rows.Count; i < h; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++)
          row[j] = fn(i, j, row[j]);
      }
      return rows;
    }
    public static List<List<TO>> CastTo<T, TO>(this List<List<T>> rows) => rows.Map(Conv.Cast<T, TO>);
    public static List<List<TO>> CastTo<T, TO>(this List<List<T>> rows, Converter<T, TO> converter) => rows.Map(x => converter(x));
  }

  public static partial class Mappers {
    public static void RestOf<T>(this List<List<T>> rows, (int x, int y) start, Action<T> action) {
      var (x, y) = start;
      if (x >= rows.Count) return;
      var row = rows[x];
      for (int j = y + 1, w = row.Count; j < w; j++) action(row[j]);
      for (int i = x + 1, h = rows.Count; i < h; i++) {
        row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) action(row[j]);
      }
    }
    public static void RestOf<T>(this List<List<T>> rows, (int x, int y) start, Action<int, int, T> action) {
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