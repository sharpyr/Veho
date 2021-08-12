using System;
using Typen;

namespace Veho.NestedVector {
  public static class Info {
    public static int Height<T>(this T[][] matrix) => matrix.Length;
    public static int Width<T>(this T[][] matrix) => matrix.Length == 0 ? 0 : matrix[0].Length;
    public static (int height, int width) Size<T>(this T[][] matrix) {
      var h = matrix.Length;
      return (h, h == 0 ? 0 : matrix[0].Length);
    }
  }

  public static class Nested {
    public static T[] Flatten<T>(this T[][] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h * w];
      for (var i = 0; i < h; i++)
        Array.Copy(matrix[i], 0, target, i * w, w);
      return target;
    }
    public static T[,] NestToMatrix<T>(this T[][] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      for (var i = 0; i < h; i++) {
        var row = matrix[i];
        for (var j = 0; j < w; j++) target[i, j] = row[j]; // Array.Copy(matrix[i], 0, target, i * w, w);
      }
      return target;
    }
    public static TO[,] NestToMatrix<T, TO>(this T[][] matrix, Func<T, TO> func) {
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (var i = 0; i < h; i++) {
        var row = matrix[i];
        for (var j = 0; j < w; j++) target[i, j] = func(row[j]); // Array.Copy(matrix[i], 0, target, i * w, w);
      }
      return target;
    }
    public static TO[,] NestToMatrix<T, TO>(this T[][] matrix) => matrix.NestToMatrix(Conv.Cast<T, TO>);
  }
}