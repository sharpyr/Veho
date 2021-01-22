using System;

namespace Veho.Matrix {
  public static class Zippers {
    public static T[] Zip<TA, TB, T>(this TA[] vector, TB[] another, Func<TA, TB, T> fn) {
      var hi = vector.Length;
      var result = new T[hi];
      for (var i = 0; i < hi; i++) result[i] = fn(vector[i], another[i]);
      return result;
    }
    public static TA[] Mutazip<TA, TB>(this TA[] vector, TB[] another, Func<TA, TB, TA> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) vector[i] = fn(vector[i], another[i]);
      return vector;
    }
    public static T[,] Zipper<TA, TB, T>(this Func<TA, TB, T> fn, TA[,] a, TB[,] b) {
      var (height, width) = a.Size();
      var matrix = new T[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(a[i, j], b[i, j]);
      return matrix;
    }
    public static T[,] Zipper<TA, TB, TC, T>(this Func<TA, TB, TC, T> fn, TA[,] a, TB[,] b, TC[,] c) {
      var (height, width) = a.Size();
      var matrix = new T[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(a[i, j], b[i, j], c[i, j]);
      return matrix;
    }
    public static T[,] Zipper<TA, TB, TC, TD, T>(this Func<TA, TB, TC, TD, T> fn, TA[,] a, TB[,] b, TC[,] c, TD[,] d) {
      var (height, width) = a.Size();
      var matrix = new T[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(a[i, j], b[i, j], c[i, j], d[i, j]);
      return matrix;
    }
  }
}