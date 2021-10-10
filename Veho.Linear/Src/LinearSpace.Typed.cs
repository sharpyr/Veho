using System.Collections.Generic;
using Veho.Matrix;
using Veho.Utils;

namespace Veho {
  public static class LinearSpace<T> {
    public static T[] op_BitwiseAnd(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Vector.ZipperSpace.op_BitwiseAnd(vector, another);
    public static T[] op_BitwiseOr(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Vector.ZipperSpace.op_BitwiseOr(vector, another);
    public static T[] op_Addition(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Vector.ZipperSpace.op_Addition(vector, another);
    public static T[] op_Subtraction(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Vector.ZipperSpace.op_Subtraction(vector, another);
    public static T[] op_Multiply(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Vector.ZipperSpace.op_Multiply(vector, another);
    public static T[] op_Division(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Vector.ZipperSpace.op_Division(vector, another);
    public static T[] op_Concatenate(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Vector.ZipperSpace.op_Concatenate(vector, another);

    public static T[] op_BitwiseAnd(IReadOnlyList<T> vector, T point) => Vector.PointSpace.op_BitwiseAnd(vector, point);
    public static T[] op_BitwiseOr(IReadOnlyList<T> vector, T point) => Vector.PointSpace.op_BitwiseOr(vector, point);
    public static T[] op_Addition(IReadOnlyList<T> vector, T point) => Vector.PointSpace.op_Addition(vector, point);
    public static T[] op_Subtraction(IReadOnlyList<T> vector, T point) => Vector.PointSpace.op_Subtraction(vector, point);
    public static T[] op_Multiply(IReadOnlyList<T> vector, T point) => Vector.PointSpace.op_Multiply(vector, point);
    public static T[] op_Division(IReadOnlyList<T> vector, T point) => Vector.PointSpace.op_Division(vector, point);
    public static T[] op_Concatenate(IReadOnlyList<T> vector, T point) => Vector.PointSpace.op_Concatenate(vector, point);


    public static T[,] op_BitwiseAnd(T[,] matrix, T[,] another) => matrix.ColToRow(another) ? ProductSpace.op_BitwiseAnd(matrix, another) : ZipperSpace.op_BitwiseAnd(matrix, another);
    public static T[,] op_BitwiseOr(T[,] matrix, T[,] another) => matrix.ColToRow(another) ? ProductSpace.op_BitwiseOr(matrix, another) : ZipperSpace.op_BitwiseOr(matrix, another);
    public static T[,] op_Addition(T[,] matrix, T[,] another) => matrix.ColToRow(another) ? ProductSpace.op_Addition(matrix, another) : ZipperSpace.op_Addition(matrix, another);
    public static T[,] op_Subtraction(T[,] matrix, T[,] another) => matrix.ColToRow(another) ? ProductSpace.op_Subtraction(matrix, another) : ZipperSpace.op_Subtraction(matrix, another);
    public static T[,] op_Multiply(T[,] matrix, T[,] another) => matrix.ColToRow(another) ? ProductSpace.op_Multiply(matrix, another) : ZipperSpace.op_Multiply(matrix, another);
    public static T[,] op_Division(T[,] matrix, T[,] another) => matrix.ColToRow(another) ? ProductSpace.op_Division(matrix, another) : ZipperSpace.op_Division(matrix, another);
    public static T[,] op_Concatenate(T[,] matrix, T[,] another) => matrix.ColToRow(another) ? ProductSpace.op_Concatenate(matrix, another) : ZipperSpace.op_Concatenate(matrix, another);

    public static T[,] op_BitwiseAnd(T[,] matrix, T point) => PointSpace.op_BitwiseAnd(matrix, point);
    public static T[,] op_BitwiseOr(T[,] matrix, T point) => PointSpace.op_BitwiseOr(matrix, point);
    public static T[,] op_Addition(T[,] matrix, T point) => PointSpace.op_Addition(matrix, point);
    public static T[,] op_Subtraction(T[,] matrix, T point) => PointSpace.op_Subtraction(matrix, point);
    public static T[,] op_Multiply(T[,] matrix, T point) => PointSpace.op_Multiply(matrix, point);
    public static T[,] op_Division(T[,] matrix, T point) => PointSpace.op_Division(matrix, point);
    public static T[,] op_Concatenate(T[,] matrix, T point) => PointSpace.op_Concatenate(matrix, point);
  }
}