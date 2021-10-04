using System;
using System.Diagnostics;
using Spare;

namespace Veho.Test.Utils {
  public abstract class Pgs {
    public delegate void Rfs(float val, string msg);

    public abstract Rfs RegPgs { set; }
  }

  //public class rolex : elPrimero
  //{
  //    public csvCaruso tfp;
  //    public rolex(string pathFolder)
  //    {
  //        tfp = new csvCaruso() {path=$"{pathFolder}\\tmdlog.csv"};
  //        //tfp.writeLine("srno", "date", "type", "ht", "wd", "cn", "lag", "comment")
  //    }
  //    public void startLog(params string[] itm)
  //    {
  //        iniTmr(itm.concate(Constants.vbTab));
  //    }
  //    public void lapseLog<T>(T[,] omx, string comment = "-")
  //    {
  //        List<string> cLst = omx.brief();
  //        cLst.Add(elapseMsg);
  //        cLst.Add(comment);
  //        lapTmr(cLst.ToArray().concate(Constants.vbTab));
  //        tfp.writeLine(cLst.ToArray().hBrief());
  //    }
  //    public void lapseLog(params string[] itm)
  //    {
  //        lapTmr(itm.concate(Constants.vbTab));
  //        tfp.writeLine(itm);
  //    }
  //    public void closeLog(params string[] itm)
  //    {
  //        endTmr(itm.concate(Constants.vbTab));
  //    }
  //    public void close()
  //    {
  //        tfp.close();
  //    }
  //}

  public class ElPrimero : Stopwatch {
    private DateTime _curr;
    private DateTime _next;

    public string IniMsg => $"[   starts] ({_curr:hh:mm:ss} {_curr.Millisecond:D3})";
    public string LagMsg {
      get {
        long tLag = this.ElapsedMilliseconds;
        string tTag = tLag > 1000 ? $"{this.Elapsed.TotalSeconds:N} s" : $"{tLag:D3} ms";
        return $"[  process] ({_next:hh:mm:ss} {_next.Millisecond:D3}) [Lag] ({tTag})";
      }
    }
    public string EndMsg {
      get {
        TimeSpan span = _next - _curr;
        string spanText = $"{span.Seconds}.{span.Milliseconds} s";
        return $"[terminate] ({_next:hh:mm:ss} {_next.Millisecond:D3}) ({spanText})";
      }
    }
    public string ElapseMsg => this.ElapsedMilliseconds.ToString("##,##0");

    public void IniTmr(string adtMsg = "") {
      _curr = DateTime.Now;
      string msg = IniMsg;
      if (!string.IsNullOrEmpty(adtMsg)) msg += $"\t{adtMsg}";
      msg.Logger();
      if (this.IsRunning)
        this.Restart();
      else
        this.Start();
    }
    public void LapTmr(string adtMsg = "") {
      _next = DateTime.Now;
      string msg = LagMsg;
      if (!string.IsNullOrEmpty(adtMsg)) msg += $"\t{adtMsg}";
      msg.Logger();
      this.Restart();
    }
    public void EndTmr(string adtMsg = "") {
      _next = DateTime.Now;
      string msg = EndMsg;
      if (this.IsRunning) this.Stop();
      if (!string.IsNullOrEmpty(adtMsg)) msg += $"\t{adtMsg}";
      string txtSplit = " ".PadRight(msg.Length).Replace(" ", "-");
      $"{msg}\r\n{txtSplit}".Logger();
    }
  }
}