using System;
using System.Collections.Generic;
using System.Drawing;
using NUnit.Framework;

namespace Veho.Test.Alpha {
  // [Ignore("skip default value test")]
  [TestFixture]
  public class DefaultTests {
    [Test]
    public void DefaultTestAlpha() {
      Console.WriteLine($"[default(bool)] ({default(bool)})");
      Console.WriteLine($"[default(int)] ({default(int)})");
      Console.WriteLine($"[default(float)] ({default(float)})");
      Console.WriteLine($"[default(double)] ({default(double)})");
      Console.WriteLine($"[default(string)] ({default(string)})");
      Console.WriteLine($"[default(Color)] ({default(Color)})");
      Console.WriteLine($"[default(int[])] ({default(int[])})");
      Console.WriteLine($"[default(List<int>)] ({default(List<int>)})");
    }
  }
}