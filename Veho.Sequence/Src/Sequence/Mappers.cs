using System;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Sequence {
  public static class Mappers {
    //
    // IList(of T)
    //
    public static TOut[] MapToArray<T, TOut>(this IReadOnlyList<T> list, Func<T, TOut> func) {
      var tar = new TOut[list.Count];
      for (var i = 0; i < list.Count; i++)
        tar[i] = func(list.ElementAt(i));
      return tar;
    }
    public static List<TOut> Map<T, TOut>(this IReadOnlyList<T> list, Func<T, TOut> func) {
      var tar = new List<TOut>(list.Count);
      for (int i = 0, hi = list.Count; i < hi; i++) tar.Add(func(list[i]));
      return tar;
    }
    public static List<TOut> Map<T, TOut>(this IReadOnlyList<T> list, Func<int, T, TOut> fn) {
      var tar = new List<TOut>(list.Count);
      for (int i = 0, hi = list.Count; i < hi; i++) tar.Add(fn(i, list[i]));
      return tar;
    }
    public static void Iterate<T>(this IReadOnlyList<T> list, Action<T> func) {
      foreach (var cel in list) func(cel);
    }
    public static void Iterate<T>(this IReadOnlyList<T> list, Action<int, T> func) {
      for (var i = 0; i < list.Count; i++) func(i, list.ElementAt(i));
    }
    public static void IterateBack<T>(this IReadOnlyList<T> list, Action<T> func) {
      for (var i = list.Hi(); i >= 0; i--) func(list[i]);
    }

    public static int Hi<T>(this IReadOnlyList<T> list) => list.Count - 1;
  }
}