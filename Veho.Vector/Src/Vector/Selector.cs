﻿using System;
using System.Collections.Generic;

namespace Veho.Vector {
  public static partial class Selector {
    public static (T el, TO to) Morph<T, TO>(this IReadOnlyList<T> vec, int i, Func<T, TO> func) => (vec[i], func(vec[i]));

    public static T[] Filter<T>(this T[] vec, Predicate<T> match) => Array.FindAll(vec, match);

    public static T[] Sort<T>(this T[] vec, Comparison<T> comp) {
      Array.Sort(vec, comp);
      return vec;
    }
    public static bool Every<T>(this T[] vec, Predicate<T> match) => Array.TrueForAll(vec, match);
    public static bool Some<T>(this T[] vec, Predicate<T> match) => Array.Exists(vec, match);


    public static int[] Indexes<T>(this IReadOnlyList<T> vec, Predicate<T> match) =>
      vec.Fold((i, indexes, x) => {
        if (match(x)) indexes.Add(i);
      }, new List<int>()).ToArray();
    public static int[] Indexes<T>(this IReadOnlyList<T> vec, Func<int, T, bool> match) =>
      vec.Fold((i, indexes, x) => {
        if (match(i, x)) indexes.Add(i);
      }, new List<int>()).ToArray();
    public static T[] SelectBy<T>(this IReadOnlyList<T> vec, IReadOnlyList<int> indexes) {
      var target = new T[indexes.Count];
      var i = 0;
      foreach (var index in indexes) target[i++] = index < 0 ? default : vec[index];
      return target;
    }
    public static T[] SelectOf<T>(this IReadOnlyList<T> vec, params int[] indexes) {
      return vec.SelectBy(indexes);
    }
    public static bool Every<T>(this IReadOnlyList<T> vec, Predicate<T> match) {
      for (int i = 0, hi = vec.Count; i < hi; i++) {
        if (!match(vec[i])) return false;
      }
      return true;
    }
    public static bool Every<T>(this IReadOnlyList<T> vec, Func<int, T, bool> match) {
      for (int i = 0, hi = vec.Count; i < hi; i++) {
        if (!match(i, vec[i])) return false;
      }
      return true;
    }
    public static bool Some<T>(this IReadOnlyList<T> vec, Predicate<T> match) {
      for (int i = 0, hi = vec.Count; i < hi; i++) {
        if (match(vec[i])) return true;
      }
      return false;
    }
    public static bool Some<T>(this IReadOnlyList<T> vec, Func<int, T, bool> match) {
      for (int i = 0, hi = vec.Count; i < hi; i++) {
        if (match(i, vec[i])) return true;
      }
      return false;
    }
    public static T Find<T>(this IReadOnlyList<T> vec, Predicate<T> match) {
      for (int i = 0, hi = vec.Count; i < hi; i++) {
        var value = vec[i];
        if (match(value)) return value;
      }
      return default;
    }
    public static T Find<T>(this IReadOnlyList<T> vec, Func<int, T, bool> match) {
      for (int i = 0, hi = vec.Count; i < hi; i++) {
        var value = vec[i];
        if (match(i, value)) return value;
      }
      return default;
    }

    public static int IndexOf<T>(this T[] vec, T value) => Array.IndexOf(vec, value);
    // public static int IndexOf<T>(this IReadOnlyList<T> vec, T value) where T : IEquatable<T> {
    //   for (int i = 0, hi = vec.Count; i < hi; i++) {
    //     if (vec[i].Equals(value)) return i;
    //   }
    //   return -1;
    // }

    public static int FindIndex<T>(this T[] vec, Predicate<T> match) => Array.FindIndex(vec, match);
    public static int IndexOf<T>(this T[] vec, Predicate<T> match) => Array.FindIndex(vec, match);
    // public static int IndexOf<T>(this IReadOnlyList<T> vec, Predicate<T> match) {
    //   for (int i = 0, hi = vec.Count; i < hi; i++) {
    //     if (match(vec[i])) return i;
    //   }
    //   return -1;
    // }

    public static int LastIndexOf<T>(this T[] vec, T value) => Array.LastIndexOf(vec, value);
    public static int LastIndexOf<T>(this T[] vec, Predicate<T> match) => Array.FindLastIndex(vec, match);

    public static int FindLastIndex<T>(this T[] vec, Predicate<T> match) => Array.FindLastIndex(vec, match);

    public static (T, T) Dualet<T>(this T[] ve) => (ve[0], ve[1]);
    public static (T, T, T) Triplet<T>(this T[] ve) => (ve[0], ve[1], ve[2]);
    public static (T, T, T, T) Quadlet<T>(this T[] ve) => (ve[0], ve[1], ve[2], ve[3]);
    public static (T, T, T, T, T) Pentlet<T>(this T[] ve) => (ve[0], ve[1], ve[2], ve[3], ve[4]);
    public static (T, T, T, T, T, T) Hexlet<T>(this T[] ve) => (ve[0], ve[1], ve[2], ve[3], ve[4], ve[5]);
    public static (T, T, T, T, T, T, T) Septlet<T>(this T[] ve) => (ve[0], ve[1], ve[2], ve[3], ve[4], ve[5], ve[6]);
    public static (T, T, T, T, T, T, T, T) Octlet<T>(this T[] ve) => (ve[0], ve[1], ve[2], ve[3], ve[4], ve[5], ve[6], ve[7]);

    [Obsolete("Use Dualet instead")]
    public static (T, T) T2<T>(this T[] vec) => (vec[0], vec[1]);

    [Obsolete("Use Triplet instead")]
    public static (T, T, T) T3<T>(this T[] vec) => (vec[0], vec[1], vec[2]);

    [Obsolete("Use Quadlet instead")]
    public static (T, T, T, T) T4<T>(this T[] vec) => (vec[0], vec[1], vec[2], vec[3]);
  }
}