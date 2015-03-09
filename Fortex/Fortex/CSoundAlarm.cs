using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DiffPress {
  public class CSoundAlarm {
    private System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
    System.Media.SoundPlayer player = null;
    private bool nowPlaying = false;
    private bool nowPlayingLast = false;

    private bool enableAlarm = false;
    private CGlobal glob = null;
    public CSoundAlarm(CGlobal glob) {
      this.glob = glob;

      string pathWavFile = Application.StartupPath + @"\" + glob.g_wr.alarmWavFile;
      SetWavFile(pathWavFile);
      SetAlarmEnable(glob.g_wr.alarmPlaySound);

      //player = new System.Media.SoundPlayer( Application.StartupPath + @"\s1.wav");
      tmr.Interval = 1000;
      //tmr.Elapsed += new System.Timers.ElapsedEventHandler(tmr_Elapsed);
      tmr.Tick += new EventHandler(tmr_Tick);
      tmr.Enabled = true;

      
    }
    public void SetWavFile(string wavFile) {
      player = new System.Media.SoundPlayer(wavFile);
    }
    public void SetAlarmEnable(bool enable) {
      enableAlarm = enable;
    }


    void tmr_Tick(object sender, EventArgs e) {
      if(player == null)return;
      if (enableAlarm == false) {
        player.Stop();
        return;
      }
      AnalizeAlarms();

      if (nowPlaying == true && nowPlayingLast == false) {
        player.PlayLooping();
      }
      
      if (nowPlaying == false/* && nowPlayingLast == false*/) {
        player.Stop();
      }
        
      nowPlayingLast = nowPlaying;

    }
    private int AnalizeDevsArray(CDev[] devs,int howMany) {
      int i;
      for(i=0; i< howMany;++i){
        if (devs[i].alarmStatus_HiVal1 == DevAlarms.Hi && devs[i].isSoundKvint == false) {
          return 1;
        }
        if (devs[i].alarmStatus_HiVal2 == DevAlarms.Hi && devs[i].isSoundKvint == false) {
          return 1;
        }
        if (devs[i].alarmStatus_LoVal1 == DevAlarms.Lo && devs[i].isSoundKvint == false) {
          return 1;
        }
        if (devs[i].alarmStatus_LoVal2 == DevAlarms.Lo && devs[i].isSoundKvint == false) {
          return 1;
        }
      }
      return 0;
    }
    private void AnalizeAlarms() {
      CDev[] devs = glob.comm.devs.mmm[0].devs;
      int howMany = glob.g_wr.howManyDevsFloor1;
      int alarms = 0;
      alarms += AnalizeDevsArray(devs,howMany);

      devs = glob.comm.devs.mmm[1].devs;
      howMany = glob.g_wr.howManyDevsFloor2;
      alarms += AnalizeDevsArray(devs,howMany);

      devs = glob.comm.devs.mmm[2].devs;
      howMany = glob.g_wr.howManyDevsFloor3;
      alarms += AnalizeDevsArray(devs,howMany);

      if (alarms > 0) {
        nowPlaying = true;
      } else {
        nowPlaying = false;
      }
    }

  }
}
