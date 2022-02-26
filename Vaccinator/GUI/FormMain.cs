using System;
using System.Windows.Forms;
using Vaccinator.Fonts;

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

            this.Shown += (s, a) => {
                this.isInit = true;
            };
            this.FormClosed += formClosed;
            this.PreviewKeyDown += this.formMain_PreviewKeyDown;
        }

        private void formMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            if (e.KeyCode == Keys.Escape)
                ActivityController.GetInstance().OpenPrevWindow();
        }

        private void formClosed(object sender, EventArgs args) {
            if (typeof(FormMain) == sender.GetType())
                Program.Exit();
        }

        protected void fontsInit(Form form, Control head) {
            foreach (Control control in form.Controls)
                control.Font = Fonts.Font.GetFont(FontName.MENU_TEXT);
            head.Font = Fonts.Font.GetFont(FontName.MAIN_TEXT);
        }
    }
}
