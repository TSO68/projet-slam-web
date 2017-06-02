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
            numericUpDown1.Value=0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
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
            Joueur j = new Joueur(Convert.ToInt32(numericUpDown2.Value), float.Parse(textBox2.Text.Replace('.',',')), float.Parse(textBox3.Text.Replace('.', ',')), textBox4.Text.ToString(), textBox1.Text.ToString(), pD.findById(numericUpDown3.Value.ToString()), Convert.ToInt32(numericUpDown1.Value), textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString(), textBox9.Text.ToString(), nD.findById(numericUpDown4.Value.ToString()), phD.findById(numericUpDown5.Value.ToString()));
            jD.create(j);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            JoueurDAO jD = new JoueurDAO();
            jD.delete(jD.findById(numericUpDown6.Value.ToString()));
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            JoueurDAO jD = new JoueurDAO();
            Joueur j = jD.findById(numericUpDown11.Value.ToString());
            if (j != null)
            {
                string[] res = j.DateNaiss.ToString().Split('/', ':', ' ');
                numericUpDown10.Value = j.Num;
                textBox17.Text = j.Taille.ToString();
                textBox16.Text = j.Poids.ToString();
                textBox15.Text = j.Pied;
                textBox18.Text = j.DateVenueClub;
                numericUpDown9.Value = j.LePoste.Id;
                textBox14.Text = j.Nom;
                textBox13.Text = j.Prenom;
                textBox12.Text = res[2] + "-" + res[1] + "-" + res[0];
                textBox11.Text = j.LieuNaiss;
                textBox10.Text = j.Biographie;
                numericUpDown8.Value = j.LaNationalite.Id;
                numericUpDown7.Value = j.LaPhoto.Id;
            }
            else
            {
                numericUpDown10.Value = 0;
                textBox17.ResetText();
                textBox16.ResetText();
                textBox15.ResetText();
                textBox18.ResetText();
                numericUpDown9.Value=0;
                textBox14.ResetText();
                textBox13.ResetText();
                textBox12.ResetText();
                textBox11.ResetText();
                textBox10.ResetText();
                numericUpDown8.Value = 0;
                numericUpDown7.Value = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            JoueurDAO jD = new JoueurDAO();
            PosteDAO pD = new PosteDAO();
            NationaliteDAO nD = new NationaliteDAO();
            PhotoDAO phD = new PhotoDAO();
            MessageBox.Show("taille = "+ float.Parse(textBox17.Text.Replace('.', ','))+" poids = "+ float.Parse(textBox16.Text.Replace('.', ','))+" date = "+ textBox12.Text.ToString());
            Joueur j = new Joueur(Convert.ToInt32(numericUpDown10.Value), float.Parse(textBox17.Text.Replace('.', ',')), float.Parse(textBox16.Text.Replace('.', ',')), textBox15.Text.ToString(), textBox18.Text.ToString(), pD.findById(numericUpDown9.Value.ToString()), Convert.ToInt32(numericUpDown11.Value), textBox14.Text.ToString(), textBox13.Text.ToString(), textBox12.Text.ToString(), textBox11.Text.ToString(), textBox10.Text.ToString(), nD.findById(numericUpDown8.Value.ToString()), phD.findById(numericUpDown7.Value.ToString()));
            jD.update(j);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown10.Value = 0;
            textBox17.ResetText();
            textBox16.ResetText();
            textBox15.ResetText();
            textBox18.ResetText();
            numericUpDown9.Value = 0;
            textBox14.ResetText();
            textBox13.ResetText();
            textBox12.ResetText();
            textBox11.ResetText();
            textBox10.ResetText();
            numericUpDown8.Value = 0;
            numericUpDown7.Value = 0;
        }
    }
}
