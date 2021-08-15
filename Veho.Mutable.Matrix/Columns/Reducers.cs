using System;
using System.Collections.Generic;

namespace Veho.Mutable.Columns {
  public static class Reducers {
    public static TO FoldColumn<T, TO>(this List<List<T>> rows, int y, Func<TO, T, TO> sequence, TO accum) {
      for (var i = 0; i < rows.Count; i++) accum = sequence(accum, rows[i][y]);
      return accum;
    }

    public static TO FoldColumn<T, TO>(this List<List<T>> rows, int y, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(rows[0][y]);
      for (var i = 0; i < rows.Count; i++) accum = sequence(accum, rows[i][y]);
      return accum;
    }

    public static TO FoldColumn<T, TO>(this List<List<T>> rows, int y, Func<int, TO, T, TO> sequence, TO accum) {
      for (var i = 1; i < rows.Count; i++) accum = sequence(i, accum, rows[i][y]);
      return accum;
    }

    public static TO FoldColumn<T, TO>(this List<List<T>> rows, int y, Func<int, TO, T, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(rows[0][y]);
      for (var i = 0; i < rows.Count; i++) accum = sequence(i, accum, rows[i][y]);
      return accum;
    }

    public static T ReduceColumn<T>(this List<List<T>> rows, int y, Func<T, T, T> sequence) {
      var accum = rows[0][y];
      for (var i = 1; i < rows.Count; i++) accum = sequence(accum, rows[i][y]);
      return accum;
    }

    public static TO ReduceColumn<T, TO>(this List<List<T>> rows, int y, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(rows[0][y]);
      for (var i = 1; i < rows.Count; i++) accum = sequence(accum, indicator(rows[i][y]));
      return accum;
    }

    public static T ReduceColumn<T>(this List<List<T>> rows, int y, Func<int, T, T, T> sequence) {
      var accum = rows[0][y];
      for (var i = 1; i < rows.Count; i++) accum = sequence(i, accum, rows[i][y]);
      return accum;
    }

    public static TO ReduceColumn<T, TO>(this List<List<T>> rows, int y, Func<int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      var accum = indicator(rows[0][y]);
      for (var i = 1; i < rows.Count; i++) accum = sequence(i, accum, indicator(rows[i][y]));
      return accum;
    }
  }
}