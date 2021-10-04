using System;
using System.Linq;
using NUnit.Framework;
using Veho.Enumerable;

namespace Veho.Test.Enumerable {
  [TestFixture]
  public class SelectorTest {
    [Test]
    public void test() {
      var vec = Vec.From(1, 2, 3, 4, 5);
      var index = vec.AsEnumerable().FindIndex(x => x >= 3);
      Console.WriteLine($">> [index] {index}");
    }
  }
}