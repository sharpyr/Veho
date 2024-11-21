﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Enumerable {
  public static partial class Mappers {
    public static TO[] Map<T, TO>(this IEnumerable<T> iter, Func<T, TO> func) => iter.Select(func).ToArray();

    public static TO[] Map<T, TO>(this IEnumerable<T> iter, Func<int, T, TO> func) => iter.Select((x, i) => func(i, x)).ToArray();

    public static void Iterate<T>(this IEnumerable<T> iter, Action<T> action) {
      foreach (var x in iter) action(x);
    }
    public static void Iterate<T>(this IEnumerable<T> iter, Action<int, T> action) {
      var i = 0;
      foreach (var x in iter) action(i++, x);
    }
    public static int Hi<T>(this IEnumerable<T> iter) => iter.Count() - 1;
    public static IEnumerable<TO> Iter<T, TO>(this IEnumerable<T> items, Func<T, TO> func) {
      foreach (T item in items) yield return func(item);
    }
    public static IEnumerable<TO> Iter<T, TO>(this IEnumerable<T> items, Func<T, int, TO> func) {
      var i = 0;
      foreach (T item in items) yield return func(item, i++);
    }
    
  }

  public static partial class Mappers {
    public static TO[] Map<T, TO>(this IEnumerable iter, Func<T, TO> func) => iter.Cast<T>().Select(o => func(o)).ToArray();

    public static TO[] Map<T, TO>(this IEnumerable iter, Func<int, T, TO> func) => iter.Cast<T>().Select((o, i) => func(i, o)).ToArray();
    public static void Iterate<T>(this IEnumerable iter, Action<T> action) {
      foreach (T x in iter) action(x);
    }
    public static void Iterate<T>(this IEnumerable iter, Action<int, T> action) {
      var i = 0;
      foreach (T x in iter) action(i++, x);
    }
    public static IEnumerable<TO> Iter<T, TO>(this IEnumerable items, Func<T, TO> func) {
      foreach (T item in items) yield return func(item);
    }
    public static IEnumerable<TO> Iter<T, TO>(this IEnumerable items, Func<T, int, TO> func) {
      var i = 0;
      foreach (T item in items) yield return func(item, i++);
    }
  }
}