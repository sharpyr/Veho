using System;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Matrix {
  public static class Utils {
    public static IEnumerable<T> AsEnum<T>(this T[,] matrix) => matrix.OfType<T>();
    public static T[,] Transpose<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[w, h];
      // matrix.Iterate((i, j, v) => { target[j, i] = v; });
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
      return vec; // matrix.OfType<T>().ToArray();
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

    public static void Copy<T>(this T[,] matrix, T[,] target, int xStart = 0, int yStart = 0) {
      var wd = matrix.Width();
      for (var i = 0; i < matrix.Height(); i++) {
        for (var j = 0; j < wd; j++) {
          target[xStart + i, yStart + j] = matrix[i, j];
        }
      }
    }
  }
}