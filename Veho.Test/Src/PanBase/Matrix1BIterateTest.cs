using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Texting.Enums;
using Typen;
using Veho.Matrix;
using Veho.Rows;
using Veho.Vector;
using Veho.PanBase.Matrix;

namespace Veho.Test.PanBase {
  public static class Matrix1BIterateFunctions {
    public static T[,] ZeroOutBeta<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[h, w];
      Array.Copy(matrix, 1, target, 0, matrix.Length);
      return target;
    }

    public static string Deco<T>(this T[,] matrix) {
      matrix = matrix.Rebase();
      var body = matrix
                 .MapRows(row => Chars.SP + "[" + row.Join(Conv.ToStr) + "],")
                 .Join(x => x.ToString(), "\n");
      return "[" + Chars.LF + body + Chars.LF + "]";
    }
  }

  [TestFixture]
  public class Matrix1BIterateTest {
    [Test]
    [Ignore("Ignore a strategy")]
    public void Test() {
      var samples = new[,] {
                             { 1, 2, 3, 4, 5 },
                             { 10, 20, 30, 40, 50 },
                             { 100, 200, 300, 400, 500 },
                           };
      var eta = new Stopwatch();
      var record = new Dictionary<string, long>();
      const double count = (int)2E+6;

      eta.Start();
      for (var i = 0; i < count; i++) {
        var mx = Mat.Init(4, 5, (x, y) => x + y);
      }
      eta.Stop();
      record.Add("Init", eta.ElapsedMilliseconds);

      eta.Restart();
      var size = (4, 5);
      for (var i = 0; i < count; i++) {
        var mx = size.Init<int>();
      }
      eta.Stop();
      record.Add("M1B", eta.ElapsedMilliseconds);

      var matrix1B = (4, 5).Init<int>();
      var ((xlo, xhi), (ylo, yhi)) = (matrix1B.XBound(), matrix1B.YBound());
      for (var i = xlo; i <= xhi; i++)
        for (var j = ylo; j <= yhi; j++)
          matrix1B[i, j] = i + j;

      eta.Restart();
      for (var i = 0; i < count; i++) {
        var mx = matrix1B.Rebase();
      }
      eta.Stop();
      record.Add("Rebase", eta.ElapsedMilliseconds);
      Console.WriteLine($"Rebase {matrix1B.Rebase().Deco()}");

      eta.Restart();
      for (var i = 0; i < count; i++) {
        var mx = matrix1B.ZeroOutBeta();
      }
      eta.Stop();
      record.Add("ZeroOutBeta", eta.ElapsedMilliseconds);
      Console.WriteLine($"ZeroOutBeta {matrix1B.ZeroOutBeta().Deco()}");

      eta.Restart();
      for (var i = 0; i < count; i++) {
        var mx = matrix1B.Rebase(x => x);
      }
      eta.Stop();
      record.Add("Rebase(Mapped)", eta.ElapsedMilliseconds);
      Console.WriteLine($"Rebase {matrix1B.Rebase(x => x).Deco()}");

      eta.Restart();
      for (var i = 0; i < count; i++) {
        var mx = matrix1B.Rebase().Map(x => x);
      }
      eta.Stop();
      record.Add("Rebase + Map", eta.ElapsedMilliseconds);
      Console.WriteLine($"Rebase + Map {matrix1B.Rebase(x => x).Deco()}");

      foreach (var entry in record) {
        Console.WriteLine($"[{entry.Key}] ({entry.Value})");
      }
    }
  }
}