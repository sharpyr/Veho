using System;

namespace Veho.Matrix {
  public static class Sizers {
    public static T[,] Resize<T>(this T[,] matrix, int height, int width) {
      var target = new T[height, width];
      var width0 = matrix.Width();
      var delta = Math.Min(width0, width);
      var (count0, count) = (matrix.Length, target.Length); // Console.WriteLine($"i = {i}, di = {di}, delta = {delta}");
      for (int lo0 = 0, lo = 0; lo0 < count0 && lo < count; lo0 += width0, lo += width)
        Array.Copy(matrix, lo0, target, lo, delta);
      return target;
    }
  }
}