using System;
using System.Collections.Generic;

namespace Veho.Enumerable {
  public static partial class Selector {
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
    // public static bool Every<T>(this IEnumerable<T> list, Predicate<T> match) {
    //   foreach (var x in list)
    //     if (!match(x))
    //       return false;
    //   return true;
    // }
    // public static bool Some<T>(this IEnumerable<T> list, Predicate<T> match) {
    //   foreach (var x in list)
    //     if (match(x))
    //       return true;
    //   return false;
    // }
  }

  public static partial class Selector {
    public static bool Every<T>(this IEnumerable<T> list, Predicate<T> match) {
      foreach (var x in list)
        if (!match(x))
          return false;
      return true;
    }
    public static bool Every<T>(this IEnumerable<T> list, Func<int, T, bool> match) {
      var i = 0;
      foreach (var x in list)
        if (!match(i++, x))
          return false;
      return true;
    }
    public static bool Some<T>(this IEnumerable<T> list, Predicate<T> match) {
      foreach (var x in list)
        if (match(x))
          return true;
      return false;
    }
    public static bool Some<T>(this IEnumerable<T> list, Func<int, T, bool> match) {
      var i = 0;
      foreach (var x in list)
        if (match(i++, x))
          return true;
      return false;
    }
    public static T Find<T>(this IEnumerable<T> list, Predicate<T> match) {
      foreach (var x in list)
        if (match(x))
          return x;
      return default;
    }
    public static T Find<T>(this IEnumerable<T> list, Func<int, T, bool> match) {
      var i = 0;
      foreach (var x in list)
        if (match(i++, x))
          return x;
      return default;
    }
    public static int FindIndex<T>(this IEnumerable<T> list, Predicate<T> match) {
      var i = 0;
      foreach (var x in list) {
        if (match(x)) return i;
        i++;
      }
      return -1;
    }
    public static int FindIndex<T>(this IEnumerable<T> list, Func<int, T, bool> match) {
      var i = 0;
      foreach (var x in list) {
        if (match(i, x)) return i;
        i++;
      }
      return -1;
    }
    public static int IndexOf<T>(this IEnumerable<T> list, T value) where T : IEquatable<T> {
      var i = 0;
      foreach (var x in list) {
        if (x.Equals(value)) return i;
        i++;
      }
      return -1;
    }

    // public static (T, T) T2<T>(this IEnumerable<T> ve) => (ve[0], ve[1]);
    // public static (T, T, T) T3<T>(this IEnumerable<T> ve) => (ve[0], ve[1], ve[2]);
    // public static (T, T, T, T) T4<T>(this IEnumerable<T> ve) => (ve[0], ve[1], ve[2], ve[3]);
    // public static (T, T, T, T, T) T5<T>(this IEnumerable<T> ve) => (ve[0], ve[1], ve[2], ve[3], ve[4]);
    // public static (T, T, T, T, T, T) T6<T>(this IEnumerable<T> ve) => (ve[0], ve[1], ve[2], ve[3], ve[4], ve[5]);
  }
}