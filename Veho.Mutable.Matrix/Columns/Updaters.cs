using System.Collections.Generic;

namespace Veho.Mutable.Columns {
  public static class Updaters {
    public static IList<IList<T>> UnshiftColumn<T>(this IList<IList<T>> matrix, List<T> vec) {
      for (int i = 0, hi = vec.Count; i < hi; i++) matrix[i].Insert(0, vec[i]);
      return matrix;
    }
    public static IList<IList<T>> PushColumn<T>(this IList<IList<T>> matrix, List<T> vec) {
      for (int i = 0, hi = vec.Count; i < hi; i++) matrix[i].Add(vec[i]);
      return matrix;
    }
    public static IList<IList<T>> WriteColumn<T>(this IList<IList<T>> matrix, List<T> vec, int y) {
      for (int i = 0, hi = vec.Count; i < hi; i++) matrix[i][y] = vec[i];
      return matrix;
    }
  }
}