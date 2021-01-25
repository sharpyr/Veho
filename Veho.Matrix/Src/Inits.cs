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


  }
}