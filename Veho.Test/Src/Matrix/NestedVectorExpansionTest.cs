using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;
using Veho.Vector;
using Veho.Matrix;
using static Veho.Vector.Inits;

namespace Veho.Test.Matrix {
  public static class NestedVectorExt {
    public static T[][] PushRow<T>(this T[][] matrix, T[] row) => matrix.Push(row);

    public static T[][] PushColumn<T>(this T[][] matrix, T[] column) =>
      matrix.Zip(column, (row, x) => row.Push(x));
  }

  [TestFixture]
  public class NestedVectorExpansionTest {
    [Test]
    public void PushRowTest() {
      var mx = Init(3, i => Init(4, j => i + j));
      mx
        .PushRow(Init(4, j => 0))
        .NestToMatrix()
        .Deco()
        .Logger();
    }
    [Test]
    public void PushColumnTest() {
      var mx = Init(3, i => Init(4, j => i + j));
      mx
        .PushColumn(Init(3, i => 0))
        .NestToMatrix()
        .Deco()
        .Logger();
    }
  }
}