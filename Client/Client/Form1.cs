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

        string[] valeurs = new string[13]; // Nombre d'attributs
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false; // Joueur
            tabControl2.Visible = false; // Staff
            tabControl3.Visible = false; // Match
            tabControl4.Visible = false; // Produit

            joueurMenu.PerformClick();
        }

        

        private void trouverToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {        
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void setAttributs(int table)
        {
 
        }

        private void button3_Click(object sender, EventArgs e) // Bouton ajouter
        {
   
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_Enter_1(object sender, EventArgs e)
        {

        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            joueurMenu.BackColor = Color.DarkGray;
            staffMenu.BackColor = Color.Empty;
            matchMenu.BackColor = Color.Empty;
            produitMenu.BackColor = Color.Empty;
            tabControl1.Visible = true; // Joueur
            tabControl2.Visible = false; // Staff
            tabControl3.Visible = false; // Match
            tabControl4.Visible = false; // Produit

        }
        private void pypToolStripMenuItem_Click(object sender, EventArgs e)
        {
            joueurMenu.BackColor = Color.Empty;
            staffMenu.BackColor = Color.DarkGray;
            matchMenu.BackColor = Color.Empty;
            produitMenu.BackColor = Color.Empty;
            tabControl1.Visible = false; // Joueur
            tabControl2.Visible = true; // Staff
            tabControl3.Visible = false; // Match
            tabControl4.Visible = false; // Produit
        }

        private void matchMenu_Click(object sender, EventArgs e)
        {
            joueurMenu.BackColor = Color.Empty;
            staffMenu.BackColor = Color.Empty;
            matchMenu.BackColor = Color.DarkGray;
            produitMenu.BackColor = Color.Empty;
            tabControl1.Visible = false; // Joueur
            tabControl2.Visible = false; // Staff
            tabControl3.Visible = true; // Match
            tabControl4.Visible = false; // Produit
        }

        private void produitMenu_Click(object sender, EventArgs e)
        {
            joueurMenu.BackColor = Color.Empty;
            staffMenu.BackColor = Color.Empty;
            matchMenu.BackColor = Color.Empty;
            produitMenu.BackColor = Color.DarkGray;
            tabControl1.Visible = false; // Joueur
            tabControl2.Visible = false; // Staff
            tabControl3.Visible = false; // Match
            tabControl4.Visible = true; // Produit
        }

        private void joueurTab_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            numericUpDown1.ResetText();
            numericUpDown2.ResetText();
            numericUpDown3.ResetText();
            numericUpDown4.ResetText();
            numericUpDown5.ResetText();
            textBox1.ResetText();
            textBox2.ResetText();
            textBox3.ResetText();
            textBox4.ResetText();
            textBox5.ResetText();
            textBox6.ResetText();
            textBox7.ResetText();
            textBox8.ResetText();
            textBox9.ResetText();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            JoueurDAO jD = new JoueurDAO();
            PosteDAO pD = new PosteDAO();
            NationaliteDAO nD = new NationaliteDAO();
            PhotoDAO phD = new PhotoDAO();
            Joueur j = new Joueur(Convert.ToInt32(numericUpDown2.Value), float.Parse(textBox2.Text), float.Parse(textBox3.Text), textBox4.Text.ToString(), textBox1.Text.ToString(), pD.findById(numericUpDown3.Value.ToString()), Convert.ToInt32(textBox5.Text), numericUpDown1.Value.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString(), textBox9.Text.ToString(), nD.findById(numericUpDown4.Value.ToString()), phD.findById(numericUpDown5.Value.ToString()));
        }
    }
}
