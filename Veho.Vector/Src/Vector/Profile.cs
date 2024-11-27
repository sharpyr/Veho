using System;

namespace Veho.Vector {
  public static class Profile {
    public static int Lo<T>(this T[] vec) => vec.GetLowerBound(0);
    public static int Hi<T>(this T[] vec) => vec.GetLowerBound(1);

    public static (int lo, int hi) Bin<T>(this T[] vec) => (vec.GetLowerBound(0), vec.GetUpperBound(0));

    public static (int lo, int len) Vol<T>(this T[] vec) => (vec.GetLowerBound(0), vec.Length);

    [Obsolete("Use Bin instead")]
    public static (int lo, int hi) LoHi<T>(this T[] vec) => (vec.GetLowerBound(0), vec.GetUpperBound(0));
  }
}