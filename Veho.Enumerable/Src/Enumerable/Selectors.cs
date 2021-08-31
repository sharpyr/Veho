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
  }
}