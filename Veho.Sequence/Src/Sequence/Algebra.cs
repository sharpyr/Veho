using System;
using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Algebra {
    public static List<List<TO>> IndoCartesian<T, TO>(this IReadOnlyList<T> vec, Func<T, T, TO> func) {
      var hi = vec.Count;
      var mx = new List<List<TO>>(hi);
      for (var i = 0; i < hi; i++) {
        var x = vec[i];
        mx.Add(vec.Map(y => func(x, y)));
      }
      return mx;
    }
    public static List<List<TO>> Cartesian<TA, TB, TO>(this IReadOnlyList<TA> vecA, IReadOnlyList<TB> vecB, Func<TA, TB, TO> func) {
      var hi = vecA.Count;
      var mx = new List<List<TO>>(hi);
      for (var i = 0; i < hi; i++) {
        var x = vecA[i];
        mx.Add(vecB.Map(y => func(x, y)));
      }
      return mx;
    }
    public static List<List<TO>> IndoCartesian<T, TO>(this IReadOnlyList<T> vec, Func<int, int, T, T, TO> func) {
      var hi = vec.Count;
      var mx = new List<List<TO>>(hi);
      for (var i = 0; i < hi; i++) {
        var x = vec[i];
        mx.Add(vec.Map((j, y) => func(i, j, x, y)));
      }
      return mx;
    }
    public static List<List<TO>> Cartesian<TA, TB, TO>(this IReadOnlyList<TA> vecA, IReadOnlyList<TB> vecB, Func<int, int, TA, TB, TO> func) {
      var hi = vecA.Count;
      var mx = new List<List<TO>>(hi);
      for (var i = 0; i < hi; i++) {
        var x = vecA[i];
        mx.Add(vecB.Map((j, y) => func(i, j, x, y)));
      }
      return mx;
    }
  }
}