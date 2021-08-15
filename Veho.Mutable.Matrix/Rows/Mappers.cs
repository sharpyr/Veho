using System;
using System.Collections.Generic;

namespace Veho.Mutable.Rows {
  public static class Mappers {
    public static List<TO> MapRows<T, TO>(this List<List<T>> matrix, Func<List<T>, TO> rowTo) {
      var h = matrix.Count;
      var vertica = new List<TO>(h);
      for (var i = 0; i < h; i++) vertica[i] = rowTo(matrix[i]);
      return vertica;
    }

    public static List<TO> MapRows<T, TO>(this List<List<T>> matrix, Func<int, List<T>, TO> rowTo) {
      var h = matrix.Count;
      var vertica = new List<TO>(h);
      for (var i = 0; i < h; i++) vertica[i] = rowTo(i, matrix[i]);
      return vertica;
    }
  }
}