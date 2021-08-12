// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using NUnit.Framework;
//
// namespace Veho.Test.Alpha {
//   [TestFixture]
//   public class LinqVsForeachTest {
//     [Test]
//     public void Test() {
//       var samples = new List<string>() {"foo", "bar", "zen", "shakes", "heming", "fitz"};
//       var eta = new Stopwatch();
//
//       eta.Start();
//       for (int i = 0; i < 100000; i++) {
//         var linq = samples.Select(x => "000" + x).ToArray(); //Linq，返回IEnumerable
//       }
//       eta.Stop();
//       var lap1 = (double) eta.ElapsedMilliseconds;
//
//
//       eta.Restart();
//       for (int i = 0; i < 100000; i++) {
//         var linq = samples.Select(x => "000" + x).ToList(); //Linq + ToList，返回List
//       }
//       eta.Stop();
//       var lap2 = (double) eta.ElapsedMilliseconds;
//
//       eta.Restart();
//       for (int i = 0; i < 100000; i++) {
//         var yyy = new List<string>();
//         foreach (var item in samples) yyy.Add("000" + item); //foreach，返回List
//       }
//       eta.Stop();
//       var lap3 = (double) eta.ElapsedMilliseconds;
//
//       Console.WriteLine($"use time 1 = {lap1}");
//       Console.WriteLine($"use time 2 = {lap2}");
//       Console.WriteLine($"use time 3 = {lap3}");
//     }
//   }
// }

