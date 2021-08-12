using System;
using NUnit.Framework;
using Veho.Vector;

namespace Veho.Test.Vector {
  [TestFixture]
  public class ReducersTest {
    [Test]
    public void ReduceTest() {
      var some = default(string);
      Assert.AreEqual(some, null);

      var vec = new[] {1, 4, 6, 3, 2};
      var max = vec.Reduce(Math.Max);
      Console.WriteLine(max);

      var vec2 = new[] {2};
      var max2 = vec2.Reduce(Math.Max);
      Console.WriteLine(max2);

      // this throws IndexOutOfRangeException
      // var vec3 = new int[] {};
      // var max3 = vec3.Reduce(Math.Max);
      // Console.WriteLine(max3);
    }
  }
}