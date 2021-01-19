using System;
using NUnit.Framework;
using Veho.Vector;

namespace Veho.Test.Vector {
  [TestFixture]
  public class UtilTest {
    [Test]
    public void SwapTest() {
      int[] vector = {1, 2, 3, 4, 5};
      Console.WriteLine(vector.Swap(0, 4));
    }
  }
}