using Generic.Math;

namespace Veho {
  public static partial class Op {
    public static (T x, T y) BitwiseAnd<T>(this (T, T) a, (T, T) b) => a.Zip(b, GenericMath<T>.And); // op_BitwiseAnd
    public static (T x, T y) BitwiseOr<T>(this (T, T) a, (T, T) b) => a.Zip(b, GenericMath<T>.Or); // op_BitwiseOr
    public static (T x, T y) Add<T>(this (T, T) a, (T, T) b) => a.Zip(b, GenericMath<T>.Add); // op_Addition
    public static (T x, T y) Minus<T>(this (T, T) a, (T, T) b) => a.Zip(b, GenericMath<T>.Subtract); // op_Subtraction
    public static (T x, T y) Multiply<T>(this (T, T) a, (T, T) b) => a.Zip(b, GenericMath<T>.Multiply); // op_Multiply
    public static (T x, T y) DivideBy<T>(this (T, T) a, (T, T) b) => a.Zip(b, GenericMath<T>.Divide); // op_Division

    public static (T x, T y) BitwiseAnd<T>(this (T, T) a, T v) => a.Zip(v, GenericMath<T>.And);
    public static (T x, T y) BitwiseOr<T>(this (T, T) a, T v) => a.Zip(v, GenericMath<T>.Or);
    public static (T x, T y) Add<T>(this (T, T) a, T v) => a.Zip(v, GenericMath<T>.Add);
    public static (T x, T y) Minus<T>(this (T, T) a, T v) => a.Zip(v, GenericMath<T>.Subtract);
    public static (T x, T y) Multiply<T>(this (T, T) a, T v) => a.Zip(v, GenericMath<T>.Multiply);
    public static (T x, T y) DivideBy<T>(this (T, T) a, T v) => a.Zip(v, GenericMath<T>.Divide);
  }

  public static partial class Op {
    public static (T x, T y, T z) BitwiseAnd<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, GenericMath<T>.And);
    public static (T x, T y, T z) BitwiseOr<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, GenericMath<T>.Or);
    public static (T x, T y, T z) Add<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, GenericMath<T>.Add);
    public static (T x, T y, T z) Minus<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, GenericMath<T>.Subtract);
    public static (T x, T y, T z) Multiply<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, GenericMath<T>.Multiply);
    public static (T x, T y, T z) DivideBy<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, GenericMath<T>.Divide);

    public static (T x, T y, T z) BitwiseAnd<T>(this (T, T, T) a, T v) => a.Zip(v, GenericMath<T>.And);
    public static (T x, T y, T z) BitwiseOr<T>(this (T, T, T) a, T v) => a.Zip(v, GenericMath<T>.Or);
    public static (T x, T y, T z) Add<T>(this (T, T, T) a, T v) => a.Zip(v, GenericMath<T>.Add);
    public static (T x, T y, T z) Minus<T>(this (T, T, T) a, T v) => a.Zip(v, GenericMath<T>.Subtract);
    public static (T x, T y, T z) Multiply<T>(this (T, T, T) a, T v) => a.Zip(v, GenericMath<T>.Multiply);
    public static (T x, T y, T z) DivideBy<T>(this (T, T, T) a, T v) => a.Zip(v, GenericMath<T>.Divide);
  }
}