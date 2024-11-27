using System;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Dictionary {
  public static class Mappers {
    public static IEnumerable<TP> Map<TK, TV, TP>(this IDictionary<TK, TV> dict, Func<TK, TV, TP> func) {
      foreach (var kv in dict) yield return func(kv.Key, kv.Value);
    }
    public static IEnumerable<TP> MapKeys<TK, TV, TP>(this IDictionary<TK, TV> dict, Func<TK, TP> func) {
      // foreach (var kv in dict.Keys) yield return kv ;
      return dict.Keys.Select(func);
    }
    public static IEnumerable<TP> MapValues<TK, TV, TP>(this IDictionary<TK, TV> dict, Func<TV, TP> func) {
      return dict.Values.Select(func);
    }
  }
}