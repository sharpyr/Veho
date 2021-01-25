using System;
using System.Collections.Generic;

namespace Veho.Entries {
  public static class Mapper {

    public static P[] MapKeys<K, _, P>(this (K, _)[] entries, Func<K, P> fn) {
      var vec = new P[entries.Length];
      var i = 0;
      foreach (var (k, _) in entries) vec[i++] = fn(k);
      return vec;
    }
    public static P[] MapValues<_, V, P>(this (_, V)[] entries, Func<V, P> fn) {
      var vec = new P[entries.Length];
      var i = 0;
      foreach (var (_, v) in entries) vec[i++] = fn(v);
      return vec;
    }
  }
}