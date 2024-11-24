using System;
using NUnit.Framework;
using Spare;
using Veho.Matrix;
using Veho.Rows;
using Veho.Test.Utils;

namespace Veho.Test.Alpha {
  public static partial class Functions {
    public static T[] Row<T>(this T[,] matrix, int x) {
      var wd = matrix.Width();
      var row = new T[wd];
      for (var j = 0; j < wd; j++) row[j] = matrix[x, j];
      return row;
    }

    public static T[] RowBeta<T>(this T[,] matrix, int x) {
      var row = Array.Empty<T>();
      // Array.Copy(matrix, x * w, row, 0, w);
      // for (var j = 0; j < w; j++) row[j] = matrix[x, j];
      // return row;
      foreach (var el in matrix.RowInto(x)) { }
      return row;
    }

    public static T[] RowGamma<T>(this T[,] matrix, int x) {
      var wd = matrix.Width();
      var row = new T[wd];
      // Array.Copy(matrix, x * w, row, 0, w);
      // for (var j = 0; j < w; j++) row[j] = matrix[x, j];
      // return row;
      var i = 0;
      foreach (var el in matrix.RowInto(x)) row[i++] = el;
      return row;
    }
  }

  [TestFixture]
  public class MatrixGetRowSpeedTest {
    [Test]
    public void Test() {
      var matrix = (3, 5).Init((x, y) => x + y);
      var eta = ETA<int[]>.Build((int)1E+6);
      eta.Run("Plain", () => matrix.Row(0));
      eta.Run("Array.Beta", () => matrix.RowBeta(0));
      eta.Run("Array.Gamma", () => matrix.RowGamma(0));
      eta.Log(x => x.Deco());
    }
  }
}