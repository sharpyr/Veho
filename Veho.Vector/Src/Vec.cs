using System;

namespace Veho {
  public static class Vec {
    public static T[] Init<T>(int len, Func<int, T> func) {
      var vec = new T[len];
      for (var i = 0; i < len; i++) vec[i] = func(i);
      return vec;
    }

    public static T[] From<T>(params T[] elements) => elements;

    public static T[] Iso<T>(int len, T value) {
      var vec = new T[len];
      for (var i = 0; i < len; i++) vec[i] = value;
      return vec;
    }

    private static readonly int[] SingleOne = { 1 };

    public static Array V1B<T>(int len) => Array.CreateInstance(typeof(T), new[] { len }, SingleOne);

    public static int Push<T>(ref T[] vector, T val) {
      var hi = vector.Length;
      var len = hi + 1;
      Array.Resize(ref vector, len);
      vector[hi] = val;
      return vector.Length;
    }

    public static TA[] MutaZip<TA, TB>(ref TA[] vector, TB[] arr, Func<TA, TB, TA> func) {
      var hi = vector.Length;
      for (var i = 0; i < hi; i++) vector[i] = func(vector[i], arr[i]);
      return vector;
    }
  }
}