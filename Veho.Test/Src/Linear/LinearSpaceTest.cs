using NUnit.Framework;
using Spare;

namespace Veho.Test.Linear {
  [TestFixture]
  public class LinearSpaceTest {
    [Test]
    public void TestAlpha() {
      var a = new double[,] {
                              { 1, 2, 3 },
                              { 4, 5, 6 },
                              { 7, 8, 9 }
                            };
      var b = new double[,] {
                              { 1, 0, 0 },
                              { 0, 1, 0 },
                              { 0, 0, 1 }
                            };
      var c = new double[,] {
                              { 1, double.NaN, 2 },
                              { 1, double.NaN, 2 },
                              { 1, double.NaN, 2 }
                            };
      LinearSpace<double>.op_Addition(a, b).Deco().Says("a + b");
      LinearSpace<double>.op_Division(a, b).Deco().Says("a / b");
      LinearSpace<double>.op_Multiply(a, c).Deco().Says("a * c");
      LinearSpace<double>.op_Division(a, c).Deco().Says("a / c");
    }
  }
}