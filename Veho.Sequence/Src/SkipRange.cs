using System.Collections.Generic;

namespace Veho {
  public class SkipRange {
    public HashSet<int> Used { get; private set; }
    public int Lower { get; set; }
    public int Upper { get; set; }
    public static SkipRange Build(int upper) => new SkipRange {
      Lower = 0,
      Upper = upper,
      Used = new HashSet<int>()
    };
    public IEnumerable<int> IntoIter() {
      for (var i = Lower; i < Upper; i++) {
        if (Used.Contains(i)) continue;
        yield return i;
      }
    }
    public HashSet<int> AcquireIndices(IEnumerable<int> indices) {
      this.Used.UnionWith(indices);
      return this.Used;
    }
  }
}