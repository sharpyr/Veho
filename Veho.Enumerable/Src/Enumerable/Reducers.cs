using System;
using System.Collections.Generic;

namespace Veho.Enumerable {
  public static class Reducers {
    public static TO Fold<T, TO>(this IEnumerable<T> list, Action<TO, T> sequence, TO accum) {
      foreach (var x in list) { sequence(accum, x); }
      return accum;
    }
    public static TO Fold<T, TO>(this IEnumerable<T> list, Action<int, TO, T> sequence, TO accum) {
      var i = 0;
      foreach (var x in list) { sequence(i++, accum, x); }
      return accum;
    }
    public static TO Fold<T, TO>(this IEnumerable<T> list, Func<TO, T, TO> sequence, TO accum) {
      foreach (var x in list) { accum = sequence(accum, x); }
      return accum;
    }
    // public static TO Fold<T, TO>(this IEnumerable<T> list, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
    //   var accum = indicator(list.First());
    //   foreach (var x in list) { accum = sequence(accum, x); }
    //   return accum;
    // }
    public static TO Fold<T, TO>(this IEnumerable<T> list, Func<int, TO, T, TO> sequence, TO accum) {
      var i = 0;
      foreach (var x in list) { accum = sequence(i++, accum, x); }
      return accum;
    }
    // public static TO Fold<T, TO>(this IEnumerable<T> list, Func<int, TO, T, TO> sequence, Func<T, TO> indicator) {
    //   var hi = list.Count;
    //   if (hi == 0) return default; //throw new IndexOutOfRangeException();
    //   var accum = indicator(list[0]);
    //   for (var i = 1; i < hi; i++) accum = sequence(i, accum, list[i]);
    //   return accum;
    // }

    public static T Reduce<T>(this IEnumerable<T> enumerable, Func<T, T, T> sequence) {
      T accum = default;
      using (var iter = enumerable.GetEnumerator()) {
        if (iter.MoveNext()) accum = iter.Current;
        while (iter.MoveNext()) accum = sequence(accum, iter.Current);
      }
      return accum;
    }
    public static TO Reduce<T, TO>(this IEnumerable<T> enumerable, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      TO accum = default;
      using (var iter = enumerable.GetEnumerator()) {
        if (iter.MoveNext()) accum = indicator(iter.Current);
        while (iter.MoveNext()) accum = sequence(accum, indicator(iter.Current));
      }
      return accum;
    }
    //
    //
    // public static T Reduce<T>(this IEnumerable<T> list, Func<int, T, T, T> sequence) {
    //   var hi = list.Count;
    //   if (hi == 0) return default; //throw new IndexOutOfRangeException();
    //   var accum = list[0];
    //   for (var i = 1; i < hi; i++) accum = sequence(i, accum, list[i]);
    //   return accum;
    // }
    // public static TO Reduce<T, TO>(this IEnumerable<T> list, Func<int, TO, TO, TO> sequence, Func<T, TO> indicator) {
    //   var hi = list.Count;
    //   if (hi == 0) return default;
    //   var accum = indicator(list[0]);
    //   for (var i = 1; i < hi; i++) accum = sequence(i, accum, indicator(list[i]));
    //   return accum;
    // }
  }
}