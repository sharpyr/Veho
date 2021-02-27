using System;

namespace Veho.Vector {
  public static class Updaters {
    public static int Push<T>(this T[] vector, T element) {
      var hi = vector.Length;
      Array.Resize(ref vector, hi + 1);
      vector[hi] = element;
      return vector.Length;
    }
  }
}