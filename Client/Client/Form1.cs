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
            //CompteDAO c = new CompteDAO();
            //MessageBox.Show(c.chercherCompteAvecIdCommande("59245eb46b083").Nom);
            //participeDAO pa = new participeDAO();
            //MessageBox.Show(pa.readAll().Count.ToString());
            FaitDAO f = new FaitDAO();
            //MessageBox.Show(f.findById("5").LeProduit.Nom);
            //MessageBox.Show(f.findById("10").LaTaille.Libelle.ToString());

            foreach(Fait fait in f.readAll())
            {
                MessageBox.Show(fait.LeProduit.Nom.ToString());
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
