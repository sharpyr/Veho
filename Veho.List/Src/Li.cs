using System;
using System.Linq;
using G = System.Collections.Generic;

namespace Veho {
  public static class Li {
    public static G::List<T> Iso<T>(int len, T element) {
      var list = new G::List<T>(len);
      for (var i = 0; i < len; i++) list.Add(element);
      return list;
    }
    public static G::List<T> Init<T>(int len, Func<int, T> func) {
      var list = new G::List<T>(len);
      for (var i = 0; i < len; i++) list.Add(func(i));
      return list;
    }
    public static G::List<T> From<T>(params T[] elements) => elements.ToList();
  }
}