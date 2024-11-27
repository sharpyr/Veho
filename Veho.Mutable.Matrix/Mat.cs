using System;
using System.Collections.Generic;
using Veho.Enumerable;
using static System.Linq.Enumerable;

namespace Veho.Mutable {
  public static class Mat {
    public static List<List<T>> Empty<T>() => new List<List<T>>();

    public static List<List<T>> M1X1<T>(T element) => new List<List<T>> { new List<T> { element } };

    public static List<List<T>> Init<T>(this (int h, int w ) size) {
      return Range(0, size.h).Map(rowIndex => new List<T>(size.w)).ToList();
    }

    public static List<List<T>> Init<T>(this (int h, int w) size, Func<int, int, T> func) {
      return Seq.Init(size.h, x => Seq.Init(size.w, y => func(x, y)));
    }

    public static List<List<T>> Init<T>(int h, int w, Func<int, int, T> func) {
      return Seq.Init(h, x => Seq.Init(w, y => func(x, y)));
    }

    public static List<List<T>> Iso<T>(int h, int w, T value) {
      return Seq.Init(h, x => Seq.Iso(w, value));
    }
  }
}