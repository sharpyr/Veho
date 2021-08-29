using System;
using NUnit.Framework;
using System.Collections.Generic;
using Veho.Sequence;

namespace Veho.Test.Sequence {
  [TestFixture]
  public static class MaxByTests {
    [Test]
    public static void TestAlpha() {
      List<(string key, int value)> list = Seq.From(
        ("foo", 1),
        ("bar", 3),
        ("zen", 5),
        ("kha", 6),
        ("boa", 4),
        ("dee", 2)
      );
      var max = list.MaxBy(x => x.value);
      Console.WriteLine($">> [MaxBy Value] {max}");
      var min = list.MinBy(x => x.value);
      Console.WriteLine($">> [MinBy Value] {min}");
    }
  }
}