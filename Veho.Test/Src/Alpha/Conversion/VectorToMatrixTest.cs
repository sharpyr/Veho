using System;
using System.Runtime.InteropServices;
using Analys;
using NUnit.Framework;
using Palett;
using Spare;
using Veho.Matrix;
using Veho.Test.PanBase;
using Veho.Types;

namespace Veho.Test.Alpha.Conversion {
  [TestFixture]
  public class Array1DCopyToArray2DTest {
    public int[,] MatrixAlpha = {
                                  { 0, 1, 2 },
                                  { 10, 11, 12 },
                                  { 20, 21, 22 },
                                };
    [Test]
    public void CopyTest() {
      var vector = new[] { 4, 5, 6 };

      MatrixAlpha.Deco().Logger();

      MatrixAlpha.ReplaceRow(1, vector);

      MatrixAlpha.Deco().Logger();
    }
    [Test]
    // [Ignore("Ignore a strategy")]
    public void CopyStrategies() {
      var (elapsed, result) = Valjoux.Strategies.Run(
        (int)1E+6,
        Seq.From<(string, Func<int[], int[,]>)>(
          ("NaiveCopier", vec => MatrixAlpha.ReplaceRowNaive(1, vec)),
          ("BufferCopier", vec => MatrixAlpha.ReplaceRow(1, vec))
        ),
        Seq.From(
          ("alpha", new[] { 4, 5, 6 }),
          ("beta", new[] { 95, 96, 97 })
        )
      );
      "\nElapsed".Logger();
      elapsed.Deco(orient: Operated.Rowwise, presets: (Presets.Subtle, Presets.Fresh)).Logger();
      "\nResult".Logger();
      result.Deco().Logger();
    }
  }

  public static partial class Copiers {
    public static T[,] ReplaceRowNaive<T>(this T[,] matrix, int destRowIndex, T[] vector) where T : struct {
      var width = Math.Min(matrix.Width(), vector.Length);
      for (var j = 0; j < width; j++) matrix[destRowIndex, j] = vector[j];
      return matrix;
    }
    public static T[,] ReplaceRow<T>(this T[,] matrix, int destRowIndex, T[] vector) where T : struct {
      Buffer.BlockCopy(
        vector,                                                     // src
        0,                                                          // srcOffset
        matrix,                                                     // dst
        destRowIndex * matrix.Width() * Marshal.SizeOf(default(T)), // dstOffset
        vector.Length * Marshal.SizeOf(default(T)));                // count
      return matrix;
    }
  }
}