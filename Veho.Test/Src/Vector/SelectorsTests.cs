using NUnit.Framework;
using Spare;
using Veho.Vector;

namespace Veho.Test.Vector {
  [TestFixture]
  public class SelectorsTests {
    [Test]
    public void TestAlpha() {
      var list = Vec.From("foo", "bar", "zen", "kha", "voo");
      var result = list.SelectOf(0, 2, 4);
      result.Deco().Logger();
    }
  }
}