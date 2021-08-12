using System.Collections.Generic;

namespace Veho {
  public static partial class Dict {
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
  }
}