namespace Veho.Matrix.Columns {
  public static class Updaters {
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
  }
}