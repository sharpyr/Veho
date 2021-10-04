using System;
using NUnit.Framework;
using Spare;
using Veho.OneBase.Columns;
using Veho.OneBase.Matrix;
using Veho.OneBase.Rows;

namespace Veho.Test.OneBase {
  [TestFixture]
  public class ZeroizeMatrixTest {
    [Test]
    public void ZeroizeMatrixTestAlpha() {
      var parameters = Seq.From(
        ("alpha", (3, 4).M1B((i, j) => i)),
        ("beta", (3, 4).M1B((i, j) => j)),
        ("gamma", (3, 4).M1B((i, j) => i * j))
      );
      foreach (var (key, matrix) in parameters) {
        Console.WriteLine($">> [{key}]");
        var mx1 = matrix.Zeroize();
        Console.WriteLine($">> [mx1] {mx1.Deco()}");
        var mx2 = matrix.Zeroize(x => x * 10);
        Console.WriteLine($">> [mx2] {mx2.Deco()}");
        var mx3 = matrix.Zeroize((i, j, x) => (i == j) ? x : 0);
        Console.WriteLine($">> [mx3] {mx3.Deco()}");

        Console.WriteLine("");
      }
    }
    [Test]
    public void ZeroizeColumnTest() {
      var parameters = Seq.From(
        ("alpha", (3, 4).M1B((i, j) => i)),
        ("beta", (3, 4).M1B((i, j) => j)),
        ("gamma", (3, 4).M1B((i, j) => i * j))
      );
      foreach (var (key, matrix) in parameters) {
        Console.WriteLine($">> [{key}] {matrix.Zeroize().Deco()}");
        var mx1 = matrix.ZeroizeColumn(1);
        Console.WriteLine($">> [mx1] {mx1.Deco()}");
        var mx2 = matrix.ZeroizeColumn(1, x => x * 10);
        Console.WriteLine($">> [mx2] {mx2.Deco()}");
        var mx3 = matrix.ZeroizeColumn(1, (i, x) => x * 10 + i);
        Console.WriteLine($">> [mx3] {mx3.Deco()}");

        Console.WriteLine("");
      }
    }

    [Test]
    public void ZeroizeRowTest() {
      var parameters = Seq.From(
        ("alpha", (3, 4).M1B((i, j) => i)),
        ("beta", (3, 4).M1B((i, j) => j)),
        ("gamma", (3, 4).M1B((i, j) => i * j))
      );
      foreach (var (key, matrix) in parameters) {
        Console.WriteLine($">> [{key}] {matrix.Zeroize().Deco()}");
        var mx1 = matrix.ZeroizeRow(1);
        Console.WriteLine($">> [mx1] {mx1.Deco()}");
        var mx2 = matrix.ZeroizeRow(1, x => x * 10);
        Console.WriteLine($">> [mx2] {mx2.Deco()}");
        var mx3 = matrix.ZeroizeRow(1, (j, x) => x * 10 + j);
        Console.WriteLine($">> [mx3] {mx3.Deco()}");

        Console.WriteLine("");
      }
    }
  }
}