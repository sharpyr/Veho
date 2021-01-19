using System;
using NUnit.Framework;
using Veho.Matrix;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class MatrixTest {
    [Test]
    public void SomeTest() {
      int[,] matrix = {
        {1, 1, 2, 3, 5, 8, 13, 21},
        {1, 1, 2, 3, 5, 8, 13, 21},
        {1, 1, 2, 3, 5, 8, 13, 21}
      };
      matrix = matrix.Map(x => x * 2);
      var height = matrix.GetLength(0);
      var width = matrix.GetLength(1);
      for (var i = 0; i < height; i++) {
        for (var j = 0; j < width; j++) {
          var value = matrix[i, j];
          Console.Write($"{value}, ");
        }
        Console.WriteLine();
      }
      Console.WriteLine("passed");
    }
  }
}