using System;

namespace Veho.Vector {
  public static class Reducers {
    public static TO Fold<T, TO>(this T[] vector, Func<TO, T, TO> sequence, TO accum) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) accum = sequence(accum, vector[i]);
      return accum;
    }

    public static T Reduce<T>(this T[] vector, Func<T, T, T> sequence) {
      var hi = vector.Length;
      if (hi == 0) throw new IndexOutOfRangeException();
      var accum = vector[0];
      for (var i = 1; i < hi; i++) accum = sequence(accum, vector[i]);
      return accum;
    }

    public static TO Reduce<T, TO>(this T[] vector, Func<TO, TO, TO> sequence, Func<T, TO> indicator) {
      int hi;
      switch (hi = vector.Length) {
        case 0: return default;
        case 1: return indicator(vector[0]);
        default:
          var accum = indicator(vector[0]);
          for (var i = 1; i < hi; i++) accum = sequence(accum, indicator(vector[i]));
          return accum;
      }
    }

    public static TO Fold<T, TO>(this T[] vector, Func<int, TO, T, TO> sequence, TO accum) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) accum = sequence(i, accum, vector[i]);
      return accum;
    }

    public static T Reduce<T>(this T[] vector, Func<int, T, T, T> sequence) {
      var hi = vector.Length;
      if (hi == 0) throw new IndexOutOfRangeException();
      var accum = vector[0];
      for (var i = 1; i < hi; i++) accum = sequence(i, accum, vector[i]);
      return accum;
    }

    public static TO Reduce<T, TO>(this T[] vector, Func<int, TO, TO, TO> sequence, Func<T, TO> indicator) {
      int hi;
      switch (hi = vector.Length) {
        case 0: return default;
        case 1: return indicator(vector[0]);
        default:
          var accum = indicator(vector[0]);
          for (var i = 1; i < hi; i++) accum = sequence(i, accum, indicator(vector[i]));
          return accum;
      }
    }
  }
}