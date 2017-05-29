using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* MatchsDAO perso = new MatchsDAO();
             foreach(Matchs j in perso.readAll())
             {
                 MessageBox.Show(j.Id+" "+j.DateMatch+" "+j.Heure+" " + j.ExterieurON + " Stade :" + j.LeStade.Libelle+ " " + j.LeStade.NbPlaces+" Adversaire : "+j.LAdversaire.Libelle);
             }*/
            MatchsDAO p = new MatchsDAO();
            MessageBox.Show(p.findById("1").LAdversaire.Libelle.ToString());
        }
    }
}
