using System;
using System.Collections.Generic;

namespace Veho.Vector {
  public static class Zippers {
    public static T[] Zip<TA, TB, T>(this IReadOnlyList<TA> vec, IReadOnlyList<TB> other, Func<TA, TB, T> func) {
      var hi = vec.Count;
      var result = new T[hi];
      for (var i = 0; i < hi; i++) result[i] = func(vec[i], other[i]);
      return result;
    }
    public static void IterZip<TA, TB>(this IReadOnlyList<TA> vec, IReadOnlyList<TB> other, Action<TA, TB> action) {
      var hi = vec.Count;
      for (var i = 0; i < hi; i++) action(vec[i], other[i]);
    }
    public static TA[] MutaZip<TA, TB>(this TA[] vec, TB[] arr, Func<TA, TB, TA> func) {
      var hi = vec.Length;
      for (var i = 0; i < hi; i++) vec[i] = func(vec[i], arr[i]);
      return vec;
    }

    public static T[] Zipper<TA, TB, T>(this Func<TA, TB, T> func, IReadOnlyList<TA> a, IReadOnlyList<TB> b) {
      var hi = a.Count;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = func(a[i], b[i]);
      return vec;
    }
    public static T[] Zipper<TA, TB, TC, T>(this Func<TA, TB, TC, T> func, IReadOnlyList<TA> a, IReadOnlyList<TB> b, IReadOnlyList<TC> c) {
      var hi = a.Count;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = func(a[i], b[i], c[i]);
      return vec;
    }
    public static T[] Zipper<TA, TB, TC, TD, T>(this Func<TA, TB, TC, TD, T> func, IReadOnlyList<TA> a, IReadOnlyList<TB> b, IReadOnlyList<TC> c, IReadOnlyList<TD> d) {
      var hi = a.Count;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = func(a[i], b[i], c[i], d[i]);
      return vec;
    }
  }
}