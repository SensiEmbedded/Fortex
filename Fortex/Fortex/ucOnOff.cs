using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class ucOnOff : UserControl {
    string[] txt = {"Off","On"};
    bool[] onoff = {false,true};
    Color[] clr = {Color.Gray,Color.Blue};
    int currIx = 0;
    

    public ucOnOff() {
      InitializeComponent();
      isOn = false;
    }
  
  
	public bool isOn
	{
		get { return (currIx == 0) ? false : true;}
		set { currIx = (value == false) ? 0 : 1; }
	}
	

    private void ucOnOff_Load(object sender, EventArgs e) {
      pictureBox1.Image = imageList1.Images[currIx];
      lblOnOff.Text = txt[currIx];
      lblOnOff.ForeColor = clr[currIx];
    }

    private void pictureBox1_Click(object sender, EventArgs e) {
      currIx = (currIx == 0) ? 1 : 0;
      lblOnOff.Text = txt[currIx];
      pictureBox1.Image = imageList1.Images[currIx];
      lblOnOff.ForeColor = clr[currIx];
    }
  }
}
