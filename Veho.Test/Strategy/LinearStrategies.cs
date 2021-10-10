using System;
using System.Linq.Expressions;
using System.Reflection;
using Analys;
using NUnit.Framework;
using Palett;
using Spare;
using Valjoux;
using static Veho.Factory.OperatorFactory;

namespace Veho.Test.Strategy {
  [TestFixture]
  public class LinearStrategies {
    public class AlgebraArch<T> {
      // public static Algebra<T> Build() { return new Algebra<T>(); }
      public static T Zero { get; } = default(T);
      private static readonly Lazy<Func<T, T, T>> add, subtract, multiply, divide, power;

      static AlgebraArch() {
        "init arch".Logger();
        var type = typeof(T);
        if (
          type.GetTypeInfo().IsValueType &&
          type.GetTypeInfo().IsGenericType &&
          type.GetGenericTypeDefinition() == typeof(Nullable<>)
        ) {
          throw new InvalidOperationException($"Generic math between {nameof(Nullable)} types is not implemented. Type: {typeof(T).FullName} is nullable.");
        }
        add = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Add), true);
        subtract = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Subtract), true);
        divide = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Divide), true);
        multiply = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Multiply), true);
        power = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Power), true);
      }

      public Func<T, T, T> op_Addition => add.Value;
      public Func<T, T, T> op_Subtraction => subtract.Value;
      public Func<T, T, T> op_Multiply => multiply.Value;
      public Func<T, T, T> op_Division => divide.Value;
      public Func<T, T, T> op_Concatenate => power.Value;
    }

    public static class AlgebraEpic<T> {
      // public static Algebra<T> Build() { return new Algebra<T>(); }
      public static T Zero { get; } = default(T);
      private static readonly Lazy<Func<T, T, T>> add;
      private static readonly Lazy<Func<T, T, T>> subtract;
      private static readonly Lazy<Func<T, T, T>> multiply;
      private static readonly Lazy<Func<T, T, T>> divide;
      private static readonly Lazy<Func<T, T, T>> power;

      static AlgebraEpic() {
        "init epic".Logger();
        var type = typeof(T);
        if (
          type.GetTypeInfo().IsValueType &&
          type.GetTypeInfo().IsGenericType &&
          type.GetGenericTypeDefinition() == typeof(Nullable<>)
        ) {
          throw new InvalidOperationException($"Generic math between {nameof(Nullable)} types is not implemented. Type: {typeof(T).FullName} is nullable.");
        }
        add = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Add), true);
        subtract = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Subtract), true);
        multiply = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Multiply), true);
        divide = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Divide), true);
        power = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Power), true);
      }
      public static Func<T, T, T> op_Addition => add.Value;
      public static Func<T, T, T> op_Subtraction => subtract.Value;
      public static Func<T, T, T> op_Multiply => multiply.Value;
      public static Func<T, T, T> op_Division => divide.Value;
      public static Func<T, T, T> op_Concatenate => power.Value;
    }

    public static class AlgebraGran<T> {
      // public static Algebra<T> Build() { return new Algebra<T>(); }
      public static T Zero { get; } = default(T);

      static AlgebraGran() {
        var type = typeof(T);
        if (
          type.GetTypeInfo().IsValueType &&
          type.GetTypeInfo().IsGenericType &&
          type.GetGenericTypeDefinition() == typeof(Nullable<>)
        ) {
          throw new InvalidOperationException($"Generic math between {nameof(Nullable)} types is not implemented. Type: {typeof(T).FullName} is nullable.");
        }
      }

      public static Func<T, T, T> op_Addition { get; } = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Add), true).Value;
      public static Func<T, T, T> op_Subtraction { get; } = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Subtract), true).Value;
      public static Func<T, T, T> op_Multiply { get; } = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Multiply), true).Value;
      public static Func<T, T, T> op_Division { get; } = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Divide), true).Value;
      public static Func<T, T, T> op_Concatenate { get; } = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Power), true).Value;
    }

    public static class AlgebraBrev<T> {
      // public static Algebra<T> Build() { return new Algebra<T>(); }
      public static T Zero { get; } = default(T);
      private static readonly Lazy<Func<T, T, T>> add = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Add), true);
      private static readonly Lazy<Func<T, T, T>> subtract = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Subtract), true);
      private static readonly Lazy<Func<T, T, T>> multiply = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Multiply), true);
      private static readonly Lazy<Func<T, T, T>> divide = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Divide), true);
      private static readonly Lazy<Func<T, T, T>> power = new Lazy<Func<T, T, T>>(() => Binary<T>(Expression.Power), true);

      static AlgebraBrev() {
        "init brev".Logger();
        var type = typeof(T);
        if (
          type.GetTypeInfo().IsValueType &&
          type.GetTypeInfo().IsGenericType &&
          type.GetGenericTypeDefinition() == typeof(Nullable<>)
        ) {
          throw new InvalidOperationException($"Generic math between {nameof(Nullable)} types is not implemented. Type: {typeof(T).FullName} is nullable.");
        }
      }
      public static Func<T, T, T> op_Addition => add.Value;
      public static Func<T, T, T> op_Subtraction => subtract.Value;
      public static Func<T, T, T> op_Multiply => multiply.Value;
      public static Func<T, T, T> op_Division => divide.Value;
      public static Func<T, T, T> op_Concatenate => power.Value;
    }

    [Test]
    public void TestAlpha() {
      var algebra = new AlgebraArch<double>();
      var result = algebra.op_Addition(1, 2);
      Console.WriteLine($">> [result] {result}");
    }

    [Test]
    public void AlgebraInitializationStrategies() {
      dynamic DynamicAddition(dynamic x, dynamic y) => x + y;
      var methods = Seq.From<(string, Func<(double x, double y), double>)>(
        ("arch", (xy) => new AlgebraArch<double>().op_Addition(xy.x, xy.y)),
        ("epic", (xy) => AlgebraEpic<double>.op_Addition(xy.x, xy.y)),
        ("gran", (xy) => AlgebraGran<double>.op_Addition(xy.x, xy.y)),
        ("brev", (xy) => AlgebraBrev<double>.op_Addition(xy.x, xy.y)),
        ("prim", (xy) => xy.x + xy.y),
        ("vari", (xy) => DynamicAddition(xy.x, xy.y))
        // ("arch", type => new AlgebraEpic<double>().Add),
      );
      var parameters = Seq.From(
        ("alpha", (Math.PI, Math.PI)),
        ("beta", (128, 256))
        // ("gamma", 0D)
      );
      var (elapsed, result) = Strategies.Run(
        (int)1E+6,
        methods,
        parameters
      );

      elapsed.Deco(presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");
      result.Deco(presets: (Presets.Subtle, Presets.Fresh)).Says("Result");
      // foreach (var (side, matrix) in parameters) {
      //   matrix.Deco().Says(side);
      //   foreach (var (head, _) in methods) {
      //     result[side, head].Deco().Says(side + "-" + head);
      //   }
      //   Console.WriteLine("");
      // }
    }
  }
}