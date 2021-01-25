using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Veho.Matrix;
using Veho.Vector;
using Inits = Veho.Matrix.Inits;

namespace Veho.Test.Alpha {
  public static class Matrix1BIterateFunctions {
    public static T[,] ZeroOutBeta<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      Array.Copy(matrix, 1, target, 0, matrix.Length);
      return target;
    }

    public static string Deco<T>(this T[,] matrix) {
      const string CRLF = "\r\n", TAB = "  ";
      matrix = matrix.ZeroOut();
      var body = matrix
                 .MapRows(row => TAB + "[" + row.Join(", ") + "],")
                 .Join("\r\n");
      return "[" + CRLF + body + CRLF + "]";
    }
  }

  [TestFixture]
  public class Matrix1BIterateTest {
    [Test]
    public void Test() {
      var samples = new[,] {
        {1, 2, 3, 4, 5},
        {10, 20, 30, 40, 50},
        {100, 200, 300, 400, 500},
      };
      var eta = new Stopwatch();
      var record = new Dictionary<String, long>();
      const double count = (int) 2E+6;

      eta.Start();
      for (var i = 0; i < count; i++) {
        var mx = Inits.Init(4, 5, (x, y) => x + y);
      }
      eta.Stop();
      record.Add("Init", eta.ElapsedMilliseconds);

      eta.Restart();
      for (var i = 0; i < count; i++) {
        var mx = Inits.M1B<int>(4, 5);
      }
      eta.Stop();
      record.Add("M1B", eta.ElapsedMilliseconds);

      var matrix1B = Inits.M1B<int>(4, 5);
      var ((xlo, xhi), (ylo, yhi)) = (matrix1B.XBound(), matrix1B.YBound());
      for (var i = xlo; i <= xhi; i++)
        for (var j = ylo; j <= yhi; j++)
          matrix1B[i, j] = i + j;

      eta.Restart();
      for (var i = 0; i < count; i++) {
        var mx = matrix1B.ZeroOut();
      }
      eta.Stop();
      Console.WriteLine($"ZeroOut {matrix1B.ZeroOut().Deco()}");
      record.Add("ZeroOut", eta.ElapsedMilliseconds);

      eta.Restart();
      for (var i = 0; i < count; i++) {
        var mx = matrix1B.ZeroOutBeta();
      }
      eta.Stop();
      Console.WriteLine($"ZeroOutBeta {matrix1B.ZeroOutBeta().Deco()}");
      record.Add("ZeroOutBeta", eta.ElapsedMilliseconds);

      foreach (var entry in record) {
        Console.WriteLine($"[{entry.Key}] ({entry.Value})");
      }
    }
  }
}