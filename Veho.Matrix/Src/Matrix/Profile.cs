namespace Veho.Matrix {
  public static class Profile {
    public static bool Any<T>(this T[,] matrix) => matrix.Size().Any();
    public static (int height, int width) Size<T>(this T[,] matrix) => (matrix.GetLength(0), matrix.GetLength(1));
    public static (int xlo, int ht, int ylo, int wd) Leaps<T>(this T[,] matrix) => (matrix.GetLowerBound(0), matrix.GetLength(0), matrix.GetLowerBound(1), matrix.GetLength(1));
    public static (int xlo, int xhi, int ylo, int yhi) Bounds<T>(this T[,] matrix) => (matrix.GetLowerBound(0), matrix.GetUpperBound(0), matrix.GetLowerBound(1), matrix.GetUpperBound(1));
    public static (int lo, int hi) XBound<T>(this T[,] matrix) => (matrix.GetLowerBound(0), matrix.GetUpperBound(0));
    public static (int lo, int hi) YBound<T>(this T[,] matrix) => (matrix.GetLowerBound(1), matrix.GetUpperBound(1));
    public static (int lo, int ht) XLeap<T>(this T[,] matrix) => (matrix.GetLowerBound(0), matrix.GetLength(0));
    public static (int lo, int wd) YLeap<T>(this T[,] matrix) => (matrix.GetLowerBound(1), matrix.GetLength(1));
    public static int XLo<T>(this T[,] matrix) => matrix.GetLowerBound(0);
    public static int YLo<T>(this T[,] matrix) => matrix.GetLowerBound(1);
    public static int XHi<T>(this T[,] matrix) => matrix.GetUpperBound(0);
    public static int YHi<T>(this T[,] matrix) => matrix.GetUpperBound(1);
    public static int Height<T>(this T[,] matrix) => matrix.GetLength(0);
    public static int Width<T>(this T[,] matrix) => matrix.GetLength(1);
    public static int Count<T>(this T[,] matrix) => matrix.Length;
  }
}