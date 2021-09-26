using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace Veho.Test.Alpha {
  [TestFixture]
  public class Vector1BIterateTest {
    [Test]
    [Ignore("Ignore a strategy")]
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
        var vec = Vec.Init(8, x => x);
      }
      eta.Stop();
      record.Add("Init", eta.ElapsedMilliseconds);


      eta.Restart();
      for (var i = 0; i < count; i++) {
        var vec = Vec.V1B<int>(8);
      }
      eta.Stop();
      record.Add("V1B", eta.ElapsedMilliseconds);

      // var vec1B = Inits.V1B<int>(4);
      // var (lo, hi) = (vec1B.LoHi());
      // for (var i = lo; i < hi; i++)
      //   vec1B[i] = i;
      //
      // eta.Restart();
      // for (var i = 0; i < count; i++) {
      //   var vec = vec1B.ZeroOut();
      // }
      // eta.Stop();
      // record.Add("ZeroOut", eta.ElapsedMilliseconds);
      // Console.WriteLine($"{vec1B.ZeroOut()}");
      //
      // eta.Restart();
      // for (int i = 0; i < count; i++) {
      //   var col = samples.IterColumn(2);
      // }
      // eta.Stop();
      // record.Add("IterColumn", eta.ElapsedMilliseconds);

      foreach (var entry in record) {
        Console.WriteLine($"[{entry.Key}] ({entry.Value})");
      }
    }
  }
}