using System;

namespace Veho.Matrix.Columns {
  public static class Updaters {
    public static T[,] ExpandColumn<T>(this T[,] matrix, int delta) {
      var (height, width) = matrix.Size();
      var width2 = width + delta;
      var target = new T[height, width2];
      for (int lo = 0, lo2 = 0, hi = matrix.Length; lo < hi; lo += width, lo2 += width2)
        Array.Copy(matrix, lo, target, lo2, width);
      return target;
    }
    public static T[,] WriteColumn<T>(this T[,] matrix, T[] vec, int y) {
      for (int i = 0, hi = vec.Length; i < hi; i++) matrix[i, y] = vec[i];
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
    public static T[,] PushColumn<T>(this T[,] matrix, T[] vec) {
      var y = matrix.Width();
      return matrix
        .ExpandColumn(1)
        .WriteColumn(vec, y);
    }

    public static T[,] UnshiftColumn<T>(this T[,] matrix, T[] vec) {
      var (height, width) = matrix.Size();
      var target = new T[height, width + 1];
      for (int lo = 0, lo2 = 1, hi = matrix.Length; lo < hi; lo += width, lo2 += width + 1) {
        Array.Copy(matrix, lo, target, lo2, width);
      }
      return target.WriteColumn(vec, 0);
    }
  }
}