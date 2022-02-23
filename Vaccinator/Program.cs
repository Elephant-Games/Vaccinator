using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;
using Vaccinator.Properties;

namespace Vaccinator {
    static class Program {
        public const float D_SIZE_MAIN_TEXT = 50f;
        public const float D_SIZE_MENU_TEXT = 26f;

        private static PrivateFontCollection fontCollect = new PrivateFontCollection();
        private static Dictionary<string, Font> fonts = new Dictionary<string, Font>();

        public static Dictionary<string, Font> Fonts {
            get {
                return fonts;
            }
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            fontsLoad();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ActivityController.GetInstance();
        }

        public static void Exit() {
            Application.Exit();
        }

        private static void fontsLoad() {
            string path = Application.LocalUserAppDataPath + @"\GorgeousPixel.ttf";
            if (!File.Exists(path))
                File.WriteAllBytes(path, Resources.GorgeousPixel);

            fontCollect.AddFontFile(path);
            fonts.Add("menu-text", new Font(fontCollect.Families[0], D_SIZE_MENU_TEXT));
            fonts.Add("main-text", new Font(fontCollect.Families[0], D_SIZE_MAIN_TEXT));
        }
    }
}
