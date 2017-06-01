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
            JoueurDAO perso = new JoueurDAO();
            foreach(Joueur j in perso.readAll())
            {
                MessageBox.Show(j.LaPhoto.Id.ToString());
            }

            /*JoueurDAO p = new JoueurDAO();
            MessageBox.Show(p.findById("11").DateNaiss.ToString());
            /*ligneCmdDAO perso = new ligneCmdDAO();
             foreach (ligneCmd j in perso.findByIdCommandeEtProduit("59245eb46b083", "1"))
             {
                 MessageBox.Show(j.Quantite.ToString()+" "+j.LaCommande.Id+" "+j.LaTaille.Id+" "+j.LeProduit.Id);
             }*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
