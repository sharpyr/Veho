using System;

namespace Veho.Vector {
  public static class Selectors {
    public static int IndexOf<T>(this T[] arr, T value) => Array.IndexOf(arr, value);
    public static int IndexOf<T>(this T[] arr, Predicate<T> match) => Array.FindIndex(arr, match);
    public static int LastIndexOf<T>(this T[] arr, T value) => Array.LastIndexOf(arr, value);
    public static int LastIndexOf<T>(this T[] arr, Predicate<T> match) => Array.FindLastIndex(arr, match);
    public static T[] Filter<T>(this T[] arr, Predicate<T> predicate) => Array.FindAll(arr, predicate);
    public static T[] Sort<T>(this T[] arr, Comparison<T> comparer) {
      Array.Sort(arr, comparer);
      return arr;
    }
    public static bool Every<T>(this T[] arr, Predicate<T> match) => Array.TrueForAll(arr, match);
    public static bool Some<T>(this T[] arr, Predicate<T> match) => Array.Exists(arr, match);
  }
}