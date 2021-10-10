using System;
using System.Linq.Expressions;
using static Veho.Factory.OperatorFactory;

namespace Veho.Formula {
  /// <summary>
  /// Provides standard operators (such as addition) that operate over operands of
  /// different types. For operators, the return type is assumed to match the first
  /// operand.
  ///
  /// Returns a delegate to convert a value between two types
  /// Returns a delegate to evaluate binary addition (+) for the given types; this delegate will throw
  /// an InvalidOperationException if the type T does not provide this operator, or for
  /// Nullable&lt;TInner&gt; if TInner does not provide this operator.
  /// </summary>
  public static class Algebra<TV, TO> {
    private static readonly Lazy<Func<TV, TO>> convert = new Lazy<Func<TV, TO>>(() => Unary<TV, TO>(body => Expression.Convert(body, typeof(TO))), true);
    private static readonly Lazy<Func<TO, TV, TO>> andAlso = new Lazy<Func<TO, TV, TO>>(() => Binary<TO, TV, TO>(Expression.AndAlso, true), true);
    private static readonly Lazy<Func<TO, TV, TO>> orElse = new Lazy<Func<TO, TV, TO>>(() => Binary<TO, TV, TO>(Expression.OrElse, true), true);
    private static readonly Lazy<Func<TO, TV, TO>> add = new Lazy<Func<TO, TV, TO>>(() => Binary<TO, TV, TO>(Expression.Add, true), true);
    private static readonly Lazy<Func<TO, TV, TO>> subtract = new Lazy<Func<TO, TV, TO>>(() => Binary<TO, TV, TO>(Expression.Subtract, true), true);
    private static readonly Lazy<Func<TO, TV, TO>> multiply = new Lazy<Func<TO, TV, TO>>(() => Binary<TO, TV, TO>(Expression.Multiply, true), true);
    private static readonly Lazy<Func<TO, TV, TO>> divide = new Lazy<Func<TO, TV, TO>>(() => Binary<TO, TV, TO>(Expression.Divide, true), true);
    private static readonly Lazy<Func<TO, TV, TO>> power = new Lazy<Func<TO, TV, TO>>(() => Binary<TO, TV, TO>(Expression.Power, true), true);

    // static Algebra() { }

    public static Func<TV, TO> Convert => convert.Value;

    public static Func<TO, TV, TO> op_BitwiseAnd => andAlso.Value;
    public static Func<TO, TV, TO> op_BitwiseOr => orElse.Value;
    public static Func<TO, TV, TO> op_Addition => add.Value;
    public static Func<TO, TV, TO> op_Subtraction => subtract.Value;
    public static Func<TO, TV, TO> op_Multiply => multiply.Value;
    public static Func<TO, TV, TO> op_Division => divide.Value;
    public static Func<TO, TV, TO> op_Concatenate => power.Value;
  }
}