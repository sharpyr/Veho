using NUnit.Framework;
using Spare;
using Veho.Matrix;
using Veho.Mutable.Matrix;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class ConvertTests {
    [Test]
    public void ToMutableMatrixTest() {
      var matrix = Mat.Init(5, 5, (i, j) => i * j);
      matrix.ToMutableMatrix().ToMatrix().Deco().Logger();
      
    }
  }
}