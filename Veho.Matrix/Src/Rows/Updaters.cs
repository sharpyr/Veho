namespace Veho.Matrix.Rows {
  public static class Updaters {
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
  }
}