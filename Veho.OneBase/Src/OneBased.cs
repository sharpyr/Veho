using System;
using Veho.Tuple;

namespace Veho {
  public static class OneBased {
    private static readonly (int, int) S1 = (1, 1);
    private static readonly int[] B1 = { 1, 1 };

    public static T[,] Boot<T>(T val) {
      var mx = OneBased.Init<T>(S1);
      mx[1, 1] = val;
      return mx;
    }

    public static T[,] Init<T>((int, int) sizes) => (T[,])Array
      .CreateInstance(typeof(T), sizes.Vec(), B1);

    public static T[,] Init<T>(int ht, int wd) => (T[,])Array
      .CreateInstance(typeof(T), new[] { ht, wd }, B1);


    public static T[,] Init<T>((int, int) sizes, Func<int, int, T> func) {
      var mx = OneBased.Init<T>(sizes);
      var (ht, wd) = sizes;
      for (var i = 1; i <= ht; i++)
        for (var j = 1; j <= wd; j++)
          mx[i, j] = func(i, j);
      return mx;
    }

    public static T[,] Init<T>(int ht, int wd, Func<int, int, T> func) {
      var mx = OneBased.Init<T>(ht, wd);
      for (var i = 1; i <= ht; i++)
        for (var j = 1; j <= wd; j++)
          mx[i, j] = func(i, j);
      return mx;
    }
  }
}