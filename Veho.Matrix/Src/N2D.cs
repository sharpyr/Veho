using System;
using Veho.Matrix.Rows;

namespace Veho.Matrix {
  public static class N2D {
    public static int Height<T>(this T[][] matrix) => matrix.Length;
    public static int Width<T>(this T[][] matrix) => matrix.Length == 0 ? 0 : matrix[0].Length;
    public static (int height, int width) Size<T>(this T[][] matrix) {
      var h = matrix.Length;
      return (h, h == 0 ? 0 : matrix[0].Length);
    }
    // public static T[,] NestToMatrix<T>(T[][] matrix) {
    //   var (h, w) = matrix.Size();
    //   var target = new T[h, w];
    //   Array.Resize();
    //   matrix.Iterate(
    //     row => { }
    //   );
    // }
    public static T[][] MatrixToNest<T>(T[,] matrix) => matrix.MapRows(row => row);
  }
}