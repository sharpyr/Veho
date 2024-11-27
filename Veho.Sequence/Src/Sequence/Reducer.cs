using System;
using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Reducer {
    public static T MaxOfListBy<T, TO>(this IReadOnlyList<T> list, Func<T, TO> to) where TO : IComparable {
      var hi = list.Count;
      if (hi == 0) return default;
      var curr = list.MorphList(0, to);
      for (var i = 1; i < hi; i++) {
        var next = list.MorphList(i, to);
        if (curr.to.CompareTo(next.to) < 0) curr = next;
      }
      return curr.el;
    }
    public static T MinOfListBy<T, TO>(this IReadOnlyList<T> list, Func<T, TO> to) where TO : IComparable {
      var hi = list.Count;
      if (hi == 0) return default;
      var curr = list.MorphList(0, to);
      for (var i = 1; i < hi; i++) {
        var next = list.MorphList(i, to);
        if (curr.to.CompareTo(next.to) > 0) curr = next;
      }
      return curr.el;
    }
    // public static T MinBy<T, TO>( IReadOnlyList<T> list, Func<T, TO> selector) where TO : IComparable {
    //   return list.Reduce((a, b) => selector(a).CompareTo(selector(b)) < 0 ? a : b);
    // }
    public static TO FoldList<T, TO>(this IReadOnlyList<T> list, Action<TO, T> fold, TO init) {
      for (int i = 0, hi = list.Count; i < hi; ++i) fold(init, list[i]);
      return init;
    }
    public static TO FoldList<T, TO>(this IReadOnlyList<T> list, Action<int, TO, T> fold, TO init) {
      for (int i = 0, hi = list.Count; i < hi; ++i) fold(i, init, list[i]);
      return init;
    }
    public static TO FoldList<T, TO>(this IReadOnlyList<T> list, Func<TO, T, TO> fold, TO init) {
      var hi = list.Count;
      for (var i = 0; i < hi; i++) init = fold(init, list[i]);
      return init;
    }
    public static TO FoldList<T, TO>(this IReadOnlyList<T> list, Func<TO, T, TO> fold, Func<T, TO> to) {
      var hi = list.Count;
      if (hi == 0) return default;
      var init = to(list[0]);
      for (var i = 1; i < hi; i++) init = fold(init, list[i]);
      return init;
    }

    public static TO FoldList<T, TO>(this IReadOnlyList<T> list, Func<int, TO, T, TO> fold, TO init) {
      var hi = list.Count;
      for (var i = 0; i < hi; i++) init = fold(i, init, list[i]);
      return init;
    }
    public static TO FoldList<T, TO>(this IReadOnlyList<T> list, Func<int, TO, T, TO> fold, Func<T, TO> to) {
      var hi = list.Count;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var init = to(list[0]);
      for (var i = 1; i < hi; i++) init = fold(i, init, list[i]);
      return init;
    }

    public static T ReduceList<T>(this IReadOnlyList<T> list, Func<T, T, T> fold) {
      var hi = list.Count;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var init = list[0];
      for (var i = 1; i < hi; i++) init = fold(init, list[i]);
      return init;
    }
    public static TO ReduceList<T, TO>(this IReadOnlyList<T> list, Func<TO, TO, TO> fold, Func<T, TO> to) {
      var hi = list.Count;
      if (hi == 0) return default;
      var init = to(list[0]);
      for (var i = 1; i < hi; i++) init = fold(init, to(list[i]));
      return init;
    }
    public static T ReduceList<T>(this IReadOnlyList<T> list, Func<int, T, T, T> fold) {
      var hi = list.Count;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var init = list[0];
      for (var i = 1; i < hi; i++) init = fold(i, init, list[i]);
      return init;
    }
    public static TO ReduceList<T, TO>(this IReadOnlyList<T> list, Func<int, TO, TO, TO> fold, Func<T, TO> to) {
      var hi = list.Count;
      if (hi == 0) return default;
      var init = to(list[0]);
      for (var i = 1; i < hi; i++) init = fold(i, init, to(list[i]));
      return init;
    }
    public static string JoinList<T>(this IReadOnlyList<T> list, Func<T, string> toStr, string de = ", ") =>
      list.ReduceList((acc, cu) => acc + de + cu, toStr) ?? "";
  }
}