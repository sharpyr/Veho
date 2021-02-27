using System;
using Veho.Matrix.Rows;

namespace Veho.Matrix {
  public static class NestedVector {
    public static int Height<T>(this T[][] matrix) => matrix.Length;
    public static int Width<T>(this T[][] matrix) => matrix.Length == 0 ? 0 : matrix[0].Length;
    public static (int height, int width) Size<T>(this T[][] matrix) {
      var h = matrix.Length;
      return (h, h == 0 ? 0 : matrix[0].Length);
    }
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
    public static T[][] MatrixToNest<T>(this T[,] matrix) => matrix.MapRows(row => row);
  }
}