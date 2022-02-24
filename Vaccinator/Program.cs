using System;
using System.Windows.Forms;
using Vaccinator.Fonts;

namespace Vaccinator {
    static class Program {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            Font.FontsLoad();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ActivityController.GetInstance();
        }

        public static void Exit() {
            Application.Exit();
        }
    }
}
