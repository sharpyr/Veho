using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Veho.Test.Alpha {
  public static class MatrixUtils {
    public static T[] LinqColumn<T>(this T[,] matrix, int columnNumber) {
      return System.Linq.Enumerable.Range(0, matrix.GetLength(0))
                   .Select(x => matrix[x, columnNumber])
                   .ToArray();
    }

    public static T[] LinqRow<T>(this T[,] matrix, int rowNumber) {
      return System.Linq.Enumerable.Range(0, matrix.GetLength(1))
                   .Select(x => matrix[rowNumber, x])
                   .ToArray();
    }

    public static T[] IterRow<T>(this T[,] matrix, int r) {
      var w = matrix.GetLength(1);
      var row = new T[w];
      for (var j = 0; j < w; j++) row[j] = matrix[r, j];
      return row;
    }

    public static T[] IterColumn<T>(this T[,] matrix, int c) {
      var h = matrix.GetLength(0);
      var col = new T[h];
      for (var i = 0; i < h; i++) col[i] = matrix[i, c];
      return col;
    }
  }

  [TestFixture]
  public class MatrixLinqVsForeachTest {
    [Test]
    public void Test() {
      var samples = new[,] {
        {1, 2, 3, 4, 5},
        {10, 20, 30, 40, 50},
        {100, 200, 300, 400, 500},
      };
      var eta = new Stopwatch();
      var record = new Dictionary<String, long>();
      var count = 1000000;

      eta.Start();
      for (int i = 0; i < count; i++) {
        var row = samples.LinqRow(2);
      }
      eta.Stop();
      record.Add("LinqRow", eta.ElapsedMilliseconds);


      eta.Restart();
      for (int i = 0; i < count; i++) {
        var col = samples.LinqColumn(2);
      }
      eta.Stop();
      record.Add("LinqColumn", eta.ElapsedMilliseconds);

      eta.Restart();
      for (int i = 0; i < count; i++) {
        var row = samples.IterRow(2);
      }
      eta.Stop();
      record.Add("IterRow", eta.ElapsedMilliseconds);

      eta.Restart();
      for (int i = 0; i < count; i++) {
        var col = samples.IterColumn(2);
      }
      eta.Stop();
      record.Add("IterColumn", eta.ElapsedMilliseconds);

      foreach (var entry in record) {
        Console.WriteLine($"[{entry.Key}] ({entry.Value})");
      }
    }
  }
}