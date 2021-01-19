using System;

namespace Veho.Vector {
  public static class Zippers {
    public static T[] Zippper<A, B, T>(this A[] vector, B[] another, Func<A, B, T> fn) {
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
    public static T[] DuoZipper<A, B, T>(this Func<A, B, T> fn, A[] a, B[] b) {
      var hi = a.Length;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = fn(a[i], b[i]);
      return vec;
    }
    public static T[] TriZipper<A, B, C, T>(this Func<A, B, C, T> fn, A[] a, B[] b, C[] c) {
      var hi = a.Length;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = fn(a[i], b[i], c[i]);
      return vec;
    }
    public static T[] QuaZipper<A, B, C, D, T>(this Func<A, B, C, D, T> fn, A[] a, B[] b, C[] c, D[] d) {
      var hi = a.Length;
      var vec = new T[hi];
      for (var i = 0; i < hi; i++) vec[i] = fn(a[i], b[i], c[i], d[i]);
      return vec;
    }
  }
}