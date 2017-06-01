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


            /*participeDAO perso = new participeDAO();
            foreach(participe j in perso.readAll())
            {
                MessageBox.Show(j.ButMarques.ToString());
            }*/
            /*
            participeDAO p = new participeDAO();
            MessageBox.Show(p.findByIdMatch("5").);*/
             participeDAO perso = new participeDAO();
             foreach (participe j in perso.findByIdMatch("5"))
             {
                 MessageBox.Show(j.PasseDecisives.ToString());
             }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
