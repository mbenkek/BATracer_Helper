using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BATracerHelper
{
    class Strategija : BATracerHelper.IStrategija
    {
        // Defaultni konstruktor
        public Strategija() { }

        // Privatne varijable za pohranu
        private int INLaps;
        private int INStops;
        private int INSc;
        private int INPr;
        private int INStint;
        private bool INMode;
        private int INVrijeme;
        private int INVrijeme2;

        // Getter i Setter metode
        public int BrojKrugova
        {
            get { return INLaps; }
            set { INLaps = value; }
        }
        public int BrojPitova
        {
            get { return INStops; }
            set { INStops = value; }
        }
        public int SliderSc
        {
            get { return INSc; }
            set { INSc = value; }
        }
        public int SliderPr
        {
            get { return INPr; }
            set { INPr = value; }
        }
        public int SliderStint
        {
            get { return INStint; }
            set { INStint = value; }
        }
        public bool CheckBoxMode
        {
            get { return INMode; }
            set { INMode = value; }
        }
        public int SliderVrijeme
        {
            get { return INVrijeme; }
            set { INVrijeme = value; }
        }

        public int SliderVrijeme2
        {
            get { return INVrijeme2; }
            set { INVrijeme2 = value; }
        }


        // Mega metoda za izracun pitova i vremena
        public string Racun()
        {

            // StringBuilder za izlaz kao string
            StringBuilder sb = new StringBuilder("");

            //Klasa za generiranje random brojeva
            Random RandomClass = new Random();

            // Pomocne varijable za ustimavanje postotaka sa slajdera
            float INScF = ((float)SliderSc / 10);
            float INPrF = ((float)SliderPr / 10);
            float INStintF = (((float)SliderStint / 10));

            // Inicijalno
            int FirstBase = 0;
            int Base = 0;

            // Ako vrijeme nismo dirali
            int ktools = 0;
            string gume = "Soft/Hard";

            // Odredimo koliko je dugacak nas prvi pit
            if (INStintF > 0.5)
            {
                INStintF = (float)INStintF + 1 - (float)0.5;
                FirstBase = (int)((float)(BrojKrugova / (BrojPitova + 1)) * INStintF);
            }

            if (INStintF == 0.5)
            {
                INStintF = 1;
                FirstBase = (int)((float)(BrojKrugova / (BrojPitova + 1)) * INStintF);
            }

            if (INStintF < 0.5)
            {
                INStintF = -(float)INStintF + (float)0.5;
                FirstBase = (int)((float)(BrojKrugova / (BrojPitova + 1))) - (int)((float)(BrojKrugova / (BrojPitova + 1)) * INStintF);
            }

            // Osnovni stint
            if (BrojPitova != 0) Base = (int)((float)((BrojKrugova - FirstBase) / (BrojPitova)));


            // Inicijalno
            int Inkrement = 0;

            // Dijelimo krugove i odredujemo pitove
            for (int i = 0; i < BrojPitova; i++)
            {
                if (!CheckBoxMode) { Inkrement = Inkrement + (RandomClass.Next(-(int)((float)FirstBase * (float)0.07), (int)((float)FirstBase * (float)0.07))) + FirstBase; } else { Inkrement = Inkrement + FirstBase; }
                if (Base != 0 && BrojPitova != 0) sb.AppendLine("Pit in lap: " + Convert.ToString(Inkrement));
                FirstBase = Base;
            }

            // Racunamo ktools faktor i gume

            int[] bitvremena = { 0, 5, 9, 14, 18, 23, 27, 32, 36, 42, 45, 50 };
            string[] bitguma = { "Dry", "Dry OR Intermediate", "Intermediate", "Intermediate", "Intermediate", "Intermediate", "Intermediate OR Wet", "Wet", "Wet", "Wet", "Wet", "Wet" };

            ktools = bitvremena[SliderVrijeme2] - bitvremena[SliderVrijeme];
            gume = bitguma[SliderVrijeme2];



            // Sredujemo SC,PSR,KToolsWF i gume
            sb.AppendLine("Set Safety Car Reaction: " + Convert.ToString((int)(INScF * Base)));
            sb.AppendLine("Set Pit Stop Reschedule: " + Convert.ToString((int)(INPrF * Base)));
            sb.AppendLine("KTools Weather Factor: " + Convert.ToString(ktools));
            sb.AppendLine("Tires type: " + gume);

            // Vracamo string
            return sb.ToString();
        }
    }
}
