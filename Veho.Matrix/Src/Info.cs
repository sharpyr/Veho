namespace Veho.Matrix {
  public static class Info {
    public static (int, int) Size<T>(this T[,] matrix) {
      return (matrix.GetLength(0), matrix.GetLength(1));
    }
  }
}