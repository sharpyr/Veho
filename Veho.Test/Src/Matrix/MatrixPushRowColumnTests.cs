using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;
using Veho.Matrix.Columns;
using Veho.Matrix.Rows;
using Veho.Vector;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class MatrixPushRowColumnTests {
    [Test]
    public void MatrixPushRowTest() {
      var mat = new int[0, 3];
      mat.PushRow(Vec.From(0, 1, 2)).Deco().Logger();
    }
    [Test]
    public void MatrixPushColumnTest() {
      var mat = new int[3, 0];
      mat.PushColumn(Vec.From(0, 1, 2)).Deco().Logger();
    }
  }
}