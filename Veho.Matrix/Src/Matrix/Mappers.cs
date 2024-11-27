using System;
using Typen;

namespace Veho.Matrix {
  public static class Mappers {
    public static void Iterate<T>(this T[,] matrix, Action<T> func) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          func(matrix[i, j]);
    }
    public static TO[,] Map<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = func(matrix[i, j]);
      return target;
    }
    public static T[,] Mutate<T>(this T[,] matrix, Func<T, T> func) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(matrix[i, j]);
      return matrix;
    }

    public static void Iterate<T>(this T[,] matrix, Action<int, int, T> func) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          func(i, j, matrix[i, j]);
    }
    public static TO[,] Map<T, TO>(this T[,] matrix, Func<int, int, T, TO> func) {
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = func(i, j, matrix[i, j]);
      return target;
    }
    public static T[,] Mutate<T>(this T[,] matrix, Func<int, int, T, T> func) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(i, j, matrix[i, j]);
      return matrix;
    }

    // Func<tIn, tOut> conv = Operator.Convert<tIn, tOut>;
    public static TO[,] CastTo<T, TO>(this T[,] matrix) => matrix.Map(Conv.Cast<T, TO>);
    public static TO[,] CastTo<T, TO>(this T[,] matrix, Converter<T, TO> converter) => matrix.Map(x => converter(x));
  }
}