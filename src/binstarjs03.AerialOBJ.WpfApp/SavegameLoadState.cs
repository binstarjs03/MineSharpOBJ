﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binstarjs03.AerialOBJ.WpfApp;

public delegate void SavegameLoadStateHandler(SavegameLoadState state);

public enum SavegameLoadState
{
    Opened,
    Closed,
}