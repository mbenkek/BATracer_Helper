using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BATracerHelper
{
    interface IOphod
    {
        void Update();
        Version NovaVerzija { get; set; }
        string UpdateUrl { get; set; }
    }
}
