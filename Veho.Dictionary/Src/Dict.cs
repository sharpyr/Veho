using System.Collections.Generic;
using System.Linq;

namespace Veho {
  public static class Dict {
    public static Dictionary<TK, TV> From<TK, TV>(params (TK key, TV value)[] entries) => entries
      .ToDict();
    public static Dictionary<TK, TV> ToDict<TK, TV>(this IReadOnlyList<(TK key, TV value)> entries) {
      var dict = new Dictionary<TK, TV>();
      for (int i = 0, hi = entries.Count; i < hi; i++) {
        var (k, v) = entries[i];
        dict.Add(k, v);
      }
      return dict;
    }

    public static (TK[], TV[]) Unwind<TK, TV>(this IDictionary<TK, TV> dict) {
      var len = dict.Count;
      var keys = new TK[len];
      var values = new TV[len];
      var index = 0;
      foreach (var entry in dict) {
        keys[index] = entry.Key;
        values[index++] = entry.Value;
      }
      return (keys, values);
    }

    public static Dictionary<TK, TV> Wind<TK, TV>(IReadOnlyList<TK> keys, IReadOnlyList<TV> values) {
      var hi = keys.Count;
      var dict = new Dictionary<TK, TV>();
      for (var lo = 0; lo < hi; lo++) dict.Add(keys[lo], values[lo]);
      return dict;
    }

    public static IEnumerable<(TK key, TV value)> EnumEntries<TK, TV>(this IDictionary<TK, TV> dict) {
      return dict.Select(kv => (kv.Key, kv.Value));
    }
    public static List<(TK key, TV value)> Entries<TK, TV>(this IDictionary<TK, TV> dict) {
      return dict.Select(kv => (kv.Key, kv.Value)).ToList();
    }
  }
}