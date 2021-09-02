using NUnit.Framework;
using Spare;
using Veho.Mutable.Columns;
using Veho.Mutable.LinearAlgebra;
using Veho.Mutable.Matrix;
using MU = Veho.Mutable;

namespace Veho.Test.Mutable.Matrix {
  [TestFixture]
  public class SelectorsTests {
    [Test]
    public void SelectByColumnIndicesTest() {
      var rows = MU::Mat.Init(5, 5, (i, j) => i * j);
      rows.ToMatrix().Deco().Says("rows");
      rows.SelectByColumnIndices(Seq.From(1, 2, 4)).ToMatrix().Deco().Says("selected");
      SymmetricMatrix.SelectBy(rows,Seq.From(1, 2, 4)).ToMatrix().Deco().Says("symmetric selected");
    }
  }
}