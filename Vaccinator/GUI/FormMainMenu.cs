using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaccinator.GUI {
    public partial class FormMainMenu : Form {
        public FormMainMenu() {
            InitializeComponent();

            foreach (Control control in this.Controls)
                control.Font = Program.Fonts["menu-text"];
            label5.Font = Program.Fonts["main-text"];
        }
    }
}
