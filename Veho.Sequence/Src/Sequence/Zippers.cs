using System;
using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Zippers {
    public static List<T> Zip<TA, TB, T>(this IReadOnlyList<TA> a, IReadOnlyList<TB> b, Func<TA, TB, T> func) {
      var hi = a.Count;
      var tar =new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(func(a[i], b[i]));
      return tar;
    }
    public static List<T> Zip<TA, TB, T>(this IReadOnlyList<TA> a, IReadOnlyList<TB> b, Func<int, TA, TB, T> func) {
      var hi = a.Count;
      var tar =new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(func(i, a[i], b[i]));
      return tar;
    }
    public static void ZipList<TA, TB>(this IReadOnlyList<TA> a, IReadOnlyList<TB> b, Action<TA, TB> action) {
      var hi = a.Count;
      for (var i = 0; i < hi; i++) action(a[i], b[i]);
    }
    public static void ZipList<TA, TB>(this IReadOnlyList<TA> a, IReadOnlyList<TB> b, Action<int, TA, TB> action) {
      var hi = a.Count;
      for (var i = 0; i < hi; i++) action(i, a[i], b[i]);
    }
    public static List<TA> MutaZip<TA, TB>(this List<TA> a, IReadOnlyList<TB> b, Func<TA, TB, TA> func) {
      var hi = a.Count;
      for (var i = 0; i < hi; i++) a[i] = func(a[i], b[i]);
      return a;
    }
    public static List<TA> MutaZip<TA, TB>(this List<TA> a, IReadOnlyList<TB> b, Func<int, TA, TB, TA> func) {
      var hi = a.Count;
      for (var i = 0; i < hi; i++) a[i] = func(i, a[i], b[i]);
      return a;
    }
    public static List<T> Zipper<TA, TB, T>(this Func<TA, TB, T> func, IReadOnlyList<TA> a, IReadOnlyList<TB> b) {
      var hi = a.Count;
      var tar =new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(func(a[i], b[i]));
      return tar;
    }
    public static List<T> Zipper<TA, TB, TC, T>(this Func<TA, TB, TC, T> func, IReadOnlyList<TA> a, IReadOnlyList<TB> b, IReadOnlyList<TC> c) {
      var hi = a.Count;
      var tar =new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(func(a[i], b[i], c[i]));
      return tar;
    }
    public static List<T> Zipper<TA, TB, TC, TD, T>(this Func<TA, TB, TC, TD, T> func, IReadOnlyList<TA> a, IReadOnlyList<TB> b, IReadOnlyList<TC> c, IReadOnlyList<TD> d) {
      var hi = a.Count;
      var tar =new List<T>(hi);
      for (var i = 0; i < hi; i++) tar.Add(func(a[i], b[i], c[i], d[i]));
      return tar;
    }
  }
}