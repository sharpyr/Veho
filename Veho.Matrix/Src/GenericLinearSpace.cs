using System.Collections.Generic;
using Veho.Matrix;

namespace Veho {
  public static class LinearSpace<T> {
    #region "array to array"
    public static T[] And(IReadOnlyList<T> aV, IReadOnlyList<T> bV) => VectorZipperOperators.op_BitwiseAnd(aV, bV);
    public static T[] Or(IReadOnlyList<T> aV, IReadOnlyList<T> bV) => VectorZipperOperators.op_BitwiseOr(aV, bV);
    public static T[] Add(IReadOnlyList<T> aV, IReadOnlyList<T> bV) => VectorZipperOperators.op_Addition(aV, bV);
    public static T[] Subtract(IReadOnlyList<T> aV, IReadOnlyList<T> bV) => VectorZipperOperators.op_Subtraction(aV, bV);
    public static T[] Multiply(IReadOnlyList<T> aV, IReadOnlyList<T> bV) => VectorZipperOperators.op_Multiply(aV, bV);
    public static T[] Divide(IReadOnlyList<T> aV, IReadOnlyList<T> bV) => VectorZipperOperators.op_Division(aV, bV);
    public static T[] Concat(IReadOnlyList<T> aV, IReadOnlyList<T> bV) => VectorZipperOperators.op_Concatenate(aV, bV);
    #endregion

    #region "array to value"
    public static T[] And(IReadOnlyList<T> aV, T bN) => VectorToValueOperators.op_BitwiseAnd(aV, bN);
    public static T[] Or(IReadOnlyList<T> aV, T bN) => VectorToValueOperators.op_BitwiseOr(aV, bN);
    public static T[] Add(IReadOnlyList<T> aV, T bN) => VectorToValueOperators.op_Addition(aV, bN);
    public static T[] Subtract(IReadOnlyList<T> aV, T bN) => VectorToValueOperators.op_Subtraction(aV, bN);
    public static T[] Multiply(IReadOnlyList<T> aV, T bN) => VectorToValueOperators.op_Multiply(aV, bN);
    public static T[] Divide(IReadOnlyList<T> aV, T bN) => VectorToValueOperators.op_Division(aV, bN);
    public static T[] Concat(IReadOnlyList<T> aV, T bN) => VectorToValueOperators.op_Concatenate(aV, bN);
    #endregion

    #region "matrix to matrix"
    public static T[,] And(T[,] aX, T[,] bX) => aX.Width() == 1 && bX.Height() == 1
      ? MatrixLinearOperators.op_BitwiseAnd(aX, bX)
      : MatrixZipperOperators.op_BitwiseAnd(aX, bX);
    public static T[,] Or(T[,] aX, T[,] bX) => aX.Width() == 1 && bX.Height() == 1
      ? MatrixLinearOperators.op_BitwiseOr(aX, bX)
      : MatrixZipperOperators.op_BitwiseOr(aX, bX);
    public static T[,] Add(T[,] aX, T[,] bX) => aX.Width() == 1 && bX.Height() == 1
      ? MatrixLinearOperators.op_Addition(aX, bX)
      : MatrixZipperOperators.op_Addition(aX, bX);
    public static T[,] Subtract(T[,] aX, T[,] bX) => aX.Width() == 1 && bX.Height() == 1
      ? MatrixLinearOperators.op_Subtraction(aX, bX)
      : MatrixZipperOperators.op_Subtraction(aX, bX);
    public static T[,] Multiply(T[,] aX, T[,] bX) => aX.Width() == 1 && bX.Height() == 1
      ? MatrixLinearOperators.op_Multiply(aX, bX)
      : MatrixZipperOperators.op_Multiply(aX, bX);
    public static T[,] Divide(T[,] aX, T[,] bX) => aX.Width() == 1 && bX.Height() == 1
      ? MatrixLinearOperators.op_Division(aX, bX)
      : MatrixZipperOperators.op_Division(aX, bX);
    public static T[,] Concat(T[,] aX, T[,] bX) => aX.Width() == 1 && bX.Height() == 1
      ? MatrixLinearOperators.op_Concatenate(aX, bX)
      : MatrixZipperOperators.op_Concatenate(aX, bX);
    #endregion

    #region "matrix to value"
    public static T[,] And(T[,] aX, T bN) => MatrixToValueOperators.op_BitwiseAnd(aX, bN);
    public static T[,] Or(T[,] aX, T bN) => MatrixToValueOperators.op_BitwiseOr(aX, bN);
    public static T[,] Add(T[,] aX, T bN) => MatrixToValueOperators.op_Addition(aX, bN);
    public static T[,] Subtract(T[,] aX, T bN) => MatrixToValueOperators.op_Subtraction(aX, bN);
    public static T[,] Multiply(T[,] aX, T bN) => MatrixToValueOperators.op_Multiply(aX, bN);
    public static T[,] DivideBy(T[,] aX, T bN) => MatrixToValueOperators.op_Division(aX, bN);
    public static T[,] Concat(T[,] aX, T bN) => MatrixToValueOperators.op_Concatenate(aX, bN);
    #endregion
  }
}