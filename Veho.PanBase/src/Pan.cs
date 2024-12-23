﻿using System;
using Veho.Tuple;

namespace Veho {
  public static class Pan {
    private static readonly int[] S1 = { 1, 1 };

    public static T[,] Boot<T>((int, int) bases) => (T[,])Array
      .CreateInstance(typeof(T), Pan.S1, bases.Vec());
    public static T[,] Init<T>(this (int, int) sizes, (int, int) bases) => (T[,])Array
      .CreateInstance(typeof(T), sizes.Vec(), bases.Vec());

    public static T[,] Init<T>(this (int, int) sizes, (int, int) bases, Func<int, int, T> func) {
      var mx = sizes.Init<T>(bases);
      var (ht, wd) = sizes;
      var (xlo, ylo) = bases;
      for (int i = xlo, xhi = xlo + ht - 1, yhi = ylo + wd - 1; i <= xhi; i++)
        for (var j = ylo; j <= yhi; j++)
          mx[i, j] = func(i, j);
      return mx;
    }
  }
}