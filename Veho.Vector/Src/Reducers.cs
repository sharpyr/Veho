using System;

namespace Veho.Vector {
  public static class Reducers {
    public static T Reduce<T>(this T[] vector, Func<T, T, T> sequence) {
      int hi = vector.Length;
      if (hi == 0) throw new IndexOutOfRangeException();
      var accum = vector[0];
      for (var i = 1; i < hi; i++) accum = sequence(accum, vector[i]);
      return accum;
    }

    public static P Fold<T, P>(this T[] vector, Func<P, T, P> sequence, P accum) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) accum = sequence(accum, vector[i]);
      return accum;
    }

    public static P MapReduce<T, P>(this T[] vector, Func<P, P, P> sequence, Func<T, P> indicator) {
      int hi;
      switch (hi = vector.Length) {
        case 0:
        case 1: return indicator(vector[0]);
        default:
          var accum = indicator(vector[0]);
          for (var i = 1; i < hi; i++) accum = sequence(accum, indicator(vector[i]));
          return accum;
      }
    }
  }
}