using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Veho.Matrix {
  public static class Convert {
    private static T[] ToVectorArch<T>(this T[,] matrix) {
      var count = matrix.Length;
      var vector = new T[count];
      var (h, w) = matrix.Size();
      var k = 0;
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          vector[k++] = matrix[i, j];
      return vector;
    }
    private static T[] ToVectorPrim<T>(this T[,] matrix) {
      var count = matrix.Length;
      var vector = new T[count];
      Buffer.BlockCopy(matrix, 0, vector, 0, count * Marshal.SizeOf(default(T)));
      return vector;
    }

    public static T[] ToVector<T>(this T[,] matrix) => typeof(T).IsPrimitive ? matrix.ToVectorPrim() : matrix.ToVectorArch();
    
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