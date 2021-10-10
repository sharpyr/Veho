using System;
using System.Linq.Expressions;

namespace Veho.Factory {
  //From JonSkeet's MiscUtil: http://www.yoda.arachsys.com/csharp/miscutil/licence.txt
  //From: http://www.yoda.arachsys.com/csharp/miscutil/

  /// <summary>
  /// General purpose Expression utilities
  /// </summary>
  public static partial class OperatorFactory {


    /// <summary>
    /// Create a function delegate representing a unary operation
    /// </summary>
    /// <typeparam name="TA">The parameter type</typeparam>
    /// <typeparam name="TO">The return type</typeparam>
    /// <param name="body">Body factory</param>
    /// <returns>Compiled function delegate</returns>
    public static Func<TA, TO> Unary<TA, TO>(Func<Expression, UnaryExpression> body) {
      ParameterExpression inp = Expression.Parameter(typeof(TA), "inp");
      try { return Expression.Lambda<Func<TA, TO>>(body(inp), inp).Compile(); }
      catch (Exception ex) { return x => throw new InvalidOperationException(ex.Message); }
    }
    
  

    /// <summary>
    /// Create a function delegate representing a binary operation
    /// </summary>
    /// <typeparam name="TA">The first parameter type</typeparam>
    /// <typeparam name="TB">The second parameter type</typeparam>
    /// <typeparam name="TO">The return type</typeparam>
    /// <param name="operator">Body factory</param>
    /// <returns>Compiled function delegate</returns>
    public static Func<TA, TB, TO> Binary<TA, TB, TO>(Func<Expression, Expression, BinaryExpression> @operator) {
      return Binary<TA, TB, TO>(@operator, false);
    }

    /// <summary>
    /// Create a function delegate representing a binary operation
    /// </summary>
    /// <param name="castArgsToResultOnFailure">
    /// If no matching operation is possible, attempt to convert
    /// TA and TB to TO for a match? For example, there is no
    /// "decimal operator /(decimal, int)", but by converting TB (int) to
    /// TO (decimal) a match is found.
    /// </param>
    /// <typeparam name="TA">The first parameter type</typeparam>
    /// <typeparam name="TB">The second parameter type</typeparam>
    /// <typeparam name="TO">The return type</typeparam>
    /// <param name="operator">Body factory</param>
    /// <returns>Compiled function delegate</returns>
    public static Func<TA, TB, TO> Binary<TA, TB, TO>(Func<Expression, Expression, BinaryExpression> @operator, bool castArgsToResultOnFailure) {
      ParameterExpression lhs = Expression.Parameter(typeof(TA), "lhs"), rhs = Expression.Parameter(typeof(TB), "rhs");
      try {
        try { return Expression.Lambda<Func<TA, TB, TO>>(@operator(lhs, rhs), lhs, rhs).Compile(); }
        catch (InvalidOperationException) {
          if (castArgsToResultOnFailure && !( // if we show retry                                                        
            typeof(TA) == typeof(TO) &&       // and the args aren't
            typeof(TB) == typeof(TO))) {      // already "TValue, TValue, TValue"...
            // convert both lhs and rhs to TO (as appropriate)
            Expression castLhs = typeof(TA) == typeof(TO) ? (Expression)lhs : (Expression)Expression.Convert(lhs, typeof(TO));
            Expression castRhs = typeof(TB) == typeof(TO) ? (Expression)rhs : (Expression)Expression.Convert(rhs, typeof(TO));

            return Expression.Lambda<Func<TA, TB, TO>>(
              @operator(castLhs, castRhs), lhs, rhs).Compile();
          }
          else throw;
        }
      }
      catch (Exception ex) {
        return (x, y) => throw new InvalidOperationException(ex.Message);
      }
    }
  }
}