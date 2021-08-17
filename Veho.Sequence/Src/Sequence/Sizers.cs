using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace Veho.Sequence {
  public static class Sizers {
    public static List<T> Resize<T>(this List<T> list, int hi, T c) {
      var curr = list.Count;
      if (curr == hi) return list;
      if (curr > hi) {
        list.RemoveRange(hi, curr - hi);
        return list;
      }
      // curr < hi
      if (hi > list.Capacity) list.Capacity = hi; //this bit is purely an optimisation, to avoid multiple automatic capacity changes.
      list.AddRange(Repeat(c, hi - curr));
      return list;
    }
  }
}