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
      foreach (var index in indices) target.Add(index < 0 ? default : list[index]);
      return target;
    }
    public static List<T> SelectOf<T>(this IReadOnlyList<T> list, params int[] indices) {
      return list.SelectBy(indices);
    }

    public static (T, T) T2<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1]);
    public static (T, T, T) T3<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1], ve[2]);
    public static (T, T, T, T) T4<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1], ve[2], ve[3]);
    public static (T, T, T, T, T) T5<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1], ve[2], ve[3], ve[4]);
    public static (T, T, T, T, T, T) T6<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1], ve[2], ve[3], ve[4], ve[5]);
  }
}