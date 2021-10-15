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
    public partial class Help : Form
    { //Dit is de class die hoort bij de help form, deze wordt geopend door de instructies knop.
        public Help()
        {
            InitializeComponent();
            instructies();
        }
        //in de deze methode voegen we de tekst toe door dit alles is in één label te schrijven.
        public void instructies()
        {
            Font f = new Font("Microsoft Sans Serif", 14);
            label1.Font = f;
            label1.Text = "Reversi Help:" + Environment.NewLine +
                "" + Environment.NewLine + //"Environment.NewLine" slaat een regel over.
                "Reversi wordt gespeeld op een bord met vierkante velden." + Environment.NewLine +
                "Het spel wordt gespeeld met 2 spelers. Elke speler kiest" + Environment.NewLine +
                "een eigen kleur waarmee het spel gespeeld gaat worden." + Environment.NewLine +
                "Aan het begin van het spel liggen er 4 stenen klaar" + Environment.NewLine +
                "verdeeld in de verschillende kleuren. Het is de bedoeling" + Environment.NewLine +
                "dat de stenen van de tegenstander worden ingesloten." + Environment.NewLine +
                "Insluiten kan gebeuren op verschillende manieren " + Environment.NewLine +
                "bijvoorbeeld: horizontaal, verticaal of diagonaal." + Environment.NewLine +
                "Zodra er geen zetten meer mogelijk zijn dan moet de " + Environment.NewLine +
                "speler passen en de beurt doorgeven aan de tegenstander." + Environment.NewLine +
                "Als er geen zetten meer mogelijk zijn heeft de speler" + Environment.NewLine +
                "met de meeste stenen gewonnen. De stenen kunnen geplaatst " + Environment.NewLine +
                "worden door op een vakje te klikken.";
        }
    }
}
