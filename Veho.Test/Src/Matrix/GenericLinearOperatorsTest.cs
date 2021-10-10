using NUnit.Framework;
using Spare;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class GenericLinearOperatorsTest {
    [Test]
    public void VectorToVectorTest() {
      var a = new double[] { 1, 2, 3 };
      var b = new double[] { 10, 20, 30 };
      var z = LinearSpace<double>.op_Multiply(a, b);
      z.Deco().Says("vector-to-vector");
    }
    [Test]
    public void VectorToPointTest() {
      var a = new double[] { 1, 2, 3 };
      var b = 2D;
      var z = LinearSpace<double>.op_Multiply(a, b);
      z.Deco().Says("vector-to-point");
    }

    [Test]
    public void MatrixToMatrixTest() {
      var a = new double[,] {
                              { 1, 2, 3 },
                              { 4, 5, 6 },
                              { 7, 8, 9 }
                            };
      var b = new double[,] {
                              { 10, 0, 0 },
                              { 0, 20, 0 },
                              { 0, 0, 30 }
                            };
      var z = LinearSpace<double>.op_Multiply(a, b);
      z.Deco().Says("matrix-to-matrix");
    }
    [Test]
    public void MatrixToPointTest() {
      var a = new double[,] {
                              { 1, 2, 3 },
                              { 4, 5, 6 },
                              { 7, 8, 9 }
                            };
      var b = 2D;
      var z = LinearSpace<double>.op_Concatenate(a, b);
      z.Deco().Says("matrix-to-point");
    }
  }
}