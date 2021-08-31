using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Updaters {
    public static List<T> Push<T>(this List<T> list, T element) {
      list.Add(element);
      return list;
    }
    public static List<T> Unshift<T>(this List<T> list, T element) {
      list.Insert(0, element);
      return list;
    }
    public static List<T> Acquire<T>(this List<T> list, IEnumerable<T> another) {
      list.AddRange(another);
      return list;
    }
    public static List<T> Merge<T>(this List<T> list, List<T> another) {
      int lenA = list.Count, lenB = another.Count;
      var target = new List<T>(lenA + lenB);
      target.AddRange(list);
      target.AddRange(another);
      return target;
    }
  }
}