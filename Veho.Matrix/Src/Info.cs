﻿namespace Veho.Matrix {
  public static class Info {
    public static (int, int) Size<T>(this T[,] matrix) => (matrix.GetLength(0), matrix.GetLength(1));
    public static (int, int) XBound<T>(this T[,] matrix) => (matrix.GetLowerBound(0), matrix.GetUpperBound(0));
    public static (int, int) YBound<T>(this T[,] matrix) => (matrix.GetLowerBound(1), matrix.GetUpperBound(1));
    public static int XLo<T>(this T[,] matrix) => matrix.GetLowerBound(0);
    public static int YLo<T>(this T[,] matrix) => matrix.GetLowerBound(1);
    public static int XHi<T>(this T[,] matrix) => matrix.GetUpperBound(0);
    public static int YHi<T>(this T[,] matrix) => matrix.GetUpperBound(1);
    public static int Height<T>(this T[,] matrix) => matrix.GetLength(0);
    public static int Width<T>(this T[,] matrix) => matrix.GetLength(1);
    public static int Count<T>(this T[,] matrix) => matrix.Length;
  }
}