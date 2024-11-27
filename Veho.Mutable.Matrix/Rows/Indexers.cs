using System;
using System.Collections.Generic;
using Veho.Sequence;

namespace Veho.Mutable.Rows {
  public static class Indexers {
    public static IList<T> Row<T>(this IReadOnlyList<IList<T>> matrix, int x) => matrix[x];

    public static List<TO> Row<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<T, TO> func) => matrix[x].Map(func);

    public static List<TO> Row<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, int x, Func<int, T, TO> func) => matrix[x].Map(func);
  }
}