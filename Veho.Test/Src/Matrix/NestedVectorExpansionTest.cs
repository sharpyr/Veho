using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;
using Veho.NestedVector;
using Veho.Vector;

namespace Veho.Test.Matrix {
  public static class NestedVectorExt {
    public static T[][] PushRow<T>(this T[][] matrix, T[] row) => matrix.Push(row);

    public static T[][] PushColumn<T>(this T[][] matrix, T[] column) =>
      matrix.Zip(column, (row, x) => row.Push(x));

    public static int PushRow<T>(ref T[][] matrix, T[] row) => Vec.Push(ref matrix, row);

    public static int PushColumn<T>(ref T[][] matrix, T[] column) =>
      Vec.MutaZip(ref matrix, column, (row, x) => row.Push(x)).Width();
  }

  [TestFixture]
  public class NestedVectorExpansionTest {
    [Test]
    public void PushRowTest() {
      var mx = Vec.Init(3, i => Vec.Init(4, j => i + j));
      mx
        .PushRow(Vec.Init(4, j => 0))
        .NestToMatrix()
        .Deco()
        .Logger();
    }
    [Test]
    public void PushColumnTest() {
      var mx = Vec.Init(3, i => Vec.Init(4, j => i + j));
      mx
        .PushColumn(Vec.Init(3, i => 0))
        .NestToMatrix()
        .Deco()
        .Logger();
    }
    [Test]
    public void RefPushRowTest() {
      var mx = Vec.Init(3, i => Vec.Init(4, j => i + j));
      NestedVectorExt.PushRow(ref mx, Vec.Init(4, j => 0));
      mx.NestToMatrix()
        .Deco()
        .Logger();
    }
    [Test]
    public void RefPushColumnTest() {
      var mx = Vec.Init(3, i => Vec.Init(4, j => i + j));
      NestedVectorExt.PushColumn(ref mx, Vec.Init(3, i => 0));
      mx.NestToMatrix()
        .Deco()
        .Logger();
    }
  }
}