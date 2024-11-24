using System;
using System.Collections.Generic;
using System.Diagnostics;
using Typen;

namespace Veho.Test.Utils {
  public static class FlyBack {
    public static ETA<object> Build(int n) => new ETA<object> {
      Loop = n, Records = new Dictionary<string, (object, long)>()
    };
  }

  public class ETA<T> : Stopwatch {
    public Dictionary<string, (T value, long elapsed)> Records;
    public int Loop { get; set; }
    public static ETA<T> Build(int n) => new ETA<T> {
      Loop = n, Records = new Dictionary<string, (T, long)>()
    };

    public void Log(Func<T, string> formatter = null) {
      formatter = formatter ?? Conv.ToStr;
      foreach (var entry in Records) {
        var (value, elapsed) = entry.Value;
        Console.WriteLine($"[{entry.Key}] ({elapsed}) {formatter(value)}");
      }
    }
    public void Run(string message, Action action) {
      Restart();
      for (var i = 0; i < Loop; i++) action();
      Stop();
      Records[message] = (default(T), ElapsedMilliseconds);
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