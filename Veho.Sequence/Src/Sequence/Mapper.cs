using System;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Sequence {
  public static class Mapper {
    //
    // IList(of T)
    //
    public static List<T> Slice<T>(this IReadOnlyList<T> list) {
      return list.Map(x => x);
    }
    public static List<TOut> Map<T, TOut>(this IReadOnlyList<T> list, Func<T, TOut> func) {
      var tar = new List<TOut>(list.Count);
      for (int i = 0, hi = list.Count; i < hi; i++) tar.Add(func(list[i]));
      return tar;
    }
    public static List<TOut> Map<T, TOut>(this IReadOnlyList<T> list, Func<int, T, TOut> func) {
      var tar = new List<TOut>(list.Count);
      for (int i = 0, hi = list.Count; i < hi; i++) tar.Add(func(i, list[i]));
      return tar;
    }
    public static TOut[] MapListToArray<T, TOut>(this IReadOnlyList<T> list, Func<T, TOut> func) {
      var tar = new TOut[list.Count];
      for (var i = 0; i < list.Count; i++)
        tar[i] = func(list.ElementAt(i));
      return tar;
    }
    public static void IterateList<T>(this IReadOnlyList<T> list, Action<T> func) {
      foreach (var cel in list) func(cel);
    }
    public static void IterateList<T>(this IReadOnlyList<T> list, Action<int, T> func) {
      for (var i = 0; i < list.Count; i++) func(i, list.ElementAt(i));
    }
    public static void IterateListBack<T>(this IReadOnlyList<T> list, Action<T> func) {
      for (var i = list.Count - 1; i >= 0; i--) func(list[i]);
    }
  }
}