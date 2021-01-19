namespace Veho.Matrix {
  public static class Utils {
    public static T[,] Transpose<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      var target = new T[w, h];
      // matrix.IndexedIterate((i, j, v) => { target[j, i] = v; });
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          target[j, i] = matrix[i, j];
      return target;
    }
  }
}