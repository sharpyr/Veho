using System;
using System.Collections.Generic;
using Veho.Formula;

namespace Veho.Vector {
  public static class ZipperSpace {
    public static T[] Op<T>(IReadOnlyList<T> vector, IReadOnlyList<T> another, Func<T, T, T> @operator) {
      return @operator.Zipper(vector, another);
      // return OperatorFactory.ParseElementOperator(@operator).Zipper(vector, another);
    }
    public static T[] op_BitwiseAnd<T>(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Op(vector, another, Algebra<T>.op_BitwiseAnd);
    public static T[] op_BitwiseOr<T>(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Op(vector, another, Algebra<T>.op_BitwiseOr);
    public static T[] op_Addition<T>(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Op(vector, another, Algebra<T>.op_Addition);
    public static T[] op_Subtraction<T>(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Op(vector, another, Algebra<T>.op_Subtraction);
    public static T[] op_Multiply<T>(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Op(vector, another, Algebra<T>.op_Multiply);
    public static T[] op_Division<T>(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Op(vector, another, Algebra<T>.op_Division);
    public static T[] op_Concatenate<T>(IReadOnlyList<T> vector, IReadOnlyList<T> another) => Op(vector, another, Algebra<T>.op_Concatenate);
  }
}