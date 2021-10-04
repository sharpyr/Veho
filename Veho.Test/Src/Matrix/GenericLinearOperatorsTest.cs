using NUnit.Framework;
using Spare;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class GenericLinearOperatorsTest {
    [Test]
    public void Test() {
      var a = new[] { 1, 2, 3 };
      var b = 2;
      var z = LinearSpace<int>.Multiply(a, b);
      z.Deco().Logger();
    }
  }
}