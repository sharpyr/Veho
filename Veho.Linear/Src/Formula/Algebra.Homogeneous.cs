using System;
using System.Linq.Expressions;
using System.Reflection;
using static Veho.Factory.OperatorFactory;

namespace Veho.Formula {
  /// <summary>
  /// Provides standard operators (such as addition) over a single type
  ///
  /// Returns a delegate to evaluate binary addition (+) for the given type; this delegate will throw
  /// an InvalidOperationException if the type T does not provide this operator, or for
  /// Nullable&lt;TInner&gt; if TInner does not provide this operator.
  /// </summary>
  public static class Algebra<T> {
    /// <summary>
    /// Returns the zero value for value-types (even full Nullable&lt;TInner&gt;) - or null for reference types
    /// </summary>
    static readonly Lazy<Func<T, T, T>> andAlso = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.AndAlso), true);
    static readonly Lazy<Func<T, T, T>> orElse = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.OrElse), true);
    static readonly Lazy<Func<T, T, T>> add = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Add), true);
    static readonly Lazy<Func<T, T, T>> subtract = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Subtract), true);
    static readonly Lazy<Func<T, T, T>> divide = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Divide), true);
    static readonly Lazy<Func<T, T, T>> multiply = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Multiply), true);
    static readonly Lazy<Func<T, T, T>> power = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Power), true);

    static Algebra() {
      var type = typeof(T);
      if (
        type.GetTypeInfo().IsValueType &&
        type.GetTypeInfo().IsGenericType &&
        type.GetGenericTypeDefinition() == typeof(Nullable<>)
      ) {
        throw new InvalidOperationException($"Generic math between {nameof(Nullable)} types is not implemented. Type: {typeof(T).FullName} is nullable.");
      }
    }

    public static T Zero { get; } = default(T);
    public static Func<T, T, T> op_BitwiseAnd => andAlso.Value;
    public static Func<T, T, T> op_BitwiseOr => orElse.Value;
    public static Func<T, T, T> op_Addition => add.Value;
    public static Func<T, T, T> op_Subtraction => subtract.Value;
    public static Func<T, T, T> op_Multiply => multiply.Value;
    public static Func<T, T, T> op_Division => divide.Value;
    public static Func<T, T, T> op_Concatenate => power.Value;
  }
}

// static readonly Lazy<Func<T, T>> negate, not;
// static readonly Lazy<Func<T, T, T>> or, and, xor;
// static readonly Lazy<Func<T, T, bool>> equal, notEqual, greaterThan, lessThan, greaterThanOrEqual, lessThanOrEqual;
//
// greaterThan = new Lazy<Func<T, T, bool>>(() => Binary<T, T, bool>(Expression.GreaterThan), true);
// greaterThanOrEqual = new Lazy<Func<T, T, bool>>(() => Binary<T, T, bool>(Expression.GreaterThanOrEqual), true);
// lessThan = new Lazy<Func<T, T, bool>>(() => Binary<T, T, bool>(Expression.LessThan), true);
// lessThanOrEqual = new Lazy<Func<T, T, bool>>(() => Binary<T, T, bool>(Expression.LessThanOrEqual), true);
// equal = new Lazy<Func<T, T, bool>>(() => Binary<T, T, bool>(Expression.Equal), true);
// notEqual = new Lazy<Func<T, T, bool>>(() => Binary<T, T, bool>(Expression.NotEqual), true);
//
// negate = new Lazy<Func<T, T>>(() => Unary<T, T>(Expression.Negate), true);
// and = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.And), true);
// or = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Or), true);
// not = new Lazy<Func<T, T>>(() => Unary<T, T>(Expression.Not), true);
// xor = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.ExclusiveOr), true);