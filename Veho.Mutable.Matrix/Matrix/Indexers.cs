using System.Collections.Generic;

namespace Veho.Mutable.Matrix {
  public static class Indexers {
    public static T First<T>(this IReadOnlyList<IReadOnlyList<T>> rows) => rows[0][0];
    public static T Cell<T>(this IReadOnlyList<IReadOnlyList<T>> rows, int x, int y) => rows[x][y];
  }
}