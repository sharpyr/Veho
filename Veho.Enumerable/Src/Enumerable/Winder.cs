using System.Collections.Generic;

namespace Veho.Enumerable {
  public static class Winder {
    public static (List<TK>, List<TV>) Unwind<TK, TV>(this IEnumerable<(TK, TV)> entries) {
      var keys = new List<TK>();
      var values = new List<TV>();
      foreach (var entry in entries) {
        var (k, v) = entry;
        keys.Add(k);
        values.Add(v);
      }
      return (keys, values);
    }

    public static IEnumerable<(TK, TV)> Wind<TK, TV>(IEnumerable<TK> keys, IEnumerable<TV> values) {
      var keyEnu = keys.GetEnumerator();
      var valEnu = values.GetEnumerator();
      if (keyEnu.MoveNext() && valEnu.MoveNext()) yield return (keyEnu.Current, valEnu.Current);
      keyEnu.Dispose();
      valEnu.Dispose();
    }
  }
}