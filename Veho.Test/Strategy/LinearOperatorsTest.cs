using System;
using System.Threading.Tasks;
using Analys;
using NUnit.Framework;
using Palett;
using Spare;
using Veho.Columns;
using Veho.Enumerable;
using Veho.Matrix;
using Veho.Rows;
using Veho.Test.Utils;
using Gn = Generic.Math.GenericMath;
using VecZippers = Veho.Vector.Zippers;
using VecReducers = Veho.Vector.Reducers;
using Zippers = Veho.Sequence.Zippers;

namespace Veho.Test.Strategy {
  public static class LinearClassic {
    public static TO[,] Cross<T, TO>(T[,] aX, T[,] bX, Func<T, T, TO> zipper, Func<TO, TO, TO> reducer) {
      int height = aX.Height(), interim = aX.Width(), width = bX.Width();
      var matrix = new TO[height, width];
      if (interim == 0) return matrix;
      for (var i = 0; i < height; i++) {
        for (var j = 0; j < width; j++) {
          var accum = zipper(aX[i, 0], bX[0, j]);
          for (var k = 0; k < interim; k++) accum = reducer(accum, zipper(aX[i, k], bX[k, j]));
          matrix[i, j] = accum;
        }
      }
      return matrix;
    }
    static T[,] MultiplySimple<T>(T[,] aX, T[,] bX) {
      int height = aX.Height(), interim = aX.Width(), width = bX.Width();
      var matrix = new T[height, width];
      for (var i = 0; i < height; i++) {
        for (var j = 0; j < width; j++) {
          T temp = default;
          for (var k = 0; k < interim; k++) temp = Gn.Add(temp, Gn.Multiply(aX[i, k], bX[k, j]));
          matrix[i, j] = temp;
        }
      }
      return matrix;
    }
    public static T[,] Multiply<T>(this T[,] aX, T[,] bX) {
      return Cross(aX, bX, Gn.Multiply, Gn.Add);
    }
  }

  public static class LinearEpitome {
    public static T[,] Cross<T>(T[,] aX, T[,] bX, Func<T, T, T> zipper, Func<T, T, T> reducer) {
      int height = aX.Height(), width = bX.Width();
      var matrix = new T[height, width];
      for (var i = 0; i < height; i++) {
        var row = aX.Row(i);
        for (var j = 0; j < width; j++) {
          var column = bX.Column(j);
          var zipped = VecZippers.Zip(row, column, zipper);
          var reduced = VecReducers.Reduce(zipped, reducer);
          matrix[i, j] = reduced;
        }
      }
      return matrix;
    }
    public static T[,] Multiply<T>(this T[,] aX, T[,] bX) {
      return Cross(aX, bX, Gn.Multiply, Gn.Add);
    }
  }

  public static class LinearArch {
    public static T[,] Cross<T>(this T[,] aX, T[,] bX, Func<T, T, T> zipper, Func<T, T, T> reducer) {
      int height = aX.Height(), width = bX.Width();
      var matrix = new T[height, width];
      var rows = matrix.RowsIter();
      var columns = matrix.ColumnsIter();
      rows.Iterate((i, row) => {
        columns.Iterate((j, column) => {
          var zipped = VecZippers.Zip(row, column, zipper);
          var reduced = VecReducers.Reduce(zipped, reducer);
          matrix[i, j] = reduced;
        });
      });
      return matrix;
    }
    public static T[,] Multiply<T>(this T[,] aX, T[,] bX) {
      return Cross(aX, bX, Gn.Multiply, Gn.Add);
    }
  }

  public static class LinearEdge {
    public static T[,] Cross<T>(this T[,] aX, T[,] bX, Func<T, T, T> zipper, Func<T, T, T> reducer) {
      int height = aX.Height(), interim = aX.Width(), width = bX.Width();
      return height + width >= 12 && interim >= 6
        ? LinearFuture.Cross(aX, bX, zipper, reducer)
        : LinearClassic.Cross(aX, bX, zipper, reducer);
    }
    public static T[,] Multiply<T>(this T[,] aX, T[,] bX) {
      return Cross(aX, bX, Gn.Multiply, Gn.Add);
    }
  }

