using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BATracerHelper
{
    class Ophod : BATracerHelper.IOphod
    {
        // Defaultni konstruktor
        public Ophod() { }

        // Privatne varijable za pohranu
        Version newVersion;
        private string INUrl;

        // Getter i Setter metode
        public Version NovaVerzija
        {
            get { return newVersion; }
            set { newVersion = value; }
        }
        public string UpdateUrl
        {
            get { return INUrl; }
            set { INUrl = value; }
        }

        // Citanje podataka za XML fajla i usporedba verzija
        public void Update()
        {
            try
            {
                // Za lokalno testiranje:
                // string xmlURL = "file://C:/TEMP/update.xml";
                string xmlURL = "http://batracerhelper.webs.com/update.xml";

                XmlTextReader reader = new XmlTextReader(xmlURL);
                reader.MoveToContent();
                string elementName = "";

                // Provjera da XML zapocenje sa "ourfancyapp"
                if ((reader.NodeType == XmlNodeType.Element) &&
                    (reader.Name == "ourfancyapp"))
                {
                    while (reader.Read())
                    {
                        // Guta cvorove i pamti imena
                        if (reader.NodeType == XmlNodeType.Element)
                            elementName = reader.Name;
                        else
                        {
                            // za tekstualne ...
                            if ((reader.NodeType == XmlNodeType.Text) &&
                                (reader.HasValue))
                            {
                                // Provjeravamo da li je dohvaceno ime cvora
                                switch (elementName)
                                {
                                    case "version":
                                        // format je: xxx.xxx.xxx.xxx 
                                        newVersion = new Version(reader.Value);
                                        break;
                                    case "url":
                                        UpdateUrl = reader.Value;
                                        break;
                                }
                            }
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception)
            {
            }
        }
    }
}