using System.Collections.Generic;

namespace Veho.Sequence {
  public static class Util {
    public static T Swap<T>(this IList<T> vector, int i, int j) {
      var temp = vector[i];
      vector[i] = vector[j];
      return vector[j] = temp;
    }
  }
}