namespace Veho.Matrix {
  public static class Indexer {
    public static T First<T>(this T[,] matrix) => matrix[0, 0];
  }
}