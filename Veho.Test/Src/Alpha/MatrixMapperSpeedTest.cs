using System;
using NUnit.Framework;
using Spare;
using Veho.Matrix;
using Veho.Test.PanBase;
using Veho.Test.Utils;

namespace Veho.Test.Alpha {
  public static class MatrixMapperFunctions {
    public static TO[,] Map2<T, TO>(this T[,] matrix, Func<T, TO> func) {
      var (h, w) = matrix.Size();
      var target = new TO[h, w];
      for (var j = 0; j < w; j++)
        for (var i = 0; i < h; i++)
          target[i, j] = func(matrix[i, j]);
      return target;
    }
  }

  [TestFixture]
  public class MatrixMapperSpeedTest {
    [Test]
    [Ignore("Ignore a strategy")]
    public void Test() {
      var matrix = (3, 5).Init((_, y) => y);
      var eta = ETA<int[,]>.Build((int) 1E+6);

      var a = eta.Run("Map", () => matrix.Map(x => x + 1));
      a.Deco().Logger();

      var b = eta.Run("Map2", () => matrix.Map2(x => x + 1));
      b.Deco().Logger();

      eta.Log();
    }
  }
}