using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaccinator {
    static class Program {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Vaccinator.Gui.Form1());

            Parser parser = new Parser("https://www.sourcegear.com/diffmerge/downloaded.php"/*"file:///C:/Users/shtya/Desktop/index.html"*/, "text/javascript");
            List<string> list = parser.Parse();
            foreach (string str in list)
                Console.WriteLine(str);
        }
    }
}
