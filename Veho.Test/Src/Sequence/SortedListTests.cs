using NUnit.Framework;
using System.Collections.Generic;
using Spare;

namespace Veho.Test.Sequence {
  [TestFixture]
  public class SortedListTests {
    [Test]
    public void SortedListTestAlpha() {
      var list = new SortedList<double, string>() {
        { 1, "foo" },
        { 3, "zen" },
        { 2, "bar" },
      };
      list.Entries().DecoEntries().Says("sorted list");
    }
  }
}