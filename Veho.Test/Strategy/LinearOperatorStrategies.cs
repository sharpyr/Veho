using System;
using Analys;
using Generic.Math;
using NUnit.Framework;
using Palett;
using Spare;
using Valjoux;
using Veho.Formula;
using Veho.Matrix;
using static Veho.Test.Strategy.LinearStrategies;

namespace Veho.Test.Strategy {
  public static class ZipperSpaceArch {
    private static T[,] Op<T>(T[,] matrix, T[,] another, Func<T, T, T> @operator) {
      return @operator.Zipper(matrix, another);
    }
    public static T[,] op_Addition<T>(T[,] matrix, T[,] another) => Op(matrix, another, GenericMath.Add);
  }

  public static class ZipperSpaceEpic {
    private static T[,] Op<T>(T[,] matrix, T[,] another, Func<T, T, T> @operator) {
      return @operator.Zipper(matrix, another);
    }
    public static T[,] op_Addition<T>(T[,] matrix, T[,] another) => Op(matrix, another, Algebra<T>.op_Addition);
  }

  public static class ZipperSpaceBrev {
    private static T[,] Op<T>(T[,] matrix, T[,] another, Func<T, T, T> @operator) {
      return @operator.Zipper(matrix, another);
    }
    public static T[,] op_Addition<T>(T[,] matrix, T[,] another) => Op(matrix, another, AlgebraBrev<T>.op_Addition);
  }

  [TestFixture]
  public class LinearOperatorStrategies {
    [Test]
    public void ZipperOperatorStrategies() {
      var methods = Seq.From<(string, Func<(double[,] x, double[,] y), double[,]>)>(
        ("arch", pair => ZipperSpaceArch.op_Addition(pair.x, pair.y)),
        ("epic", pair => ZipperSpaceEpic.op_Addition(pair.x, pair.y)),
        ("brev", pair => ZipperSpaceBrev.op_Addition(pair.x, pair.y))
      );
      var parameters = Seq.From<(string, (double[,] x, double[,] y))>(
        ("alpha", ((3, 4).Init<double>((i, j) => i * 3 + j), (3, 4).Init<double>((i, j) => i == j ? (i + 1) : 0))),
        ("beta", ((8, 8).Init<double>((i, j) => i * j), (8, 8).Init<double>((i, j) => 100))),
        ("gamma", ((16, 16).Init<double>((i, j) => i), (16, 16).Init<double>((i, j) => j)))
      );
      var (elapsed, result) = Strategies.Run(
        (int)1E+5,
        methods,
        parameters
      );

      elapsed.Deco(presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");

      foreach (var (side, matrix) in parameters) {
        // matrix.Deco().Says(side);
        foreach (var (head, _) in methods) {
          result[side, head].Deco().Says(side + "-" + head);
        }
        Console.WriteLine("");
      }
    }
  }
}