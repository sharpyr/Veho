using System;

namespace Veho.Matrix {
  public static class Profile {
    public static bool Any(this (int height, int width) size) => size.height != 0 && size.width != 0;

    public static bool IsUnit(this (int height, int width) size) => size.height == 1 && size.width == 1;

    public static void Iter(this (int height, int width) size, Action<int, int> func) {
      var (h, w) = size;
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          func(i, j);
    }
    public static void RestOf(this (int height, int width) size, (int x, int y) coordinate, Action<int, int> action) {
      var (h, w) = size;
      var (x, y) = coordinate;
      for (++y; y < w; y++) action(x, y);
      for (++x; x < h; x++)
        for (y = 0; y < w; y++)
          action(x, y);
    }

    public static bool Any<T>(this T[,] matrix) => matrix.Size().Any();
    public static (int height, int width) Size<T>(this T[,] matrix) => (matrix.GetLength(0), matrix.GetLength(1));
    public static (int xlo, int ht, int ylo, int wd) Leaps<T>(this T[,] matrix) => (matrix.GetLowerBound(0), matrix.GetLength(0), matrix.GetLowerBound(1), matrix.GetLength(1));
    public static (int xlo, int xhi, int ylo, int yhi) Bounds<T>(this T[,] matrix) => (matrix.GetLowerBound(0), matrix.GetUpperBound(0), matrix.GetLowerBound(1), matrix.GetUpperBound(1));
    public static (int lo, int hi) XBound<T>(this T[,] matrix) => (matrix.GetLowerBound(0), matrix.GetUpperBound(0));
    public static (int lo, int hi) YBound<T>(this T[,] matrix) => (matrix.GetLowerBound(1), matrix.GetUpperBound(1));
    public static (int lo, int ht) XLeap<T>(this T[,] matrix) => (matrix.GetLowerBound(0), matrix.GetLength(0));
    public static (int lo, int wd) YLeap<T>(this T[,] matrix) => (matrix.GetLowerBound(1), matrix.GetLength(1));
    public static int XLo<T>(this T[,] matrix) => matrix.GetLowerBound(0);
    public static int YLo<T>(this T[,] matrix) => matrix.GetLowerBound(1);
    public static int XHi<T>(this T[,] matrix) => matrix.GetUpperBound(0);
    public static int YHi<T>(this T[,] matrix) => matrix.GetUpperBound(1);
    public static int Height<T>(this T[,] matrix) => matrix.GetLength(0);
    public static int Width<T>(this T[,] matrix) => matrix.GetLength(1);
    public static int Count<T>(this T[,] matrix) => matrix.Length;
  }
}