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
            string id = textBox3.Text.ToString();
            switch (comboBox1.Text.ToString())
            {
                
                case "ADVERSAIRE":
                    AdversaireDAO a = new AdversaireDAO();
                    a.delete(a.findById(id));
                    break;
                case "COMMANDE":
                    CommandeDAO c = new CommandeDAO();
                    c.delete(c.findById(id));
                    break;
                case "COMPTE":
                    CompteDAO co = new CompteDAO();
                    co.delete(co.findById(id));
                    break;
                case "JOUEUR":
                    JoueurDAO j = new JoueurDAO();
                    j.delete(j.findById(id));
                    break;
                case "MATCHS":
                    MatchsDAO m = new MatchsDAO();
                    m.delete(m.findById(id));
                    break;
                case "NATIONALITE":
                    NationaliteDAO n = new NationaliteDAO();
                    n.delete(n.findById(id));
                    break;
                case "PERSONNEL":
                    PersonnelDAO pe = new PersonnelDAO();
                    pe.delete(pe.findById(id));
                    break;
                case "PHOTO":
                    PhotoDAO ph = new PhotoDAO();
                    ph.delete(ph.findById(id));
                    break;
                case "POSTE":
                    PosteDAO po = new PosteDAO();
                    po.delete(po.findById(id));
                    break;
                case "PRODUIT":
                    ProduitDAO pr = new ProduitDAO();
                    pr.delete(pr.findById(id));
                    break;
                case "ROLE":
                    RoleDAO r = new RoleDAO();
                    r.delete(r.findById(id));
                    break;
                case "STADE":
                    StadeDAO s = new StadeDAO();
                    s.delete(s.findById(id));
                    break;
                case "STAFF":
                    StaffDAO st = new StaffDAO();
                    st.delete(st.findById(id));
                    break;
                case "TAILLE":
                    TailleDAO t = new TailleDAO();
                    t.delete(t.findById(id));
                    break;



            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ////////////////////////////////////////// Remplir combobox
            string[] table = new string[17];

            table[0] = "ADVERSAIRE";            table[1] = "COMMANDE";            table[2] = "COMPTE";            table[3] = "fait";            table[4] = "JOUEUR";            table[5] = "ligneCmd";            table[6] = "MATCHS";            table[7] = "NATIONALITE";            table[8] = "participe";            table[9] = "PERSONNEL";            table[10] = "PHOTO";            table[11] = "POSTE";            table[12] = "PRODUIT";            table[13] = "ROLE";            table[14] = "STADE";            table[15] = "STAFF";            table[16] = "TAILLE";

            for (int i = 0; i <= 16;i++)
            {
                comboBox2.Items.Add(table[i]);
                comboBox1.Items.Add(table[i]);
                comboBox5.Items.Add(table[i]);
            }
            //////////////////////////////////////// Fin remplir combobox

            

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trouverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox3.Visible = false;
            groupBox2.Visible = true;
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Visible = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonnelDAO p = new PersonnelDAO();
            //int i=0;

            //while ()
            //{
            //    i++;
            //}

            
            foreach(Personnel pa in p.readAll())
            {
                if(pa.Nom == "Jérémy")
                {
                    MessageBox.Show("TEst");
                }
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           // comboBox3.Items.Clear();
           // comboBox3.Text = "";
            switch (comboBox2.Text.ToString())
            {
                case "ADVERSAIRE":setAttributs(0);
                        break;
                case "COMMANDE":setAttributs(1);
                    break;
                case "COMPTE":setAttributs(2);
                    break;
                case "fait":setAttributs(3);
                    break;
                case "JOUEUR":setAttributs(4);
                    break;
                case "ligneCmd":setAttributs(5);
                    break;
                case "MATCHS":setAttributs(6);
                    break;
                case "NATIONALITE":setAttributs(7);
                    break;
                case "participe":setAttributs(8);
                    break;
                case "PERSONNEL":setAttributs(9);
                    break;
                case "PHOTO":setAttributs(10);
                    break;
                case "POSTE":setAttributs(11);
                    break;
                case "PRODUIT":setAttributs(12);
                    break;
                case "ROLE":setAttributs(13);
                    break;
                case "STADE":setAttributs(14);
                    break;
                case "STAFF":setAttributs(15);
                    break;
                case "TAILLE":setAttributs(16);
                    break;
            }
            
            //if(comboBox3.SelectedItem.ToString() == "ADVERSAIRE")
            //{

            //}
        }

        private void setAttributs(int table)
        {
            //////////////////////////////////////// Debut remplir attributs

            string[][] attributs = new string[17][];

            attributs[0] = new string[14];
            attributs[1] = new string[14];
            attributs[2] = new string[14];
            attributs[3] = new string[14];
            attributs[4] = new string[14];
            attributs[5] = new string[14];
            attributs[6] = new string[14];
            attributs[7] = new string[14];
            attributs[8] = new string[14];
            attributs[9] = new string[14];
            attributs[10] = new string[14];
            attributs[11] = new string[14];
            attributs[12] = new string[14];
            attributs[13] = new string[14];
            attributs[14] = new string[14];
            attributs[15] = new string[14];
            attributs[16] = new string[14];


            attributs[0][0] = "id";
            attributs[0][1] = "libelle";
            attributs[0][2] = "logo";
            attributs[0][3] = "id_STADE";
            attributs[0][4] = null;
            attributs[0][5] = null;
            attributs[0][6] = null;
            attributs[0][7] = null;
            attributs[0][8] = null;
            attributs[0][9] = null;
            attributs[0][10] = null;
            attributs[0][11] = null;
            attributs[0][12] = null;
            attributs[0][13] = null;
            
            

            attributs[1][0] = "id";
            attributs[1][1] = "dateCommande";
            attributs[1][2] = "id_COMPTE";
            attributs[1][3] = null;
            attributs[1][4] = null;
            attributs[1][5] = null;
            attributs[1][6] = null;
            attributs[1][7] = null;
            attributs[1][8] = null;
            attributs[1][9] = null;
            attributs[1][10] = null;
            attributs[1][11] = null;
            attributs[1][12] = null;
            attributs[1][13] = null;
            
            


            attributs[2][0] = "id";
            attributs[2][1] = "mail";
            attributs[2][2] = "mdp";
            attributs[2][3] = "nom";
            attributs[2][4] = "prenom";
            attributs[2][5] = "tel";
            attributs[2][6] = "adresse";
            attributs[2][7] = "cp";
            attributs[2][8] = "ville";
            attributs[2][9] = null;
            attributs[2][10] = null;
            attributs[2][11] = null;
            attributs[2][12] = null;
            attributs[2][13] = null;
            
            

            attributs[3][0] = "id";
            attributs[3][1] = "id_TAILLE";
            attributs[3][2] = null;
            attributs[3][3] = null;
            attributs[3][4] = null;
            attributs[3][5] = null;
            attributs[3][6] = null;
            attributs[3][7] = null;
            attributs[3][8] = null;
            attributs[3][9] = null;
            attributs[3][10] = null;
            attributs[3][11] = null;
            attributs[3][12] = null;
            attributs[3][13] = null;
            
            

            attributs[4][0] = "num";
            attributs[4][1] = "taille";
            attributs[4][2] = "poids";
            attributs[4][3] = "pied";
            attributs[4][4] = "venueClub";
            attributs[4][5] = "id_POSTE";
            attributs[4][6] = "id";
            attributs[4][7] = "nom";
            attributs[4][8] = "prenom";
            attributs[4][9] = "dateNaiss";
            attributs[4][10] = "lieuNaiss";
            attributs[4][11] = "biographie";
            attributs[4][12] = "id_NATIONALITE";
            attributs[4][13] = "id_PHOTO";

            attributs[5][0] = "id_PRODUIT";
            attributs[5][1] = "id_TAILLE";
            attributs[5][2] = "id_COMMANDE";
            attributs[5][3] = "quantite";
            attributs[5][4] = null;
            attributs[5][5] = null;
            attributs[5][6] = null;
            attributs[5][7] = null;
            attributs[5][8] = null;
            attributs[5][9] = null;
            attributs[5][10] = null;
            attributs[5][11] = null;
            attributs[5][12] = null;
            attributs[5][13] = null;
            
            


            attributs[6][0] = "id";
            attributs[6][1] = "dateMatch";
            attributs[6][2] = "heure";
            attributs[6][3] = "scoreDom";
            attributs[6][4] = "scoreExt";
            attributs[6][5] = "exterieurON";
            attributs[6][6] = "id_ADVERSAIRE";
            attributs[6][7] = "id_STADE";
            attributs[6][8] = null;
            attributs[6][9] = null;
            attributs[6][10] = null;
            attributs[6][11] = null;
            attributs[6][12] = null;
            attributs[6][13] = null;
            
            

            attributs[7][0] = "id";
            attributs[7][1] = "libelle";
            attributs[7][2] = null;
            attributs[7][3] = null;
            attributs[7][4] = null;
            attributs[7][5] = null;
            attributs[7][6] = null;
            attributs[7][7] = null;
            attributs[7][8] = null;
            attributs[7][9] = null;
            attributs[7][10] = null;
            attributs[7][11] = null;
            attributs[7][12] = null;
            attributs[7][13] = null;
            
            


            attributs[8][0] = "id";
            attributs[8][1] = "id_PERSONNEL";
            attributs[8][2] = "butMarques";
            attributs[8][3] = "passeDecisives";
            attributs[8][4] = "cartonJauneON";
            attributs[8][5] = "cartonRougeON";
            attributs[8][6] = "minutesJouees";
            attributs[8][7] = null;
            attributs[8][8] = null;
            attributs[8][9] = null;
            attributs[8][10] = null;
            attributs[8][11] = null;
            attributs[8][12] = null;
            attributs[8][13] = null;
            
            

            attributs[9][0] = "id";
            attributs[9][1] = "nom";
            attributs[9][2] = "prenom";
            attributs[9][3] = "dateNaiss";
            attributs[9][4] = "lieuNaiss";
            attributs[9][5] = "biographie";
            attributs[9][6] = "id_NATIONALITE";
            attributs[9][7] = "id_PHOTO";
            attributs[9][8] = null;
            attributs[9][9] = null;
            attributs[9][10] = null;
            attributs[9][11] = null;
            attributs[9][12] = null;
            attributs[9][13] = null;
            
            

            attributs[10][0] = "id";
            attributs[10][1] = "lien";
            attributs[10][2] = null;
            attributs[10][3] = null;
            attributs[10][4] = null;
            attributs[10][5] = null;
            attributs[10][6] = null;
            attributs[10][7] = null;
            attributs[10][8] = null;
            attributs[10][9] = null;
            attributs[10][10] = null;
            attributs[10][11] = null;
            attributs[10][12] = null;
            attributs[10][13] = null;
            
            

            attributs[11][0] = "id";
            attributs[11][1] = "libelle";
            attributs[11][2] = null;
            attributs[11][3] = null;
            attributs[11][4] = null;
            attributs[11][5] = null;
            attributs[11][6] = null;
            attributs[11][7] = null;
            attributs[11][8] = null;
            attributs[11][9] = null;
            attributs[11][10] = null;
            attributs[11][11] = null;
            attributs[11][12] = null;
            attributs[11][13] = null;
            
            

            attributs[12][0] = "id";
            attributs[12][1] = "nom";
            attributs[12][2] = "prix";
            attributs[12][3] = "description";
            attributs[12][4] = "id_PHOTO";
            attributs[12][5] = null;
            attributs[12][6] = null;
            attributs[12][7] = null;
            attributs[12][8] = null;
            attributs[12][9] = null;
            attributs[12][10] = null;
            attributs[12][11] = null;
            attributs[12][12] = null;
            attributs[12][13] = null;
           
            

            attributs[13][0] = "id";
            attributs[13][1] = "libelle";
            attributs[13][2] = null;
            attributs[13][3] = null;
            attributs[13][4] = null;
            attributs[13][5] = null;
            attributs[13][6] = null;
            attributs[13][7] = null;
            attributs[13][8] = null;
            attributs[13][9] = null;
            attributs[13][10] = null;
            attributs[13][11] = null;
            attributs[13][12] = null;
            attributs[13][13] = null;
          
            

            attributs[14][0] = "id";
            attributs[14][1] = "libelle";
            attributs[14][2] = "nbPlaces";
            attributs[14][3] = null;
            attributs[14][4] = null;
            attributs[14][5] = null;
            attributs[14][6] = null;
            attributs[14][7] = null;
            attributs[14][8] = null;
            attributs[14][9] = null;
            attributs[14][10] = null;
            attributs[14][11] = null;
            attributs[14][12] = null;
            attributs[14][13] = null;
         
            

            attributs[15][0] = "id";
            attributs[15][1] = "id_ROLE";
            attributs[15][2] = "nom";
            attributs[15][3] = "prenom";
            attributs[15][4] = "dateNaiss";
            attributs[15][5] = "lieuNaiss";
            attributs[15][6] = "biographie";
            attributs[15][7] = "id_NATIONALITE";
            attributs[15][8] = "id_PHOTO";
            attributs[15][9] = null;
            attributs[15][10] = null;
            attributs[15][11] = null;
            attributs[15][12] = null;
            attributs[15][13] = null;

            attributs[16][0] = "id";
            attributs[16][1] = "libelle";
            attributs[16][2] = null;
            attributs[16][3] = null;
            attributs[16][4] = null;
            attributs[16][5] = null;
            attributs[16][6] = null;
            attributs[16][7] = null;
            attributs[16][8] = null;
            attributs[16][9] = null;
            attributs[16][10] = null;
            attributs[16][11] = null;
            attributs[16][12] = null;
            attributs[16][13] = null;
            
            


            for (int i = 0; i <= 13; i++) // Nombre d'attribut max ?
            {
                if (!string.IsNullOrEmpty(attributs[table][i]))
                {
                    comboBox4.Items.Add(attributs[table][i].ToString());
                }
            }

            //////////////////////////////////////// Fin remplir attributs
        }

        private void button3_Click(object sender, EventArgs e) // Bouton ajouter
        {
            valeurs[comboBox4.SelectedIndex] = textBox2.Text.ToString();
            bool ok = true;
            for(int i = 0;i <= comboBox4.Items.Count-1; i++)
            {
                if(valeurs[i] == null)
                {
                    ok = false;
                    MessageBox.Show("Veuillez entrer toutes les valeurs.");
                }
                
            }
            if(ok == true)
            {
                
                switch (comboBox5.Text.ToString())
                {

                    case "ADVERSAIRE":
                        AdversaireDAO a = new AdversaireDAO();
                        StadeDAO s = new StadeDAO();
                        Adversaire ad = new Adversaire(Convert.ToInt32(valeurs[0]), valeurs[1], valeurs[2], s.findById(valeurs[3]));
                        a.create(ad);
                        break;
                    case "COMMANDE":
                        CommandeDAO c = new CommandeDAO();
                        Commande co = new Commande(valeurs[0], valeurs[1], Convert.ToInt32(valeurs[2]));
                        c.create(co);
                        break;
                    case "COMPTE": 
                        CompteDAO com = new CompteDAO();
                        Compte comp = new Compte(Convert.ToInt32(valeurs[0]), valeurs[1], valeurs[2], valeurs[3], valeurs[4], valeurs[5], valeurs[6], valeurs[7], valeurs[8]);
                        com.create(comp);
                        break;
                    case "JOUEUR": 
                        JoueurDAO j = new JoueurDAO();
                        PosteDAO pos = new PosteDAO();
                        NationaliteDAO nat = new NationaliteDAO();
                        PhotoDAO phot = new PhotoDAO();
                        Joueur jo = new Joueur(Convert.ToInt32(valeurs[0]), float.Parse(valeurs[1]), float.Parse(valeurs[2]), valeurs[3], valeurs[4], pos.findById(valeurs[5]),Convert.ToInt32(valeurs[6]),valeurs[7],valeurs[8],valeurs[9],valeurs[10],valeurs[11], nat.findById(valeurs[12]),phot.findById(valeurs[13]));

                        j.create(jo);
                        break;
                    case "MATCHS": 
                        MatchsDAO m = new MatchsDAO();
                        AdversaireDAO adv = new AdversaireDAO();
                        StadeDAO st = new StadeDAO();
                        string[] res = valeurs[1].ToString().Split('-', ':', ' ');
                        MessageBox.Show(res[0]+" " + res[1]+" "+ res[2].ToString()+" "+ valeurs[2].ToString());
                        DateTime date = new DateTime(Int32.Parse(res[0]), Int32.Parse(res[1]), Int32.Parse(res[2]), Int32.Parse(valeurs[2]), 0, 0);
                        Matchs ma = new Matchs(Convert.ToInt32(valeurs[0]), date, Convert.ToInt32(valeurs[3]), Convert.ToInt32(valeurs[4]), Convert.ToBoolean(valeurs[5]), adv.findById(valeurs[6]), st.findById(valeurs[7]));
                        m.create(ma);
                        break;
                    case "NATIONALITE": 
                        NationaliteDAO n = new NationaliteDAO();
                        Nationalite na = new Nationalite(Convert.ToInt32(valeurs[0]), valeurs[1]);
                        n.create(na);
                        break;
                    case "PERSONNEL": 
                        PersonnelDAO pe = new PersonnelDAO();
                        NationaliteDAO nati = new NationaliteDAO();
                        PhotoDAO photo = new PhotoDAO();
                        Personnel perso = new Personnel(Convert.ToInt32(valeurs[0]), valeurs[1], valeurs[2], valeurs[3], valeurs[4], valeurs[5], nati.findById(valeurs[6]), photo.findById(valeurs[7]));
                        pe.create(perso);
                        break;
                    case "PHOTO": 
                        PhotoDAO p = new PhotoDAO();
                        PersonnelDAO per = new PersonnelDAO();
                        ProduitDAO pr = new ProduitDAO();
                        Photo ph = new Photo(Convert.ToInt32(valeurs[0]), valeurs[1], per.findById(valeurs[2]), pr.findById(valeurs[3]));
                        p.create(ph);
                        break;
                    case "POSTE": 
                        PosteDAO post = new PosteDAO();
                        Poste poste = new Poste(Convert.ToInt32(valeurs[0]), valeurs[1]);
                        post.create(poste);
                        break;
                    case "PRODUIT"://fait
                        ProduitDAO prod = new ProduitDAO();
                        PhotoDAO pho = new PhotoDAO();
                        Produit produit = new Produit(Convert.ToInt32(valeurs[0]), valeurs[1], Convert.ToInt32(valeurs[2]), valeurs[3], pho.findById(valeurs[4]));
                        prod.create(produit);
                        break;
                    case "ROLE": 
                        RoleDAO r = new RoleDAO();
                        Role ro = new Role(Convert.ToInt32(valeurs[0]), valeurs[1]);
                        r.create(ro);
                        break;
                    case "STADE": 
                        StadeDAO stad = new StadeDAO();
                        Stade sta = new Stade(Convert.ToInt32(valeurs[0]), valeurs[1], Convert.ToInt32(valeurs[2]));
                        stad.create(sta);
                        break;
                    case "STAFF": 
                        StaffDAO staf = new StaffDAO();
                        NationaliteDAO natio = new NationaliteDAO();
                        PhotoDAO photoD = new PhotoDAO();
                        RoleDAO rol = new RoleDAO();
                        Staff staff = new Staff(rol.findById(valeurs[1]),Convert.ToInt32(valeurs[0]), valeurs[2], valeurs[3], valeurs[4], valeurs[5], valeurs[6], natio.findById(valeurs[7]), photoD.findById(valeurs[8]));
                        staf.create(staff);
                        break;
                    case "TAILLE": 
                        TailleDAO t = new TailleDAO();
                        Taille ta = new Taille(Convert.ToInt32(valeurs[0]), valeurs[1]);
                        t.create(ta);
                        break;



                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox3.Visible = true;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.Text = "";
            switch (comboBox5.Text.ToString())
            {
                case "ADVERSAIRE":
                    setAttributs(0);
                    break;
                case "COMMANDE":
                    setAttributs(1);
                    break;
                case "COMPTE":
                    setAttributs(2);
                    break;
                case "fait":
                    setAttributs(3);
                    break;
                case "JOUEUR":
                    setAttributs(4);
                    break;
                case "ligneCmd":
                    setAttributs(5);
                    break;
                case "MATCHS":
                    setAttributs(6);
                    break;
                case "NATIONALITE":
                    setAttributs(7);
                    break;
                case "participe":
                    setAttributs(8);
                    break;
                case "PERSONNEL":
                    setAttributs(9);
                    break;
                case "PHOTO":
                    setAttributs(10);
                    break;
                case "POSTE":
                    setAttributs(11);
                    break;
                case "PRODUIT":
                    setAttributs(12);
                    break;
                case "ROLE":
                    setAttributs(13);
                    break;
                case "STADE":
                    setAttributs(14);
                    break;
                case "STAFF":
                    setAttributs(15);
                    break;
                case "TAILLE":
                    setAttributs(16);
                    break;
                
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int nombreAttribut = comboBox4.Items.Count;
            if (!string.IsNullOrEmpty(valeurs[comboBox4.SelectedIndex])) // Je met la valeur dans le textbox2 si la valeur n'est pas vide
            {
                textBox2.Text = valeurs[comboBox4.SelectedIndex];
                
            }
            else
            {
                textBox2.Text = "";
            }
            
            
        }

        private void comboBox4_Enter_1(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(textBox2.Text)) // Sauvegarde de la valeur si le textbox2 n'est pas nul
            {
                valeurs[comboBox4.SelectedIndex] = textBox2.Text.ToString();
                
            }
        }
    }
}
