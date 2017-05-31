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
            participeDAO pa = new participeDAO();
            MessageBox.Show(pa.readAll().Count.ToString());
            



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
