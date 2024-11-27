using System;
using System.Linq;
using NUnit.Framework;
using Veho.Enumerable;

namespace Veho.Test.Enumerable {
  [TestFixture]
  public class ZipperTest {
    [Test]
    public void DuoZipperTest() {
      var a = new[] { 1, 2, 3, 4, 5 };
      var b = new[] { 2, 2, 0, 3, 3 };
      Func<int, int, int, int> func = (i, x, y) => (int)Math.Pow(10, i) + x * y;
      var vec = func.Zipper(a.AsEnumerable(), b.AsEnumerable());
      Console.WriteLine(string.Join(", ", vec));
      Console.WriteLine();
    }
  }
}