using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BATracerHelper
{
    interface IStrategija
    {
        // Ulazne varijable iz forme
        int BrojKrugova { get; set; }
        int BrojPitova { get; set; }
        int SliderSc { get; set; }
        int SliderPr { get; set; }
        int SliderStint { get; set; }
        int SliderVrijeme { get; set; }
        int SliderVrijeme2 { get; set; }
        bool CheckBoxMode { get; set; }
        string Racun();
    }
}
