using System;
using System.Collections.Generic;

namespace Veho.Vector {
  public static class Reducer {
    public static T MaxBy<T, TO>(this IReadOnlyList<T> vec, Func<T, TO> to) where TO : IComparable {
      var hi = vec.Count;
      if (hi == 0) return default;
      var c = vec.Morph(0, to);
      for (var i = 1; i < hi; i++) {
        var next = vec.Morph(i, to);
        if (c.to.CompareTo(next.to) < 0) c = next;
      }
      return c.el;
    }
    public static T MinBy<T, TO>(this IReadOnlyList<T> vec, Func<T, TO> to) where TO : IComparable {
      var hi = vec.Count;
      if (hi == 0) return default;
      var curr = vec.Morph(0, to);
      for (var i = 1; i < hi; i++) {
        var next = vec.Morph(i, to);
        if (curr.to.CompareTo(next.to) > 0) curr = next;
      }
      return curr.el;
    }
    // public static T MinBy<T, TO>(this IReadOnlyList<T> vec, Func<T, TO> selector) where TO : IComparable {
    //   return vec.Reduce((a, b) => selector(a).CompareTo(selector(b)) < 0 ? a : b);
    // }
    public static TO Fold<T, TO>(this IReadOnlyList<T> vec, Action<TO, T> fold, TO init) {
      for (int i = 0, hi = vec.Count; i < hi; ++i) fold(init, vec[i]);
      return init;
    }
    public static TO Fold<T, TO>(this IReadOnlyList<T> vec, Action<int, TO, T> fold, TO init) {
      for (int i = 0, hi = vec.Count; i < hi; ++i) fold(i, init, vec[i]);
      return init;
    }
    public static TO Fold<T, TO>(this IReadOnlyList<T> vec, Func<TO, T, TO> fold, TO init) {
      var hi = vec.Count;
      for (var i = 0; i < hi; i++) init = fold(init, vec[i]);
      return init;
    }
    public static TO Fold<T, TO>(this IReadOnlyList<T> vec, Func<TO, T, TO> fold, Func<T, TO> to) {
      var hi = vec.Count;
      if (hi == 0) return default;
      var init = to(vec[0]);
      for (var i = 1; i < hi; i++) init = fold(init, vec[i]);
      return init;
    }

    public static TO Fold<T, TO>(this IReadOnlyList<T> vec, Func<int, TO, T, TO> fold, TO init) {
      var hi = vec.Count;
      for (var i = 0; i < hi; i++) init = fold(i, init, vec[i]);
      return init;
    }
    public static TO Fold<T, TO>(this IReadOnlyList<T> vec, Func<int, TO, T, TO> fold, Func<T, TO> to) {
      var hi = vec.Count;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var init = to(vec[0]);
      for (var i = 1; i < hi; i++) init = fold(i, init, vec[i]);
      return init;
    }

    public static T Reduce<T>(this IReadOnlyList<T> vec, Func<T, T, T> fold) {
      var hi = vec.Count;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var init = vec[0];
      for (var i = 1; i < hi; i++) init = fold(init, vec[i]);
      return init;
    }
    public static TO Reduce<T, TO>(this IReadOnlyList<T> vec, Func<TO, TO, TO> fold, Func<T, TO> to) {
      var hi = vec.Count;
      if (hi == 0) return default;
      var init = to(vec[0]);
      for (var i = 1; i < hi; i++) init = fold(init, to(vec[i]));
      return init;
    }
    public static T Reduce<T>(this IReadOnlyList<T> vec, Func<int, T, T, T> fold) {
      var hi = vec.Count;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var init = vec[0];
      for (var i = 1; i < hi; i++) init = fold(i, init, vec[i]);
      return init;
    }
    public static TO Reduce<T, TO>(this IReadOnlyList<T> vec, Func<int, TO, TO, TO> fold, Func<T, TO> to) {
      var hi = vec.Count;
      if (hi == 0) return default;
      var init = to(vec[0]);
      for (var i = 1; i < hi; i++) init = fold(i, init, to(vec[i]));
      return init;
    }
    public static string Join<T>(this IReadOnlyList<T> vec, Func<T, string> toStr, string de = ", ") =>
      vec.Reduce((acc, cu) => acc + de + cu, toStr) ?? "";
  }
}