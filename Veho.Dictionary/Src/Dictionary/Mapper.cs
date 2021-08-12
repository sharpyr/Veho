using System;
using System.Collections.Generic;

namespace Veho.Dictionary {
  public static class Mappers {
    public static P[] MapKeys<K, _, P>(this IDictionary<K, _> dict, Func<K, P> fn) {
      var vec = new P[dict.Count];
      var i = 0;
      foreach (var key in dict.Keys) vec[i++] = fn(key);
      return vec;
    }
    public static P[] MapValues<_, V, P>(this IDictionary<_, V> dict, Func<V, P> fn) {
      var vec = new P[dict.Count];
      var i = 0;
      foreach (var value in dict.Values) vec[i++] = fn(value);
      return vec;
    }
  }
}