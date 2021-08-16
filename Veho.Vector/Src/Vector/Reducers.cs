using System;

namespace Veho.Vector {
  public static class Reducers {
    public static TO Fold<T, TO>(this T[] vector, Func<TO, T, TO> sequence, TO accum) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) accum = sequence(accum, vector[i]);
      return accum;
    }
    public static TO Fold<T, TO>(this T[] vector, Func<TO, T, TO> sequence, Func<T, TO> indicator) {
      var hi = vector.Length;
      if (hi == 0) return default;
      var accum = indicator(vector[0]);
      for (var i = 1; i < hi; i++) accum = sequence(accum, vector[i]);
      return accum;
    }
    public static T Reduce<T>(this T[] vector, Func<T, T, T> sequence) {
      var hi = vector.Length;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var accum = vector[0];
      for (var i = 1; i < hi; i++) accum = sequence(accum, vector[i]);
      return accum;
    }
    public static TO Reduce<T, TO>(this T[] vector, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      var hi = vector.Length;
      if (hi == 0) return default;
      var accum = indicator(vector[0]);
      for (var i = 1; i < hi; i++) accum = sequence(accum, indicator(vector[i]));
      return accum;
    }

    public static TO Fold<T, TO>(this T[] vector, Func<int, TO, T, TO> sequence, TO accum) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) accum = sequence(i, accum, vector[i]);
      return accum;
    }
    public static TO Fold<T, TO>(this T[] vector, Func<int, TO, T, TO> sequence, Func<T, TO> indicator) {
      var hi = vector.Length;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var accum = indicator(vector[0]);
      for (var i = 1; i < hi; i++) accum = sequence(i, accum, vector[i]);
      return accum;
    }
    public static T Reduce<T>(this T[] vector, Func<int, T, T, T> sequence) {
      var hi = vector.Length;
      if (hi == 0) return default; //throw new IndexOutOfRangeException();
      var accum = vector[0];
      for (var i = 1; i < hi; i++) accum = sequence(i, accum, vector[i]);
      return accum;
    }
    public static TO Reduce<T, TO>(this T[] vector, Func<int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      var hi = vector.Length;
      if (hi == 0) return default;
      var accum = indicator(vector[0]);
      for (var i = 1; i < hi; i++) accum = sequence(i, accum, indicator(vector[i]));
      return accum;
    }
    public static string Join<T>(this T[] vector, Func<T, string> toStr, string de = ", ") =>
      vector.Reduce((acc, cu) => acc + de + cu, toStr) ?? "";
  }
}