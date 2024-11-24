using System;
using Veho.Matrix;
using static System.Convert;

namespace Veho.OneBase.Matrix {
  public static class Indexer {
    public static T[,] Rebase<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      Array.Copy(matrix, 1, target, 0, matrix.Length);
      return target;
    }

    public static TO[,] Rebase<T, TO>(this T[,] matrix) => matrix.Rebase(v => (TO)ChangeType(v, typeof(TO)));

    public static TO[,] Rebase<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (int i = 0, x = 1; i < h; i++, x++) {
        for (var j = 0; j < w;)
          target[i, j] = func(matrix[x, ++j]);
      }
      return target;
    }
  }
}