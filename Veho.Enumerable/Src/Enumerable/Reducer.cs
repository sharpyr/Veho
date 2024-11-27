using System;
using System.Collections.Generic;

namespace Veho.Enumerable {
  public static class Reducer {
    public static TO Fold<T, TO>(this IEnumerable<T> list, Action<TO, T> fold, TO tar) {
      foreach (var x in list) { fold(tar, x); }
      return tar;
    }
    public static TO Fold<T, TO>(this IEnumerable<T> list, Action<int, TO, T> fold, TO tar) {
      var i = 0;
      foreach (var x in list) { fold(i++, tar, x); }
      return tar;
    }
    public static TO Fold<T, TO>(this IEnumerable<T> list, Func<TO, T, TO> fold, TO tar) {
      foreach (var x in list) { tar = fold(tar, x); }
      return tar;
    }
    // public static TO Fold<T, TO>(this IEnumerable<T> list, Func<TO, T, TO> fold, Func<T, TO> to) {
    //   var tar = to(list.First());
    //   foreach (var x in list) { tar = fold(tar, x); }
    //   return tar;
    // }
    public static TO Fold<T, TO>(this IEnumerable<T> list, Func<int, TO, T, TO> fold, TO tar) {
      var i = 0;
      foreach (var x in list) { tar = fold(i++, tar, x); }
      return tar;
    }
    // public static TO Fold<T, TO>(this IEnumerable<T> list, Func<int, TO, T, TO> fold, Func<T, TO> to) {
    //   var hi = list.Count;
    //   if (hi == 0) return default; //throw new IndexOutOfRangeException();
    //   var tar = to(list[0]);
    //   for (var i = 1; i < hi; i++) tar = fold(i, tar, list[i]);
    //   return tar;
    // }

    public static T Reduce<T>(this IEnumerable<T> enumerable, Func<T, T, T> fold) {
      T tar = default;
      using (var iter = enumerable.GetEnumerator()) {
        if (iter.MoveNext()) tar = iter.Current;
        while (iter.MoveNext()) tar = fold(tar, iter.Current);
      }
      return tar;
    }
    public static TO Reduce<T, TO>(this IEnumerable<T> enumerable, Func<TO, TO, TO> fold, Func<T, TO> to) {
      TO tar = default;
      using (var iter = enumerable.GetEnumerator()) {
        if (iter.MoveNext()) tar = to(iter.Current);
        while (iter.MoveNext()) tar = fold(tar, to(iter.Current));
      }
      return tar;
    }
    //
    //
    // public static T Reduce<T>(this IEnumerable<T> list, Func<int, T, T, T> fold) {
    //   var hi = list.Count;
    //   if (hi == 0) return default; //throw new IndexOutOfRangeException();
    //   var tar = list[0];
    //   for (var i = 1; i < hi; i++) tar = fold(i, tar, list[i]);
    //   return tar;
    // }
    // public static TO Reduce<T, TO>(this IEnumerable<T> list, Func<int, TO, TO, TO> fold, Func<T, TO> to) {
    //   var hi = list.Count;
    //   if (hi == 0) return default;
    //   var tar = to(list[0]);
    //   for (var i = 1; i < hi; i++) tar = fold(i, tar, to(list[i]));
    //   return tar;
    // }
  }
}