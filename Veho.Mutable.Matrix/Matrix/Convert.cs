using System;
using System.Collections.Generic;

namespace Veho.Mutable.Matrix {
  public static class Convert {
    public static T[,] ToMatrix<T>(this List<List<T>> rows) {
      var (height, width) = rows.Size();
      var target = new T[height, width];
      for (var i = 0; i < height; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) target[i, j] = row[j]; // Array.Copy(matrix[i], 0, target, i * w, w);
      }
      return target;
    }
    public static TO[,] ToMatrix<T, TO>(this List<List<T>> rows, Func<T, TO> func) {
      var (height, width) = rows.Size();
      var target = new TO[height, width];
      for (var i = 0; i < height; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) target[i, j] = func(row[j]); // Array.Copy(matrix[i], 0, target, i * w, w);
      }
      return target;
    }
    public static TO[,] ToMatrix<T, TO>(this List<List<T>> rows, Func<int, int, T, TO> func) {
      var (height, width) = rows.Size();
      var target = new TO[height, width];
      for (var i = 0; i < height; i++) {
        var row = rows[i];
        for (int j = 0, w = row.Count; j < w; j++) target[i, j] = func(i, j, row[j]); // Array.Copy(matrix[i], 0, target, i * w, w);
      }
      return target;
    }
  }
}