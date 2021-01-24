using System;

namespace Veho.Matrix {
  public class Inits {
    public static T[,] Init<T>(int h, int w, Func<int, int, T> fn) {
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = fn(i, j);
      return matrix;
    }

    public static T[,] Iso<T>(int h, int w, T value) {
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = value;
      return matrix;
    }

    public static int[] LowerBounds1B = {1, 1};
    public static T[,] M1B<T>(int h, int w) =>
      (T[,]) Array.CreateInstance(typeof(T), new[] {h, w}, LowerBounds1B);
  }
}