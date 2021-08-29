using System;
using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Reducers {
    public static TO Fold<T, TO>(this List<T> list, Func<TO, T, TO> sequence, TO accum) {
      var hi = list.Count;
      for (var i = 0; i < hi; i++) accum = sequence(accum, list[i]);
      return accum;
    }
    public static TO Fold<T, TO>(this List<T> list, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
      var hi = list.Count;
      if (hi == 0) return default;
      var accum = indicator(list[0]);
      for (var i = 1; i < hi; i++) accum = sequence(accum, list[i]);
      return accum;
    }
    public static T Reduce<T>(this List<T> list, Func<T, T, T> sequence) {
      var hi = list.Count;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var accum = list[0];
      for (var i = 1; i < hi; i++) accum = sequence(accum, list[i]);
      return accum;
    }
    public static TO Reduce<T, TO>(this List<T> list, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      var hi = list.Count;
      if (hi == 0) return default;
      var accum = indicator(list[0]);
      for (var i = 1; i < hi; i++) accum = sequence(accum, indicator(list[i]));
      return accum;
    }

    public static TO Fold<T, TO>(this List<T> list, Func<int, TO, T, TO> sequence, TO accum) {
      var hi = list.Count;
      for (var i = 0; i < hi; i++) accum = sequence(i, accum, list[i]);
      return accum;
    }
    public static TO Fold<T, TO>(this List<T> list, Func<int, TO, T, TO> sequence, Func<T, TO> indicator) {
      var hi = list.Count;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var accum = indicator(list[0]);
      for (var i = 1; i < hi; i++) accum = sequence(i, accum, list[i]);
      return accum;
    }
    public static T Reduce<T>(this List<T> list, Func<int, T, T, T> sequence) {
      var hi = list.Count;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var accum = list[0];
      for (var i = 1; i < hi; i++) accum = sequence(i, accum, list[i]);
      return accum;
    }
    public static TO Reduce<T, TO>(this List<T> list, Func<int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      var hi = list.Count;
      if (hi == 0) return default;
      var accum = indicator(list[0]);
      for (var i = 1; i < hi; i++) accum = sequence(i, accum, indicator(list[i]));
      return accum;
    }
    public static string Join<T>(this List<T> list, Func<T, string> toStr, string de = ", ") =>
      list.Reduce((acc, cu) => acc + de + cu, toStr) ?? "";
  }
}