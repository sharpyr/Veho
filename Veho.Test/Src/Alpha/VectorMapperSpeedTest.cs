using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Veho.Vector;
using Veho.Matrix;

namespace Veho.Test.Alpha {
  [TestFixture]
  public class VectorMapperSpeedTest {
    [Test]
    public void Test() {
      var samples = new[,] {
        {1, 2, 3, 4, 5},
        {10, 20, 30, 40, 50},
        {100, 200, 300, 400, 500},
      };
      var sample = samples.Row(1);
      var eta = new Stopwatch();
      var record = new Dictionary<String, long>();
      const double count = (int) 1E+7;

      eta.Start();
      for (var i = 0; i < count; i++) {
        var vec = sample.Map(x => x + 1);
      }
      eta.Stop();
      record.Add("Map", eta.ElapsedMilliseconds);


      eta.Restart();
      for (var i = 0; i < count; i++) {
        var vec = Array.ConvertAll(sample, x => x + 1);
      }
      eta.Stop();
      record.Add("Array.ConvertAll", eta.ElapsedMilliseconds);


      eta.Start();
      for (var i = 0; i < count; i++) {
        sample.Iterate(x => { var some=x + 1; });
      }
      eta.Stop();
      record.Add("Iterate", eta.ElapsedMilliseconds);
      
      
      eta.Restart();
      for (var i = 0; i < count; i++) {
        Array.ForEach(sample, x => { var some= x + 1; });
      }
      eta.Stop();
      record.Add("Array.ForEach", eta.ElapsedMilliseconds);

      foreach (var entry in record) {
        Console.WriteLine($"[{entry.Key}] ({entry.Value})");
      }
    }
  }
}