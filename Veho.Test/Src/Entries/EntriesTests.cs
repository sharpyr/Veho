using NUnit.Framework;
using Spare;

namespace Veho.Test.Entries {
  [TestFixture]
  public class EntriesTests {
    [Test]
    public void TestAlpha() {
      var va = Vec.From(1, 2, 3);
      var vb = Vec.From(4, 5, 6);
      var vc = Vec.From(7, 8, 9);
      var vd = Vec.From(0, 0, 0);
      Ent.Wind(va, vb).Deco().Says("dual");
      Ent.Wind(va, vb, vc).Deco().Says("tri");
      Ent.Wind(va, vb, vc, vd).Deco().Says("quadri");
    }
  }
}