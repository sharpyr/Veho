using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;
using Veho.Matrix;
using Veho.Matrix.Columns;
using Veho.Matrix.Rows;
using Veho.Vector;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class MatrixUpdatersTests {
    [Test]
    public void MatrixPushRowTest() {
      var mat = (2, 3).Init((i, j) => i + j);
      mat.Deco().Logger();
      mat.PushRow(Vec.From(10, 20, 30)).Deco().Logger();
    }
    [Test]
    public void MatrixPushColumnTest() {
      var mat = (3, 2).Init((i, j) => i + j);
      mat.Deco().Logger();
      mat.PushColumn(Vec.From(10, 20, 30)).Deco().Logger();
    }
    [Test]
    public void MatrixUnshiftRowTest() {
      var mat = (2, 3).Init((i, j) => i + j);
      mat.Deco().Logger();
      mat.UnshiftRow(Vec.From(10, 20, 30)).Deco().Logger();
    }
    [Test]
    public void MatrixUnshiftColumnTest() {
      var mat = (3, 2).Init((i, j) => i + j);
      mat.UnshiftColumn(Vec.From(10, 20, 30)).Deco().Logger();
    }
  }
}