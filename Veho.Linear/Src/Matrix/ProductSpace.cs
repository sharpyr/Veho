using System;
using Veho.Formula;

namespace Veho.Matrix {
  public static class ProductSpace {
    private static T[,] Op<T>(T[,] matrix, T[,] another, Func<T, T, T> @operator) {
      return LinearOperator.Cross<T>(matrix, another, @operator);
      // return LinearOperator.Cross(matrix, another, OperatorFactory.ParseElementOperator(func));
    }
    public static T[,] op_BitwiseAnd<T>(T[,] matrix, T[,] another) => Op(matrix, another, Algebra<T>.op_BitwiseAnd);
    public static T[,] op_BitwiseOr<T>(T[,] matrix, T[,] another) => Op(matrix, another, Algebra<T>.op_BitwiseOr);
    public static T[,] op_Addition<T>(T[,] matrix, T[,] another) => Op(matrix, another, Algebra<T>.op_Addition);
    public static T[,] op_Subtraction<T>(T[,] matrix, T[,] another) => Op(matrix, another, Algebra<T>.op_Subtraction);
    public static T[,] op_Multiply<T>(T[,] matrix, T[,] another) => Op(matrix, another, Algebra<T>.op_Multiply);
    public static T[,] op_Division<T>(T[,] matrix, T[,] another) => Op(matrix, another, Algebra<T>.op_Division);
    public static T[,] op_Concatenate<T>(T[,] matrix, T[,] another) => Op(matrix, another, Algebra<T>.op_Concatenate);
  }
}