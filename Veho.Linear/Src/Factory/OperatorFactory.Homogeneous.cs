using System;
using System.Linq.Expressions;

namespace Veho.Factory {
  public static partial class OperatorFactory {
    public static (ParameterExpression left, ParameterExpression right) MakeHand<T>() {
      return (Expression.Parameter(typeof(T), "lhs"), Expression.Parameter(typeof(T), "rhs"));
    }

    public static Func<T, T, T> Binary<T>(Func<Expression, Expression, BinaryExpression> @operator) {
      var (left, right) = MakeHand<T>();
      try { return Expression.Lambda<Func<T, T, T>>(@operator(left, right), left, right).Compile(); }
      catch (Exception ex) { return (x, y) => throw new InvalidOperationException(ex.Message); }
    }
  }
}