using System;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Matrix {
  public static class Util {
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

    public static TP[] Flatten<T, TP>(this T[,] matrix, Func<T, TP> func) {
      var (h, w) = matrix.Size();
      var vec = new TP[matrix.Length];
      var label = 0;
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          vec[label++] = func(matrix[i, j]);
      return vec;
    }

    public static void Copy<T>(this T[,] matrix, T[,] target, int xlb = 0, int ylb = 0) {
      var wd = matrix.Width();
      for (var i = 0; i < matrix.Height(); i++)
        for (var j = 0; j < wd; j++)
          target[xlb + i, ylb + j] = matrix[i, j];
    }
  }
}