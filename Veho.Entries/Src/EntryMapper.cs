using System;

namespace Veho.Entries {
  public static class EntryMapper {
    public static T[] ToVector<T>(this (T, T) entry) {
      var (x, y) = entry;
      return new[] {x, y};
    }
    public static T[] ToVector<T>(this (T, T, T) entry) {
      var (x, y, z) = entry;
      return new[] {x, y, z};
    }
    public static (TO, TO) Map<T, TO>(this (T, T) entry, Func<T, TO> f) {
      var (x, y) = entry;
      return (f(x), f(y));
    }
    public static (TO, TO, TO) Map<T, TO>(this (T, T, T) entry, Func<T, TO> f) {
      var (x, y, z) = entry;
      return (f(x), f(y), f(z));
    }
  }
}