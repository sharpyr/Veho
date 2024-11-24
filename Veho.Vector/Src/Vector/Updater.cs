using System;

namespace Veho.Vector {
  public static class Updater {
    public static T[] Push<T>(this T[] vector, T element) {
      int hi = vector.Length, len = hi + 1;
      Array.Resize(ref vector, len);
      vector[hi] = element;
      return vector;
    }
    public static T[] Unshift<T>(this T[] vector, T element) {
      int hi = vector.Length, len = hi + 1;
      Array.Resize(ref vector, len);
      Array.Copy(vector, 0, vector, 1, hi);
      vector[0] = element;
      return vector;
    }
    public static T[] Acquire<T>(this T[] vector, T[] another) {
      int hi = vector.Length, len = another.Length;
      Array.Resize(ref vector, hi + len);
      Array.Copy(another, 0, vector, hi, len);
      return vector;
    }
    public static T[] Merge<T>(this T[] vector, T[] another) {
      int hi = vector.Length, len = another.Length;
      var target = new T[hi + len];
      Array.Copy(vector, 0, target, 0, hi);
      Array.Copy(another, 0, target, hi, len);
      return target;
    }
  }
}