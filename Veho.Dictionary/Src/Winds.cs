using System.Collections.Generic;

namespace Veho.Dictionary {
  public static class Winds {
    public static Dictionary<K, V> Wind<K, V>(K[] keys, V[] values) {
      var hi = keys.Length;
      var dict = new Dictionary<K, V>();
      for (var lo = 0; lo < hi; lo++) dict.Add(keys[lo], values[lo]);
      return dict;
    }
  }
}