  public static class LinearFuture {
    public static TO[,] Cross<T, TO>(T[,] aX, T[,] bX, Func<T, T, TO> zipper, Func<TO, TO, TO> reducer) {
      int height = aX.Height(), interim = aX.Width(), width = bX.Width();
      var matrix = new TO[height, width];
      if (interim == 0) return matrix;
      Parallel.For(0, height, i => {
        Parallel.For(0, width, j => {
          var accum = zipper(aX[i, 0], bX[0, j]);
          for (var k = 0; k < interim; k++) accum = reducer(accum, zipper(aX[i, k], bX[k, j]));
          matrix[i, j] = accum;
        });
      });
      return matrix;
    }
    public static T[,] Multiply<T>(this T[,] aX, T[,] bX) {
      return Cross(aX, bX, Gn.Multiply, Gn.Add);
    }
  }

  public static class LinearStrategy {
    public static void TestParams<T>(int loop, params (T[,], T[,])[] matrixPairs) {
      var parameters = Zippers.Zip(matrixPairs, GreekAlphabets.Alphabets, (pair, key) => (key, pair));
      var (elapsed, result) = Valjoux.Strategies.Run(
        loop,
        Seq.From<(string, Func<(T[,] a, T[,] b), T[,]>)>(
          ("classic", x => LinearClassic.Multiply(x.a, x.b)),
          ("epitome", x => LinearEpitome.Multiply(x.a, x.b)),
          ("arch", x => LinearArch.Multiply(x.a, x.b)),
          ("edge", x => LinearEdge.Multiply(x.a, x.b)),
          ("future", x => LinearFuture.Multiply(x.a, x.b))
        ),
        parameters
      );
      elapsed.Deco(presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");
      var candidates = Seq.From(
        ("alpha", "classic"),
        ("alpha", "epitome"),
        ("alpha", "arch"),
        ("alpha", "edge"),
        ("alpha", "future"),
        ("beta", "classic"),
        ("beta", "epitome"),
        ("beta", "arch"),
        ("beta", "edge"),
        ("beta", "future")
      );
      foreach (var (side, head) in candidates) {
        result[side, head].Deco().Says(side + "-" + head);
      }
    }
  }

