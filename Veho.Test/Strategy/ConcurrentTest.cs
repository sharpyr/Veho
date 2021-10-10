using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Analys;
using NUnit.Framework;
using Palett;
using Spare;
using Valjoux;
using Veho.Vector;

namespace Veho.Test.Strategy {
  public static class Concurrents {
    public static TO[] ParaMapArc<T, TO>(this IReadOnlyList<T> vec, Func<T, TO> mapper) {
      var hi = vec.Count;
      var results = new TO[hi];
      var result = Parallel.For(0, hi, i => results[i] = mapper(vec[i]));
      return results;
    }
    public static TO[] ParaMapEdg<T, TO>(this IReadOnlyList<T> vec, Func<T, TO> mapper) {
      var concurrentBag = new ConcurrentBag<TO>();
      var result = Parallel.ForEach(vec, it => concurrentBag.Add(mapper(it)));
      return concurrentBag.ToArray();
    }
    public static TO[] ParaMapFut<T, TO>(this IReadOnlyList<T> vec, Func<T, TO> mapper) {
      var target = new List<TO>();
      var localLockObject = new object();
      Parallel.ForEach(
        vec,
        () => new List<TO>(),
        (word, state, localList) => {
          localList.Add(mapper(word));
          return localList;
        },
        finalResult => {
          lock (localLockObject) target.AddRange(finalResult);
        }
      );
      return target.ToArray();
    }
  }

  [TestFixture]
  public class ConcurrentTest {
    [Test]
    public void AlphaTest() {
      var (elapsed, result) = Strategies.Run(
        (int)1E+4,
        Seq.From<(string, Func<string[], string[]>)>(
          ("cla", vec => vec.Map(x => "-" + x)),
          ("arc", vec => vec.ParaMapArc(x => "-" + x)),
          ("edg", vec => vec.ParaMapEdg(x => "-" + x)),
          ("fut", vec => vec.ParaMapFut(x => "-" + x))
        ),
        Seq.From(
          ("alpha", Vec.From("foo", "bar", "zen", "eck", "van", "sto", "knu")),
          ("beta", Vec.Init(256, x => x.ToString("000"))),
          ("gamma", Vec.Init(1024, x => x.ToString("0000")))
          // ("delta", Vec.Init(16384, x => x.ToString("00000")))
        )
      );

      elapsed.Deco(presets: (Presets.Subtle, Presets.Fresh)).Says("Elapsed");
      result.Deco(presets: (Presets.Subtle, Presets.Fresh)).Says("Results");
      var candidates = Seq.From(
        ("alpha", "cla"),
        ("alpha", "arc"),
        ("alpha", "edg"),
        ("alpha", "fut")
      );
      foreach (var (side, head) in candidates) {
        result[side, head].Deco().Says(side + "-" + head);
      }
    }
  }
}