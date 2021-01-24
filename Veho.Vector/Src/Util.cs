﻿using System;

namespace Veho.Vector {
  public static class Util {
    public static T Swap<T>(this T[] vector, int i, int j) {
      var temp = vector[i];
      vector[i] = vector[j];
      return vector[j] = temp;
    }

    public static T[] Reverse<T>(this T[] arr) {
      Array.Reverse(arr);
      return arr;
    }

    public static void Resize<T>(this T[] vector, int len) => Array.Resize(ref vector, len);
  }
}