  [Ignore("ingore LinearOperatorsTest")]
  [TestFixture]
  public class LinearOperatorsTest {
    [Test]
    public void LowLevelLargeInterimStrategies() {
      (int[,], int[,]) alpha = (
        (4, 4).Init((x, y) => x),
        (4, 4).Init((x, y) => y)
      );
      (int[,], int[,]) beta = (
        (8, 4).Init((x, y) => x),
        (4, 8).Init((x, y) => y)
      );
      (int[,], int[,]) gamma = (
        (16, 4).Init((x, y) => y),
        (4, 16).Init((x, y) => (x == y) ? 2 : 0)
      );
      (int[,], int[,]) delta = (
        (8, 4).Init((x, y) => x),
        (4, 24).Init((x, y) => y)
      );
      (int[,], int[,]) epsilon = (
        (24, 4).Init((x, y) => x),
        (4, 8).Init((x, y) => y)
      );
      LinearStrategy.TestParams(10000, alpha, beta, gamma, delta, epsilon);
    }
    [Test]
    public void LowLevelSmallInterimStrategies() {
      (int[,], int[,]) alpha = (
        (4, 4).Init((x, y) => x),
        (4, 4).Init((x, y) => y)
      );
      (int[,], int[,]) beta = (
        (4, 8).Init((x, y) => x),
        (8, 4).Init((x, y) => y)
      );
      (int[,], int[,]) gamma = (
        (4, 12).Init((x, y) => y),
        (12, 4).Init((x, y) => (x == y) ? 2 : 0)
      );
      (int[,], int[,]) delta = (
        (4, 16).Init((x, y) => x),
        (4, 4).Init((x, y) => y)
      );
      (int[,], int[,]) epsilon = (
        (2, 20).Init((x, y) => x),
        (20, 4).Init((x, y) => y)
      );
      LinearStrategy.TestParams(10000, alpha, beta, gamma, delta, epsilon);
    }
    [Test]
    public void MidLevelLargeInterimStrategies() {
      (int[,], int[,]) alpha = (
        (4, 32).Init((x, y) => x),
        (32, 4).Init((x, y) => y)
      );
      (int[,], int[,]) beta = (
        (8, 32).Init((x, y) => x),
        (32, 8).Init((x, y) => y)
      );
      (int[,], int[,]) gamma = (
        (16, 32).Init((x, y) => y),
        (32, 16).Init((x, y) => (x == y) ? 2 : 0)
      );
      (int[,], int[,]) delta = (
        (8, 32).Init((x, y) => x),
        (32, 24).Init((x, y) => y)
      );
      (int[,], int[,]) epsilon = (
        (24, 32).Init((x, y) => x),
        (32, 8).Init((x, y) => y)
      );
      LinearStrategy.TestParams(100, alpha, beta, gamma, delta, epsilon);
    }
    [Test]
    public void MidLevelSmallInterimStrategies() {
      (int[,], int[,]) alpha = (
        (32, 4).Init((x, y) => x),
        (4, 32).Init((x, y) => y)
      );
      (int[,], int[,]) beta = (
        (32, 8).Init((x, y) => x),
        (8, 32).Init((x, y) => y)
      );
      (int[,], int[,]) gamma = (
        (32, 12).Init((x, y) => y),
        (12, 32).Init((x, y) => (x == y) ? 2 : 0)
      );
      (int[,], int[,]) delta = (
        (32, 16).Init((x, y) => x),
        (4, 32).Init((x, y) => y)
      );
      (int[,], int[,]) epsilon = (
        (32, 20).Init((x, y) => x),
        (20, 32).Init((x, y) => y)
      );
      LinearStrategy.TestParams(50, alpha, beta, gamma, delta, epsilon);
    }
    [Test]
    public void HighLevelLargeInterimStrategies() {
      (int[,], int[,]) alpha = (
        (4, 256).Init((x, y) => x),
        (256, 4).Init((x, y) => y)
      );
      (int[,], int[,]) beta = (
        (8, 256).Init((x, y) => x),
        (256, 8).Init((x, y) => y)
      );
      (int[,], int[,]) gamma = (
        (16, 256).Init((x, y) => y),
        (256, 16).Init((x, y) => (x == y) ? 2 : 0)
      );
      (int[,], int[,]) delta = (
        (8, 256).Init((x, y) => x),
        (256, 24).Init((x, y) => y)
      );
      (int[,], int[,]) epsilon = (
        (24, 256).Init((x, y) => x),
        (256, 8).Init((x, y) => y)
      );
      LinearStrategy.TestParams(10, alpha, beta, gamma, delta, epsilon);
    }
    [Test]
    public void HighLevelSmallInterimStrategies() {
      (int[,], int[,]) alpha = (
        (256, 4).Init((x, y) => x),
        (4, 256).Init((x, y) => y)
      );
      (int[,], int[,]) beta = (
        (256, 8).Init((x, y) => x),
        (8, 256).Init((x, y) => y)
      );
      (int[,], int[,]) gamma = (
        (256, 12).Init((x, y) => y),
        (12, 256).Init((x, y) => (x == y) ? 2 : 0)
      );
      (int[,], int[,]) delta = (
        (256, 16).Init((x, y) => x),
        (4, 256).Init((x, y) => y)
      );
      (int[,], int[,]) epsilon = (
        (256, 20).Init((x, y) => x),
        (20, 256).Init((x, y) => y)
      );
      LinearStrategy.TestParams(10, alpha, beta, gamma, delta, epsilon);
    }
  }
}