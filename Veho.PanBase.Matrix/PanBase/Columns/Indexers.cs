using System;
using Veho.Matrix;

// var (lo, size) = matrix.YLeap();

namespace Veho.PanBase.Columns {
  public static class Indexers {
    public static T[] ZeroOutColumn<T>(this T[,] matrix, int y, int lo = -1, int size = -1) {
      if (lo < 0) lo = matrix.XLo();
      if (size < 0) size = matrix.Height();
      var column = new T[size];
      for (var i = 0; i < size; i++) column[i] = matrix[lo + i, y];
      return column;
    }   

    public static TO[] ZeroOutColumn<T, TO>(this T[,] matrix, int y, Func<T, TO> fn, int lo = -1, int size = -1) {
      if (lo < 0) lo = matrix.XLo();
      if (size < 0) size = matrix.Height();
      var column = new TO[size];
      for (var i = 0; i < size; i++) column[i] = fn(matrix[lo + i, y]);
      return column;
    }

    public static TO[] ZeroOutColumn<T, TO>(this T[,] matrix, int y, Func<int, T, TO> fn, int lo = -1, int size = -1) {
      if (lo < 0) lo = matrix.XLo();
      if (size < 0) size = matrix.Height();
      var column = new TO[size];
      for (var i = 0; i < size; i++) column[i] = fn(i, matrix[lo + i, y]);
      return column;
    }
  }
}