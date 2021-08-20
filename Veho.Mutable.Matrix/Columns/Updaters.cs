using System.Collections.Generic;

namespace Veho.Mutable.Columns {
  public static class Updaters {
    public static List<List<T>> UnshiftColumn<T>(this List<List<T>> matrix, List<T> vec) {
      for (int i = 0, hi = vec.Count; i < hi; i++) matrix[i].Insert(0, vec[i]);
      return matrix;
    }
    public static List<List<T>> PushColumn<T>(this List<List<T>> matrix, List<T> vec) {
      for (int i = 0, hi = vec.Count; i < hi; i++) matrix[i].Add(vec[i]);
      return matrix;
    }
    public static List<List<T>> WriteColumn<T>(this List<List<T>> matrix, List<T> vec, int y) {
      for (int i = 0, hi = vec.Count; i < hi; i++) matrix[i][y] = vec[i];
      return matrix;
    }
  }
}