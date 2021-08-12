using System;
using System.Linq;
using NUnit.Framework;
using Veho.Columns;
using Veho.Matrix;
using Veho.Rows;
using Veho.Test.Utils;

namespace Veho.Test.Alpha {
  public static partial class MatrixReducersFunctions {
    public static void Rest<T>(this (int, int) size, T[,] matrix, (int, int) coordinate, Action<T> action) {
      var (h, w) = size;
      var (x, y) = coordinate;
      for (var j = y; j < w; j++) { action(matrix[x, j]); }
      for (++x; x < h; x++)
        for (var j = 0; j < w; j++) { action(matrix[x, j]); }
    }
    // public static T Reduce<T>(this T[,] matrix, Func<T, T, T> sequence) {
    //   var (h, w) = matrix.Size();
    //   if (h == 0 || w == 0) return default;
    //   var accum = matrix[0, 0];
    //   for (var j = 1; j < w; j++) accum = sequence(accum, matrix[0, j]);
    //   for (var i = 1; i < h; i++)
    //     for (var j = 0; j < w; j++)
    //       accum = sequence(accum, matrix[i, j]);
    //   return accum;
    // }
    public static T Reduce1<T>(this T[,] matrix, Func<T, T, T> sequence) {
      var size = matrix.Size();
      if (size.Item1 == 0 || size.Item2 == 0) return default;
      var accum = matrix[0, 0];
      void Lambda(int i, int j) => accum = sequence(accum, matrix[i, j]);
      size.RestOf((0, 0), Lambda);
      return accum;
    }
    public static T Reduce2<T>(this T[,] matrix, Func<T, T, T> sequence) {
      var size = matrix.Size();
      if (size.Item1 == 0 || size.Item2 == 0) return default;
      var accum = matrix[0, 0];
      size.Rest(matrix, (0, 0), x => accum = sequence(accum, x));
      return accum;
    }
    public static T Reduce3<T>(this T[,] matrix, Func<T, T, T> sequence) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = matrix.ReduceRow(0, sequence);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(accum, matrix[i, j]);
      return accum;
    }

    public static T Reduce4<T>(this T[,] matrix, Func<T, T, T> sequence) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = matrix.ReduceColumn(0, sequence);
      for (var j = 1; j < w; j++)
        for (var i = 0; i < h; i++)
          accum = sequence(accum, matrix[i, j]);
      return accum;
    }
  }

  [TestFixture]
  public class MatrixReducerSpeedTest {
    [Test]
    public void Test() {
      var matrix = (3, 5).Init((_, y) => y);
      var eta = FlyBack<int>.Build((int) 1E+6);

      var linq = eta.Run("LinqSum", () => matrix.OfType<int>().Aggregate((ac, x) => ac + x));

      var a = eta.Run("ReducedSum1", () => matrix.Reduce1((ac, x) => ac + x));

      var b = eta.Run("ReducedSum2", () => matrix.Reduce2((ac, x) => ac + x));

      var c = eta.Run("ReducedSum3", () => matrix.Reduce3((ac, x) => ac + x));

      var d = eta.Run("ReducedSum4", () => matrix.Reduce4((ac, x) => ac + x));

      var bench = eta.Run("ReducedSum", () => matrix.Reduce((ac, x) => ac + x));

      eta.Log();
    }
  }
}