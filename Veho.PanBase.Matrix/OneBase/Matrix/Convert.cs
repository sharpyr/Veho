using System;
using Veho.Matrix;
using static System.Convert;

namespace Veho.OneBase.Matrix {
  public static class PanBase {
    public static void Iter1B<T>(this (int, int) size, Action<int, int> action) {
      var (h, w) = size;
      for (var i = 1; i <= h; i++)
        for (var j = 1; j <= w; j++)
          action(i, j);
    }

    public static T[,] Zeroize<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      Array.Copy(matrix, 1, target, 0, matrix.Length);
      return target;
    }

    public static TO[,] Zeroize<T, TO>(this T[,] matrix) {
      TO Cast(T v) => (TO)ChangeType(v, typeof(TO));
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (int i = 0, x = 1; i < h; i++, x++) {
        for (var j = 0; j < w;)
          target[i, j++] = Cast(matrix[x, j]);
      }
      return target;
    }

    public static TO[,] Zeroize<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (int i = 0, x = 1; i < h; i++, x++) {
        for (var j = 0; j < w;)
          target[i, j++] = func(matrix[x, j]);
      }
      return target;
    }

    public static TO[,] Zeroize<T, TO>(this T[,] matrix, Func<int, int, T, TO> func) {
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (int i = 0, x = 1; i < h; i++, x++) {
        for (var j = 0; j < w;)
          target[i, j] = func(i, j, matrix[x, ++j]);
      }
      return target;
    }
  }
}