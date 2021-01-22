using System;
using System.Linq;

namespace Veho.Matrix {
  public static class Columns {
    // public static P[] MapColumns<T, P>(this T[,] matrix, Func<T[], P> fn) {
    //   var (height, width) = matrix.Size();
    //   for (var i = 0; i < height; i++)
    //     for (var j = 0; j < width; j++)
    //       fn(matrix[i,j]);
    //   
    // }

    public static T[] Column<T>(this T[,] matrix, int columnNumber) {
      return Enumerable.Range(0, matrix.GetLength(0))
        .Select(x => matrix[x, columnNumber])
        .ToArray();
    }

    public static T[] Row<T>(this T[,] matrix, int rowNumber) {
      return Enumerable.Range(0, matrix.GetLength(1))
        .Select(x => matrix[rowNumber, x])
        .ToArray();
    }
  }
}