using System;

namespace Veho.Matrix {
  public static class Sizes {
    public static bool Any(this (int height, int width) size) => size.height != 0 && size.width != 0;

    public static void Iter(this (int height, int width) size, Action<int, int> fn) {
      var (h, w) = size;
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          fn(i, j);
    }
    public static void RestOf(this (int height, int width) size, (int x, int y) coordinate, Action<int, int> action) {
      var (h, w) = size;
      var (x, y) = coordinate;
      for (++y; y < w; y++) { action(x, y); }
      for (++x; x < h; x++)
        for (y = 0; y < w; y++) { action(x, y); }
    }
  }
}