// using System;
// using NUnit.Framework;
// using Spare.Deco;
// using Veho.Matrix;
// using Veho.Matrix.Rows;
// using Veho.Test.Utils;
//
// namespace Veho.Test.Alpha {
//   public static partial class  Functions {
//     public static T[] Row<T>(this T[,] matrix, int x, int w = 0) {
//       var row = new T[w == 0 ? w = matrix.Width() : w];
//       for (var j = 0; j < w; j++) row[j] = matrix[x, j];
//       return row;
//     }
//
//     public static T[] RowBeta<T>(this T[,] matrix, int x, int w = 0) {
//       var row = new T[w == 0 ? w = matrix.Width() : w];
//       Array.Copy(matrix, x * w, row, 0, w);
//       // for (var j = 0; j < w; j++) row[j] = matrix[x, j];
//       return row;
//     }
//   }
//
//   [TestFixture]
//   public class MatrixGetRowSpeedTest {
//     [Test]
//     public void Test() {
//       var matrix = (3, 5).Init((x, y) => x + y);
//       var eta = FlyBack<int[]>.Build((int) 1E+5);
//       eta.Run("Plain", () => matrix.Row(0));
//       eta.Run("Array.Copy", () => matrix.RowBeta(0));
//       eta.Log(x => x.Deco());
//     }
//   }
// }

