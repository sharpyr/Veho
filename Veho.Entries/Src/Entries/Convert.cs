using System;
using System.Collections.Generic;

namespace Veho.Entries {
  public static class Convert {
    public static T[,] ToMatrix<T>(this List<(T key, T value)> entries) {
      var hi = entries.Count;
      var target = new T[hi, 2];
      for (var i = 0; i < hi; i++) {
        var (key, value) = entries[i];
        target[i, 0] = key;
        target[i, 1] = value;
      }
      return target;
    }
    public static TO[,] ToMatrix<T, TO>(this List<(T key, T value)> entries, Func<T, TO> func) {
      var hi = entries.Count;
      var target = new TO[hi, 2];
      for (var i = 0; i < hi; i++) {
        var (key, value) = entries[i];
        target[i, 0] = func(key);
        target[i, 1] = func(value);
      }
      return target;
    }

    public static T[,] ToMatrix<T>(this List<(T a, T b, T c)> entries) {
      var hi = entries.Count;
      var target = new T[hi, 3];
      for (var i = 0; i < hi; i++) {
        var (a, b, c) = entries[i];
        target[i, 0] = a;
        target[i, 1] = b;
        target[i, 2] = c;
      }
      return target;
    }
    public static TO[,] ToMatrix<T, TO>(this List<(T a, T b, T c)> entries, Func<T, TO> func) {
      var hi = entries.Count;
      var target = new TO[hi, 3];
      for (var i = 0; i < hi; i++) {
        var (a, b, c) = entries[i];
        target[i, 0] = func(a);
        target[i, 1] = func(b);
        target[i, 2] = func(c);
      }
      return target;
    }
  }
}