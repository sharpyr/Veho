using System;

namespace Veho.Vector {
  public static class Updater {
    public static T[] Push<T>(this T[] vec, T val) {
      int ind = vec.Length, len = ind + 1;
      Array.Resize(ref vec, len);
      vec[ind] = val;
      return vec;
    }

    public static T[] Unshift<T>(this T[] vec, T val) {
      int ind = vec.Length, len = ind + 1;
      Array.Resize(ref vec, len);
      Array.Copy(vec, 0, vec, 1, ind);
      vec[0] = val;
      return vec;
    }
    public static T[] Acquire<T>(this T[] vec, T[] arr) {
      int ind = vec.Length, len = arr.Length;
      Array.Resize(ref vec, ind + len);
      Array.Copy(arr, 0, vec, ind, len);
      return vec;
    }
    public static T[] Merge<T>(this T[] vec, T[] arr) {
      int ind = vec.Length, len = arr.Length;
      var target = new T[ind + len];
      Array.Copy(vec, 0, target, 0, ind);
      Array.Copy(arr, 0, target, ind, len);
      return target;
    }
  }
}