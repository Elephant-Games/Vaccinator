using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccinator.Properties;

namespace Vaccinator.Fonts {
    class Font {
        public const float D_SIZE_MAIN_TEXT = 50f;
        public const float D_SIZE_MENU_TEXT = 26f;

        private static string path = Application.LocalUserAppDataPath + @"\GorgeousPixel.ttf";
        private static PrivateFontCollection fontCollect = new PrivateFontCollection();
        private static Dictionary<FontName, System.Drawing.Font> fonts = new Dictionary<FontName, System.Drawing.Font>();

        public static void FontsLoad() {
            if (!File.Exists(path))
                File.WriteAllBytes(path, Resources.GorgeousPixel);

            fontCollect.AddFontFile(path);
            fonts.Add( FontName.MENU_TEXT, new System.Drawing.Font( fontCollect.Families[0], D_SIZE_MENU_TEXT ));
            fonts.Add( FontName.MAIN_TEXT, new System.Drawing.Font( fontCollect.Families[0], D_SIZE_MAIN_TEXT ));
        }

        public static System.Drawing.Font GetFont(FontName name) {
            return fonts[name];
        }
    }
}
