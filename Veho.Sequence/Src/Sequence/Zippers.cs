using System;
using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Zippers {
    public static List<T> Zip<TA, TB, T>(this List<TA> a, List<TB> b, Func<TA, TB, T> fn) {
      var hi = a.Count;
      var tar = new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(fn(a[i], b[i]));
      return tar;
    }
    public static List<T> Zip<TA, TB, T>(this List<TA> a, List<TB> b, Func<int, TA, TB, T> fn) {
      var hi = a.Count;
      var tar = new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(fn(i, a[i], b[i]));
      return tar;
    }
    public static void IterZip<TA, TB>(this List<TA> a, List<TB> b, Action<TA, TB> action) {
      var hi = a.Count;
      for (var i = 0; i < hi; i++) action(a[i], b[i]);
    }
    public static void IterZip<TA, TB>(this List<TA> a, List<TB> b, Action<int, TA, TB> action) {
      var hi = a.Count;
      for (var i = 0; i < hi; i++) action(i, a[i], b[i]);
    }
    public static List<TA> MutaZip<TA, TB>(this List<TA> a, List<TB> b, Func<TA, TB, TA> fn) {
      var hi = a.Count;
      for (var i = 0; i < hi; i++) a[i] = fn(a[i], b[i]);
      return a;
    }
    public static List<TA> MutaZip<TA, TB>(this List<TA> a, List<TB> b, Func<int, TA, TB, TA> fn) {
      var hi = a.Count;
      for (var i = 0; i < hi; i++) a[i] = fn(i, a[i], b[i]);
      return a;
    }
    public static List<T> Zipper<TA, TB, T>(this Func<TA, TB, T> fn, List<TA> a, List<TB> b) {
      var hi = a.Count;
      var tar = new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(fn(a[i], b[i]));
      return tar;
    }
    public static List<T> Zipper<TA, TB, TC, T>(this Func<TA, TB, TC, T> fn, List<TA> a, List<TB> b, TC[] c) {
      var hi = a.Count;
      var tar = new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(fn(a[i], b[i], c[i]));
      return tar;
    }
    public static List<T> Zipper<TA, TB, TC, TD, T>(this Func<TA, TB, TC, TD, T> fn, List<TA> a, List<TB> b, TC[] c, TD[] d) {
      var hi = a.Count;
      var tar = new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(fn(a[i], b[i], c[i], d[i]));
      return tar;
    }
  }
}