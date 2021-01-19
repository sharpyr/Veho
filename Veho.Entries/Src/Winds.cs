using System.Collections.Generic;

namespace Veho.Entries {
  public static class Winds {
    public static (K, V)[] wind<K, V>(K[] keys, V[] values) {
      var hi = keys.Length;
      var entries = new (K, V)[hi];
      for (var lo = 0; lo < hi; lo++) entries[lo] = (keys[lo], values[lo]);
      return entries;
    }
  }
}