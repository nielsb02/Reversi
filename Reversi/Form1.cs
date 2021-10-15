using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    
    public partial class StartUp : Form
    { //Dit is de class van de form van het startscherm, in program.cs is dit form opgegeven in de run, waardoor deze als eerste opstart.
        public StartUp()
        { //Hier worden een aantal standaar waardes gedeclareerd.
            InitializeComponent();
            colorDialog1.Color = Color.White;
            button1.BackColor = colorDialog1.Color;
            colorDialog2.Color = Color.Black;
            button2.BackColor = colorDialog2.Color;
            textBox3.Text = "8";
            textBox4.Text = "8";
        }
        
        public void Start_Click(object sender, EventArgs e)
        {//Waneer er op start wordt geklikt
            //Er worden eerst een aantal variabelen die we nodig hebben in het reversi Form toegekend.
            Color c1 = colorDialog1.Color;
            Color c2 = colorDialog2.Color;
            int breedte = 8; int hoogte = 8;
            string naam1 = textBox1.Text;
            string naam2 = textBox2.Text;

            //Al deze variablen worden gecontroleerd, klopt een van de variablen niet dan krijg je een fout melding.
            try
            {
                breedte = int.Parse(textBox3.Text);
                hoogte = int.Parse(textBox4.Text);
            }
            catch
            {
                MessageBox.Show("U kunt alleen gehele getallen invoeren");
            }

            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Vul voor beide spelers een naam in!");
            else if (textBox1.Text == textBox2.Text)
                MessageBox.Show("Beide spelers kunnen niet dezelfde naam hebben!");
            else if (c1 == c2)
                MessageBox.Show("Kies beide een andere kleur!");
            else if (textBox1.Text.Length > 10 || textBox2.Text.Length > 10)
                MessageBox.Show("Naam kan maximaal uit 12 karakters bestaan!");
            else if (breedte > 12 || hoogte > 12 || breedte < 3 || hoogte < 3)
                MessageBox.Show("de minimale breedte en hoogte is 3 en de maximale breedte en hoogte is 12");
            else if (Hoofdletter(naam1) > 2 || Hoofdletter(naam2) > 2)
                MessageBox.Show("Naam kan maximaal uit twee Hoofdletters bestaan");
            else
            {
                //als alle variabelen kloppen dan wordt het nieuwe form geopend en geef je de variabelen mee.
                Reversi reversi = new Reversi(naam1, naam2, c1, c2, breedte, hoogte);
                reversi.Show();
                this.Hide();
            }
        }
        //in deze methode wordt het aantal hoofdletters in een string geteld.
        private int Hoofdletter(string s)
        {
            int hoofdletter = 0;
            for (int t = 0; t < s.Length; t++)
            {
                if (Char.IsUpper(s[t]))
                    hoofdletter++;
            }
            return hoofdletter;
        }
        //kleur speler 1
        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {
                Color c1 = colorDialog1.Color;
                button1.BackColor = c1;
            }
        }
        //kleur speler 2
        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
            {
                Color c2 = colorDialog2.Color;
                button2.BackColor = c2;
            }
        }
        //door het klikken op de Instructies knop (later van naam gewijzigd), wordt een nieuw form geopend die de spelinstructies bevat. 
        private void button3_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        //Als deze form wordt weggeklikt stopt het programma met runnen.
        private void StartUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(1);
        }
    }
}
