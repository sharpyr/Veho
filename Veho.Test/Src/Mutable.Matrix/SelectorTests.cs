using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Spare;
using Veho.Mutable.Columns;
using Veho.Mutable.Matrix;
using Veho.Mutable.Rows;
using MU = Veho.Mutable;

namespace Veho.Test.Mutable.Matrix {
  [TestFixture]
  public class SelectorTests {
    public static readonly List<List<int>> Rows = MU::Mat.Init(5, 5, (i, j) => i * 10 + j);
    [Test]
    public void SelectByColumnIndicesTest() {
      var rows = MU::Mat.Init(5, 5, (i, j) => i * j);
      rows.ToMatrix().Deco().Says("rows");
      rows.SelectByColumnIndices(Seq.From(1, 2, 4)).ToMatrix().Deco().Says("selected");
      SymmetricMatrix.SelectBy(rows, Seq.From(1, 2, 4)).ToMatrix().Deco().Says("symmetric selected");
      SymmetricMatrix.LowerTriangular(rows).ToMatrix().Deco().Says("lower triangular");
      SymmetricMatrix.UpperTriangular(rows).ToMatrix().Deco().Says("upper triangular");
    }

    [Test]
    public void IntoRowsIterTest() {
      Rows.SelectRowsIntoIter(Seq.From(0, 2, 4)).ToList().DecoMutableMatrix().Says("IntoRowsIterTest");
    }

    [Test]
    public void IntoColumnsIterTest() {
      Rows.SelectColumnsIntoIter(Seq.From(0, 2, 4)).ToList().DecoMutableMatrix().Says("IntoColumnsIterTest");
    }
  }
}