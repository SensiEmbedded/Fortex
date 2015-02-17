using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aUtils;
using ChartDirector;

namespace DiffPress {
	public partial class frmChartDir : Form {
		CGlobal glob;
    

		public frmChartDir() {
			InitializeComponent();
		}
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
			if (keyData == Keys.Escape) {
				this.Close();
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}
		public void SetRef(ref CGlobal rfGl) {
      glob = rfGl;
     
    }
		private CDev _cdev=null;
		public CDev cdev {
			get{return _cdev;}
			set {
				_cdev = value;
        ucChartDir1.cdev = _cdev;
				if (_cdev != null) {  
					_cdev.Changed +=new ChangedEventHandler(_cdev_Changed);
					_cdev.evAlarm += new AlarmOccured(_cdev_evAlarm);                                               
				}
			}
		}
		public void PrepareToDelete() {
			_cdev.Changed -= _cdev_Changed;
			_cdev.evAlarm -= _cdev_evAlarm;
			_cdev = null;
		}
		void _cdev_evAlarm(DevAlarms type,DevAlarms typeLast,string tag) {
			//./AnalizeAlarm(type,typeLast,tag); 
			
			System.Diagnostics.Debug.WriteLine("type:" +type.ToString());
			System.Diagnostics.Debug.WriteLine("typeLast:" +typeLast.ToString());
			System.Diagnostics.Debug.WriteLine("name:" + _cdev.name);
			System.Diagnostics.Debug.WriteLine("strID:" + _cdev.strID);
			System.Diagnostics.Debug.WriteLine("GuID:" + _cdev.InstanceID.ToString());

		}
		void _cdev_Changed(object sender, EventArgs e) {
			//./this.UIThread(() => this.ShowVals());
		}

		private void frmChartDir_Load(object sender, EventArgs e) {
     
		}
		
		
    
    

	}
}
