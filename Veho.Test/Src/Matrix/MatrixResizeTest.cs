using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;
using Veho.Matrix;
using Veho.Rows;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class MatrixResizeTest {
    [Test]
    public void ExpandTest() {
      var mx2X3 = (2, 3).Init((i, j) => i + j);
      mx2X3.Deco().Logger();
      var mx2X5 = mx2X3.Resize(2, 5);
      mx2X5.Deco().Logger();
      var mx4X3 = mx2X3.Resize(4, 3);
      mx4X3.Deco().Logger();
      var mx4X5 = mx2X3.Resize(4, 5);
      mx4X5.Deco().Logger();
    }
    [Test]
    public void ShrinkTest() {
      var mx4X5 = (4, 5).Init((i, j) => i + j);
      mx4X5.Deco().Logger();
      var mx2X5 = mx4X5.Resize(2, 5);
      mx2X5.Deco().Logger();
      var mx4X3 = mx4X5.Resize(4, 3);
      mx4X3.Deco().Logger();
      var mx2X3 = mx4X5.Resize(2, 3);
      mx2X3.Deco().Logger();
    }
    [Test]
    public void ResizeRowTest() {
      var mx2X3 = (2, 3).Init((i, j) => i + j);
      mx2X3.Deco().Logger();
      var mx4X3 = mx2X3.ExpandRow(2);
      mx4X3.Deco().Logger();
      var mx1X3 = mx2X3.ExpandRow(-1);
      mx1X3.Deco().Logger();
      var mx0X3 = mx2X3.ExpandRow(-2);
      mx0X3.Deco().Logger();
    }
  }
}