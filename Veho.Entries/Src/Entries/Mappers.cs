using System.Collections.Generic;
using System.Linq;
using Veho.Sequence;

namespace Veho.Entries {
  public static class Mappers {
    public static List<TK> Keys<TK, TV>(this IReadOnlyList<(TK key, TV value)> entries) => entries.Map(kv => kv.key);
    public static List<TV> Values<TK, TV>(this IReadOnlyList<(TK key, TV value)> entries) => entries.Map(kv => kv.value);

    public static IEnumerable<TK> Keys<TK, TV>(this IEnumerable<(TK key, TV value)> entries) => entries.Select(kv => kv.key);
    public static IEnumerable<TV> Values<TK, TV>(this IEnumerable<(TK key, TV value)> entries) => entries.Select(kv => kv.value);
  }
}