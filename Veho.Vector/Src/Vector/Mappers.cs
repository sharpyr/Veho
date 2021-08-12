using System;
using Typen;

namespace Veho.Vector {
  public static partial class Mappers {
    public static void Iterate<T>(this T[] vector, Action<T> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) fn(vector[i]);
      // Array.ForEach(vector, fn);
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
    public static TO[] CastTo<T, TO>(this T[] vector) => vector.Map(Conv.Cast<T, TO>);
    public static TO[] CastTo<T, TO>(this T[] vector, Converter<T, TO> converter) => vector.Map(x => converter(x));
  }
}