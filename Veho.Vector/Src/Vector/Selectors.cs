using System;
using System.Collections.Generic;

namespace Veho.Vector {
  public static class Selectors {
    public static int IndexOf<T>(this T[] arr, T value) => Array.IndexOf(arr, value);
    public static int IndexOf<T>(this T[] arr, Predicate<T> match) => Array.FindIndex(arr, match);
    public static int LastIndexOf<T>(this T[] arr, T value) => Array.LastIndexOf(arr, value);
    public static int LastIndexOf<T>(this T[] arr, Predicate<T> match) => Array.FindLastIndex(arr, match);
    public static T[] Filter<T>(this T[] arr, Predicate<T> predicate) => Array.FindAll(arr, predicate);
    public static T[] SelectBy<T>(this IReadOnlyList<T> arr, IReadOnlyList<int> indices) {
      var target = new T[indices.Count];
      var i = 0;
      foreach (var index in indices) target[i++] = arr[index];
      return target;
    }
    public static T[] Sort<T>(this T[] arr, Comparison<T> comparer) {
      Array.Sort(arr, comparer);
      return arr;
    }
    public static bool Every<T>(this T[] arr, Predicate<T> match) => Array.TrueForAll(arr, match);
    public static bool Some<T>(this T[] arr, Predicate<T> match) => Array.Exists(arr, match);

    public static (T, T) T2<T>(this T[] arr) => (arr[0], arr[1]);
    public static (T, T, T) T3<T>(this T[] arr) => (arr[0], arr[1], arr[2]);
    public static (T, T, T, T) T4<T>(this T[] arr) => (arr[0], arr[1], arr[2], arr[4]);
  }
}