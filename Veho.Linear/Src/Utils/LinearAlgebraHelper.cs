using Veho.Matrix;

namespace Veho.Utils {
  public static class LinearAlgebraHelper {
    public static bool ColToRow<T>(this T[,] aX, T[,] bX) => aX.Width() == 1 && bX.Height() == 1;
  }
}