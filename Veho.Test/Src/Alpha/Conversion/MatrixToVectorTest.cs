using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Analys;
using NUnit.Framework;
using Palett;
using Spare;
using Texting;
using Valjoux;
using Veho.Enumerable;
using Veho.Matrix;
using Veho.Rows;
using Veho.Test.Utils;
using Veho.Types;
using Veho.Vector;

namespace Veho.Test.Alpha.Conversion {
  public static class StrategyFactory {
    public static void CopyStrategies<T>(int count, IReadOnlyList<T[,]> matrices) {
      var parameters = Veho.Sequence.Zippers.Zip<T[,], string, (string, T[,])>(matrices, GreekAlphabets.Alphabets, (matrix, alpha) => (alpha, matrix));
      var (elapsed, result) = Strategies.Run(
        (int)count,
        Seq.From<(string, Func<T[,], T[]>)>(
          ("arch", matrix => matrix.ToVectorArch()),
          ("edge", matrix => matrix.ToVectorEdge()),
          ("epic", matrix => matrix.ToVectorEpic()),
          ("salt", matrix => matrix.IntoIter().ToArray())
        ),
        parameters
      );
      elapsed.Deco(orient: Operated.Rowwise, presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");
      result.Deco().Logger("Result");
      var candidates = Seq.From(
        ("alpha", "arch"),
        ("alpha", "edge"),
        ("alpha", "epic"),
        ("alpha", "salt"),
        ("beta", "arch"),
        ("beta", "edge"),
        ("beta", "epic"),
        ("beta", "salt")
      );
      foreach (var (side, head) in candidates) {
        result[side, head].Deco().Says(side + "-" + head);
      }
    }
  }

  [Ignore("ignore MatrixToVectorTest")]
  [TestFixture]
  public class MatrixToVectorTest {
    [Test]
    // [Ignore("Ignore a strategy")]
    public static void IntStrategies() {
      var matrices = Seq.From(
        (3, 3).Init((x, y) => x * 10 + y),
        (10, 10).Init((x, y) => x == y ? x + y : 0),
        (32, 16).Init((x, y) => y),
        (16, 32).Init((x, y) => x) // '*'.Repeat(y)
      );
      StrategyFactory.CopyStrategies((int)1E+5, matrices);
    }
    [Test]
    // [Ignore("Ignore a strategy")]
    public static void StringStrategies() {
      var matrices = Seq.From(
        (3, 3).Init((x, y) => '*'.Repeat(x * 10 + y)),
        (10, 10).Init((x, y) => '*'.Repeat(x == y ? x + y : 0)),
        (32, 16).Init((x, y) => '*'.Repeat(y)),
        (16, 32).Init((x, y) => '*'.Repeat(x)) // '*'.Repeat(y)
      );
      StrategyFactory.CopyStrategies((int)5E+4, matrices);
    }
  }

  public static partial class Copiers {
    public static T[] ToVectorArch<T>(this T[,] matrix) {
      var count = matrix.Length;
      var vector = new T[count];
      var (h, w) = matrix.Size();
      var k = 0;
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          vector[k++] = matrix[i, j];
      return vector;
    }
    public static T[] ToVectorPrim<T>(this T[,] matrix) {
      var count = matrix.Length;
      var vector = new T[count];
      Buffer.BlockCopy(matrix, 0, vector, 0, count * Marshal.SizeOf(default(T)));
      return vector;
    }
    private static readonly Type TypeBoolean = typeof(bool);
    private static readonly Type TypeByte = typeof(byte);
    private static readonly Type TypeSByte = typeof(sbyte);
    private static readonly Type TypeInt16 = typeof(short);
    private static readonly Type TypeUInt16 = typeof(ushort);
    private static readonly Type TypeInt32 = typeof(int);
    private static readonly Type TypeUInt32 = typeof(uint);
    private static readonly Type TypeInt64 = typeof(long);
    private static readonly Type TypeUInt64 = typeof(ulong);
    private static readonly Type TypeIntPtr = typeof(IntPtr);
    private static readonly Type TypeUIntPtr = typeof(UIntPtr);
    private static readonly Type TypeChar = typeof(char);
    private static readonly Type TypeDouble = typeof(double);
    private static readonly Type TypeSingle = typeof(float);

    public static bool IsPrimitive(this Type t) {
      return t == TypeBoolean ||
             t == TypeByte ||
             t == TypeSByte ||
             t == TypeInt16 ||
             t == TypeUInt16 ||
             t == TypeInt32 ||
             t == TypeUInt32 ||
             t == TypeInt64 ||
             t == TypeUInt64 ||
             t == TypeIntPtr ||
             t == TypeUIntPtr ||
             t == TypeChar ||
             t == TypeDouble ||
             t == TypeSingle;
    }
    public static T[] ToVectorEdge<T>(this T[,] matrix) {
      // Console.WriteLine($">> [{typeof(T)}] isPrimitive {typeof(T).IsPrimitive()}");
      return typeof(T).IsPrimitive
        ? matrix.ToVectorPrim()
        : matrix.ToVectorArch();
    }
    public static T[] ToVectorEpic<T>(this T[,] matrix) {
      return matrix.RowsIter().Reduce((a, b) => a.Acquire(b));
    }
    public static IEnumerable<T> IntoIter<T>(this T[,] matrix) {
      var (h, w) = matrix.Size();
      for (var i = 0; i < h; i++)
        for (var j = 0; j < w; j++)
          yield return matrix[i, j];
    }
    // public static IEnumerable<T> IntoIter<T>(this T[,] matrix) {
    //   return matrix.Cast<T>();
    // }
  }
}