using System;
using NUnit.Framework;
using Spare;
using Veho.OneBase.Columns;
using Veho.OneBase.Matrix;
using Veho.OneBase.Rows;

namespace Veho.Test.OneBase {
  [TestFixture]
  public class RebaseMatrixTest {
    [Test]
    public void RebaseMatrixTestAlpha() {
      var candidates = Vec.From(
        ("alpha", OneBased.Init((3, 4), (i, j) => i)),
        ("beta", OneBased.Init((3, 4), (i, j) => j)),
        ("gamma", OneBased.Init((3, 4), (i, j) => i * j))
      );

      foreach (var (key, matrix) in candidates) {
        Console.WriteLine($">> [{key}]");
        var mx1 = matrix.Rebase();
        Console.WriteLine($">> [mx1] {mx1.Deco()}");
        var mx2 = matrix.Rebase(x => x * 10);
        Console.WriteLine($">> [mx2] {mx2.Deco()}");
        // var mx3 = matrix.Rebase((i, j, x) => (i == j) ? x : 0);
        // Console.WriteLine($">> [mx3] {mx3.Deco()}");

        Console.WriteLine("");
      }
    }
    [Test]
    public void RebaseColumnTest() {
      var parameters = Seq.From(
        ("alpha", OneBased.Init((3, 4), (i, j) => i)),
        ("beta", OneBased.Init((3, 4), (i, j) => j)),
        ("gamma", OneBased.Init((3, 4), (i, j) => i * j))
      );
      foreach (var (key, matrix) in parameters) {
        Console.WriteLine($">> [{key}] {matrix.Rebase().Deco()}");
        var mx1 = matrix.RebaseColumn();
        Console.WriteLine($">> [mx1] {mx1.Deco()}");
        var mx2 = matrix.RebaseColumn(x => x * 10, 1);
        Console.WriteLine($">> [mx2] {mx2.Deco()}");
        // var mx3 = matrix.RebaseColumn(1, (i, x) => x * 10 + i);
        // Console.WriteLine($">> [mx3] {mx3.Deco()}");

        Console.WriteLine("");
      }
    }

    [Test]
    public void RebaseRowTest() {
      var parameters = Seq.From(
        ("alpha", OneBased.Init((3, 4), (i, j) => i)),
        ("beta", OneBased.Init((3, 4), (i, j) => j)),
        ("gamma", OneBased.Init((3, 4), (i, j) => i * j))
      );
      foreach (var (key, matrix) in parameters) {
        Console.WriteLine($">> [{key}] {matrix.Rebase().Deco()}");
        var mx1 = matrix.RebaseRow();
        Console.WriteLine($">> [mx1] {mx1.Deco()}");
        var mx2 = matrix.RebaseRow(x => x * 10);
        Console.WriteLine($">> [mx2] {mx2.Deco()}");
        // var mx3 = matrix.RebaseRow(1, (j, x) => x * 10 + j);
        // Console.WriteLine($">> [mx3] {mx3.Deco()}");

        Console.WriteLine("");
      }
    }
  }
}