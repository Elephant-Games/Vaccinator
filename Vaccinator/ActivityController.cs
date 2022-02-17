using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.Gui;

namespace Vaccinator {
    /// <summary>
    /// Контроллер, отвечающий за переключение между окнами и передачу данных
    /// </summary>
    class ActivityController {
        private static ActivityController instance;

        private Thread curFThread;
        private Form currentForm;

        private ActivityController() {
            this.curFThread = new Thread(new ParameterizedThreadStart(openWindow));
            this.curFThread.Start(new FormMain());
        }

        public static ActivityController GetInstance() {
            if (instance == null)
                instance = new ActivityController();
            return instance;
        }

        private void openWindow(object form) {
            Application.Run(form as Form);
        }
    }
}
