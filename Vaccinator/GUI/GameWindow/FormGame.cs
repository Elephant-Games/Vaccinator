using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaccinator.GUI.GameWindow {
    public partial class FormGame : FormMain {
        public FormGame() {
            InitializeComponent();
            base.fontsInit(this);

            (new Thread(new ParameterizedThreadStart( (object o) => Game.Game.GetInstance(o) ))).Start(this);
        }

        public void MoveControl(Control control, Point destination) {
            control.Location = destination;
        }
    }
}
