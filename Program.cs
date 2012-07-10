using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BATracerHelper
{

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Prozor());

            //TIMEBOMB?
            //System.DateTime danasnjiDatum = System.DateTime.Today;
            //System.DateTime istjecajniDatum = new System.DateTime(2009, 8, 30, 12, 0, 0);
            //if (danasnjiDatum<istjecajniDatum) Application.Run(new Prozor()); else
            //MessageBox.Show("Bomba!");
        }
    }
}
