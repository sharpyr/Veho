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
  public static partial class RebaseMethods {
    // public static T[] RebaseFlatArch<T>(this T[,] matrix) {
    //   var count = matrix.Length;
    //   var vector = new T[count];
    //   Buffer.BlockCopy(matrix, matrix.XLo(), vector, 0, count * Marshal.SizeOf(default(T)));
    //   vector.Deco().Logger();
    //   return vector;
    // }

    public static T[] RebaseRowPrim<T>(this T[,] matrix, int x, int width = -1) {
      if (width < 0) width = matrix.Width();
      var row = new T[width];
      x++;
      for (var j = 0; j < width;) row[j++] = matrix[x, j];
      return row;
    }

    public static T[] RebaseColumnPrim<T>(this T[,] matrix, int y, int height = -1) {
      if (height < 0) height = matrix.Height();
      var column = new T[height];
      y++;
      for (var i = 0; i < height;) column[i++] = matrix[i, y];
      return column;
    }

    public static T[] RebaseRowGran<T>(this T[,] matrix, int x, int width = -1, int xLo = -1, int yLo = -1) {
      if (xLo < 0) xLo = matrix.XLo();
      if (yLo < 0) yLo = matrix.YLo();
      if (width < 0) width = matrix.Width();
      var row = new T[width];
      x += xLo;
      for (var i = 0; i < width; i++, yLo++) row[i] = matrix[x, yLo];
      return row;
    }

    public static T[] RebaseColumnGran<T>(this T[,] matrix, int y, int height = -1, int xLo = -1, int yLo = -1) {
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
  public partial class RebaseStrategies {
    [Test]
    public void RebaseRowTest() {
      var methods = Seq.From<(string, Func<int[,], int[]>)>(
        ("arch", matrix => matrix.Rebase().Row(1)),
        ("prim", matrix => matrix.RebaseRowPrim(1)),
        ("gran", matrix => matrix.RebaseRowGran(1))
      );
      var parameters = Seq.From(
        ("alpha", OneBased.Init((3,4),(i, j) => i)),
        ("beta", OneBased.Init((3,4),(i, j) => j)),
        ("gamma", OneBased.Init((3,4),(i, j) => i * j))
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
    public void RebaseColumnTest() {
      var methods = Seq.From<(string, Func<int[,], int[]>)>(
        ("arch", matrix => matrix.Rebase().Column(2)),
        ("prim", matrix => matrix.RebaseColumnPrim(2)),
        ("gran", matrix => matrix.RebaseColumnGran(2))
      );
      var parameters = Seq.From(
        ("alpha", OneBased.Init((3,4),(i, j) => i)),
        ("beta", OneBased.Init((3,4),(i, j) => j)),
        ("gamma", OneBased.Init((3,4),(i, j) => i * j))
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