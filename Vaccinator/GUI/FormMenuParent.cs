using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.Fonts;

namespace Vaccinator.GUI {
    public partial class FormMenuParent : FormMain {
        public FormMenuParent() {
            InitializeComponent();

            foreach (Control control in this.Controls)
                control.Font = Fonts.Font.GetFont(FontName.MENU_TEXT);
        }
    }
}
