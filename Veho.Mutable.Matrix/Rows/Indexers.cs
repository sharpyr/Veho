using System;
using System.Collections.Generic;
using Veho.List;

namespace Veho.Mutable.Rows {
  public static class Indexers {
    public static List<T> Row<T>(this List<List<T>> matrix, int x) => matrix[x];

    public static List<TO> Row<T, TO>(this List<List<T>> matrix, int x, Func<T, TO> fn) => matrix[x].Map(fn);

    public static List<TO> Row<T, TO>(this List<List<T>> matrix, int x, Func<int, T, TO> fn) => matrix[x].Map(fn);
  }
}