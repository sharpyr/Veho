using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;
using Veho.Matrix.Columns;
using Veho.Matrix.Rows;
using Veho.Vector;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class MatrixUpdatersTests {
    [Test]
    public void MatrixPushRowTest() {
      var mat = new int[2, 3];
      mat.PushRow(Vec.From(1, 2, 3)).Deco().Logger();
    }
    [Test]
    public void MatrixPushColumnTest() {
      var mat = new int[3, 2];
      mat.PushColumn(Vec.From(1, 2, 3)).Deco().Logger();
    }
    [Test]
    public void MatrixUnshiftRowTest() {
      var mat = new int[2, 3];
      mat.UnshiftRow(Vec.From(1, 2, 3)).Deco().Logger();
    }
    [Test]
    public void MatrixUnshiftColumnTest() {
      var mat = new int[3, 2];
      mat.UnshiftColumn(Vec.From(1, 2, 3)).Deco().Logger();
    }
  }
}