using System;
using System.Linq;
using NUnit.Framework;
using Veho.Matrix;
using Veho.Matrix.Columns;
using Veho.Matrix.Rows;
using Veho.Test.Utils;

namespace Veho.Test.Alpha {
  public static class MatrixReducersFunctions {
    public static T Reduce2<T>(this T[,] matrix, Func<T, T, T> sequence) {
      var (h, w) = matrix.Size();
      if (h == 0 || w == 0) return default;
      var accum = matrix.ReduceRow(0, sequence);
      for (var i = 1; i < h; i++)
        for (var j = 0; j < w; j++)
          accum = sequence(accum, matrix[i, j]);
      return accum;
    }

    public static T Reduce3<T>(this T[,] matrix, Func<T, T, T> sequence) {
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

      var a = eta.Run("LinqSum", () => matrix.OfType<int>().Aggregate((ac, x) => ac + x));

      var b = eta.Run("ReducedSum", () => matrix.Reduce((ac, x) => ac + x));

      var c = eta.Run("ReducedSum2", () => matrix.Reduce2((ac, x) => ac + x));

      var d = eta.Run("ReducedSum3", () => matrix.Reduce3((ac, x) => ac + x));

      eta.Log();
    }
  }
}