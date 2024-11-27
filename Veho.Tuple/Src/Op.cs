using Veho.Tuple;
using static Generic.Math.GenericMath;
using Gen = Generic.Math.GenericMath;

namespace Veho {
  public static partial class Op {
    public static bool Equals<T>(this (T x, T y) a, (T x, T y) b) => Equal(a.x, b.x) && Equal(a.y, b.y);
    public static (T x, T y) BitwiseAnd<T>(this (T, T) a, (T, T) b) => a.Zip(b, And);        // op_BitwiseAnd
    public static (T x, T y) BitwiseOr<T>(this (T, T) a, (T, T) b) => a.Zip(b, Or);          // op_BitwiseOr
    public static (T x, T y) Add<T>(this (T, T) a, (T, T) b) => a.Zip(b, Gen.Add);           // op_Addition
    public static (T x, T y) Minus<T>(this (T, T) a, (T, T) b) => a.Zip(b, Subtract);        // op_Subtraction
    public static (T x, T y) Multiply<T>(this (T, T) a, (T, T) b) => a.Zip(b, Gen.Multiply); // op_Multiply
    public static (T x, T y) DivideBy<T>(this (T, T) a, (T, T) b) => a.Zip(b, Divide);       // op_Division

    public static (T x, T y) BitwiseAnd<T>(this (T, T) a, T v) => a.Zip(v, And);
    public static (T x, T y) BitwiseOr<T>(this (T, T) a, T v) => a.Zip(v, Or);
    public static (T x, T y) Add<T>(this (T, T) a, T v) => a.Zip(v, Gen.Add);
    public static (T x, T y) Minus<T>(this (T, T) a, T v) => a.Zip(v, Subtract);
    public static (T x, T y) Multiply<T>(this (T, T) a, T v) => a.Zip(v, Gen.Multiply);
    public static (T x, T y) DivideBy<T>(this (T, T) a, T v) => a.Zip(v, Divide);
  }

  public static partial class Op {
    public static bool Equals<T>(this (T x, T y, T z) a, (T x, T y, T z) b) => Equal(a.x, b.x) && Equal(a.y, b.y) && Equal(a.z, b.z);
    public static (T x, T y, T z) BitwiseAnd<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, And);
    public static (T x, T y, T z) BitwiseOr<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, Or);
    public static (T x, T y, T z) Add<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, Gen.Add);
    public static (T x, T y, T z) Minus<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, Subtract);
    public static (T x, T y, T z) Multiply<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, Gen.Multiply);
    public static (T x, T y, T z) DivideBy<T>(this (T, T, T) a, (T, T, T) b) => a.Zip(b, Divide);

    public static (T x, T y, T z) BitwiseAnd<T>(this (T, T, T) a, T v) => a.Zip(v, And);
    public static (T x, T y, T z) BitwiseOr<T>(this (T, T, T) a, T v) => a.Zip(v, Or);
    public static (T x, T y, T z) Add<T>(this (T, T, T) a, T v) => a.Zip(v, Gen.Add);
    public static (T x, T y, T z) Minus<T>(this (T, T, T) a, T v) => a.Zip(v, Subtract);
    public static (T x, T y, T z) Multiply<T>(this (T, T, T) a, T v) => a.Zip(v, Gen.Multiply);
    public static (T x, T y, T z) DivideBy<T>(this (T, T, T) a, T v) => a.Zip(v, Divide);
  }
}