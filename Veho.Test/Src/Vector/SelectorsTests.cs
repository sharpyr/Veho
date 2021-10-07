using System;
using System.Collections.Generic;
using NUnit.Framework;
using Spare;
using Veho.Vector;

namespace Veho.Test.Vector {
  public static class Methods {
    public static void ShowSomething<T>(this IList<T> list) {
      Console.WriteLine($">> [list.count] {list.Count}");
    }
  }

  [TestFixture]
  public class SelectorsTests {
    [Test]
    public void TestAlpha() {
      var list = Vec.From("foo", "bar", "zen", "kha", "voo");
      var result = list.SelectOf(0, 2, 4);
      result.Deco().Logger();
      Console.WriteLine($">> [list.type] {list.GetType()}");
      list.ShowSomething();
    }
  }
}