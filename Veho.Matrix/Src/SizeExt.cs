using System;

namespace Veho {
  public static class Through {
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
  }
}