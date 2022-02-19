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
using Vaccinator.Exceptions;

namespace Vaccinator.GUI{
    public partial class FormMain : Form {
        protected bool isInit = false;

        public bool IsInit {
            get {
                return this.isInit;
            }
        }

        public FormMain() {
            InitializeComponent();
            this.isInit = true;

            this.FormClosed += formClosed;
        }

        private void formClosed(object sender, EventArgs args) {
            Program.Exit();
        }
    }
}
