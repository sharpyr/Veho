using System;
using System.Collections.Generic;
using System.Linq;

namespace Veho {
  public static class Seq {
    public static List<T> Iso<T>(int len, T element) {
      var list = new List<T>(len);
      for (var i = 0; i < len; i++) list.Add(element);
      return list;
    }
    public static List<T> Init<T>(int len, Func<int, T> func) {
      var list = new List<T>(len);
      for (var i = 0; i < len; i++) list.Add(func(i));
      return list;
    }
    public static List<T> From<T>(params T[] elements) => elements.ToList();

    public static List<TA> MutaZip<TA, TB>(ref List<TA> list, List<TB> another, Func<TA, TB, TA> fn) {
      var hi = list.Count;
      for (var i = 0; i < hi; i++) list[i] = fn(list[i], another[i]);
      return list;
    }
  }
}