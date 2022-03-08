using System;
using System.Windows.Forms;

namespace Vaccinator.GUI.MainMenu {
    public partial class FormMainMenu : FormMain {

        //TODO: get value from settings
        private const int AUTOPLAY_INTERVAL = 90_000; //ms

        private static int row = -1;

        private System.Timers.Timer autoplayTimer;

        public FormMainMenu() {
            InitializeComponent();

            base.fontsInit(this, this.labelHead);

            if (row == -1)
                row = this.getRow(this.lblPtrLeft);
            else
                this.MovePointer(0);

            this.autoplayTimer = new System.Timers.Timer(AUTOPLAY_INTERVAL);
            this.autoplayTimer.Elapsed += (s, a) => {
                ActivityController.GetInstance().OpenWindow<FormGame>();//TODO: autoplay
            };
            this.autoplayTimer.Start();

            this.KeyUp += frmMainMenu_KeyUp;
            this.FormClosed += (s, a) => this.autoplayTimer.Close();
        }

        private void frmMainMenu_KeyUp(object sender, KeyEventArgs e) {
            this.autoplayTimer.Interval = AUTOPLAY_INTERVAL;
            switch (e.KeyData) {
                case Keys.Up: //TODO: using key constants from settings
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
                    ActivityController.GetInstance().OpenWindow<FormGame>();
                    break;

                case MainMenuChoice.SETTINGS:
                    ActivityController.GetInstance().OpenWindow<Settings.FormSettings>();
                    break;

                case MainMenuChoice.RECORDS:
                    break;

                case MainMenuChoice.AUTHORS:
                    break;

                case MainMenuChoice.EXIT:
                    Program.Exit();
                    break;
            }
        }

        /// <summary>
        /// Перемещает указатели справа и слева от пункта меню.
        /// </summary>
        /// <param name="value">Размер сдвига указателей.</param>
        private void MovePointer(sbyte value = 1) {
            row += value;
            row %= tblInner.RowCount - 1;
            if (row < 0)
                row = tblInner.RowCount - 2;

            tblInner.SetRow(this.lblPtrLeft, row);
            tblInner.SetRow(this.lblPtrRight, row);
        }

        private int getRow(Control control) {
            return tblInner.GetPositionFromControl(control).Row;
        }
    }
}
