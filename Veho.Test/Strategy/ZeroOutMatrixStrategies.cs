using System;
using Analys;
using NUnit.Framework;
using Palett;
using Spare;
using Valjoux;
using Veho.Matrix;
using static System.Convert;


namespace Veho.Test.Strategy {
  public static partial class ZeroOutMethods {
    public static T[,] ZeroOutArch<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      Array.Copy(matrix, matrix.XLo(), target, 0, matrix.Length);
      return target;
    }

    public static T[,] ZeroOutPrim<T>(this T[,] matrix) {
      var ((xlo, h), (ylo, w)) = (matrix.XLeap(), matrix.YLeap());
      var target = new T[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = matrix[xlo + i, ylo + j];
      return target;
    }

    public static T[,] ZeroOutEpic<T>(this T[,] matrix) {
      var ((xlo, h), (ylo, w)) = (matrix.XLeap(), matrix.YLeap());
      var target = new T[h, w];
      for (int oI = 0, tI = xlo; oI < h; oI++, tI++) {
        for (int oJ = 0, tJ = ylo; oJ < w; oJ++, tJ++)
          target[oI, oJ] = matrix[tI, tJ];
      }
      return target;
    }

    public static TO[,] ZeroOutVari<T, TO>(this T[,] matrix) {
      TO Cast(T v) => (TO)ChangeType(v, typeof(TO));
      var ((xlo, h), (ylo, w)) = (matrix.XLeap(), matrix.YLeap());
      var target = new TO[h, w];
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[i, j] = Cast(matrix[xlo + i, ylo + j]);
      return target;
    }
  }

  [TestFixture]
  public partial class ZeroOutStrategies {
    [Test]
    public void MatrixZeroOutTest() {
      var (elapsed, result) = Strategies.Run(
        (int)1E+5,
        Seq.From<(string, Func<int[,], int[,]>)>(
          ("arch", ZeroOutMethods.ZeroOutArch),
          ("prim", ZeroOutMethods.ZeroOutPrim),
          ("epic", ZeroOutMethods.ZeroOutEpic),
          ("vari", x => ZeroOutMethods.ZeroOutVari<int, int>(x))
        ),
        Seq.From(
          ("alpha", (3, 4).M1B((i, j) => i)),
          ("beta", (3, 4).M1B((i, j) => j)),
          ("gamma", (3, 4).M1B((i, j) => i * j))
        )
      );
      elapsed.Deco(presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");
      var results = Seq.From(
        ("alpha", "arch"),
        ("alpha", "prim"),
        ("alpha", "epic"),
        ("alpha", "vari"),
        ("beta", "arch"),
        ("beta", "prim"),
        ("beta", "epic"),
        ("beta", "vari"),
        ("gamma", "arch"),
        ("gamma", "prim"),
        ("gamma", "epic"),
        ("gamma", "vari")
      );
      foreach (var (side, head) in results) {
        result[side, head].Deco().Says(side + "-" + head);
      }
    }
  }
}