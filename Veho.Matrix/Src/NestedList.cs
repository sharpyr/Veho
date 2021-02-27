using System.Collections.Generic;

// using LM = System.Collections.Generic.IList<System.Collections.Generic.IList<T>>;

namespace Veho.Matrix {
  public static class NestedList {
    public static int Height<T>(List<List<T>> matrix) => matrix.Count;
    public static int Width<T>(List<List<T>> matrix) => matrix.Count == 0 ? 0 : matrix[0].Count;
    public static (int height, int width) Size<T>(List<List<T>> matrix) {
      var h = matrix.Count;
      return (h, h == 0 ? 0 : matrix[0].Count);
    }

    // public static List<List<T>> GrowRow<T>(List<List<T>> matrix) { }
    //
    // public static T[,] ListMatrixToArrayMatrix<T>(List<List<T>> matrix) { }
    //
    // public static List<List<T>> ArrayMatrixToListMatrix<T>(T[,] matrix) {
    //   var (h, w) = matrix.Size();
    // }
  }
}