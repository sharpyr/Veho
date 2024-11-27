using System;
using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Selector {
    public static (T el, TO to) MorphList<T, TO>(this IReadOnlyList<T> list, int i, Func<T, TO> to) {
      var el = list[i];
      return (el, to(el));
    }
    public static List<int> ListIndexes<T>(this IReadOnlyList<T> list, Predicate<T> match) {
      var hi = list.Count;
      return list.FoldList((i, indexes, x) => {
        if (match(x)) indexes.Add(i);
      }, new List<int>(hi));
    }
    public static List<int> ListIndexes<T>(this IReadOnlyList<T> list, Func<int, T, bool> match) {
      var hi = list.Count;
      return list.FoldList((i, indexes, x) => {
        if (match(i, x)) indexes.Add(i);
      }, new List<int>(hi));
    }
    public static List<T> SelectListBy<T>(this IReadOnlyList<T> list, IReadOnlyList<int> indexes) {
      var target = new List<T>(indexes.Count);
      foreach (var index in indexes) target.Add(index < 0 ? default : list[index]);
      return target;
    }
    public static List<T> SelectListOf<T>(this IReadOnlyList<T> list, params int[] indexes) {
      return list.SelectListBy(indexes);
    }
    public static bool EveryOfList<T>(this IReadOnlyList<T> list, Predicate<T> match) {
      for (int i = 0, hi = list.Count; i < hi; i++) {
        if (!match(list[i])) return false;
      }
      return true;
    }
    public static bool EveryOfList<T>(this IReadOnlyList<T> list, Func<int, T, bool> match) {
      for (int i = 0, hi = list.Count; i < hi; i++) {
        if (!match(i, list[i])) return false;
      }
      return true;
    }
    public static bool SomeOfList<T>(this IReadOnlyList<T> list, Predicate<T> match) {
      for (int i = 0, hi = list.Count; i < hi; i++) {
        if (match(list[i])) return true;
      }
      return false;
    }
    public static bool SomeOfList<T>(this IReadOnlyList<T> list, Func<int, T, bool> match) {
      for (int i = 0, hi = list.Count; i < hi; i++) {
        if (match(i, list[i])) return true;
      }
      return false;
    }
    public static T FindInList<T>(this IReadOnlyList<T> list, Predicate<T> match) {
      for (int i = 0, hi = list.Count; i < hi; i++) {
        var value = list[i];
        if (match(value)) return value;
      }
      return default;
    }
    public static T FindInList<T>(this IReadOnlyList<T> list, Func<int, T, bool> match) {
      for (int i = 0, hi = list.Count; i < hi; i++) {
        var value = list[i];
        if (match(i, value)) return value;
      }
      return default;
    }
    public static int FindIndexInList<T>(this IReadOnlyList<T> list, Predicate<T> match) {
      for (int i = 0, hi = list.Count; i < hi; i++) {
        if (match(list[i])) return i;
      }
      return -1;
    }
    public static int IndexOfInList<T>(this IReadOnlyList<T> list, T value) where T : IEquatable<T> {
      for (int i = 0, hi = list.Count; i < hi; i++) {
        if (list[i].Equals(value)) return i;
      }
      return -1;
    }

    public static (T, T) ListToDualet<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1]);
    public static (T, T, T) ListToTriplet<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1], ve[2]);
    public static (T, T, T, T) ListToQuadlet<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1], ve[2], ve[3]);
    public static (T, T, T, T, T) ListToPentlet<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1], ve[2], ve[3], ve[4]);
    public static (T, T, T, T, T, T) ListToHexlet<T>(this IReadOnlyList<T> ve) => (ve[0], ve[1], ve[2], ve[3], ve[4], ve[5]);
  }
}