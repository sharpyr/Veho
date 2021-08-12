﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Enumerable {
  public static partial class GenericMapper {
    public static TO[] Map<T, TO>(this IEnumerable<T> iter, Func<T, TO> func) => iter.Select(func).ToArray();

    public static TO[] Map<T, TO>(this IEnumerable<T> iter, Func<int, T, TO> func) => iter.Select((x, i) => func(i, x)).ToArray();
    public static void Iterate<T>(this IEnumerable<T> iter, Action<T> func) {
      foreach (var x in iter) func(x);
    }
    public static void Iterate<T>(this IEnumerable<T> iter, Action<int, T> func) {
      var i = 0;
      foreach (var x in iter) func(i++, x);
    }
    public static int Hi<T>(this IEnumerable<T> iter) => iter.Count() - 1;
  }

  public static partial class Mapper {
    public static TO[] Map<T, TO>(this IEnumerable iter, Func<T, TO> func) => iter.Cast<T>().Select(o => func(o)).ToArray();

    public static TO[] Map<T, TO>(this IEnumerable iter, Func<int, T, TO> func) => iter.Cast<T>().Select((o, i) => func(i, o)).ToArray();
    public static void Iterate<T>(this IEnumerable iter, Action<T> func) {
      foreach (T x in iter) func(x);
    }
    public static void Iterate<T>(this IEnumerable iter, Action<int, T> func) {
      var i = 0;
      foreach (T x in iter) func(i++, x);
    }
  }
}