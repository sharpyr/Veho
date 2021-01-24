using System;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Enumerable {
  public static class Mapper {
    public static TO[] Map<T, TO>(this IEnumerable<T> en, Func<T, TO> func) {
      return en.Select(func).ToArray();
    }
    public static void Iterate<T>(this IEnumerable<T> en, Action<T> func) {
      foreach (var x in en) func(x);
    }
    public static void Iterate<T>(this IEnumerable<T> en, Action<int, T> func) {
      var i = 0;
      foreach (var x in en) func(i++, x);
    }
    public static int Hi<T>(this IEnumerable<T> en) => en.Count() - 1;
  }
}