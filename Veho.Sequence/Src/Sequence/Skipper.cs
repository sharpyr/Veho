using System.Collections.Generic;

namespace Veho.Sequence {
  public class Skipper<T> {
    public HashSet<int> UsedIndices { get; private set; }
    public IReadOnlyList<T> Vec { get; private set; }
    public static Skipper<T> Build(IReadOnlyList<T> vec) => new Skipper<T> {
      Vec = vec,
      UsedIndices = new HashSet<int>()
    };
    public IEnumerable<int> IntoIndexIter() {
      for (int i = 0, hi = Vec.Count; i < hi; i++) {
        if (UsedIndices.Contains(i)) continue;
        yield return i;
      }
    }
    public IEnumerable<T> IntoIter() {
      for (int i = 0, hi = Vec.Count; i < hi; i++) {
        if (UsedIndices.Contains(i)) continue;
        yield return Vec[i];
      }
    }
    public IEnumerable<(int, T)> IntoIndexedIter() {
      for (int i = 0, hi = Vec.Count; i < hi; i++) {
        if (UsedIndices.Contains(i)) continue;
        yield return (i, Vec[i]);
      }
    }
    public HashSet<int> PushIndex(int index) {
      this.UsedIndices.Add(index);
      return this.UsedIndices;
    }
    public HashSet<int> AcquireIndices(IEnumerable<int> indices) {
      this.UsedIndices.UnionWith(indices);
      return this.UsedIndices;
    }
  }
}