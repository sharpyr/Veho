using System;

namespace Veho.Vector {
  public static class Inits {
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

    public static readonly int[] SingleOne = {1};

    public static T[] V1B<T>(int len) => (T[]) Array.CreateInstance(typeof(T), new[] {len}, SingleOne);
  }
}