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

        private void testToolStripMenuItem_Click(object sender, EventArgs e) // Menu Joueur
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
        private void pypToolStripMenuItem_Click(object sender, EventArgs e) // Menu Staff
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

        private void matchMenu_Click(object sender, EventArgs e) // Menu Match
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

        private void produitMenu_Click(object sender, EventArgs e) // Menu Produit
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

        private void button2_Click_1(object sender, EventArgs e) // Bouton Annuler ==> Joueur Ajouter
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

        private void button1_Click_1(object sender, EventArgs e) // Joueur Bouton Ajouter
        {
            try
            {
                JoueurDAO jD = new JoueurDAO();
                PosteDAO pD = new PosteDAO();
                NationaliteDAO nD = new NationaliteDAO();
                PhotoDAO phD = new PhotoDAO();
                Joueur j = new Joueur(Convert.ToInt32(numericUpDown2.Value), float.Parse(textBox2.Text.Replace('.',',')), float.Parse(textBox3.Text.Replace('.', ',')), textBox4.Text.ToString(), textBox1.Text.ToString(), pD.findById(numericUpDown3.Value.ToString()), Convert.ToInt32(numericUpDown1.Value), textBox5.Text.ToString(), textBox6.Text.ToString(), textBox7.Text.ToString(), textBox8.Text.ToString(), textBox9.Text.ToString(), nD.findById(numericUpDown4.Value.ToString()), phD.findById(numericUpDown5.Value.ToString()));
                jD.create(j);
            }
            catch
            {
                MessageBox.Show("ERREUR : Le joueur n'a pas pu être ajouté.");
            }
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e) // Joueur Bonton Supprimer
        {
            try
            {
                JoueurDAO jD = new JoueurDAO();
                jD.delete(jD.findById(numericUpDown6.Value.ToString()));
            }
            catch
            {
                MessageBox.Show("ERREUR : Le joueur n'a pas pu être supprimé.");
            }
            
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)// Joueur Modifier Changement d'ID 
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

        private void button6_Click(object sender, EventArgs e) // Joueur Bonton Modifier
        {
            try
            {
                JoueurDAO jD = new JoueurDAO();
                PosteDAO pD = new PosteDAO();
                NationaliteDAO nD = new NationaliteDAO();
                PhotoDAO phD = new PhotoDAO();
                Joueur j = new Joueur(Convert.ToInt32(numericUpDown10.Value), float.Parse(textBox17.Text.Replace('.', ',')), float.Parse(textBox16.Text.Replace('.', ',')), textBox15.Text.ToString(), textBox18.Text.ToString(), pD.findById(numericUpDown9.Value.ToString()), Convert.ToInt32(numericUpDown11.Value), textBox14.Text.ToString(), textBox13.Text.ToString(), textBox12.Text.ToString(), textBox11.Text.ToString(), textBox10.Text.ToString(), nD.findById(numericUpDown8.Value.ToString()), phD.findById(numericUpDown7.Value.ToString()));
                jD.update(j);
            }
            catch
            {
                MessageBox.Show("ERREUR : Le joueur n'a pas pu être modifié.");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)// Bouton Annuler ==> Joueur Modifier
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

        private void button4_Click_1(object sender, EventArgs e)// Bouton Annuler ==> Joueur Supprimer
        {
            numericUpDown6.Value = 0;
        }

        private void button7_Click(object sender, EventArgs e)// Bouton Annuler ==> Match Ajouter
        {
            numericUpDown16.Value = 0;
            numericUpDown15.Value = 0;
            numericUpDown14.Value = 0;
            numericUpDown13.Value = 0;
            numericUpDown12.Value = 0;
            dateTimePicker1.Value = DateTime.Today;
            checkBox1.Checked = false;
            
        }

        private void button8_Click(object sender, EventArgs e)// Match Bonton Ajouter
        {
            try
            {
                MatchsDAO mD = new MatchsDAO();
                AdversaireDAO aD = new AdversaireDAO();
                StadeDAO sD = new StadeDAO();
                Matchs m = new Matchs(Convert.ToInt32(numericUpDown16.Value), dateTimePicker1.Value, Convert.ToInt32(numericUpDown15.Value), Convert.ToInt32(numericUpDown14.Value), checkBox1.Checked, aD.findById(numericUpDown13.Value.ToString()), sD.findById(numericUpDown12.Value.ToString()));
                MessageBox.Show("Le match a été ajouté !");
                mD.create(m);
                button7.PerformClick();
            }
            catch
            {
                MessageBox.Show("ERREUR : Le match n'a pas pu être ajouté.");
            }
        }

        private void button9_Click(object sender, EventArgs e) // Bouton Annuler ==> Match Modifier
        {
            numericUpDown21.Value = 0;
            numericUpDown20.Value = 0;
            numericUpDown19.Value = 0;
            numericUpDown18.Value = 0;
            numericUpDown17.Value = 0;
            dateTimePicker2.Value = DateTime.Today;
            checkBox2.Checked = false;
        }

        private void button10_Click(object sender, EventArgs e)// Match Bonton Modifier
        {
            try
            {
                MatchsDAO mD = new MatchsDAO();
                AdversaireDAO aD = new AdversaireDAO();
                StadeDAO sD = new StadeDAO();
                Matchs m = new Matchs(Convert.ToInt32(numericUpDown16.Value), dateTimePicker1.Value, Convert.ToInt32(numericUpDown15.Value), Convert.ToInt32(numericUpDown14.Value), checkBox1.Checked, aD.findById(numericUpDown13.Value.ToString()), sD.findById(numericUpDown12.Value.ToString()));
                 MessageBox.Show("Le match a été modifié !");
                mD.update(m);
                button7.PerformClick();
            }
            catch
            {
                MessageBox.Show("ERREUR : Le match n'a pas pu être modifié.");
            }
        }

        private void numericUpDown21_ValueChanged(object sender, EventArgs e)// Match Modifier Changement d'ID 
        {
            MatchsDAO mD = new MatchsDAO();
            Matchs m = mD.findById(numericUpDown21.Value.ToString());
            if (m != null)
            {
                numericUpDown21.Value = m.Id;
                numericUpDown20.Value = m.ScoreDom;
                numericUpDown19.Value = m.ScoreExt;
                numericUpDown18.Value = m.LAdversaire.Id;
                numericUpDown17.Value = m.LeStade.Id;
                dateTimePicker2.Value = m.DateMatch;
                checkBox2.Checked = m.ExterieurON;
            }
            else
            {
                numericUpDown21.Value = 0;
                numericUpDown20.Value = 0;
                numericUpDown19.Value = 0;
                numericUpDown18.Value = 0;
                numericUpDown17.Value = 0;
                dateTimePicker2.Value = DateTime.Today;
                checkBox2.Checked = false;
            }
        }

        private void button11_Click(object sender, EventArgs e) // Bouton Annuler ==> Match Supprimer
        {
            numericUpDown22.Value = 0;
        }

        private void button12_Click(object sender, EventArgs e)// Match Bouton Supprimer
        {
            try
            {
                MatchsDAO mD = new MatchsDAO();
                mD.delete(mD.findById(numericUpDown22.Value.ToString()));
            }
            catch
            {
                MessageBox.Show("ERREUR : Le match n'a pas pu être supprimé.");
            }
        }
    }
}
