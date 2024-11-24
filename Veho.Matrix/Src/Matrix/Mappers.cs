using System;
using System.Collections.Generic;
using Typen;
using Veho.Rows;

namespace Veho.Matrix {
  public static class Mappers {
    public static void Iterate<T>(this T[,] matrix, Action<T> fn) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          fn(matrix[i, j]);
    }
    public static TO[,] Map<T, TO>(this T[,] matrix, Func<T, TO> fn) {
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = fn(matrix[i, j]);
      return target;
    }
    public static T[,] Mutate<T>(this T[,] matrix, Func<T, T> fn) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = fn(matrix[i, j]);
      return matrix;
    }

    public static void Iterate<T>(this T[,] matrix, Action<int, int, T> fn) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          fn(i, j, matrix[i, j]);
    }
    public static TO[,] Map<T, TO>(this T[,] matrix, Func<int, int, T, TO> fn) {
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = fn(i, j, matrix[i, j]);
      return target;
    }
    public static T[,] Mutate<T>(this T[,] matrix, Func<int, int, T, T> fn) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = fn(i, j, matrix[i, j]);
      return matrix;
    }

    // Func<tIn, tOut> conv = Operator.Convert<tIn, tOut>;
    public static TO[,] CastTo<T, TO>(this T[,] matrix) => matrix.Map(Conv.Cast<T, TO>);
    public static TO[,] CastTo<T, TO>(this T[,] matrix, Converter<T, TO> converter) => matrix.Map(x => converter(x));
  }
}