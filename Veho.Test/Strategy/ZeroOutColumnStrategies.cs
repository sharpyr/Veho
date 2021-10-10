using System;
using Analys;
using NUnit.Framework;
using Palett;
using Spare;
using Valjoux;
using Veho.Columns;
using Veho.Matrix;
using Veho.PanBase.Matrix;
using Veho.Rows;
using Veho.Test.PanBase;

namespace Veho.Test.Strategy {
  public static partial class ZeroizeMethods {
    // public static T[] ZeroizeFlatArch<T>(this T[,] matrix) {
    //   var count = matrix.Length;
    //   var vector = new T[count];
    //   Buffer.BlockCopy(matrix, matrix.XLo(), vector, 0, count * Marshal.SizeOf(default(T)));
    //   vector.Deco().Logger();
    //   return vector;
    // }

    public static T[] ZeroizeRowPrim<T>(this T[,] matrix, int x, int width = -1) {
      if (width < 0) width = matrix.Width();
      var row = new T[width];
      x++;
      for (var j = 0; j < width;) row[j++] = matrix[x, j];
      return row;
    }

    public static T[] ZeroizeColumnPrim<T>(this T[,] matrix, int y, int height = -1) {
      if (height < 0) height = matrix.Height();
      var column = new T[height];
      y++;
      for (var i = 0; i < height;) column[i++] = matrix[i, y];
      return column;
    }

    public static T[] ZeroizeRowGran<T>(this T[,] matrix, int x, int width = -1, int xLo = -1, int yLo = -1) {
      if (xLo < 0) xLo = matrix.XLo();
      if (yLo < 0) yLo = matrix.YLo();
      if (width < 0) width = matrix.Width();
      var row = new T[width];
      x += xLo;
      for (var i = 0; i < width; i++, yLo++) row[i] = matrix[x, yLo];
      return row;
    }

    public static T[] ZeroizeColumnGran<T>(this T[,] matrix, int y, int height = -1, int xLo = -1, int yLo = -1) {
      if (xLo < 0) xLo = matrix.XLo();
      if (yLo < 0) yLo = matrix.YLo();
      if (height < 0) height = matrix.Height();
      var column = new T[height];
      y += yLo;
      for (var i = 0; i < height; i++, xLo++) column[i] = matrix[xLo, y];
      return column;
    }
  }

  [TestFixture]
  public partial class ZeroizeStrategies {
    [Test]
    public void ZeroizeRowTest() {
      var methods = Seq.From<(string, Func<int[,], int[]>)>(
        ("arch", matrix => matrix.ZeroOut().Row(1)),
        ("prim", matrix => matrix.ZeroizeRowPrim(1)),
        ("gran", matrix => matrix.ZeroizeRowGran(1))
      );
      var parameters = Seq.From(
        ("alpha", (3, 4).M1B((i, j) => i)),
        ("beta", (3, 4).M1B((i, j) => j)),
        ("gamma", (3, 4).M1B((i, j) => i * j))
      );
      var (elapsed, result) = Strategies.Run(
        (int)1E+6,
        methods,
        parameters
      );

      elapsed.Deco(presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");

      foreach (var (side, matrix) in parameters) {
        matrix.Deco().Says(side);
        foreach (var (head, _) in methods) {
          result[side, head].Deco().Says(side + "-" + head);
        }
        Console.WriteLine("");
      }
    }

    [Test]
    public void ZeroizeColumnTest() {
      var methods = Seq.From<(string, Func<int[,], int[]>)>(
        ("arch", matrix => matrix.ZeroOut().Column(2)),
        ("prim", matrix => matrix.ZeroizeColumnPrim(2)),
        ("gran", matrix => matrix.ZeroizeColumnGran(2))
      );
      var parameters = Seq.From(
        ("alpha", (3, 4).M1B((i, j) => i)),
        ("beta", (3, 4).M1B((i, j) => j)),
        ("gamma", (3, 4).M1B((i, j) => i * j))
      );
      var (elapsed, result) = Strategies.Run(
        (int)1E+5,
        methods,
        parameters
      );

      elapsed.Deco(presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");

      foreach (var (side, matrix) in parameters) {
        matrix.Deco().Says(side);
        foreach (var (head, _) in methods) {
          result[side, head].Deco().Says(side + "-" + head);
        }
        Console.WriteLine("");
      }
    }
  }
}