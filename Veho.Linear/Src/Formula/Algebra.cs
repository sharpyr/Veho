namespace Veho.Formula {
  //Based on JonSkeet's MiscUtil: http://www.yoda.arachsys.com/csharp/miscutil/licence.txt
  //From: http://www.yoda.arachsys.com/csharp/miscutil/

  /// <summary>
  /// The Algebra class provides easy access to the standard operators
  /// (addition, etc) for generic types, using type inference to simplify
  /// usage.
  ///
  /// Evaluates binary addition (+) for the given type; this will throw
  /// an InvalidOperationException if the type T does not provide this operator, or for
  /// Nullable&lt;TInner&gt; if TInner does not provide this operator.
  /// </summary>    
  public static class Algebra {
    /// <summary>
    /// Performs a conversion between the given types; this will throw
    /// an InvalidOperationException if the type T does not provide a suitable cast, or for
    /// Nullable&lt;TInner&gt; if TInner does not provide this cast.
    /// </summary>
    public static TO Convert<T, TO>(T value) => Algebra<T, TO>.Convert(value);
    public static T op_BitwiseAnd<T>(T x, T y) => Algebra<T>.op_BitwiseAnd(x, y);
    public static T op_BitwiseOr<T>(T x, T y) => Algebra<T>.op_BitwiseOr(x, y);
    public static T op_Addition<T>(T x, T y) => Algebra<T>.op_Addition(x, y);
    public static T op_Subtraction<T>(T x, T y) => Algebra<T>.op_Subtraction(x, y);
    public static T op_Multiply<T>(T x, T y) => Algebra<T>.op_Multiply(x, y);
    public static T op_Division<T>(T x, T y) => Algebra<T>.op_Division(x, y);
    public static T op_Concatenate<T>(T x, T y) => Algebra<T>.op_Concatenate(x, y);

    public static TA op_BitwiseAnd_Alt<TA, TB>(TA x, TB y) => Algebra<TB, TA>.op_BitwiseAnd(x, y);
    public static TA op_BitwiseOr_Alt<TA, TB>(TA x, TB y) => Algebra<TB, TA>.op_BitwiseOr(x, y);
    public static TA op_Addition_Alt<TA, TB>(TA x, TB y) => Algebra<TB, TA>.op_Addition(x, y);
    public static TA op_Subtraction_Alt<TA, TB>(TA x, TB y) => Algebra<TB, TA>.op_Subtraction(x, y);
    public static TA op_Multiply_Alt<TA, TB>(TA x, TB y) => Algebra<TB, TA>.op_Multiply(x, y);
    public static TA op_Division_Alt<TA, TB>(TA x, TB y) => Algebra<TB, TA>.op_Division(x, y);
    public static TA op_Concatenate_Alt<TA, TB>(TA x, TB y) => Algebra<TB, TA>.op_Concatenate(x, y);

    public static T op_Division_Int<T>(T value, int divisor) => Algebra<int, T>.op_Division(value, divisor);
  }
}