using System;
using System.Collections.Generic;

namespace Veho.Enumerable {
  public static class Zippers {
    public static IEnumerable<T> Zip<TA, TB, T>(this IEnumerable<TA> a, IEnumerable<TB> b, Func<TA, TB, T> func) {
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext()) {
          yield return func(aI.Current, bI.Current);
        }
    }
    public static IEnumerable<T> Zip<TA, TB, T>(this IEnumerable<TA> a, IEnumerable<TB> b, Func<int, TA, TB, T> func) {
      var i = 0;
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext()) {
          yield return func(i++, aI.Current, bI.Current);
        }
    }
    public static void IterZip<TA, TB>(this IEnumerable<TA> a, IEnumerable<TB> b, Action<TA, TB> action) {
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext()) {
          action(aI.Current, bI.Current);
        }
    }
    public static void IterZip<TA, TB>(this IEnumerable<TA> a, IEnumerable<TB> b, Action<int, TA, TB> action) {
      var i = 0;
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext()) {
          action(i++, aI.Current, bI.Current);
        }
    }
   
    public static IEnumerable<T> Zipper<TA, TB, T>(this Func<TA, TB, T> func, IEnumerable<TA> a, IEnumerable<TB> b) {
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext()) {
          yield return func(aI.Current, bI.Current);
        }
    }
    public static IEnumerable<T> Zipper<TA, TB, TC, T>(this Func<TA, TB, TC, T> func, IEnumerable<TA> a, IEnumerable<TB> b, IEnumerable<TC> c) {
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
      using (var cI = c.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext() && cI.MoveNext()) {
          yield return func(aI.Current, bI.Current, cI.Current);
        }
    }
    public static IEnumerable<T> Zipper<TA, TB, TC, TD, T>(this Func<TA, TB, TC, TD, T> func, IEnumerable<TA> a, IEnumerable<TB> b, IEnumerable<TC> c, IEnumerable<TD> d) {
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
      using (var cI = c.GetEnumerator())
      using (var dI = d.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext() && cI.MoveNext() && dI.MoveNext()) {
          yield return func(aI.Current, bI.Current, cI.Current, dI.Current);
        }
    }
    public static IEnumerable<T> Zipper<TA, TB, T>(this Func<int,TA, TB, T> func, IEnumerable<TA> a, IEnumerable<TB> b) {
      var i = 0;
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext()) {
          yield return func(i++,aI.Current, bI.Current);
        }
    }
    public static IEnumerable<T> Zipper<TA, TB, TC, T>(this Func<int,TA, TB, TC, T> func, IEnumerable<TA> a, IEnumerable<TB> b, IEnumerable<TC> c) {
      var i = 0;
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
      using (var cI = c.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext() && cI.MoveNext()) {
          yield return func(i++,aI.Current, bI.Current, cI.Current);
        }
    }
    public static IEnumerable<T> Zipper<TA, TB, TC, TD, T>(this Func<int,TA, TB, TC, TD, T> func, IEnumerable<TA> a, IEnumerable<TB> b, IEnumerable<TC> c, IEnumerable<TD> d) {
      var i = 0;
      using (var aI = a.GetEnumerator())
      using (var bI = b.GetEnumerator())
      using (var cI = c.GetEnumerator())
      using (var dI = d.GetEnumerator())
        while (aI.MoveNext() && bI.MoveNext() && cI.MoveNext() && dI.MoveNext()) {
          yield return func(i++,aI.Current, bI.Current, cI.Current, dI.Current);
        }
    }
  }
}