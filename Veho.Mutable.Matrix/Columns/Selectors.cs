using System.Collections.Generic;
using Veho.Sequence;

namespace Veho.Mutable.Columns {
  public static class Selectors {
    public static List<List<T>> SelectByColumnsBy<T>(this IReadOnlyList<IReadOnlyList<T>> rows, IReadOnlyList<int> columnIndices) {
      return columnIndices.Map(rows.Column);
    }
    public static List<List<T>> SelectByColumnIndices<T>(this IReadOnlyList<IReadOnlyList<T>> rows, IReadOnlyList<int> columnIndices) {
      return rows.Map(row => row.SelectBy(columnIndices));
    }
  }
}