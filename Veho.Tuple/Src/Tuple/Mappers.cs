using System;

namespace Veho.Tuple {
  public static class Mappers {
    public static (TO x, TO y) To<T, TO>(this (T x, T y) t, Func<T, TO> f) => (f(t.x), f(t.y));
    public static (TO x, TO y, TO z) To<T, TO>(this (T x, T y, T z) t, Func<T, TO> f) => (f(t.x), f(t.y), f(t.z));
    public static void Iter<T, TO>(ref (T x, T y, T z) t, Action<T> f) {
      f(t.x);
      f(t.y);
      f(t.z);
    }
  }
}