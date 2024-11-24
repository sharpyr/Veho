using System;

namespace Veho {
  public static class OneBased {
    public static readonly int[] P1 = { 1, 1 };
    public static T[,] Init<T>((int, int) sizes) => (T[,])Array
      .CreateInstance(typeof(T), sizes.ToVector(), P1);

    public static T[,] Init<T>((int, int) sizes, Func<int, int, T> func) {
      var mx = OneBased.Init<T>(sizes);
      var (ht, wd) = sizes;
      for (var i = 1; i <= ht; i++)
        for (var j = 1; j <= wd; j++)
          mx[i, j] = func(i, j);
      return mx;
    }
  }
}