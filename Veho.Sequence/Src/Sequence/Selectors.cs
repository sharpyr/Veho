using System;
using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Selectors {
    public static (T element, TO indicator) Indicator<T, TO>(this IReadOnlyList<T> list, int index, Func<T, TO> indicator) {
      var element = list[index];
      var selected = indicator(element);
      return (element, selected);
    }
    public static (T, T) T2<T>(this List<T> list) => (list[0], list[1]);
    public static (T, T, T) T3<T>(this List<T> list) => (list[0], list[1], list[2]);
    public static (T, T, T, T) T4<T>(this List<T> list) => (list[0], list[1], list[2], list[4]);
  }
}