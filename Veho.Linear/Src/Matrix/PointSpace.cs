using System;
using Veho.Formula;

namespace Veho.Matrix {
  public static class PointSpace {
    private static T[,] Op<T>(T[,] matrix, T point, Func<T, T, T> @operator) {
      // var @operator = OperatorFactory.ParseElementOperator(func);
      return matrix.Map(it => @operator(it, point));
    }
    public static T[,] op_BitwiseAnd<T>(T[,] matrix, T point) => Op(matrix, point, Algebra<T>.op_BitwiseAnd);
    public static T[,] op_BitwiseOr<T>(T[,] matrix, T point) => Op(matrix, point, Algebra<T>.op_BitwiseOr);
    public static T[,] op_Addition<T>(T[,] matrix, T point) => Op(matrix, point, Algebra<T>.op_Addition);
    public static T[,] op_Subtraction<T>(T[,] matrix, T point) => Op(matrix, point, Algebra<T>.op_Subtraction);
    public static T[,] op_Multiply<T>(T[,] matrix, T point) => Op(matrix, point, Algebra<T>.op_Multiply);
    public static T[,] op_Division<T>(T[,] matrix, T point) => Op(matrix, point, Algebra<T>.op_Division);
    public static T[,] op_Concatenate<T>(T[,] matrix, T point) => Op(matrix, point, Algebra<T>.op_Concatenate);
  }
}