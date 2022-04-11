using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Vaccinator.GUI.GameWindow {
    public partial class FormGame : FormMain {
        private Thread gameThread;

        public Thread GameThread {
            get {
                return this.gameThread;
            }
        }

        public int TopBarHeight {
            get {
                return this.Height;
            }
        }

        public FormGame() {
            InitializeComponent();
            this.fontsInit(this);

            this.CreateParams.ExStyle |= 0x02000000; //двойная буфферизация

            this.GotFocus += (s, a) => ActivityController.GetInstance().Pause(false);
            this.LostFocus += (s, a) => ActivityController.GetInstance().Pause(true);

            gameThread = new Thread(new ParameterizedThreadStart( (object o) => Vaccinator.Game.Game.GetInstance(o) ));
            gameThread.Start(this);
        }

        public void SetAmmoText(int count) {
            this.Invoke(new MethodInvoker(() => {
                labelAmmoC.Text = count.ToString();
            }));
        }
    }
}
