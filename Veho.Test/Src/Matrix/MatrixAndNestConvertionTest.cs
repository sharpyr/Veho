using NUnit.Framework;
using Spare;
using Spare.Logger;
using Veho.NestedVector;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class MatrixAndNestConvertionTest {
    [Test]
    public void Test() {
      var mx = Vec.Init(3, i => Vec.Init(4, j => i + j));
      var target = mx.NestToMatrix();
      target.Deco().Logger();
    }
  }
}