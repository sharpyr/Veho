using System;

namespace Veho.Matrix {
  public static class Zippers {
    public static T[,] Zip<TA, TB, T>(this TA[,] matrix, TB[,] another, Func<TA, TB, T> func) {
      var (h, w) = matrix.Size();
      var result = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          result[i, j] = func(matrix[i, j], another[i, j]);
      return result;
    }
    public static void IterZip<TA, TB>(this TA[,] matrix, TB[,] another, Action<TA, TB> action) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          action(matrix[i, j], another[i, j]);
    }
    public static TA[,] MutaZip<TA, TB>(this TA[,] matrix, TB[,] another, Func<TA, TB, TA> func) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(matrix[i, j], another[i, j]);
      return matrix;
    }
    public static T[,] Zipper<TA, TB, T>(this Func<TA, TB, T> func, TA[,] a, TB[,] b) {
      var (h, w) = a.Size();
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(a[i, j], b[i, j]);
      return matrix;
    }
    public static T[,] Zipper<TA, TB, TC, T>(this Func<TA, TB, TC, T> func, TA[,] a, TB[,] b, TC[,] c) {
      var (h, w) = a.Size();
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(a[i, j], b[i, j], c[i, j]);
      return matrix;
    }
    public static T[,] Zipper<TA, TB, TC, TD, T>(this Func<TA, TB, TC, TD, T> func, TA[,] a, TB[,] b, TC[,] c, TD[,] d) {
      var (h, w) = a.Size();
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(a[i, j], b[i, j], c[i, j], d[i, j]);
      return matrix;
    }

    #region Indexed
    public static T[,] Zip<TA, TB, T>(this TA[,] matrix, TB[,] another, Func<int, int, TA, TB, T> func) {
      var (h, w) = matrix.Size();
      var result = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          result[i, j] = func(i, j, matrix[i, j], another[i, j]);
      return result;
    }
    public static void IterZip<TA, TB>(this TA[,] matrix, TB[,] another, Action<int, int, TA, TB> action) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          action(i, j, matrix[i, j], another[i, j]);
    }
    public static TA[,] MutaZip<TA, TB>(this TA[,] matrix, TB[,] another, Func<int, int, TA, TB, TA> func) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(i, j, matrix[i, j], another[i, j]);
      return matrix;
    }
    public static T[,] Zipper<TA, TB, T>(this Func<int, int, TA, TB, T> func, TA[,] a, TB[,] b) {
      var (h, w) = a.Size();
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(i, j, a[i, j], b[i, j]);
      return matrix;
    }
    public static T[,] Zipper<TA, TB, TC, T>(this Func<int, int, TA, TB, TC, T> func, TA[,] a, TB[,] b, TC[,] c) {
      var (h, w) = a.Size();
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(i, j, a[i, j], b[i, j], c[i, j]);
      return matrix;
    }
    public static T[,] Zipper<TA, TB, TC, TD, T>(this Func<int, int, TA, TB, TC, TD, T> func, TA[,] a, TB[,] b, TC[,] c, TD[,] d) {
      var (h, w) = a.Size();
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(i, j, a[i, j], b[i, j], c[i, j], d[i, j]);
      return matrix;
    }
    #endregion
  }
}