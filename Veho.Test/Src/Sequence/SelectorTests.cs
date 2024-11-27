using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare;
using Veho.Sequence;

namespace Veho.Test.Sequence {
  [TestFixture]
  public class SelectorTests {
    [Test]
    public void TestAlpha() {
      var list = Seq.From("foo", "bar", "zen", "kha", "voo");
      var result = list.SelectListOf(0, 2, 4);
      result.Deco().Logger();
    }
    [Test]
    public void TestBeta() {
      var list = Seq.From("foo", "bar", "zen", "kha", "voo");
      Console.WriteLine($">> [every] {list.EveryOfList(x => x == "foo")}");
      Console.WriteLine($">> [some] {list.SomeOfList(x => x == "foo")}");
      Console.WriteLine($">> [find] {list.Find(x => x[0] == 'z')}");
      Console.WriteLine($">> [find-index] {list.FindIndex(x => x[0] == 'z')}");
      var regex = new Regex(@"^z");
      Console.WriteLine($">> [find-index] {list.FindIndex(x => regex.IsMatch(x))}");
    }
  }
}