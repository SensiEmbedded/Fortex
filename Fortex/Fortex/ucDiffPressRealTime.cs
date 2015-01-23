using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class ucDiffPressRealTime : UserControl {
    public ucDiffPressRealTime() {
      InitializeComponent();
    }
    public CDev cdev {
      get;
      set;
    }
  }
}
