using System;

namespace Veho.Matrix.Enumerate {
  public static class Mapper {
    public static void Iterate<T>(this T[,] matrix, Action<int, int, T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          fn(i, j, matrix[i, j]);
    }

    public static P[,] Map<T, P>(this T[,] matrix, Func<int, int, T, P> fn) {
      var (height, width) = matrix.Size();
      var result = new P[height, width];
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          result[i, j] = fn(i, j, matrix[i, j]);
      return result;
    }

    public static T[,] Mutate<T>(this T[,] matrix, Func<int, int, T, T> fn) {
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
          matrix[i, j] = fn(i, j, matrix[i, j]);
      return matrix;
    }
  }
}