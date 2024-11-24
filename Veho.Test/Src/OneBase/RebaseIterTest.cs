using System;
using System.Linq;
using NUnit.Framework;
using Spare;
using Veho.Matrix;
using Veho.OneBase.Columns;
using Veho.OneBase.Matrix;
using Veho.PanBase.Rows;

namespace Veho.Test.OneBase {
  [TestFixture]
  public class RebaseIterTest {
    public static (string, int[,])[] Candidates = {
                                                    ("alpha", OneBased.Init((3, 5), (i, j) => (i % 2 == 0 ? i : -i) * (j % 2 == 1 ? j : -j))),
                                                    ("beta", OneBased.Init((4, 4), (i, j) => 1 << i & 1 << j)),
                                                    ("gamma", OneBased.Init((4, 4), (i, j) => 1 << i | 1 << j))
                                                  };
    [Test]
    public void TestAlpha() {
      foreach (var (key, matrix) in Candidates) {
        var (xlo, xhi, ylo, yhi) = matrix.Bounds();
        matrix.Rebase().Deco().Says($"{key} : [x] ({xlo} -> {xhi}) [y] ({ylo} -> {yhi})");
      }
    }
    [Test]
    public void TestPoints() {
      foreach (var (key, matrix) in Candidates) {
        var (xlo, xhi, ylo, yhi) = matrix.Bounds();
        var result = matrix.OffsetInto().Max();
        $"{result}".Says($"{key} : [x] ({xlo} -> {xhi}) [y] ({ylo} -> {yhi})");
      }
    }
    [Test]
    public void TestColumns() {
      foreach (var (key, matrix) in Candidates) {
        var (xlo, xhi, ylo, yhi) = matrix.Bounds();
        matrix.Rebase().Deco().Says($"{key} : [x] ({xlo} -> {xhi}) [y] ({ylo} -> {yhi})");
        foreach (var column in matrix.OffsetColumns()) {
          var (lo, hi) = (column.GetLowerBound(0), column.GetUpperBound(0));
          var result = column.Max();
          $"{result}".Says($"column [x] ({lo} -> {hi}");
        }
      }
    }
    [Test]
    public void TestRows() {
      foreach (var (key, matrix) in Candidates) {
        var (xlo, xhi, ylo, yhi) = matrix.Bounds();
        matrix.Rebase().Deco().Says($"{key} : [x] ({xlo} -> {xhi}) [y] ({ylo} -> {yhi})");
        foreach (var row in matrix.OffsetRows()) {
          var (lo, hi) = (row.GetLowerBound(0), row.GetUpperBound(0));
          var result = row.Max();
          $"{result}".Says($"row [x] ({lo} -> {hi}");
        }
      }
    }
  }
}