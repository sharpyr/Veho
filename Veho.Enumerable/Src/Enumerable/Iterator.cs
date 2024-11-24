using System;
using System.Collections;
using System.Collections.Generic;

namespace Veho.Enumerable {
  public static partial class Iterator {
    public static IEnumerable<TO> Iter<T, TO>(this IEnumerable<T> items, Func<T, TO> func) {
      foreach (T item in items) yield return func(item);
    }
    public static IEnumerable<TO> Iter<T, TO>(this IEnumerable<T> items, Func<int, T, TO> func) {
      var i = 0;
      foreach (T item in items) yield return func(i++, item);
    }
  }

  public static partial class Iterator {
    public static IEnumerable<TO> Iter<T, TO>(this IEnumerable items, Func<T, TO> func) {
      foreach (T item in items) yield return func(item);
    }
    public static IEnumerable<TO> Iter<T, TO>(this IEnumerable items, Func<int, T, TO> func) {
      var i = 0;
      foreach (T item in items) yield return func(i++, item);
    }
  }
}