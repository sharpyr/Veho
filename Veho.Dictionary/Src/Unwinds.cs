using System.Collections.Generic;

namespace Veho.Dictionary {
  public static class Unwinds {
    public static (K[], V[]) Unwind<K, V>(this IDictionary<K, V> dict) {
      var len = dict.Count;
      var keys = new K[len];
      var values = new V[len];
      var index = 0;
      foreach (var entry in dict) {
        keys[index] = entry.Key;
        values[index++] = entry.Value;
      }
      return (keys, values);
    }
  }
}