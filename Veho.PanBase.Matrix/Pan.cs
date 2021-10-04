using System;

namespace Veho {
  public static class Pan {
    public static readonly int[] DoubleOne = { 1, 1 };
    public static T[,] M1B<T>(this (int, int) size) {
      return (T[,])Array.CreateInstance(typeof(T), size.ToVector(), DoubleOne);
    }

    public static T[,] M1B<T>(this (int, int) size, Func<int, int, T> func) {
      var m1B = size.M1B<T>();
      var (h, w) = size;
      for (var i = 1; i <= h; i++)
        for (var j = 1; j <= w; j++)
          m1B[i, j] = func(i, j);
      return m1B;
    }
  }
}