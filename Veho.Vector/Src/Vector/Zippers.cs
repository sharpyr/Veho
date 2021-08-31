using System;
using System.Collections.Generic;

namespace Veho.Vector {
  public static class Zippers {
    public static T[] Zip<TA, TB, T>(this IReadOnlyList<TA> vector, IReadOnlyList<TB> other, Func<TA, TB, T> fn) {
      var hi = vector.Count;
      var result = new T[hi];
      for (var i = 0; i < hi; i++) result[i] = fn(vector[i], other[i]);
      return result;
    }
    public static void IterZip<TA, TB>(this IReadOnlyList<TA> vector, IReadOnlyList<TB> other, Action<TA, TB> action) {
      var hi = vector.Count;
      for (var i = 0; i < hi; i++) action(vector[i], other[i]);
    }
    public static TA[] MutaZip<TA, TB>(this TA[] vector, TB[] another, Func<TA, TB, TA> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) vector[i] = fn(vector[i], another[i]);
      return vector;
    }

    public static T[] Zipper<TA, TB, T>(this Func<TA, TB, T> fn, IReadOnlyList<TA> a, IReadOnlyList<TB> b) {
      var hi = a.Count;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = fn(a[i], b[i]);
      return vec;
    }
    public static T[] Zipper<TA, TB, TC, T>(this Func<TA, TB, TC, T> fn, IReadOnlyList<TA> a, IReadOnlyList<TB> b, IReadOnlyList<TC> c) {
      var hi = a.Count;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = fn(a[i], b[i], c[i]);
      return vec;
    }
    public static T[] Zipper<TA, TB, TC, TD, T>(this Func<TA, TB, TC, TD, T> fn, IReadOnlyList<TA> a, IReadOnlyList<TB> b, IReadOnlyList<TC> c, IReadOnlyList<TD> d) {
      var hi = a.Count;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = fn(a[i], b[i], c[i], d[i]);
      return vec;
    }
  }
}