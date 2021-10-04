using System;
using Veho.Matrix;
using static System.Convert;

namespace Veho.PanBase.Matrix {
  public static class Convert {
    public static void Iter1B<T>(this (int, int) size, Action<int, int> action) {
      var (h, w) = size;
      for (var i = 1; i <= h; i++)
        for (var j = 1; j <= w; j++)
          action(i, j);
    }
    
    public static T[,] ZeroOut<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      Array.Copy(matrix, matrix.XLo(), target, 0, matrix.Length);
      return target;
    }

    public static TO[,] ZeroOut<T, TO>(this T[,] matrix) {
      TO Cast(T v) => (TO)ChangeType(v, typeof(TO));
      var ((xlo, h), (ylo, w)) = (matrix.XLeap(), matrix.YLeap());
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = Cast(matrix[xlo + i, ylo + j]);
      return target;
    }
    
    public static TO[,] ZeroOut<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var ((xlo, h), (ylo, w)) = (matrix.XLeap(), matrix.YLeap());
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = func(matrix[xlo + i, ylo + j]);
      return target;
    }
    
    public static TO[,] ZeroOut<T, TO>(this T[,] matrix, Func<int, int, T, TO> func) {
      var ((xlo, h), (ylo, w)) = (matrix.XLeap(), matrix.YLeap());
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = func(i, j, matrix[xlo + i, ylo + j]);
      return target;
    }
    
  }
}