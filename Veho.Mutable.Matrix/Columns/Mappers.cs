using System;
using System.Collections.Generic;
using Veho.Mutable.Matrix;

namespace Veho.Mutable.Columns {
  public static class Mappers {
    public static List<TO> MapColumns<T, TO>(this List<List<T>> matrix, Func<List<T>, TO> colTo) {
      var w = matrix.Width();
      var horizon = new List<TO>();
      for (var j = 0; j < w; j++) horizon[j] = colTo(matrix.Column(j));
      return horizon;
    }

    public static List<TO> MapColumns<T, TO>(this List<List<T>> matrix, Func<int, List<T>, TO> colTo) {
      var w = matrix.Width();
      var horizon = new List<TO>();
      for (var j = 0; j < w; j++) horizon[j] = colTo(j, matrix.Column(j));
      return horizon;
    }
  }
}