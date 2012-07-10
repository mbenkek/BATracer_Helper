using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BATracerHelper
{
    public partial class Prozor : Form
    {
        public Prozor()
        {
            InitializeComponent();
            CenterToScreen();

        }

        private void Prozor_Load(object sender, EventArgs e)
        {

            // Inicijalne vrijednosti labela vezane uz slajder za vrijeme
            label14.Text = "Bone Dry";
            label21.Text = "Bone Dry";
            label18.Image = global::BATracerHelper.Properties.Resources.boneDry;
            label17.Image = global::BATracerHelper.Properties.Resources.boneDry;

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Strategija F12009 = new Strategija();

            if (textBox1.Text.Length != 0 && textBox1.Text.ToString() != "0")
            {
                F12009.BrojKrugova = Convert.ToInt32(textBox1.Text);
            }
            else F12009.BrojKrugova = 0;

            if (textBox2.Text.Length != 0 && textBox2.Text.ToString() != "0")
            {
                F12009.BrojPitova = Convert.ToInt32(textBox2.Text);
            }
            else F12009.BrojPitova = 0;

            F12009.SliderSc = trackBar1.Value;
            F12009.SliderPr = trackBar2.Value;
            F12009.SliderStint = trackBar3.Value;
            F12009.SliderVrijeme = trackBar4.Value;
            F12009.SliderVrijeme2 = trackBar5.Value;
            F12009.CheckBoxMode = checkBox1.Checked;
            textBox3.Text = F12009.Racun();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show(this, "BATRacer Helper " + curVersion.ToString() + "\n\nAuthor: Marko Benkek, marko.benkek@me.com", "BATracer Helper");
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Mode - if unchecked each scheduled pit stop will be a \nbit randomized, usually 7% +/-, depending on stint lenght.\n\nJust repeatedly press Calculate! to get new values.", "Manual");
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            switch (trackBar4.Value)
            {
                case 0:
                    label14.Text = "Bone Dry";
                    label18.Image = global::BATracerHelper.Properties.Resources.boneDry;
                    break;
                case 1:
                    label14.Text = "Greasy";
                    label18.Image = global::BATracerHelper.Properties.Resources.greasy;
                    break;
                case 2:
                    label14.Text = "Moist";
                    label18.Image = global::BATracerHelper.Properties.Resources.moist;
                    break;
                case 3:
                    label14.Text = "Drizzle";
                    label18.Image = global::BATracerHelper.Properties.Resources.drizzle;
                    break;
                case 4:
                    label14.Text = "Light Rain";
                    label18.Image = global::BATracerHelper.Properties.Resources.lightRain;
                    break;
                case 5:
                    label14.Text = "Rain";
                    label18.Image = global::BATracerHelper.Properties.Resources.rain;
                    break;
                case 6:
                    label14.Text = "Wet and Slippery";
                    label18.Image = global::BATracerHelper.Properties.Resources.wetAndSlippery;
                    break;
                case 7:
                    label14.Text = "Steady Rain";
                    label18.Image = global::BATracerHelper.Properties.Resources.steadyRain;
                    break;
                case 8:
                    label14.Text = "Heavy Rain";
                    label18.Image = global::BATracerHelper.Properties.Resources.heavyRain;
                    break;
                case 9:
                    label14.Text = "Treacherous Rain";
                    label18.Image = global::BATracerHelper.Properties.Resources.treacherousRainAndSpray;
                    break;
                case 10:
                    label14.Text = "Monsoon";
                    label18.Image = global::BATracerHelper.Properties.Resources.monsoon;
                    break;
                case 11:
                    label14.Text = "Strom";
                    label18.Image = global::BATracerHelper.Properties.Resources.storm;
                    break;
                default:
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Idemo po update ako ga ima
        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Updater je tipa Ophod koji raspolaze sa Update(), NovaVerzija i UpdateUrl
            Ophod Updater = new Ophod();

            // Prozvacimo XML i dohvatimo iz njega verziju na webu i update URL
            Updater.Update();

            // Trenutna verzija aplikacije
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            // Usporedimo verzije
            if (curVersion.CompareTo(Updater.NovaVerzija) < 0)
            {
                // Dijalog ako novija verzija postoji
                string title = "You're soooo " + curVersion + " !";
                string question = "Current version: " + curVersion + "\nUpgrade to " + Updater.NovaVerzija + " ?";
                if (DialogResult.Yes ==
                 MessageBox.Show(this, question, title,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question))
                {
                    System.Diagnostics.Process.Start(Updater.UpdateUrl);
                }
            }
            // Dijalog ako novija verzija ne postoji
            else
            {
                MessageBox.Show(this, "You're up to date, running: " + curVersion, "Still new and shiny!");

            }
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            switch (trackBar5.Value)
            {
                case 0:
                    label21.Text = "Bone Dry";
                    label17.Image = global::BATracerHelper.Properties.Resources.boneDry;
                    break;
                case 1:
                    label21.Text = "Greasy";
                    label17.Image = global::BATracerHelper.Properties.Resources.greasy;
                    break;
                case 2:
                    label21.Text = "Moist";
                    label17.Image = global::BATracerHelper.Properties.Resources.moist;
                    break;
                case 3:
                    label21.Text = "Drizzle";
                    label17.Image = global::BATracerHelper.Properties.Resources.drizzle;
                    break;
                case 4:
                    label21.Text = "Light Rain";
                    label17.Image = global::BATracerHelper.Properties.Resources.lightRain;
                    break;
                case 5:
                    label21.Text = "Rain";
                    label17.Image = global::BATracerHelper.Properties.Resources.rain;
                    break;
                case 6:
                    label21.Text = "Wet and Slippery";
                    label17.Image = global::BATracerHelper.Properties.Resources.wetAndSlippery;
                    break;
                case 7:
                    label21.Text = "Steady Rain";
                    label17.Image = global::BATracerHelper.Properties.Resources.steadyRain;
                    break;
                case 8:
                    label21.Text = "Heavy Rain";
                    label17.Image = global::BATracerHelper.Properties.Resources.heavyRain;
                    break;
                case 9:
                    label21.Text = "Treacherous Rain";
                    label17.Image = global::BATracerHelper.Properties.Resources.treacherousRainAndSpray;
                    break;
                case 10:
                    label21.Text = "Monsoon";
                    label17.Image = global::BATracerHelper.Properties.Resources.monsoon;
                    break;
                case 11:
                    label21.Text = "Strom";
                    label17.Image = global::BATracerHelper.Properties.Resources.storm;
                    break;
                default:
                    break;
            }
        }
    }
}