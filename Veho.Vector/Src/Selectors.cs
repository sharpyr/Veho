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
    // public static void SetLength<T>(this T[] arr, int hi) => Array.Resize(ref arr, hi + 1);
  }
}