// using System;
// using System.Collections.Generic;
// using System.Threading;
// using System.Threading.Tasks;
// using Fdt;
// using Spare;
// using Veho.Enumerable;
// using static System.Linq.Enumerable;
// using Log = Spare.Debugger.Log;
//
// namespace Veho.Test.Alpha {
//   public static class ThreadEngine {
//     public static async void Test() {
//       //SemaphoreSlim sms = new SemaphoreSlim(3);
//       var clx = new Dictionary<int, int>();
//       var gp = new ElPrimero();
//       gp.iniTmr("Thread [Main] starts");
//       Log.Logger(Thread.CurrentThread.ManagedThreadId.ToString());
//       void Itr() {
//         Range(1, 20).Iterate(index => {
//           //Task.Run(() =>
//           //{
//           int mtId = Thread.CurrentThread.ManagedThreadId;
//           gp.lapTmr($"Thread [{mtId:D2}] starts.");
//           Range(1, 5).Iterate(it => {
//             //$"Thread [{MTId:D2}]: ({it})".wT();
//             clx[mtId] = clx.ContainsKey(mtId) ? clx[mtId] + 1 : 1;
//           });
//           gp.lapTmr($"Thread [{mtId:D2}] ends.");
//           //});
//         });
//       }
//
//       await Task.Run((Action)Itr);
//       await Task.Run((Action)Itr);
//       //await Task.Run((Action) Iterat);
//       //await Iterat();
//       Log.Logger("Thread [Main] is doing something else.");
//       await Task.Run(() => Log.Logger($"Thread dictionary [Count] ({clx.Count})"));
//       clx.Iterate(it => Log.Logger($"[Thread] ({it.Key:D2}) [Count] ({it.Value})"));
//       gp.endTmr("Thread [Main] terminates.");
//     }
//
//     static SemaphoreSlim _semLim = new SemaphoreSlim(3);
//
//     public static void TestTask() {
//       var eta = new ElPrimero();
//       eta.iniTmr("Thread [Main] starts");
//       Log.Logger(Thread.CurrentThread.ManagedThreadId.ToString());
//       var thdIdLst = new List<int>();
//
//       Range(1, 10).Iterate(async idx => {
//         //ThreadPool.QueueUserWorkItem( m => runVal());
//         int num = await RunTask();
//         thdIdLst.Add(num);
//         //Task.Run(() => runVal());
//       });
//       Log.Logger("Thread [Main] is doing something else.");
//       Thread.Sleep(1500);
//       thdIdLst.Distinct().ToArray().Deco().Logger();
//       eta.endTmr("Thread [Main] terminates.");
//     }
//
//     static void RunSample() {
//       //semLim.Wait();
//       Thread.Sleep(500);
//       Log.Logger($"Thread [{Thread.CurrentThread.ManagedThreadId}] hanged-up.");
//       //semLim.Release();
//     }
//
//     static int RunVal() {
//       //semLim.Wait();
//       Thread.Sleep(500);
//       Log.Logger($"Thread [{Thread.CurrentThread.ManagedThreadId}] hanged-up.");
//       //semLim.Release();
//       return Thread.CurrentThread.ManagedThreadId;
//     }
//
//     static Task<int> RunTask() => Task.Run(() => {
//       Thread.Sleep(500);
//       Log.Logger($"Thread [{Thread.CurrentThread.ManagedThreadId}] hanged-up.");
//       return Thread.CurrentThread.ManagedThreadId;
//     });
//   }
// }