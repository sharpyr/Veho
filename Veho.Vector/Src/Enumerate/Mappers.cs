using System;

namespace Veho.Vector.Enumerate {
  public static class Mappers {
    public static void Iterate<T>(this T[] vector, Action<T, int> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) fn(vector[i], i);
    }
    public static P[] Map<T, P>(this T[] vector, Func<T, int, P> fn) {
      var hi = vector.Length;
      var result = new P[hi];
      for (var i = 0; i < hi; i++) result[i] = fn(vector[i], i);
      return result;
      // return vector.Select(fn).ToArray();
    }
    public static T[] Mutate<T>(this T[] vector, Func<T, int, T> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) vector[i] = fn(vector[i], i);
      return vector;
    }
  }
}