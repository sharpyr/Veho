namespace Veho.Vector {
  public static class Info {
    public static (int, int) LoHi<T>(this T[] matrix) => (matrix.GetLowerBound(0), matrix.GetUpperBound(0));
    public static int Lo<T>(this T[] matrix) => matrix.GetLowerBound(0);
    public static int Hi<T>(this T[] matrix) => matrix.GetLowerBound(1);
  }
}