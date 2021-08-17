using System;
using System.Collections.Generic;
using Veho.Sequence;

namespace Veho.Mutable.Matrix {
  public static class Sizers {
    public static List<List<T>> Resize<T>(this List<List<T>> rows, int height, int width, T element) {
      var currHeight = rows.Count;
      for (var i = 0; i < Math.Min(currHeight, height); i++) {
        rows[i].Resize(width, element);
      }
      if (currHeight > height) {
        rows.RemoveRange(height, currHeight - height);
      } else if (currHeight < height) {
        if (height > rows.Capacity) rows.Capacity = height; //theights bit is purely an optimisation, to avoid multiple automatic capacity changes.
        rows.AddRange(Mat.Iso(height - currHeight, width, element));
      }
      return rows;
    }
  }
}