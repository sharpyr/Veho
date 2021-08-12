using System;

namespace Veho {
  public static partial class Zippers {
    public static (T x, T y) Zip<TA, TB, T>(this (TA x, TA y) a, (TB x, TB y) b, Func<TA, TB, T> f) =>
      (f(a.x, b.x), f(a.y, b.y));
    public static (T x, T y) Zip<TA, TB, T>(this (TA x, TA y) a, TB b, Func<TA, TB, T> f) =>
      (f(a.x, b), f(a.y, b));
    public static (T x, T y, T z) Zip<TA, TB, T>(this (TA x, TA y, TA z) a, (TB x, TB y, TB z) b, Func<TA, TB, T> f) =>
      (f(a.x, b.x), f(a.y, b.y), f(a.z, b.z));
    public static (T x, T y, T z) Zip<TA, TB, T>(this (TA x, TA y, TA z) a, TB b, Func<TA, TB, T> f) =>
      (f(a.x, b), f(a.y, b), f(a.z, b));
  }
}