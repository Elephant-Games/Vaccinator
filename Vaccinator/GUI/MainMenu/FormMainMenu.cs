using System;
using System.Windows.Forms;

namespace Vaccinator.GUI.MainMenu {
    public partial class FormMainMenu : FormMain {
        public FormMainMenu() {
            InitializeComponent();

            base.fontsInit(this, this.labelHead);

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

                case Keys.Enter:
                    this.openWindow(this.getRow(lblPtrLeft));
                    break;
            }
        }

        private void openWindow(int row) {
            switch( (MainMenuChoice)row ) {
                case MainMenuChoice.PLAY:
                    break;

                case MainMenuChoice.SETTINGS:
                    ActivityController.GetInstance().OpenWindow<Settings.FormSettings>();
                    break;

                case MainMenuChoice.RECORDS:
                    break;

                case MainMenuChoice.AUTHORS:
                    break;
            }
        }

        /// <summary>
        /// Перемещает указатели справа и слева от пункта меню.
        /// </summary>
        /// <param name="value">Размер сдвига указателей.</param>
        private void MovePointer(sbyte value = 1) {
            int row = this.getRow(this.lblPtrLeft);
            row += value;
            row %= tblInner.RowCount;
            if (row < 0)
                row = tblInner.RowCount - 1;

            tblInner.SetRow(this.lblPtrLeft, row);
            tblInner.SetRow(this.lblPtrRight, row);
        }

        private int getRow(Control control) {
            return tblInner.GetPositionFromControl(control).Row;
        }
    }
}
