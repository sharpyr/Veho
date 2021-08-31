using System.Collections.Generic;

namespace Veho.Vector {
  public static class ToMatrix {
    public static T[,] ToRow<T>(this IReadOnlyList<T> vector) {
      var hi = vector.Count;
      var row = new T[1, hi];
      for (var j = 0; j < hi; j++) row[0, j] = vector[j];
      return row;
    }
    public static T[,] ToColumn<T>(this IReadOnlyList<T> vector) {
      var hi = vector.Count;
      var column = new T[hi, 1];
      for (var i = 0; i < hi; i++) column[i, 0] = vector[i];
      return column;
    }
  }
}