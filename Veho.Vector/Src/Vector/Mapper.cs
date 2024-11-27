using System;
using System.Collections.Generic;
using Typen;

namespace Veho.Vector {
  public static class Mapper {
    public static T[] Slice<T>(this IReadOnlyList<T> list) {
      return list.Map(x => x);
    }
    public static T[] Slice<T>(this T[] list, int lo) {
      int hi = list.Length, len = hi - lo;
      var target = new T[len];
      Array.Copy(list, lo, target, 0, len);
      return target;
    }
    public static T[] Slice<T>(this T[] list, int lo, int hi) {
      if (hi < 0) hi = list.Length + hi;
      var len = hi - lo;
      var target = new T[len];
      Array.Copy(list, lo, target, 0, len);
      return target;
    }
    public static void Iterate<T>(this T[] vec, Action<T> func) {
      for (int i = 0,hi = vec.Length; i < hi; i++) func(vec[i]);
    }
    public static void Iterate<T>(this T[] vec, Action<int, T> func) {
      for (int i = 0,hi = vec.Length; i < hi; i++) func(i, vec[i]);
    }
    public static TO[] Map<T, TO>(this IReadOnlyList<T> vec, Func<T, TO> func) {
      var hi = vec.Count;
      var result = new TO[hi];
      for (var i = 0; i < hi; i++) result[i] = func(vec[i]);
      return result;
    }
    public static TO[] Map<T, TO>(this IReadOnlyList<T> vec, Func<int, T, TO> func) {
      var hi = vec.Count;
      var result = new TO[hi];
      for (var i = 0; i < hi; i++) result[i] = func(i, vec[i]);
      return result; // return vec.Select(func).ToArray();
    }
    public static T[] Mutate<T>(this T[] vec, Func<T, T> func) {
      for (int i = 0,hi = vec.Length; i < hi; i++) vec[i] = func(vec[i]);
      return vec;
    }
    public static T[] Mutate<T>(this T[] vec, Func<int, T, T> func) {
      for (int i = 0,hi = vec.Length; i < hi; i++) vec[i] = func(i, vec[i]);
      return vec;
    }
    public static TO[] CastTo<T, TO>(this IReadOnlyList<T> vec) => vec.Map(Conv.Cast<T, TO>);
    public static TO[] CastTo<T, TO>(this IReadOnlyList<T> vec, Converter<T, TO> converter) => vec.Map(x => converter(x));
  }
}