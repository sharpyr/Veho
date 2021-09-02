using System;
using System.Collections.Generic;

namespace Veho.Vector {
  public static class Algebra {
    public static TO[,] IndoCartesian<T, TO>(this IReadOnlyList<T> vec, Func<T, T, TO> func) {
      var hi = vec.Count;
      var mx = new TO[hi, hi];
      for (var i = 0; i < hi; i++) {
        var x = vec[i];
        for (var j = 0; j < hi; j++) mx[i, j] = func(x, vec[j]);
      } // i + 1
      return mx;
    }
    public static TO[,] Cartesian<TA, TB, TO>(this IReadOnlyList<TA> vecA, IReadOnlyList<TB> vecB, Func<TA, TB, TO> func) {
      int h = vecA.Count, w = vecB.Count;
      var mx = new TO[h, w];
      for (var i = 0; i < h; i++) {
        var a = vecA[i];
        for (var j = 0; j < w; j++) mx[i, j] = func(a, vecB[j]);
      }
      return mx;
    }
    public static TO[,] IndoCartesian<T, TO>(this IReadOnlyList<T> vec, Func<int, int, T, T, TO> func) {
      var hi = vec.Count;
      var mx = new TO[hi, hi];
      for (var i = 0; i < hi; i++) {
        var x = vec[i];
        for (var j = 0; j < hi; j++) mx[i, j] = func(i, j, x, vec[j]);
      } // i + 1
      return mx;
    }
    public static TO[,] Cartesian<TA, TB, TO>(this IReadOnlyList<TA> vecA, IReadOnlyList<TB> vecB, Func<int, int, TA, TB, TO> func) {
      int h = vecA.Count, w = vecB.Count;
      var mx = new TO[h, w];
      for (var i = 0; i < h; i++) {
        var a = vecA[i];
        for (var j = 0; j < w; j++) mx[i, j] = func(i, j, a, vecB[j]);
      }
      return mx;
    }
    
  }
}