using System.Collections.Generic;

namespace Veho.Tuple {
  public static class Convert {
    public static T[] Vec<T>(this (T, T) entry) {
      var (x, y) = entry;
      return new[] { x, y };
    }
    public static T[] Vec<T>(this (T, T, T) entry) {
      var (x, y, z) = entry;
      return new[] { x, y, z };
    }
    public static T[] Vec<T>(this (T, T, T, T) entry) {
      var (a, b, c, d) = entry;
      return new[] { a, b, c, d };
    }
    public static List<T> List<T>(this (T, T) entry) {
      var (x, y) = entry;
      return new List<T> { x, y };
    }
    public static List<T> List<T>(this (T, T, T) entry) {
      var (x, y, z) = entry;
      return new List<T> { x, y, z };
    }
    public static List<T> List<T>(this (T, T, T, T) entry) {
      var (a, b, c, d) = entry;
      return new List<T> { a, b, c, d };
    }
  }
}