using System;

namespace Veho {
  public static class Pan {
    public static T[,] Init<T>(this (int, int) sizes, (int, int) bases) => (T[,])Array
      .CreateInstance(typeof(T), sizes.ToVector(), bases.ToVector());

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