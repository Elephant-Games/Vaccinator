﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaccinator.GUI.GameWindow {
    public partial class FormGame : FormMain {
        private Thread game;

        public Thread Game {
            get {
                return this.game;
            }
        }

        public FormGame() {
            InitializeComponent();
            base.fontsInit(this);

            base.CreateParams.ExStyle |= 0x02000000; //двойная буфферизация

            this.GotFocus += (s, a) => ActivityController.GetInstance().Pause(false);
            this.LostFocus += (s, a) => ActivityController.GetInstance().Pause(true);

            game = new Thread(new ParameterizedThreadStart( (object o) => Vaccinator.Game.Game.GetInstance(o) ));
            game.Start(this);
        }

        public void MoveControl(Control control, Point destination) {
            control.Location = destination;
        }
    }
}
