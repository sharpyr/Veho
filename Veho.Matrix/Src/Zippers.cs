using System;

namespace Veho.Matrix {
  public static class Zippers {
    public static T[] Zipper<A, B, T>(this A[] vector, B[] another, Func<A, B, T> fn) {
      var hi = vector.Length;
      var result = new T[hi];
      for (var i = 0; i < hi; i++) result[i] = fn(vector[i], another[i]);
      return result;
    }
    public static A[] Mutazip<A, B>(this A[] vector, B[] another, Func<A, B, A> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) vector[i] = fn(vector[i], another[i]);
      return vector;
    }
    public static T[,] DuoZipper<A, B, T>(this Func<A, B, T> fn, A[,] a, B[,] b) {
      var (height, width) = a.Size();
      var matrix = new T[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(a[i, j], b[i, j]);
      return matrix;
    }
    public static T[,] TriZipper<A, B, C, T>(this Func<A, B, C, T> fn, A[,] a, B[,] b, C[,] c) {
      var (height, width) = a.Size();
      var matrix = new T[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(a[i, j], b[i, j], c[i, j]);
      return matrix;
    }
    public static T[,] QuaZipper<A, B, C, D, T>(this Func<A, B, C, D, T> fn, A[,] a, B[,] b, C[,] c, D[,] d) {
      var (height, width) = a.Size();
      var matrix = new T[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(a[i, j], b[i, j], c[i, j], d[i, j]);
      return matrix;
    }
  }
}