using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiffPress {
  public partial class frmDevSett : Form {
    private CDev dev;
    public frmDevSett(CDev dev) {
      InitializeComponent();
      this.dev = dev;
      PopulateControls();
    }
    private void PopulateControls() {
      cmbType.Text = dev.type.ToString();
      txtName.Text = dev.name;

    }
  }
}
