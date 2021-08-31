using System.Collections.Generic;

namespace Veho {
  public static class Ent {
    public static (TK[], TV[]) Unwind<TK, TV>(this IReadOnlyList<(TK, TV)> entries) {
      var len = entries.Count;
      var keys = new TK[len];
      var values = new TV[len];
      for (var i = 0; i < len; i++) {
        var (k, v) = entries[i];
        keys[i] = k;
        values[i] = v;
      }
      return (keys, values);
    }
    public static (TK, TV)[] Wind<TK, TV>(IReadOnlyList<TK> keys, IReadOnlyList<TV> values) {
      var hi = keys.Count;
      var entries = new (TK, TV)[hi];
      for (var lo = 0; lo < hi; lo++) entries[lo] = (keys[lo], values[lo]);
      return entries;
    }

    public static (TA[] a, TB[] b, TC[] c) Unwind<TA, TB, TC>(this IReadOnlyList<(TA, TB, TC)> entries) {
      var len = entries.Count;
      var vecA = new TA[len];
      var vecB = new TB[len];
      var vecC = new TC[len];
      for (var i = 0; i < len; i++) {
        var (a, b, c) = entries[i];
        vecA[i] = a;
        vecB[i] = b;
        vecC[i] = c;
      }
      return (vecA, vecB, vecC);
    }
    public static (TA a, TB b, TC c)[] Wind<TA, TB, TC>(IReadOnlyList<TA> a, IReadOnlyList<TB> b, IReadOnlyList<TC> c) {
      var hi = a.Count;
      var entries = new (TA, TB, TC)[hi];
      for (var lo = 0; lo < hi; lo++) entries[lo] = (a[lo], b[lo], c[lo]);
      return entries;
    }

    public static (TA[] a, TB[] b, TC[] c, TD[] d) Unwind<TA, TB, TC, TD>(this IReadOnlyList<(TA, TB, TC, TD)> entries) {
      var len = entries.Count;
      var vecA = new TA[len];
      var vecB = new TB[len];
      var vecC = new TC[len];
      var vecD = new TD[len];
      for (var i = 0; i < len; i++) {
        var (a, b, c, d) = entries[i];
        vecA[i] = a;
        vecB[i] = b;
        vecC[i] = c;
        vecD[i] = d;
      }
      return (vecA, vecB, vecC, vecD);
    }
    public static (TA a, TB b, TC c, TD d)[] Wind<TA, TB, TC, TD>(IReadOnlyList<TA> a, IReadOnlyList<TB> b, IReadOnlyList<TC> c, IReadOnlyList<TD> d) {
      var hi = a.Count;
      var entries = new (TA, TB, TC, TD)[hi];
      for (var lo = 0; lo < hi; lo++) entries[lo] = (a[lo], b[lo], c[lo], d[lo]);
      return entries;
    }
  }
}