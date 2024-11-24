using System;
using Veho.Matrix;
using static System.Convert;

namespace Veho.PanBase.Matrix {
  public static class Indexer {
    public static T[,] Rebase<T>(this T[,] matrix) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      var target = new T[ht, wd];
      Array.Copy(matrix, xlo, target, 0, matrix.Length);
      return target;
    }

    public static TO[,] Rebase<T, TO>(this T[,] matrix) => matrix.Rebase(v => (TO)ChangeType(v, typeof(TO)));

    public static TO[,] Rebase<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (xlo, ht, ylo, wd) = matrix.Leaps();
      var target = new TO[ht, wd];
      for (var i = 0; i < ht; i++)
        for (var j = 0; j < wd; j++)
          target[i, j] = func(matrix[xlo + i, ylo + j]);
      return target;
    }
  }
}