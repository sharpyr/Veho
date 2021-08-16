using System;
using NUnit.Framework;
using Spare;
using Veho.Mutable.Matrix;

namespace Veho.Test.Mutable.Matrix {
  [TestFixture]
  public class MutableMatrixToMatrixTests {
    [Test]
    public void ToMatrixTest() {
      var matrix = Candidates.FibonacciMatrix.ToMatrix();
      Console.WriteLine(matrix);
      matrix.Deco().Logger();
    }
  }
}