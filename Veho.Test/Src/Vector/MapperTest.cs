using System;
using NUnit.Framework;
using Spare;
using Veho.Vector;

namespace Veho.Test.Vector {
  [TestFixture]
  public class MapperTest {
    [Test]
    public void MapTest() {
      int[] vec = { 1, 1, 2, 3, 5, 8, 13, 21 };
      Console.WriteLine(string.Join(", ", vec.Map(x => x * 2)));
      Console.WriteLine("passed");
    }

    [Test]
    public void CopyTest() {
      int[] vec = { 1, 1, 2, 3, 5, 8, 13, 21 };
      Console.WriteLine($">> [original] {Decoes.Deco(vec)}");
      Console.WriteLine($">> [slice] {Decoes.Deco(vec.Slice())}");
      Console.WriteLine($">> [slice] {Decoes.Deco(vec.Slice(2))}");
      Console.WriteLine($">> [slice] {Decoes.Deco(vec.Slice(0, 6))}");
      Console.WriteLine($">> [slice] {Decoes.Deco(vec.Slice(2, 6))}");
      Console.WriteLine($">> [slice] {Decoes.Deco(vec.Slice(2, -2))}");
    }
  }
}