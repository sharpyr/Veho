using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;
using Veho.Matrix;
using Inits = Veho.Vector.Inits;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class MatrixAndNestConvertionTest {
    [Test]
    public void Test() {
      var mx = Inits.Init(3, i => Inits.Init(4, j => i + j));
      var target = mx.NestToMatrix();
      target.Deco().Logger();
    }
  }
}