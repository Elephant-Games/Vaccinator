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
    public partial class FormMainMenu : FormMenuParent {
        public FormMainMenu() {
            InitializeComponent();

            foreach (Control control in this.Controls)
                control.Font = Fonts.Font.GetFont(FontName.MENU_TEXT);
            label5.Font = Fonts.Font.GetFont(FontName.MAIN_TEXT);

            this.KeyUp += frmMainMenu_KeyUp;
        }

        private void frmMainMenu_KeyUp(object sender, KeyEventArgs e) {
            switch (e.KeyData) {
                case Keys.Up: //TODO: using key constants form settings
                    MovePointer(-1);
                    break;
                case Keys.Down:
                    MovePointer();
                    break;
            }
        }

        /// <summary>
        /// Перемещает указатели справа и слева от пункта меню.
        /// </summary>
        /// <param name="value">Размер сдвига указателей.</param>
        private void MovePointer(sbyte value = 1) {
            int row = tblInner.GetPositionFromControl(this.lblPtrLeft).Row;
            row += value;
            row %= tblInner.RowCount;
            if (row < 0)
                row = tblInner.RowCount - 1;
            
            tblInner.SetRow(this.lblPtrLeft, row);
            tblInner.SetRow(this.lblPtrRight, row);
        }
    }
}
