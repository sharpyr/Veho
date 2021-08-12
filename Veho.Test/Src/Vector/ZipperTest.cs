using System;
using NUnit.Framework;
using Veho.Vector;

namespace Veho.Test.Vector {
  [TestFixture]
  public class ZipperTest {
    [Test]
    public void DuoZipperTest() {
      var a = new[] {1, 2, 3, 4, 5};
      var b = new[] {2, 2, 0, 3, 3};
      Func<int, int, int> fn = (x, y) => x * y;
      var vec = Zippers.Zipper(fn, a, b);
      Console.WriteLine(string.Join(", ", vec));
      Console.WriteLine();
    }
  }
}