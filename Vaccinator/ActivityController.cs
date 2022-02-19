using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.GUI;

namespace Vaccinator {
    /// <summary>
    /// Контроллер, отвечающий за переключение между окнами и передачу данных
    /// </summary>
    class ActivityController {
        private static ActivityController instance;

        private Thread curFThread;
        private FormMain parentForm;
        private Form currentForm;

        private ActivityController() {
            this.curFThread = new Thread(createParentWindow);
            this.curFThread.Start();
            this.openWindow<FormMainMenu>();
        }

        public static ActivityController GetInstance() {
            if (instance == null)
                instance = new ActivityController();
            return instance;
        }

        private void openWindow<T>() where T : Form, new() {
            DateTime time = DateTime.Now;
            while (this.parentForm == null || !this.parentForm.IsInit && (time - DateTime.Now).TotalMilliseconds < 1000)
                Thread.Sleep(10);
            if (!this.parentForm.IsInit)
                throw new Exception(); //TODO: Change to the other exception

            if (this.currentForm != null)
                this.currentForm.Close();
            this.parentForm.Invoke(new MethodInvoker(() => {
                this.currentForm = new T();
                this.currentForm.MdiParent = this.parentForm;
                this.currentForm.Show();
            }));
        }

        private void createParentWindow() {
            this.parentForm = new FormMain();
            Application.Run(this.parentForm);
        }
    }
}
