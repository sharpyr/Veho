using System;
using NUnit.Framework;
using Spare;
using Veho;
using Veho.Matrix;
using Veho.PanBase.Matrix;
using Veho.Test.PanBase;

namespace Veho.Test.OneBase {
  [TestFixture]
  public class RebasePrimTest {
    public static (string, string[,])[] Candidates = {
                                                       ("alpha", OneBased.Init((4, 4), (i, j) => (i == j ? i : 0).ToString())),
                                                       ("beta", OneBased.Init((3, 4), (i, j) => $"{(char)(i + 64)}{j}")),
                                                       ("gamma", OneBased.Init((4, 3), (i, j) => (i * j).ToString()))
                                                     };
    [Test]
    public void TestAlpha() {
      foreach (var (key, matrix) in Candidates) {
        var (xlo, xhi, ylo, yhi) = matrix.Bounds();
        matrix.Rebase().Deco().Says($"{key} : [x] ({xlo} -> {xhi}) [y] ({ylo} -> {yhi})");
      }
    }
    [Test]
    public void TestBeta() {
      foreach (var (key, matrix) in Candidates) {
        var (xlo, xhi, ylo, yhi) = matrix.Bounds();
        matrix.Rebase().Deco().Says($"{key} : [x] ({xlo} -> {xhi}) [y] ({ylo} -> {yhi})");
      }
    }
    [Test]
    public void TestGamma() {
      foreach (var (key, matrix) in Candidates) {
        var (xlo, xhi, ylo, yhi) = matrix.Bounds();
        matrix.Rebase().Deco().Says($"{key} : [x] ({xlo} -> {xhi}) [y] ({ylo} -> {yhi})");
      }
    }
  }
}