﻿using System;
using System.Collections.Generic;
using Veho.Matrix;

namespace Veho.Mutable.Matrix {
  public static class Zippers {
    public static List<List<T>> Zip<TA, TB, T>(this List<List<TA>> rowsA, List<List<TB>> rowsB, Func<TA, TB, T> fn) {
      var target = new List<List<T>>(rowsA.Count);
      List<T> rowT;
      for (int i = 0, h = rowsA.Count; i < h; i++) {
        var rowA = rowsA[i];
        var rowB = rowsB[i];
        target[i] = rowT = new List<T>(h);
        for (int j = 0, w = rowA.Count; j < w; j++)
          rowT[j] = fn(rowA[j], rowB[j]);
      }
      return target;
    }
    public static void IterZip<TA, TB>(this List<List<TA>> rowsA, List<List<TB>> rowsB, Action<TA, TB> action) {
      for (int i = 0, h = rowsA.Count; i < h; i++) {
        var rowA = rowsA[i];
        var rowB = rowsB[i];
        for (int j = 0, w = rowA.Count; j < w; j++)
          action(rowA[j], rowB[j]);
      }
    }
    public static List<List<TA>> MutaZip<TA, TB>(this List<List<TA>> rowsA, List<List<TB>> rowsB, Func<TA, TB, TA> fn) {
      for (int i = 0, h = rowsA.Count; i < h; i++) {
        var rowA = rowsA[i];
        var rowB = rowsB[i];
        for (int j = 0, w = rowA.Count; j < w; j++)
          rowA[j] = fn(rowA[j], rowB[j]);
      }
      return rowsA;
    }


    public static List<List<T>> Zip<TA, TB, T>(this List<List<TA>> rowsA, List<List<TB>> rowsB, Func<int, int, TA, TB, T> fn) {
      var target = new List<List<T>>(rowsA.Count);
      List<T> rowT;
      for (int i = 0, h = rowsA.Count; i < h; i++) {
        var rowA = rowsA[i];
        var rowB = rowsB[i];
        target[i] = rowT = new List<T>(h);
        for (int j = 0, w = rowA.Count; j < w; j++)
          rowT[j] = fn(i, j, rowA[j], rowB[j]);
      }
      return target;
    }
    public static void IterZip<TA, TB>(this List<List<TA>> rowsA, List<List<TB>> rowsB, Action<int, int, TA, TB> action) {
      for (int i = 0, h = rowsA.Count; i < h; i++) {
        var rowA = rowsA[i];
        var rowB = rowsB[i];
        for (int j = 0, w = rowA.Count; j < w; j++)
          action(i, j, rowA[j], rowB[j]);
      }
    }
    public static List<List<TA>> MutaZip<TA, TB>(this List<List<TA>> rowsA, List<List<TB>> rowsB, Func<int, int, TA, TB, TA> fn) {
      for (int i = 0, h = rowsA.Count; i < h; i++) {
        var rowA = rowsA[i];
        var rowB = rowsB[i];
        for (int j = 0, w = rowA.Count; j < w; j++)
          rowA[j] = fn(i, j, rowA[j], rowB[j]);
      }
      return rowsA;
    }
  }
}