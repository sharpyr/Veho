using System;
using Generic.Math;

namespace Veho.Tuple {
  public static class Mappers {
    public static (TO x, TO y) Map<T, TO>(this (T x, T y) t, Func<T, TO> f) => (f(t.x), f(t.y));
    public static (TO x, TO y, TO z) Map<T, TO>(this (T x, T y, T z) t, Func<T, TO> f) => (f(t.x), f(t.y), f(t.z));
    public static void Iterate<T, TO>(ref (T x, T y, T z) t, Action<T> f) {
      f(t.x);
      f(t.y);
      f(t.z);
    }
  }

  public static class Zippers {
    public static (T x, T y) Zip<TA, TB, T>(this (TA x, TA y) a, (TB x, TB y) b, Func<TA, TB, T> f) =>
      (f(a.x, b.x), f(a.y, b.y));
    public static (T x, T y) Zip<TA, TB, T>(this (TA x, TA y) a, TB b, Func<TA, TB, T> f) =>
      (f(a.x, b), f(a.y, b));
    public static (T x, T y, T z) Zip<TA, TB, T>(this (TA x, TA y, TA z) a, (TB x, TB y, TB z) b, Func<TA, TB, T> f) =>
      (f(a.x, b.x), f(a.y, b.y), f(a.z, b.z));
    public static (T x, T y, T z) Zip<TA, TB, T>(this (TA x, TA y, TA z) a, TB b, Func<TA, TB, T> f) =>
      (f(a.x, b), f(a.y, b), f(a.z, b));
  }

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