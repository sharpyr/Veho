using System;
using NUnit.Framework;

namespace Veho.Test.Vector {
  [TestFixture]
  public class MapperTest {
    [Test]
    public void SomeTest() {
      int[] vec = {1, 1, 2, 3, 5, 8, 13, 21};
      Console.WriteLine(string.Join(", ", vec.Map(x => x * 2)));
      Console.WriteLine("passed");
    }
  }
}