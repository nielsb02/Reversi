using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Reversi
{
    public partial class Reversi : Form
    {
        //Hier worden een aantal member variabelen gedeclareerd en/of toegekend.
        int beurt = 0; int x, y, a, b;
        bool help = false;
        Brush b1, b2;
        int[,] stenen;

        public Reversi(string naam1, string naam2, Color c1, Color c2, int breedte, int hoogte)
        {
            InitializeComponent();
            //eerst wordt de grootte van de array toegekend, afhangend van wat de gebruiker gekozen heeft.
            a = breedte; b = hoogte;
            stenen = new int[a, b];
            //2 nieuwe brushes worden toegekend, naar de kleur die de gebruiker gekozen heeft.
            b1 = new SolidBrush(c1);
            b2 = new SolidBrush(c2);
           
            Schalen(naam1, naam2, c1, c2, breedte, hoogte);

            //De begin stenen worden hun "kleur waarde" (1 of 2) toegekend.
            stenen[a/2 -1, b/ 2 - 1] = 2;
            stenen[a/2, b/2] = 2;
            stenen[a/2 - 1, b/2] = 1;
            stenen[a/2, b/2 -1] = 1;
        }

        private void Reversipanel_Paint(object sender, PaintEventArgs pea)
        {
            LijnenPanel(sender, pea); //Als eerst worden de lijnen getekend.

            Graphics gr = pea.Graphics; 
            //Declareren en toekennen van een aantal variabelen nodig bij het tekenen van de Stenen.
            float schaalx = (panel1.Width / a);
            float schaaly = (panel1.Height / b);
            const int d = 50;
            Pen p = new Pen(Color.Black, 3);
            //In deze for loop worden de Stenen getekend.
                for (int xs = 0; xs < a; xs++)
                {
                    for (int ys = 0; ys < b; ys++)
                    {
                        if (stenen[xs, ys] == 1) //speler 1
                    {
                            gr.FillEllipse(b1, xs * schaalx + 5, ys * schaaly + 5, d, d);
                            gr.DrawEllipse(p, xs * schaalx + 5, ys * schaaly + 5, d, d);
                        } 
                        else if (stenen[xs, ys] == 2) //speler2
                        {
                            gr.FillEllipse(b2, xs * schaalx + 5, ys * schaaly + 5, d, d);
                            gr.DrawEllipse(p, xs * schaalx + 5, ys * schaaly + 5, d, d);
                        }
                        else if (stenen[xs, ys] == 0 && ZetMogelijkheid(xs, ys) == true && help == true)
                        {//Als de speler op de help knop drukt worden er vierkanten getekend op elke plek dat de speler een steen zou kunnen plaatsen.
                            gr.FillRectangle(Brushes.DarkGreen, xs * schaalx + 5, ys * schaaly + 5, 50, 50);
                            gr.DrawRectangle(p, xs * schaalx + 5, ys * schaaly + 5, 50, 50);

                        }
                    }
                }
            BeurtAan.Text = Beurt_Text();
            Speler1.Text = Speler1_Text();
            Speler2.Text = Speler2_Text();
        }
        //In deze void worden de lijnen van het bord getekend.
        void LijnenPanel(object sender, PaintEventArgs pea)
        { 
            Graphics gr = pea.Graphics;
            Pen p = new Pen(Color.Black, 5); 
            int Lijny = 0; int Lijnx = 0;
            for (int t = 0; t <= a; t++)
            {
                for (int s = 0; s <= b; s++)
                {
                    Lijnx = (60 * t);
                    Lijny = (60 * s);
                    gr.DrawLine(p, Lijnx, 0, Lijnx, panel1.Height);
                    gr.DrawLine(p, 0, Lijny, panel1.Width, Lijny);
                }
            }
        }

        void Muisklik(object sender, MouseEventArgs mea)
        {
            //Als er geklikt wordt, wordt er berekent in welk vak er geklikt wordt.
            float schaalx = (panel1.Width / a);
            float schaaly = (panel1.Height / b);
            x = (int)(mea.X / schaalx);
            y = (int)(mea.Y / schaaly);
            //Hier wordt het geplaatste steentje zijn kleur waarde toegekend.
            if (stenen[x, y] == 0 && ZetMogelijkheid(x, y) == true)
            {
                if (beurt % 2 == 0)
                {
                    stenen[x, y] = 1;
                }
                else
                {
                    stenen[x, y] = 2;
                }

                //na een geldige zet: verdwijenen de help steenjtes, wordt oa. de methode aangeroepen die elke ingesloten steen de zelfde kleur waarde gegeven.
                help = false; 
                bool Mogelijk = ZetMogelijkheid(x, y);
                zet(Mogelijk, x, y);
                beurt++;
                BeurtAan.Text = Beurt_Text();
                panel1.Invalidate();
            }
            //In deze if opdracht, wordt gekeken of er nog mogelijke zetten zijn, zo niet dan wordt er gepast.
            int q = 0;
            if (HoeveelMogelijk() == 0)
            {
                if (q == 0)
                {
                    beurt++;
                    BeurtAan.Text = Beurt_Text();
                    q++;
                }
                //Wordt er twee keer achter elkaar gepast dan wordt de methode win aangeroepen.
                if (q == 1)
                {
                    if (HoeveelMogelijk() == 0)
                    {
                        Win();
                    }
                }
            }
        }
        //Deze methode berekent hoeveel mogelijke zetten er zijn.
        private int HoeveelMogelijk()
        {
            int waar = 0;
            for (int t = 0; t < a; t++)
            {
                for (int s = 0; s < b; s++)
                {
                    if (stenen[t, s] == 0 && ZetMogelijkheid(t, s))
                        waar++;
                }
            }
            return waar;
        }
        //Deze methode kijkt of een zet Mogelijk is.
        private bool ZetMogelijkheid(int x, int y)
        {
            bool mogelijk = false;
            for (int t = 1; t >= -1; t--)
            {
                for (int s = 1; s >= -1; s--)
                {
                    if((s != 0 || t != 0))
                    { 
                    int Tnew = t; int Snew = s;
                        while ((Tnew + x) < a && (Tnew + x) >= 0 && (Snew + y) < b && (Snew + y) >= 0  && stenen[Tnew + x, Snew + y] == (2 - beurt % 2))
                        {
                            Tnew += t;
                            Snew += s;
                        }
                        if ((Tnew + x) < a && (Tnew + x) >= 0 && (Snew + y) < b && (Snew + y) >= 0 && stenen[Tnew + x, Snew + y] == (beurt % 2 + 1) && (Math.Abs(Tnew) >=2 || Math.Abs(Snew) >= 2))
                        {
                            mogelijk = true;
                        }
                    }
                }
            }
            return mogelijk;
        }
        //In deze methode worden alle zet richting methodes aangeroepen.
        public void zet(bool mogelijk, int x, int y)
        {
            Nzet(x, y, mogelijk);
            NOzet(x, y, mogelijk);
            Ozet(x, y, mogelijk);
            ZOzet(x, y, mogelijk);
            Zzet(x, y, mogelijk);
            ZWzet(x, y, mogelijk);
            Wzet(x, y, mogelijk);
            NWzet(x, y, mogelijk);
        }
        //In de Win methode wordt er gekeken wie er gewonnen heeft, ofdat het gelijk spel is.
        private void Win()
        {
            int score1 = int.Parse(Speler1_Text());
            int score2 = int.Parse(Speler2_Text());
            if (score1 > score2)
                MessageBox.Show(Naam1.Text + " Heeft gewonnen!");
            else if (score2 > score1)
                MessageBox.Show(Naam2.Text + " Heeft gewonnen!");
            else if (score1 == score2)
                MessageBox.Show(Naam2.Text + "Remise!");
        }
        //Hier wordt geteld hoeveel stenen speler 1 heeft en dit wordt vervolgens omgezet naar een string.
        private string Speler1_Text()
        {
            string speler1 = "";
            int s1 = 0;

            for (int t = 0; t < a; t++)
            {
                for (int s = 0; s < b; s++)
                {
                    if (stenen[t, s] == 1)
                    {
                        s1++;
                    }
                    speler1 = s1.ToString();
                }
            }
            return speler1;
        }
        //Hier wordt geteld hoeveel stenen speler 2 heeft en dit wordt vervolgens omgezet naar een string.
        private string Speler2_Text()
        {
            string speler2 = "";
            int s2 = 0;

            for (int t = 0; t < a; t++)
            {
                for (int s = 0; s < b; s++)
                {
                    if (stenen[t, s] == 2)
                    {
                        s2++;
                    }
                    speler2 = s2.ToString();
                }
            }
            return speler2;
        }
        //Hier wordt gekeken welke speler er aan de beurt is.
        private string Beurt_Text()
        {
            string beurtaan = "";
            if (beurt % 2 == 1)
            {
                beurtaan = "De beurt is aan:" + Environment.NewLine + Naam2.Text;

            }
            if (beurt % 2 == 0)
            {
                beurtaan = "De beurt is aan:" + Environment.NewLine + Naam1.Text;
            }
            return beurtaan;
        }
        //Een nieuwspel begint, dus hier wordt het programma opnieuw al zijn beginwaardes toegekend.
        private void NieuwSpel_Click(object sender, EventArgs e)
        {
            for (int t = 0; t < a; t++)
            {
                for (int s = 0; s < b; s++)
                {
                    stenen[t, s] = 0;
                }
                stenen[a / 2 - 1, b / 2 - 1] = 2;
                stenen[a / 2, b / 2] = 2;
                stenen[a / 2 - 1, b / 2] = 1;
                stenen[a / 2, b / 2 - 1] = 1;
                beurt = 0;
                help = false;
                panel1.Invalidate();
                Speler1.Text = Speler1_Text();
                Speler2.Text = Speler2_Text();
                BeurtAan.Text = Beurt_Text();
            }
        }
        //Door het klikken op deze knop, wordt het starscherm opnieuw geopend en het spel gesloten.
        private void Startscherm_Click(object sender, EventArgs e)
        {
            StartUp start = new StartUp();
            start.Show();
            this.Hide();
        }
        //Als op deze knop wordt geklikt, worden de help stenen getekend.
        private void Help_Click(object sender, EventArgs e)
        {
            if (help == true)
                help = false;
            else 
                help = true;
            
            panel1.Invalidate();
        }
        //Als deze form wordt weggeklikt stopt het programma met runnen.
        private void Reversi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
        //door verschillende groottes van het bord, wordt voor elke grootte het hele form geschaal, dat gebeurt in deze methode.
        private void Schalen(string naam1, string naam2, Color c1, Color c2, int breedte, int hoogte)
        {
            this.ClientSize = new Size(a * 60 + 250, b * 65);
            panel1.Size = new Size(a * 60, b * 60);
            panel1.Location = new Point((this.Width - panel1.Width - 50), (this.Height - panel1.Height) / 2 - 20);

            Font fb = new Font("Cooper Black", 8 + (int)(0.75 * b));

            Startscherm.Size = new Size(175, 15 + 3 * b);
            Startscherm.Location = new Point(15, panel1.Location.Y + panel1.Height - 15 - 3 * b);
            Startscherm.Font = fb;
            NieuwSpel.Size = new Size(175, 15 + 3 * b);
            NieuwSpel.Location = new Point(15, Startscherm.Location.Y - 15 - 3 * b - 5);
            NieuwSpel.Font = fb;
            Help.Size = new Size(175, 15 + 3 * b);
            Help.Location = new Point(15, NieuwSpel.Location.Y - 15 - 3 * b - 5);
            Help.Font = fb;

            Font f = new Font("Cooper Black", 12 + (int)(0.75 * b));
            Naam1.Font = f;
            Naam1.Location = new Point(10, panel1.Location.Y);
            Naam1.Text = naam1;
            Naam2.Font = f;
            Naam2.Location = new Point(10, panel1.Location.Y + 12 + b + 10);
            Naam2.Text = naam2;

            Speler1.Font = f;
            Speler1.Location = new Point(175, panel1.Location.Y);
            Speler1.Text = Speler1_Text();
            Speler2.Font = f;
            Speler2.Location = new Point(175, panel1.Location.Y + 12 + b + 10);
            Speler2.Text = Speler2_Text();

            Font f1 = new Font("Cooper Black", 8 + (int)(0.75 * b));
            BeurtAan.Font = f1;
            BeurtAan.Location = new Point(10, Naam2.Location.Y + +12 + b + 3 * b);
            BeurtAan.Text = Beurt_Text();
        }
        public int Nzet(int X, int Y, bool Mogelijk)
        {
            Y--;
            int tel = 0;
            while (Y >= 0)
            {
                if (stenen[X, Y] == 0)
                    return 0;
                else if (stenen[X, Y] % 2 == beurt % 2) 
                    tel++;
                else
                {
                   for (int t = 0; t < tel; t++)
                   {
                        if (Mogelijk)
                        {
                            Y++;
                            if (beurt % 2 == 0)
                                stenen[X, Y] = 1;
                            if (beurt % 2 == 1)
                                stenen[X, Y] = 2;
                        }
                    }
                    return tel;
                }
                Y--;
            }
            return 0;
        }
        public int NOzet(int X, int Y, bool Mogelijk)
        {
            X++;
            Y--;
            int tel = 0;
            while (Y >= 0 && X < a)
            {
                if (stenen[X, Y] == 0)
                    return 0;
                else if (stenen[X, Y] % 2 == beurt % 2)
                    tel++;
                else
                {
                    for (int t = 0; t < tel; t++)
                    {
                        if (Mogelijk)
                        {
                            Y++;
                            X--;
                            if (beurt % 2 == 0)
                                stenen[X, Y] = 1;
                            if (beurt % 2 == 1)
                                stenen[X, Y] = 2;
                        }
                    }
                    return tel;
                }
                X++;
                Y--;
            }
            return 0;
        }
        public int Ozet(int X, int Y, bool Mogelijk)
        {
            X++;
            int tel = 0;
            while (X < a)
            {
                if (stenen[X, Y] == 0)
                    return 0;
                else if (stenen[X, Y] % 2 == beurt % 2)
                    tel++;
                else
                {
                    for (int t = 0; t < tel; t++)
                    {
                        if (Mogelijk)
                        {
                            X--;
                            if (beurt % 2 == 0)
                                stenen[X, Y] = 1;
                            if (beurt % 2 == 1)
                                stenen[X, Y] = 2;
                        }
                    }
                    return tel;
                }
                X++;
            }
            return 0;
        }

        public int ZOzet(int X, int Y, bool Mogelijk)
        {
            Y++;
            X++;
            int tel = 0;
            while (Y < b && X < a)
            {
                if (stenen[X, Y] == 0)
                    return 0;
                else if (stenen[X, Y] % 2 == beurt % 2)
                    tel++;
                else
                {
                    for (int t = 0; t < tel; t++)
                    {
                        if (Mogelijk)
                        {
                            Y--;
                            X--;
                            if (beurt % 2 == 0)
                                stenen[X, Y] = 1;
                            if (beurt % 2 == 1)
                                stenen[X, Y] = 2;
                        }
                    }
                    return tel;
                }
                Y++;
                X++;
            }
            return 0;
        }
        public int Zzet(int X, int Y, bool Mogelijk)
        {
            Y++;
            int tel = 0;
            while (Y < b)
            {
                if (stenen[X, Y] == 0)
                    return 0;
                else if (stenen[X, Y] % 2 == beurt % 2)
                    tel++;
                else
                {
                    for (int t = 0; t < tel; t++)
                    {
                        if (Mogelijk)
                        {
                            Y--;
                            if (beurt % 2 == 0)
                                stenen[X, Y] = 1;
                            if (beurt % 2 == 1)
                                stenen[X, Y] = 2;
                        }
                    }
                    return tel;
                }
                Y++;
            }
            return 0;
        }
        public int ZWzet(int X, int Y, bool Mogelijk)
        {
            Y++;
            X--;
            int tel = 0;
            while (Y < b && X >= 0)
            {
                if (stenen[X, Y] == 0)
                    return 0;
                else if (stenen[X, Y] % 2 == beurt % 2)
                    tel++;
                else
                {
                    for (int t = 0; t < tel; t++)
                    {
                        if (Mogelijk)
                        {
                            Y--;
                            X++;
                            if (beurt % 2 == 0)
                                stenen[X, Y] = 1;
                            if (beurt % 2 == 1)
                                stenen[X, Y] = 2;
                        }
                    }
                    return tel;
                }
                Y++;
               X--;
            }
            return 0;
        }
        public int Wzet(int X, int Y, bool Mogelijk)
        {
            X--;
            int tel = 0;
            while (X >= 0)
            {
                if (stenen[X, Y] == 0)
                    return 0;
                else if (stenen[X, Y] % 2 == beurt % 2)
                    tel++;
                else
                {
                    for (int t = 0; t < tel; t++)
                    {
                        if (Mogelijk)
                        {
                            X++;
                            if (beurt % 2 == 0)
                                stenen[X, Y] = 1;
                            if (beurt % 2 == 1)
                                stenen[X, Y] = 2;
                        }
                    }
                    return tel;
                }
                X--;
            }
            return 0;
        }
        public int NWzet(int X, int Y, bool Mogelijk)
        {
            X--;
            Y--;
            int tel = 0;
            while (X >= 0 && Y>=0)
            {
                if (stenen[X, Y] == 0)
                    return 0;
                else if (stenen[X, Y] % 2 == beurt % 2)
                    tel++;
                else
                {
                    for (int t = 0; t < tel; t++)
                    {
                        if (Mogelijk)
                        {
                            X++;
                            Y++;
                            if (beurt % 2 == 0)
                                stenen[X, Y] = 1;
                            if (beurt % 2 == 1)
                                stenen[X, Y] = 2;
                        }
                    }
                    return tel;
                }
                X--;
                Y--;
            }
            return 0;
        }
    }
}
