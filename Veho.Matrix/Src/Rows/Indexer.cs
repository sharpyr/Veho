using System;
using Veho.Matrix;

namespace Veho.Rows {
  public static class Indexer {
    public static T[] Row<T>(this T[,] matrix, int x, int w = 0) {
      var row = new T[w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) row[j] = matrix[x, j];
      return row;
    }

    public static TO[] Row<T, TO>(this T[,] matrix, int x, Func<T, TO> func, int w = 0) {
      var row = new TO[w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) row[j] = func(matrix[x, j]);
      return row;
    }

    public static TO[,] MatrixRow<T, TO>(this T[,] matrix, int x, Func<T, TO> func, int w = 0) {
      var vec = new TO[1, w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) vec[0, j] = func(matrix[x, j]);
      return vec;
    }


    public static TO[] Row<T, TO>(this T[,] matrix, int x, Func<int, T, TO> func, int w = 0) {
      var row = new TO[w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) row[j] = func(j, matrix[x, j]);
      return row;
    }

    public static TO[,] MatrixRow<T, TO>(this T[,] matrix, int x, Func<int, T, TO> func, int w = 0) {
      var vec = new TO[1, w == 0 ? w = matrix.Width() : w];
      for (var j = 0; j < w; j++) vec[0, j] = func(j, matrix[x, j]);
      return vec;
    }
 
  }
}