using System;
using System.Collections.Generic;
using System.Linq;

namespace Veho {
  public static partial class Mappers {
    //
    // IList(of T)
    //
    public static TOut[] Map<T, TOut>(this IList<T> list, Func<T, TOut> func) {
      var vec = new TOut[list.Count];
      var arr = list.ToArray();
      for (var i = 0; i < list.Count; i++)
        vec[i] = func(arr[i]);
      return vec;
    }
    public static void Iterate<T>(this IList<T> list, Action<T> func) {
      foreach (var cel in list)
        func(cel);
    }
    public static void Iterate<T>(this IList<T> list, Action<T, int> func) {
      var arr = list.ToArray();
      for (var i = 0; i < list.Count; i++) func(arr[i], i);
    }
    public static void IterateBack<T>(this IList<T> list, Action<T> func) {
      for (var i = list.Hi(); i >= 0; i--) func(list[i]);
    }

    #region "info"
    public static int Hi<T>(this IList<T> list) => list.Count - 1;
    #endregion
  }
}