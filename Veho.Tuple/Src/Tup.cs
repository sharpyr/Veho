namespace Veho {
  public static class Tup {
    public static T[] ToVector<T>(this (T, T) entry) {
      var (x, y) = entry;
      return new[] {x, y};
    }
    public static T[] ToVector<T>(this (T, T, T) entry) {
      var (x, y, z) = entry;
      return new[] {x, y, z};
    }
  }
}