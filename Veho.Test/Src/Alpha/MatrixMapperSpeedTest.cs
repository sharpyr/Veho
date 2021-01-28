using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;
using Typen;
using Veho.Matrix;

namespace Veho.Test.Alpha {
  [TestFixture]
  public class MatrixMapperSpeedTest {
    [Test]
    public void Test() {
      var matrix = (3, 5).Init((_, y) => y);
      var eta = FlyBack<object>.Build((int) 1E+5);

      var a = eta.Run("Map", () => matrix.Map(x => x + 1));

      var b = eta.Run("ReducedSum", () => matrix.Reduce((ac, x) => ac + x));

      var c = eta.Run("LinqSum", () => matrix.OfType<int>().Aggregate((ac, x) => ac + x));

      eta.Log();
    }
  }

  public class FlyBack<T> : Stopwatch {
    public Dictionary<string, (T value, long elapsed)> Records;
    public int Loop { get; set; }
    public static FlyBack<T> Build(int loopCount) =>
      new FlyBack<T> {
        Loop = loopCount,
        Records = new Dictionary<string, (T, long)>()
      };

    public void Log(Func<T, string> formatter = null) {
      if (formatter == null) formatter = Conv.ToStr;
      foreach (var entry in Records) {
        var (result, period) = entry.Value;
        Console.WriteLine($"[{entry.Key}] ({period}) {formatter(result)}");
      }
    }
    public void Run(string message, Action action) {
      Restart();
      for (var i = 0; i < Loop; i++) action();
      Stop();
      Records[message] = (default, ElapsedMilliseconds);
    }
    public T Run(string message, Func<T> func) {
      Restart();
      var result = func();
      for (var i = 1; i < Loop; i++) { func(); }
      Stop();
      Records[message] = (result, ElapsedMilliseconds);
      return result;
    }
  }
}