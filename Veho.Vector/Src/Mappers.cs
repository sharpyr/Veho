using System;

namespace Veho.Vector {
  public static class Mappers {
    #region Mappers
    public static void Iterate<T>(this T[] vector, Action<T> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) fn(vector[i]);
    }
    public static void Iterate<T>(this T[] vector, Action<int, T> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) fn(i, vector[i]);
    }
    public static TO[] Map<T, TO>(this T[] vector, Func<T, TO> fn) {
      var hi = vector.Length;
      var result = new TO[hi];
      for (var i = 0; i < hi; i++) result[i] = fn(vector[i]);
      return result;
    }
    public static TO[] Map<T, TO>(this T[] vector, Func<int, T, TO> fn) {
      var hi = vector.Length;
      var result = new TO[hi];
      for (var i = 0; i < hi; i++) result[i] = fn(i, vector[i]);
      return result; // return vector.Select(fn).ToArray();
    }
    public static T[] Mutate<T>(this T[] vector, Func<T, T> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) vector[i] = fn(vector[i]);
      return vector;
    }
    public static T[] Mutate<T>(this T[] vector, Func<int, T, T> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) vector[i] = fn(i, vector[i]);
      return vector;
    }
    #endregion
  }
}