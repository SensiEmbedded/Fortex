using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
	public partial class ucValue : UserControl {
		public ucValue() {
			InitializeComponent();
		}
		CGlobal glob;
		double alarmLimit = 0;
		int index;
    public bool isOutOfRange = false;
    Color colorControl;
    //int bar;


		public void SetRef(ref CGlobal rfGl) {
			glob = rfGl;
      lblDown.Text = "-100 -";
      lblMiddle.Text = "0 -";
      lblUp.Text = "100 -";
      tmrBlink.Enabled = true;
      colorControl = pnlBlink.BackColor;
		}
    void SetStaticLabels() {
      if (isOutOfRange == true) {
        lblAlarmType.Text = "Out of Range";
      } else {
        lblAlarmType.Text = "Low Level";
      }
      double al1 = glob.g_wr.alarm2_Low;
      double al2 = glob.g_wr.alarm2_Hi;

      if (index == 5) {
        al1 = glob.g_wr.alarm1;
        lblAlarmLimit1.Text = al1.ToString();
        lblAlarmLimit2.Text = "---";
      }
      if (index == 6) {
        al1 = glob.g_wr.alarm2_Low;
        al2 = glob.g_wr.alarm2_Hi;
        lblAlarmLimit1.Text = al1.ToString();
        lblAlarmLimit2.Text = al2.ToString();
      }

      if (index == 7) {
        al1 = glob.g_wr.alarm3;
        lblAlarmLimit1.Text = al1.ToString();
        lblAlarmLimit2.Text = "---";
      }

    }
		public void Update(int ix) {
			index = ix;
			//alarmLimit = glob.g_wr.alarms[ix];
      SetStaticLabels();
			//lblTest.Text = glob.comm.devs.devVir.alarmStatus[ix].ToString();
			double df1 = glob.comm.devs.devVir.pressure[ix];
			if ((int)df1 == (int)DevErrorCodes.AdcErr) {
				//basicProgressBar1.Text = "Err";
				//basicProgressBar1.ForeColor = Color.Red;
				digitalPanelMeterBlue1.Value = df1;
				digitalPanelMeterBlue1.Text = lblStatus.Text = "Adc Error";
        DrawBargraph(0);
				return;
			}
			if ((int)df1 == (int)DevErrorCodes.AddressExeption) {
				//basicProgressBar1.Text = "Err";
				//basicProgressBar1.ForeColor = Color.Red;
				digitalPanelMeterBlue1.Value = df1;
        digitalPanelMeterBlue1.Text = lblStatus.Text = "Ilegal Modbus Exeption";
        DrawBargraph(0);
				return;
			}
			if ((int)df1 == (int)DevErrorCodes.TimeOut) {
				//basicProgressBar1.Text = "Tout";
				//basicProgressBar1.ForeColor = Color.Red;
				digitalPanelMeterBlue1.Value = df1;
        digitalPanelMeterBlue1.Text = lblStatus.Text = "Timeout";
        DrawBargraph(0);
				return;
			}
			if ((int)df1 == (int)DevErrorCodes.ComNotExist) {
				//basicProgressBar1.Text = "CErr";
				//basicProgressBar1.ForeColor = Color.Red;
				digitalPanelMeterBlue1.Value = df1;
        digitalPanelMeterBlue1.Text = lblStatus.Text = "Com port not exist";
        DrawBargraph(0);
				return;
			}

			//basicProgressBar1.Text = df1.ToString("N1");
			//basicProgressBar1.ForeColor = Color.Green;
			digitalPanelMeterBlue1.Value = df1;
			digitalPanelMeterBlue1.Text = "Diff Pressure ";
      
			
			
			double dVal = df1;
			if (dVal < 0)
				dVal = 0;
			if (dVal > 100)
				dVal = 100;

			//basicProgressBar1.Value = (int)dVal;
      
      aUtils.CUtils.tag_Prava p = new aUtils.CUtils.tag_Prava();
      //if (isOutOfRange == true) {
        p.x1 = -100;
        p.x2 = 100;
        p.y1 = -100;
        p.y2 = 100;
      //} else {
      //  p.x1 = -100;
      //  p.x2 = 100;
      //  p.y1 = 0;
      //  p.y2 = 100;
      //}
      
      int bar = (int)aUtils.CUtils.PravaPrez2Tochki((float)df1, p);

      DrawBargraph(bar);
      
		/*
			if (glob.comm.devs.devVir.alarms[ix] == DevAlarms.Lo) {
				basicProgressBar1.ForeColor = Color.Red;
				pbAlarm.Image = imageList1.Images[1];
			} else {
				pbAlarm.Image = imageList1.Images[0];
			} 
			*/
			

			/*switch ((int)df1) {
				case DevErrorCodes.AdcErr:
					break;

			} */
		}
    private bool blink;
    private int ixImage=0, ixImageLast = 0;
		private void tmrBlink_Tick(object sender, EventArgs e) {
      blink = !blink;
      if (glob.comm.devs.devVir.alarmStatus[index] == DevAlarms.None) {
        pnlBlink.BackColor = colorControl;
      } else {
        if (blink == true) {
          pnlBlink.BackColor = colorControl;
        } else {
          if (glob.comm.devs.devVir.alarmStatus[index] == DevAlarms.Error) {
            //adc err, no comminication error
            pnlBlink.BackColor = Color.BurlyWood;
          } else {
            //pressure error
            pnlBlink.BackColor = Color.Red;
          }
        }
      }

      /*if (glob.comm.devs.devVir.alarmStatus[index] == DevAlarms.Lo) {
        if (blink == true) {
          ixImage = 2;//Yellow
        } else {
          ixImage = 1;//Red
        }
      } else {
        if (glob.comm.devs.devVir.alarmStatus[index] == DevAlarms.Error) {
          ixImage = 2;//Yellow
        } else {
          ixImage = 0;//Green 
        }
      }
      if (ixImage != ixImageLast) {
        pbAlarm.Image = imageList1.Images[ixImage];
      }
      ixImageLast = ixImage;
        */

		}

    private void pictureBox1_Click(object sender, EventArgs e) {
      
    }

    Rectangle CalcBarOutOfRange(int procent) {
      if (procent < -100)
        procent = -100;
      if (procent > 100)
        procent = 100;
      if (procent == 0)
        procent = 2;

      int h = pictureBox1.Height;
      int w = pictureBox1.Width;
      aUtils.CUtils.tag_Prava p = new aUtils.CUtils.tag_Prava();
      p.x1 = 100;
      p.x2 = -100;
      p.y1 = -h / 2;
      p.y2 = h / 2;
      int bar = (int)aUtils.CUtils.PravaPrez2Tochki(procent, p);

      int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
      x1 = 0;
      x2 = pictureBox1.Size.Width;

      if (bar < 0) {
        y1 = h / 2 + bar;
        y2 = h / 2 - y1;
      } else {
        //rect = new Rectangle(0, h / 2, pictureBox1.Size.Width, Math.Abs(count)+1);
        y1 = h / 2;
        y2 = bar;
      }
      //lblTest.Text = string.Format("{0},{1}---{2},{3}",x1,y1,x2,y2);
      Rectangle rect = new Rectangle(0, y1, x2, y2);
      return rect;

    }
    Rectangle CalcBarNormal(int procent) {
      if (procent < 0)
        procent = 2;
      if (procent > 100)
        procent = 100;

      int h = pictureBox1.Height;
      int w = pictureBox1.Width;
      aUtils.CUtils.tag_Prava p = new aUtils.CUtils.tag_Prava();

      p.x1 = 0;
      p.x2 = 100;
      p.y1 = 0;
      p.y2 = h;
      int bar = (int)aUtils.CUtils.PravaPrez2Tochki(procent, p);

      int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
      x1 = 0;
      x2 = pictureBox1.Size.Width;

      y1 = h  - bar;
      y2 = h  - y1;

      /*
      if (bar < 0) {
        y1 = h / 2 + bar;
        y2 = h / 2 - y1;
      } else {
        y1 = h / 2;
        y2 = bar;
      } */
      //lblTest.Text = string.Format("{0},{1}---{2},{3}", x1, y1, x2, y2);
      Rectangle rect = new Rectangle(0, y1, x2, y2);
      return rect;

    }

    Rectangle CalcAlarm(int procent){
      //if (procent < 0)
      //  procent = 2;
      if (procent > 100)
        procent = 100;

      lblStatus.Text = glob.comm.devs.devVir.alarmStatus[index].ToString();

      int h = pictureBox1.Height;
      int w = pictureBox1.Width;
      aUtils.CUtils.tag_Prava p = new aUtils.CUtils.tag_Prava();
      if (isOutOfRange == true) {
        p.x1 = -100;
      } else {
        p.x1 = -100;
      }
      
      p.x2 = 100;
      p.y1 = 0;
      p.y2 = h;
      int bar = (int)aUtils.CUtils.PravaPrez2Tochki(procent, p);

      int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
      x1 = 0;
      x2 = pictureBox1.Size.Width;

      y1 = h - bar;
      y2 = 2;

      //lblTest.Text = string.Format("{0},{1}---{2},{3}", x1, y1, x2, y2);
      Rectangle rect = new Rectangle(0, y1, x2, y2);
      return rect;
    }
    void DrawBargraph(int proc) {
      if (pictureBox1.Image == null) {
        pictureBox1.Image = new Bitmap(pictureBox1.Width,
                pictureBox1.Height);
      }

      //aUtils.CUtils.PravaPrez2Tochki()
      using (Graphics g = Graphics.FromImage(pictureBox1.Image)) {
        // draw black background
        g.Clear(Color.White);
        //Rectangle CalcBarNormal(proc);
        Rectangle rect = new Rectangle();
        //if (isOutOfRange == true) {
          rect = CalcBarOutOfRange(proc);
        //} else {
        //  rect = CalcBarNormal(proc);
        //}

        SolidBrush blueBrush;
        if (glob.comm.devs.devVir.alarmStatus[index] == DevAlarms.None) {
          blueBrush = new SolidBrush(Color.Blue);
        } else {
          blueBrush = new SolidBrush(Color.Red);
        }

        g.FillRectangle(blueBrush, rect);
        //./g.DrawRectangle(Pens.Black, rect);

        SolidBrush redBrush = new SolidBrush(Color.Cyan);

        if (isOutOfRange == true) {
          double al1=0, al2=0;
          if (index == 6) {
            al1 = glob.g_wr.alarm2_Hi;
            al2 = glob.g_wr.alarm2_Low;
          }
          //alarms
          rect = CalcAlarm((int)al1);
          g.FillRectangle(redBrush, rect);
          //g.DrawRectangle(Pens.Black, rect);
          rect = CalcAlarm((int)al2);
          g.FillRectangle(redBrush, rect);
          //g.DrawRectangle(Pens.Black, rect);
        } else {
          double al1 = 0;
          if (index == 5) {
            al1 = glob.g_wr.alarm1;
          }
          if (index == 7) {
            al1 = glob.g_wr.alarm3;
          }
          //alarms
          rect = CalcAlarm((int)al1);
          g.FillRectangle(redBrush, rect);
          //g.DrawRectangle(Pens.Black, rect);
        }

      }
      pictureBox1.Invalidate();
    }

    private void label4_Click(object sender, EventArgs e) {

    }

    private void lblAlarmLimit2_Click(object sender, EventArgs e) {

    }
    
	}
}
