using System;
using System.Collections.Generic;

namespace Veho.Enumerable {
  public static class Selectors {
    public static IEnumerable<T> DistinctBy<T, TK>(this IEnumerable<T> source, Func<T, TK> keySelector) {
      var seenKeys = new HashSet<TK>();
      foreach (var element in source) {
        if (seenKeys.Add(keySelector(element))) {
          yield return element;
        }
      }
    }
    public static List<int> FilterIndices<T>(this IEnumerable<T> list, Predicate<T> criteria) {
      return list.Fold((i, indexes, x) => {
        if (criteria(x)) indexes.Add(i);
      }, new List<int>());
    }
    public static List<int> FilterIndices<T>(this IEnumerable<T> list, Func<int, T, bool> criteria) {
      return list.Fold((i, indexes, x) => {
        if (criteria(i, x)) indexes.Add(i);
      }, new List<int>());
    }
    public static bool Every<T>(this IEnumerable<T> list, Predicate<T> match) {
      foreach (var x in list)
        if (!match(x))
          return false;
      return true;
    }
    public static bool Some<T>(this IEnumerable<T> list, Predicate<T> match) {
      foreach (var x in list)
        if (match(x))
          return true;
      return false;
    }
  }
}