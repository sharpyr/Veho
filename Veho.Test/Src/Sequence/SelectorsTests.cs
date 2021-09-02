using NUnit.Framework;
using Spare;
using Veho.Sequence;

namespace Veho.Test.Sequence {
  [TestFixture]
  public class SelectorsTests {
    [Test]
    public void TestAlpha() {
      var list = Seq.From("foo", "bar", "zen", "kha", "voo");
      var result = list.SelectOf(0, 2, 4);
      result.Deco().Logger();
    }
  }
}