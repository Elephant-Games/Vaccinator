using System;
using System.Threading;
using System.Windows.Forms;
using Vaccinator.Exceptions.WindowExceptions;
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
            this.OpenWindow<FormMainMenu>();
        }

        /// <summary>
        /// Получение единственного экземпляра класса ActivityController
        /// </summary>
        /// <returns>Объект ActivityController</returns>
        public static ActivityController GetInstance() {
            if (instance == null)
                instance = new ActivityController();
            return instance;
        }

        /// <summary>
        /// Открытие окна в MDI-контейнере
        /// </summary>
        /// <typeparam name="T">Класс окна, которое нужно открыть</typeparam>
        public void OpenWindow<T>() where T : Form, new() {
            DateTime time = DateTime.Now;
            while (this.parentForm == null || !this.parentForm.IsInit && (time - DateTime.Now).TotalMilliseconds < 1000)
                Thread.Sleep(10);
            if (!this.parentForm.IsInit)
                throw new IncompleteInitException();

            if (this.currentForm != null)
                this.currentForm.Close();
            this.parentForm.Invoke(new MethodInvoker(() => {
                this.currentForm = new T();
                this.currentForm.MdiParent = this.parentForm;
                this.currentForm.Show();
            }));
        }

        /// <summary>
        /// Создание основы - главного MDI-контейнера
        /// </summary>
        private void createParentWindow() {
            this.parentForm = new FormMain();
            Application.Run(this.parentForm);
        }
    }
}
