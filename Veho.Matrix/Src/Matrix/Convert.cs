using System;
using System.Collections.Generic;

namespace Veho.Matrix {
  public static class Convert {
    public static List<List<T>> ToMutableMatrix<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var rows = new List<List<T>>(h);
      for (var i = 0; i < h; i++) {
        var list = new List<T>(w);
        for (var j = 0; j < w; j++) list.Add(matrix[i, j]);
        rows.Add(list);
      }
      return rows;
    }
    public static List<List<TO>> ToMutableMatrix<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (h, w) = matrix.Size();
      var rows = new List<List<TO>>(h);
      for (var i = 0; i < h; i++) {
        var list = new List<TO>(w);
        for (var j = 0; j < w; j++) list.Add(func(matrix[i, j]));
        rows.Add(list);
      }
      return rows;
    }
    public static List<List<TO>> ToMutableMatrix<T, TO>(this T[,] matrix, Func<int, int, T, TO> func) {
      var (h, w) = matrix.Size();
      var rows = new List<List<TO>>(h);
      for (var i = 0; i < h; i++) {
        var list = new List<TO>(w);
        for (var j = 0; j < w; j++) list.Add(func(i, j, matrix[i, j]));
        rows.Add(list);
      }
      return rows;
    }
  }
}