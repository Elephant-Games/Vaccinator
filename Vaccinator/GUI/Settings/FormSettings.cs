using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaccinator.GUI.Settings {
    public partial class FormSettings : FormMain {
        public FormSettings() {
            InitializeComponent();

            base.fontsInit(this, lblHead);
        }
    }
}
