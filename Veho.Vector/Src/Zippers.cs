using System;

namespace Veho.Vector {
  public static class Zippers {
    public static T[] Zip<TA, TB, T>(this TA[] vector, TB[] other, Func<TA, TB, T> fn) {
      var hi = vector.Length;
      var result = new T[hi];
      for (var i = 0; i < hi; i++) result[i] = fn(vector[i], other[i]);
      return result;
    }
    public static TA[] Mutazip<TA, TB>(this TA[] vector, TB[] another, Func<TA, TB, TA> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) vector[i] = fn(vector[i], another[i]);
      return vector;
    }
    public static T[] Zipper<TA, TB, T>(this Func<TA, TB, T> fn, TA[] a, TB[] b) {
      var hi = a.Length;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = fn(a[i], b[i]);
      return vec;
    }
    public static T[] Zipper<TA, TB, TC, T>(this Func<TA, TB, TC, T> fn, TA[] a, TB[] b, TC[] c) {
      var hi = a.Length;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = fn(a[i], b[i], c[i]);
      return vec;
    }
    public static T[] Zipper<TA, TB, TC, TD, T>(this Func<TA, TB, TC, TD, T> fn, TA[] a, TB[] b, TC[] c, TD[] d) {
      var hi = a.Length;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = fn(a[i], b[i], c[i], d[i]);
      return vec;
    }
  }
}