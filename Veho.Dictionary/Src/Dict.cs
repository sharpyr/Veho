using System.Collections.Generic;

namespace Veho {
  public static class Dict {
    public static Dictionary<TK, TV> From<TK, TV>(params (TK key, TV value)[] entries) => entries
      .ToDict();
    public static Dictionary<TK, TV> ToDict<TK, TV>(this (TK key, TV value)[] entries) {
      var dict = new Dictionary<TK, TV>();
      for (int i = 0, hi = entries.Length; i < hi; i++) {
        var (k, v) = entries[i];
        dict.Add(k, v);
      }
      return dict;
    }

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

    public static Dictionary<K, V> Wind<K, V>(K[] keys, V[] values) {
      var hi = keys.Length;
      var dict = new Dictionary<K, V>();
      for (var lo = 0; lo < hi; lo++) dict.Add(keys[lo], values[lo]);
      return dict;
    }
  }
}