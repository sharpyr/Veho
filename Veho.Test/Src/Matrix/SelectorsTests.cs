using System.Linq;
using NUnit.Framework;
using Spare;
using Veho.Columns;
using Veho.Matrix;
using Veho.Rows;

namespace Veho.Test.Matrix {
  [TestFixture]
  public class SelectorsTests {
    public static string[,] Matrix = {
      { " ", " ", " ", " ", " ", " ", " ", "+", " ", " " },
      { " ", " ", "+", " ", "+", " ", " ", " ", " ", " " },
      { " ", "+", " ", " ", "+", " ", " ", " ", " ", " " },
      { " ", " ", " ", " ", " ", " ", "+", " ", "+", " " },
      { " ", "+", "+", " ", " ", " ", " ", " ", " ", " " },
      { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
      { " ", " ", " ", "+", " ", " ", " ", " ", "+", " " },
      { "+", " ", " ", " ", " ", " ", " ", " ", " ", " " },
      { " ", " ", " ", "+", " ", " ", "+", " ", " ", " " },
      { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " }
    };
    [Test]
    public void SelectByColumnIndicesTest() {
      Matrix.Deco().Says("rows");
      Matrix.SelectColumns(Seq.From(1, 2, 4)).Deco().Says("selected");
      Matrix.SelectRows(Seq.From(1, 2, 4)).Deco().Says("selected");
      SymmetricMatrix.SelectBy(Matrix, Seq.From(1, 2, 4)).Deco().Says("symmetric selected");
      SymmetricMatrix.LowerTriangular(Matrix).Map(x => x ?? "").Deco().Says("lower triangular");
      SymmetricMatrix.UpperTriangular(Matrix).Map(x => x ?? "").Deco().Says("upper triangular");
    }
    [Test]
    public void IntersectionalBlocksTest() {
      foreach (var indices in Matrix.IntersectionalIndices("+")) {
        indices.ToList().Deco().Says("diagonal block");
        SymmetricMatrix.SelectBy(Matrix, indices.ToList()).Deco().Says("diagonal block");
      }
    }
    [Test]
    public void IntoRowsIterTest() {
      Matrix.SelectRowsIntoIter(Seq.From(2, 4, 6)).ToList().DecoMutableMatrix().Says("IntoRowsIterTest");
    }
    [Test]
    public void IntoColumnsIterTest() {
      Matrix.SelectRowsIntoIter(Seq.From(2, 4, 6)).ToList().DecoMutableMatrix().Says("IntoColumnsIterTest");
    }
  }
}