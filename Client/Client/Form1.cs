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
            MessageBox.Show("Connecté\n\n"+perso.findById("1").Prenom+" "+perso.findById("1").Nom+" "+perso.findById("1").getLePoste+" "+perso.findById("1").Taille);
        }
    }
}
