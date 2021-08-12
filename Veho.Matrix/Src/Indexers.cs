namespace Veho {
  public static partial class Indexers {
    public static T First<T>(this T[,] matrix) => matrix[0, 0];
  }
}