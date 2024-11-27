using System;
using Veho.Rows;

namespace Veho {
  public static class Mat {
    public static T[,] Empty<T>() => new T[,] { { } };

    public static T[,] Boot<T>(T element) => new[,] { { element } };

    public static T[,] M1X1<T>(T element) => Boot(element);

    public static T[,] Init<T>(this (int, int) size) => new T[size.Item1, size.Item2];

    public static T[,] From<T>(params T[][] rows) => rows.RowsToMatrix();

    public static T[,] Init<T>(this (int, int) size, Func<int, int, T> func) {
      var (h, w) = size;
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(i, j);
      return matrix;
    }

    public static T[,] Init<T>(int h, int w, Func<int, int, T> func) {
      var matrix = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          matrix[i, j] = func(i, j);
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