using System.Collections.Generic;

namespace Veho.Entries {
  public static class Unwinds {
    public static (K[], V[]) unwind<K, V>(this (K, V)[] dict) {
      var len = dict.Length;
      var keys = new K[len];
      var values = new V[len];
      for (var i = 0; i < len; i++) {
        var (k, v) = dict[i];
        keys[i] = k;
        values[i] = v;
      }
      return (keys, values);
    }
  }
}