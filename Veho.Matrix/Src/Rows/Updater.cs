using System;
using Veho.Matrix;

namespace Veho.Rows {
  public static class Updater {
    public static T[,] ExpandRow<T>(this T[,] matrix, int delta) {
      var (height, width) = matrix.Size();
      var target = new T[(height += delta) > 0 ? height : 0, width];
      Array.Copy(matrix, 0, target, 0, Math.Min(matrix.Length, target.Length));
      return target;
    }
    public static T[,] WriteRow<T>(this T[,] matrix, T[] vec, int x) {
      for (int j = 0, hi = vec.Length; j < hi; j++) matrix[x, j] = vec[j];
      return matrix;
    }
    /// <summary>
    /// Return a new matrix
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="vec"></param>
    /// <param name="y"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>A new matrix</returns>
    public static T[,] PushRow<T>(this T[,] matrix, T[] vec) {
      var y = matrix.Height();
      return matrix
             .ExpandRow(1)
             .WriteRow(vec, y);
    }

    public static T[,] UnshiftRow<T>(this T[,] matrix, T[] vec) {
      var (height, width) = matrix.Size();
      var target = new T[height + 1, width];
      Array.Copy(matrix, 0, target, width, matrix.Length);
      return target.WriteRow(vec, 0);
    }
  }
}