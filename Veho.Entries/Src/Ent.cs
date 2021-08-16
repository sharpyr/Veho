namespace Veho {
  public static class Ent {
    // public static T[] ToVector<T>(this (T, T) entry) {
    //   var (x, y) = entry;
    //   return new[] {x, y};
    // }
    // public static T[] ToVector<T>(this (T, T, T) entry) {
    //   var (x, y, z) = entry;
    //   return new[] {x, y, z};
    // }
    // public static (TO, TO) Map<T, TO>(this (T, T) entry, Func<T, TO> f) {
    //   var (x, y) = entry;
    //   return (f(x), f(y));
    // }
    // public static (TO, TO, TO) Map<T, TO>(this (T, T, T) entry, Func<T, TO> f) {
    //   var (x, y, z) = entry;
    //   return (f(x), f(y), f(z));
    // }

    public static (TK[], TV[]) Unwind<TK, TV>(this (TK, TV)[] entries) {
      var len = entries.Length;
      var keys = new TK[len];
      var values = new TV[len];
      for (var i = 0; i < len; i++) {
        var (k, v) = entries[i];
        keys[i] = k;
        values[i] = v;
      }
      return (keys, values);
    }
    public static (TK, TV)[] Wind<TK, TV>(TK[] keys, TV[] values) {
      var hi = keys.Length;
      var entries = new (TK, TV)[hi];
      for (var lo = 0; lo < hi; lo++) entries[lo] = (keys[lo], values[lo]);
      return entries;
    }
  }
}