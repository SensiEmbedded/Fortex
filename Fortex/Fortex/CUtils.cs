using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
//using System.Windows.Controls;
using System.Windows.Forms;

namespace aUtils {
  using DiffPress;
  
  //public static class StringExtension {
  public static class FormExtension {
    // This is the extension method. 
    // The first parameter takes the "this" modifier
    // and specifies the type for which the method is defined. 
    /*
    public static int AssenMethod(this String str) {
      return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
    public static void AssenMethod2(this System.Windows.Forms.Label frm) {
      frm.Text = "basi basi";
      return;
    }
    public static void UIThread(this Control @this, Action code) {
      if (@this.InvokeRequired) {
        @this.BeginInvoke(code);
      } else {
        code.Invoke();
      }
    } */
    public static void UIThread(this Control pnt, Action code) {
      if (pnt.InvokeRequired) {
        pnt.BeginInvoke(code);
      } else {
        code.Invoke();
      }
    }
    /*
    public static void SafeInvoke<t>(this Label isi, Action<t> call) where Label : ISynchronizeInvoke {
      if (isi.InvokeRequired)
        isi.BeginInvoke(call, new object[] { isi });
      //else
        //call(isi);
    } */
   
  }
  /*
  public class VerticalProgressBar : ProgressBar {
    protected override CreateParams CreateParams {
      get {
        CreateParams cp = base.CreateParams;
        cp.Style |= 0x04;
        return cp;
      }
    }
  } */

  
  /// <summary>
  /// Class osnopwno ot static funcii. Kato prava prez dve tochki i tem podobni
  /// </summary>
  public class CUtils {
    public static string GimiBGDateTime() {
      string str = null;
      DateTime dt = DateTime.Now;
      str = dt.Day.ToString("D2") + "/";
      str += dt.Month.ToString("D2") + "/";
      str += dt.Year.ToString("D4") + " ";
      str += dt.Hour.ToString("D2") + ":";
      str += dt.Minute.ToString("D2") + ":";
      str += dt.Second.ToString("D2");
      
      return str;

    }
    public static string GimiBGDateTime(DateTime dt) {
      string str = null;
      //DateTime dt = DateTime.Now;
      str = dt.Day.ToString("D2") + "/";
      str += dt.Month.ToString("D2") + "/";
      str += dt.Year.ToString("D4") + " ";
      str += dt.Hour.ToString("D2") + ":";
      str += dt.Minute.ToString("D2") + ":";
      str += dt.Second.ToString("D2");

      return str;

    }
    public static string GimiBGDateTimeForMainScreen() {
      string str = null;
      DateTime dt = DateTime.Now;
      str = dt.Day.ToString("D2") + "/";
      str += dt.Month.ToString("D2") + "/";
      str += dt.Year.ToString("D4") + "\n";
      str += dt.Hour.ToString("D2") + ":";
      str += dt.Minute.ToString("D2") + ":";
      str += dt.Second.ToString("D2");

      return str;

    }
    public struct tag_Prava{
      public float x1,y1,x2,y2;
    };
    public static float PravaPrez2Tochki(float x,tag_Prava cmn) {
      /**************************************/
      /*   imame dve tochki (x1,y1) (x2,y2) */
      /*   prava prez tiah  y=Ax+B          */
      /*     se dava s                      */
      /*      y2-y1           y2-y1         */
      /*   A=-------  B=y1 - -------x1      */
      /*      x2-x1           x2-x1         */
      /*   v sluchaia x2-x1=tP              */
      /*   B = y1                           */
      /**************************************/
      return (cmn.y2 - cmn.y1) / (cmn.x2 - cmn.x1) * (x - cmn.x1) + cmn.y1;
    }

  }
}
