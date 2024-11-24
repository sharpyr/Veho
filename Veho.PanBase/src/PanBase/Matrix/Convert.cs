using System;
using Veho.Matrix;
using static System.Convert;

namespace Veho.PanBase.Matrix {
  public static class Convert {
    public static T[,] ZeroOut<T>(this T[,] matrix) => matrix.Rebase();

    public static TO[,] ZeroOut<T, TO>(this T[,] matrix) => matrix.Rebase<T, TO>();

    public static TO[,] ZeroOut<T, TO>(this T[,] matrix, Func<T, TO> func) => matrix.Rebase(func);
  }
}