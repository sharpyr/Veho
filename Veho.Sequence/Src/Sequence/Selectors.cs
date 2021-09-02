using System;
using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Selectors {
    public static (T element, TO indicator) Indicator<T, TO>(this IReadOnlyList<T> list, int index, Func<T, TO> indicator) {
      var element = list[index];
      var selected = indicator(element);
      return (element, selected);
    }
    public static List<int> FilterIndices<T>(this IReadOnlyList<T> list, Predicate<T> criteria) {
      var hi = list.Count;
      return list.Fold((i, indexes, x) => {
        if (criteria(x)) indexes.Add(i);
      }, new List<int>(hi));
    }
    public static List<int> FilterIndices<T>(this IReadOnlyList<T> list, Func<int, T, bool> criteria) {
      var hi = list.Count;
      return list.Fold((i, indexes, x) => {
        if (criteria(i, x)) indexes.Add(i);
      }, new List<int>(hi));
    }
    public static List<T> SelectBy<T>(this IReadOnlyList<T> list, IReadOnlyList<int> indices) {
      var target = new List<T>(indices.Count);
      var i = 0;
      foreach (var index in indices) target[i++] = list[index];
      return target;
    }

    public static (T a, T b) T2<T>(this IReadOnlyList<T> list) => (list[0], list[1]);
    public static (T a, T b, T c) T3<T>(this IReadOnlyList<T> list) => (list[0], list[1], list[2]);
    public static (T a, T b, T c, T d) T4<T>(this IReadOnlyList<T> list) => (list[0], list[1], list[2], list[4]);
  }
}