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
            dateTimePicker5.Value=DateTime.Today;
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
                string[] res = dateTimePicker5.Value.ToString().Split('/', ' ');
                string date = res[2] + "-" + res[1] + "-" + res[0];
                Joueur j = new Joueur(Convert.ToInt32(numericUpDown2.Value), float.Parse(textBox2.Text.Replace('.',',')), float.Parse(textBox3.Text.Replace('.', ',')), textBox4.Text.ToString(), textBox1.Text.ToString(), pD.findById(numericUpDown3.Value.ToString()), Convert.ToInt32(numericUpDown1.Value), textBox5.Text.ToString(), textBox6.Text.ToString(), date, textBox8.Text.ToString(), textBox9.Text.ToString(), nD.findById(numericUpDown4.Value.ToString()), phD.findById(numericUpDown5.Value.ToString()));
                jD.create(j);
                MessageBox.Show("Le joueur a bien été ajouté!");
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
                MessageBox.Show("Le joueur a bien été supprimé!");
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
                numericUpDown10.Value = j.Num;
                textBox17.Text = j.Taille.ToString();
                textBox16.Text = j.Poids.ToString();
                textBox15.Text = j.Pied;
                textBox18.Text = j.DateVenueClub;
                numericUpDown9.Value = j.LePoste.Id;
                textBox14.Text = j.Nom;
                textBox13.Text = j.Prenom;
                dateTimePicker6.Value = Convert.ToDateTime(j.DateNaiss);
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
                dateTimePicker6.Value=DateTime.Today;
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
                string[] res = dateTimePicker6.Value.ToString().Split('/', ' ');
                string date = res[2] + "-" + res[1] + "-" + res[0];
                Joueur j = new Joueur(Convert.ToInt32(numericUpDown10.Value), float.Parse(textBox17.Text.Replace('.', ',')), float.Parse(textBox16.Text.Replace('.', ',')), textBox15.Text.ToString(), textBox18.Text.ToString(), pD.findById(numericUpDown9.Value.ToString()), Convert.ToInt32(numericUpDown11.Value), textBox14.Text.ToString(), textBox13.Text.ToString(), date, textBox11.Text.ToString(), textBox10.Text.ToString(), nD.findById(numericUpDown8.Value.ToString()), phD.findById(numericUpDown7.Value.ToString()));
                jD.update(j);
                MessageBox.Show("Le joueur a bien été modifié!");
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
            dateTimePicker6.Value=DateTime.Today;
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
                MessageBox.Show("Le match a bien été supprimé!");
            }
            catch
            {
                MessageBox.Show("ERREUR : Le match n'a pas pu être supprimé.");
            }
        }

        private void button14_Click(object sender, EventArgs e) // Staff Bouton Ajouter
        {
            try
            {
                StaffDAO sD = new StaffDAO();
                RoleDAO rD = new RoleDAO();
                NationaliteDAO nD = new NationaliteDAO();
                PhotoDAO phD = new PhotoDAO();
                string[] res = dateTimePicker3.Value.ToString().Split('/', ' ');
                string date = res[2] + "-" + res[1] + "-" + res[0];
                Staff s = new Staff(rD.findById(numericUpDown25.Value.ToString()), Convert.ToInt32(numericUpDown27.Value), textBox23.Text, textBox22.Text, date, textBox20.Text, textBox19.Text, nD.findById(numericUpDown24.Value.ToString()), phD.findById(numericUpDown23.Value.ToString()));
                sD.create(s);
                MessageBox.Show("Le personnel du staff a bien été ajouté!");
                button13.PerformClick();
            }
            catch
            {
                MessageBox.Show("ERREUR : Le personnel du staff n'a pas pu être ajouté.");
            }
}

        private void button13_Click(object sender, EventArgs e)// Bouton Annuler ==> Staff Ajouter
        {
            numericUpDown25.Value = 0;
            numericUpDown27.Value = 0;
            numericUpDown24.Value = 0;
            numericUpDown23.Value = 0;
            dateTimePicker3.Value = DateTime.Today;
            textBox23.ResetText();
            textBox22.ResetText();
            textBox20.ResetText();
            textBox19.ResetText();
        }

        private void numericUpDown30_ValueChanged(object sender, EventArgs e) // Staff Modifier Changement d'ID 
        {
            StaffDAO sD = new StaffDAO();
            Staff s = sD.findById(numericUpDown30.Value.ToString());
            if (s != null)
            {
                numericUpDown29.Value = s.LeRole.Id;
                numericUpDown28.Value = s.LaNationalite.Id;
                numericUpDown26.Value = s.LaPhoto.Id;
                dateTimePicker4.Value = Convert.ToDateTime(s.DateNaiss);
                textBox26.Text = s.Nom;
                textBox25.Text = s.Prenom;
                textBox24.Text = s.LieuNaiss;
                textBox21.Text = s.Biographie;
            }
            else
            {
                numericUpDown29.Value = 0;
                numericUpDown28.Value = 0;
                numericUpDown26.Value = 0;
                dateTimePicker4.Value = DateTime.Today;
                textBox26.ResetText();
                textBox25.ResetText();
                textBox24.ResetText();
                textBox21.ResetText();
            }
        }

        private void button15_Click(object sender, EventArgs e)// Bouton Annuler ==> Staff Modifier
        {
            numericUpDown30.Value = 0;
            numericUpDown29.Value = 0;
            numericUpDown28.Value = 0;
            numericUpDown26.Value = 0;
            dateTimePicker4.Value = DateTime.Today;
            textBox26.ResetText();
            textBox25.ResetText();
            textBox24.ResetText();
            textBox21.ResetText();
        }

        private void button16_Click(object sender, EventArgs e)// Staff Bouton Modifier
        {
            try
            {
                StaffDAO sD = new StaffDAO();
                RoleDAO rD = new RoleDAO();
                NationaliteDAO nD = new NationaliteDAO();
                PhotoDAO phD = new PhotoDAO();
                string[] res = dateTimePicker4.Value.ToString().Split('/', ' ');
                string date = res[2] + "-" + res[1] + "-" + res[0];
                Staff s = new Staff(rD.findById(numericUpDown29.Value.ToString()), Convert.ToInt32(numericUpDown30.Value), textBox26.Text, textBox25.Text, date, textBox24.Text, textBox21.Text, nD.findById(numericUpDown28.Value.ToString()), phD.findById(numericUpDown26.Value.ToString()));
                sD.update(s);
                MessageBox.Show("Le personnel du staff a bien été modifié!");
                button15.PerformClick();
            }
            catch
            {
                MessageBox.Show("ERREUR : Le personnel du staff n'a pas pu être modifié.");
            }           
        }

        private void button17_Click(object sender, EventArgs e) // Bouton Annuler ==> Staff Supprimer
        {
            numericUpDown31.Value = 0;
        }

        private void supprimerStaff_Click(object sender, EventArgs e) // Staff Bouton Supprimer
        {
            try
            {
                StaffDAO sD = new StaffDAO();
                sD.delete(sD.findById(numericUpDown31.Value.ToString()));
                MessageBox.Show("Le personnel du staff a bien été supprimé!");
                button17.PerformClick();
            }
            catch
            {
                MessageBox.Show("ERREUR : Le personnel du staff n'a pas pu être supprimé.");
            }
        }

        private void btnAnnulerAjoutProduit_Click_1(object sender, EventArgs e)
        {
            idProduit.Value = 0;
            idPhotoProduit.Value = 0;
            txtNomProduit.ResetText();
            txtPrixProduit.ResetText();
            txtDescProduit.ResetText();
        }

        private void btnAjoutProduit_Click_1(object sender, EventArgs e)
        {
            try
            {
                ProduitDAO prD = new ProduitDAO();
                PhotoDAO phD = new PhotoDAO();
                Produit p = new Produit(Convert.ToInt32(idProduit.Value), txtNomProduit.Text.ToString(), float.Parse(txtPrixProduit.Text.Replace('.', ',')), txtDescProduit.Text.ToString(), phD.findById(idPhotoProduit.Value.ToString()), txtTailles.Text);
                MessageBox.Show("Le produit a été ajouté !");
                prD.create(p);
            }
            catch
            {
                MessageBox.Show("ERREUR : Le produit n'a pas pu être ajouté.");
            }
        }

        private void btnAnnulModifProduit_Click_1(object sender, EventArgs e)
        {
            modifIdProduit.Value = 0;
            modifIdPhoto.Value = 0;
            txtModifNom.ResetText();
            txtModifPrix.ResetText();
            txtModifDesc.ResetText();
            txtModifTailles.ResetText();
        }

        private void btnModifProduit_Click_1(object sender, EventArgs e)
        {
            try
            {
                ProduitDAO prD = new ProduitDAO();
                PhotoDAO phD = new PhotoDAO();
                Produit p = new Produit(Convert.ToInt32(modifIdProduit.Value), txtModifNom.Text.ToString(), float.Parse(txtModifPrix.Text.Replace('.', ',')), txtModifDesc.Text.ToString(), phD.findById(modifIdPhoto.Value.ToString()), txtModifTailles.Text);
                MessageBox.Show("Le produit a été modifié !");
                prD.update(p);
            }
            catch
            {
                MessageBox.Show("ERREUR : Le produit n'a pas pu être modifié.");
            }
        }

        private void btnAnnulSuppr_Click_1(object sender, EventArgs e)
        {
            idProduitSuppr.Value = 0;
        }

        private void btnSupprProduit_Click(object sender, EventArgs e)
        {
            try
            {
                ProduitDAO prD = new ProduitDAO();
                prD.delete(prD.findById(idProduitSuppr.Value.ToString()));
                MessageBox.Show("Le produit a été supprimé !");
            }
            catch
            {
                MessageBox.Show("ERREUR : Le produit n'a pas pu être supprimé.");
            }
        }

        private void modifIdProduit_ValueChanged_1(object sender, EventArgs e)
        {
            ProduitDAO prD = new ProduitDAO();
            Produit p = prD.findById(modifIdProduit.Value.ToString());
            if (p != null)
            {
                modifIdProduit.Value = p.Id;
                txtModifNom.Text = p.Nom;
                txtModifPrix.Text = p.Prix.ToString();
                txtModifDesc.Text = p.Description;
                modifIdPhoto.Value = p.LaPhoto.Id;
            }
            else
            {
                modifIdProduit.Value = 0;
                modifIdPhoto.Value = 0;
                txtModifNom.ResetText();
                txtModifPrix.ResetText();
                txtModifDesc.ResetText();
                txtModifTailles.ResetText();
            }
        }
    }
}
