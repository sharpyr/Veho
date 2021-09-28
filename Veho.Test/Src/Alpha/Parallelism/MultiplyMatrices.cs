using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;
using Veho.Matrix;

namespace Veho.Test.Alpha.Parallelism {
  [TestFixture]
  public class MultiplyMatrices {
    static void MultiplyMatricesSequential(double[,] matA, double[,] matB,
                                           double[,] result) {
      int height = matA.Height(), interim = matA.Width(), width = matB.Width();
      for (var i = 0; i < height; i++) {
        for (var j = 0; j < width; j++) {
          double temp = 0;
          for (var k = 0; k < interim; k++) temp += matA[i, k] * matB[k, j];
          result[i, j] += temp;
        }
      }
    }
 
    static void MultiplyMatricesParallel(double[,] matA, double[,] matB, double[,] result) {
      int height = matA.Height(), interim = matA.Width(), width = matB.Width();
      // A basic matrix multiplication.
      // Parallelize the outer loop to partition the source array by rows.
      Parallel.For(0, height, i => {
        for (var j = 0; j < width; j++) {
          double accum = 0;
          for (var k = 0; k < interim; k++) accum += matA[i, k] * matB[k, j];
          result[i, j] = accum;
        }
      }); // Parallel.For
    }
 

    #region Main
    [Test]
    public void MultiplyMatricesTest() {
      // Set up matrices. Use small values to better view
      // result matrix. Increase the counts to see greater
      // speedup in the parallel loop vs. the sequential loop.
      int colCount = 180;
      int rowCount = 2000;
      int colCount2 = 270;
      double[,] m1 = InitializeMatrix(rowCount, colCount);
      double[,] m2 = InitializeMatrix(colCount, colCount2);
      double[,] result = new double[rowCount, colCount2];

      // First do the sequential version.
      Console.Error.WriteLine("Executing sequential loop...");
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      MultiplyMatricesSequential(m1, m2, result);
      stopwatch.Stop();
      Console.Error.WriteLine("Sequential loop time in milliseconds: {0}",
        stopwatch.ElapsedMilliseconds);

      // For the skeptics.
      OfferToPrint(rowCount, colCount2, result);

      // Reset timer and results matrix.
      stopwatch.Reset();
      result = new double[rowCount, colCount2];

      // Do the parallel loop.
      Console.Error.WriteLine("Executing parallel loop...");
      stopwatch.Start();
      MultiplyMatricesParallel(m1, m2, result);
      stopwatch.Stop();
      Console.Error.WriteLine("Parallel loop time in milliseconds: {0}",
        stopwatch.ElapsedMilliseconds);
      OfferToPrint(rowCount, colCount2, result);

      // Keep the console window open in debug mode.
      Console.Error.WriteLine("Press any key to exit.");
      // Console.ReadKey();
    }
    #endregion

    #region Helper_Methods
    static double[,] InitializeMatrix(int rows, int cols) {
      double[,] matrix = new double[rows, cols];

      Random r = new Random();
      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
          matrix[i, j] = r.Next(100);
        }
      }
      return matrix;
    }

    private static void OfferToPrint(int rowCount, int colCount, double[,] matrix) {
      if (!Console.IsOutputRedirected) Console.WindowWidth = 180;
      Console.WriteLine();
      for (int x = 0; x < rowCount; x++) {
        Console.WriteLine("ROW {0}: ", x);
        for (int y = 0; y < colCount; y++) {
          Console.Write("{0:#.##} ", matrix[x, y]);
        }
        Console.WriteLine();
      }
    }
    #endregion
  }
}