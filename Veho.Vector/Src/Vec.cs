using System;

namespace Veho.Vector {
  public static class Vec {
    public static T[] Init<T>(int len, Func<int, T> func) {
      var vec = new T[len];
      for (var i = 0; i < len; i++) vec[i] = func(i);
      return vec;
    }

    public static T[] Iso<T>(int len, T value) {
      var vec = new T[len];
      for (var i = 0; i < len; i++) vec[i] = value;
      return vec;
    }

    private static readonly int[] SingleOne = {1};

    public static Array V1B<T>(int len) => Array.CreateInstance(typeof(T), new[] {len}, SingleOne);

    public static int Push<T>(ref T[] vector, T element) {
      var hi = vector.Length;
      var len = hi + 1;
      Array.Resize(ref vector, len);
      vector[hi] = element;
      return vector.Length;
    }

    public static TA[] MutaZip<TA, TB>(ref TA[] vector, TB[] another, Func<TA, TB, TA> fn) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) vector[i] = fn(vector[i], another[i]);
      return vector;
    }
  }
}