using System;
using System.Collections.Generic;

namespace Veho.Mutable.Rows {
  public static class Mappers {
    public static List<TO> MapRows<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, Func<IReadOnlyList<T>, TO> rowTo) {
      var h = matrix.Count;
      var vertica = new List<TO>(h);
      for (var i = 0; i < h; i++) vertica.Add(rowTo(matrix[i]));
      return vertica;
    }

    public static List<TO> MapRows<T, TO>(this IReadOnlyList<IReadOnlyList<T>> matrix, Func<int, IReadOnlyList<T>, TO> rowTo) {
      var h = matrix.Count;
      var vertica = new List<TO>(h);
      for (var i = 0; i < h; i++) vertica.Add(rowTo(i, matrix[i]));
      return vertica;
    }
  }
}