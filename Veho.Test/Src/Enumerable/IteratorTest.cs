using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare;
using Typen;

namespace Veho.Test.Enumerable {
  [TestFixture]
  public class IteratorTest {
    private static string[] List = {
                                     "R2C1",
                                     "R2C163834",
                                     "R1C2",
                                     "R1048576C2",
                                     "RC2",
                                     "R1C",
                                   };
    public static (T, T) Dualet<T>(IEnumerable<T> items) {
      using (var f = items.GetEnumerator()) {
        return (f.MoveNext() ? f.Current : default, f.MoveNext() ? f.Current : default);
      }
    }

    public static (TO, TO) Dualet<T, TO>(IEnumerable items, Func<T, TO> func, TO defVal = default) {
      using (var cs = items.OfType<T>().GetEnumerator()) {
        return (cs.MoveNext() ? func(cs.Current) : defVal, cs.MoveNext() ? func(cs.Current) : defVal);
      }
    }

    [Test]
    public void Test1() {
      var regex = new Regex(@"(?<=[RC])(\d+)");
      foreach (var el in List) {
        var (rn, cn) = Dualet(regex.Matches(el).OfType<Match>());
        $"[{el}] => ({rn?.Value ?? default}, {cn?.Value ?? default}) ".Logger();
      }
    }

    [Test]
    public void Test2() {
      var regex = new Regex(@"(?<=[RC])(\d+)");
      foreach (var el in List) {
        var (rn, cn) = Dualet(regex.Matches(el), (Match x) => int.Parse(x.Value));
        $"[{el}] => ({rn}, {cn}) ".Logger();
      }
    }
  }
}