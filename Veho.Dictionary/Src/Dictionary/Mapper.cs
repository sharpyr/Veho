using System;
using System.Collections.Generic;
using System.Linq;

namespace Veho.Dictionary {
  public static class Mappers {
    public static IEnumerable<TP> Map<TK, TV, TP>(this IDictionary<TK, TV> dict, Func<TK, TV, TP> fn) {
      foreach (var kv in dict) yield return fn(kv.Key, kv.Value);
    }
    public static IEnumerable<TP> MapKeys<TK, TV, TP>(this IDictionary<TK, TV> dict, Func<TK, TP> fn) {
      // foreach (var kv in dict.Keys) yield return kv ;
      return dict.Keys.Select(fn);
    }
    public static IEnumerable<TP> MapValues<TK, TV, TP>(this IDictionary<TK, TV> dict, Func<TV, TP> fn) {
      return dict.Values.Select(fn);
    }
  }
}