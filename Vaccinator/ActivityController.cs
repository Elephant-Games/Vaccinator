using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Vaccinator.Exceptions.WindowExceptions;
using Vaccinator.GUI;
using Vaccinator.GUI.MainMenu;

namespace Vaccinator {
    /// <summary>
    /// Контроллер, отвечающий за переключение между окнами и передачу данных
    /// </summary>
    class ActivityController {
        private static ActivityController instance;

        private Thread curFThread;
        private FormMain parentForm;
        private FormMain currentForm;

        private Stack<Type> guiStack;

        private ActivityController() {
            this.guiStack = new Stack<Type>();

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
        /// Открытие предыдущего окна в контейнере (операция "prev").
        /// </summary>
        public void OpenPrevWindow() {
            if (this.guiStack.Count < 2)
                return;//throw new InsufficientExecutionStackException("В стеке мало данных!");
            this.guiStack.Pop(); //Избавляемся от типа текущего окна
            this.OpenWindow(this.guiStack.Pop());
        }

        /// <summary>
        /// Открытие окна в контейнере.
        /// </summary>
        /// <typeparam name="T">Класс окна, которое нужно открыть.</typeparam>
        public void OpenWindow<T>() where T : FormMain, new() {
            initOpenWindow();
            this.currentForm = new T();
            endOpenWindow();

            this.guiStack.Push(typeof(T));
        }

        /// <summary>
        /// Открытие окна в контейнере
        /// </summary>
        /// <typeparam name="T">Класс окна, которое нужно открыть</typeparam>
        public void OpenWindow(Type type) {
            initOpenWindow();
            this.currentForm = Activator.CreateInstance(type) as FormMain;
            endOpenWindow();

            this.guiStack.Push(type);
        }

        private void initOpenWindow() {
            var time = DateTime.Now;
            while (this.parentForm == null || !this.parentForm.IsInit && (time - DateTime.Now).TotalMilliseconds < 5000)
                Thread.Sleep(10);
            if (!this.parentForm.IsInit)
                throw new IncompleteInitException();

            if (this.currentForm != null)
                this.currentForm.Invoke(new MethodInvoker(() => this.currentForm.Close()));
        }

        private void endOpenWindow() {
            this.parentForm.Invoke(new MethodInvoker(() => {
                //this.currentForm.MdiParent = this.parentForm;
                this.currentForm.TopLevel = false;
                this.currentForm.Parent = this.parentForm;
                this.currentForm.Show();
            }));
        }

        /// <summary>
        /// Создание основы - главного контейнера
        /// </summary>
        private void createParentWindow() {
            this.parentForm = new FormMain();
            Application.Run(this.parentForm);
        }
    }
}
