using System;
using NUnit.Framework;
using Veho.Mutable.Matrix;

namespace Veho.Test.Mutable.Matrix {
  [TestFixture]
  public class MutableMatrixTests {
    [Test]
    public void SomeTest() {
      var matrix = Li.From(
        Li.From(1, 1, 2, 3, 5, 8, 13, 21),
        Li.From(1, 1, 2, 3, 5, 8, 13, 21),
        Li.From(1, 1, 2, 3, 5, 8, 13, 21)
      );
      matrix = matrix.Map(x => x * 2);
      var (height, width) = matrix.Size();
      for (var i = 0; i < height; i++) {
        for (var j = 0; j < width; j++) {
          var value = matrix[i][j];
          Console.Write($"{value}, ");
        }
        Console.WriteLine();
      }
      Console.WriteLine("passed");
    }
  }
}