using System;

namespace Veho.Matrix {
  public static class Utils {
    public static T[,] Transpose<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[w, h];
      // matrix.IndexedIterate((i, j, v) => { target[j, i] = v; });
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[j, i] = matrix[i, j];
      return target;
    }

    public static T[] Flatten<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var vec = new T[matrix.Length];
      var label = 0;
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          vec[label++] = matrix[i, j];
      return vec;
    }

    public static P[] Flatten<T, P>(this T[,] matrix, Func<T, P> fn) {
      var (h, w) = matrix.Size();
      var vec = new P[matrix.Length];
      var label = 0;
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          vec[label++] = fn(matrix[i, j]);
      return vec;
    }
  }
}