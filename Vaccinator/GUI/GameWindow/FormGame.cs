﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaccinator.GUI.GameWindow {
    public partial class FormGame : FormMain {
        public FormGame() {
            InitializeComponent();
            base.fontsInit(this);

            Game.Game.GetInstance(this);
        }


    }
}
