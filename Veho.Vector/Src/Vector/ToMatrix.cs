using System.Collections.Generic;

namespace Veho.Vector {
  public static class ToMatrix {
    public static T[,] ToRow<T>(this IReadOnlyList<T> vec) {
      var hi = vec.Count;
      var row = new T[1, hi];
      for (var j = 0; j < hi; j++) row[0, j] = vec[j];
      return row;
    }
    public static T[,] ToColumn<T>(this IReadOnlyList<T> vec) {
      var hi = vec.Count;
      var column = new T[hi, 1];
      for (var i = 0; i < hi; i++) column[i, 0] = vec[i];
      return column;
    }
  }
}