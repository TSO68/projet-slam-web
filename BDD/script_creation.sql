#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: JOUEUR
#------------------------------------------------------------

CREATE TABLE JOUEUR(
        num       Int ,
        taille    Float ,
        poids     Float ,
        pied      Varchar (25) ,
        venueClub Varchar (25) ,
        id        Int NOT NULL ,
        id_POSTE  Int ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: PERSONNEL
#------------------------------------------------------------

CREATE TABLE PERSONNEL(
        id             int (11) Auto_increment  NOT NULL ,
        nom            Varchar (25) ,
        prenom         Varchar (25) ,
        dateNaiss      Date ,
        lieuNaiss      Varchar (25) ,
        biographie     Varchar (25) ,
        id_NATIONALITE Int ,
        id_PHOTO       Int ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: STAFF
#------------------------------------------------------------

CREATE TABLE STAFF(
        id      Int NOT NULL ,
        id_ROLE Int ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: NATIONALITE
#------------------------------------------------------------

CREATE TABLE NATIONALITE(
        id      int (11) Auto_increment  NOT NULL ,
        libelle Varchar (25) ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: MATCHS
#------------------------------------------------------------

CREATE TABLE MATCHS(
        id            int (11) Auto_increment  NOT NULL ,
        dateMatch     Date ,
        heure         Time ,
        exterieurON   Bool ,
        id_STADE      Int ,
        id_ADVERSAIRE Int ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: ADVERSAIRE
#------------------------------------------------------------

CREATE TABLE ADVERSAIRE(
        id       int (11) Auto_increment  NOT NULL ,
        libelle  Varchar (25) ,
        id_STADE Int ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: STADE
#------------------------------------------------------------

CREATE TABLE STADE(
        id       int (11) Auto_increment  NOT NULL ,
        libelle  Varchar (25) ,
        nbPlaces Int ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: POSTE
#------------------------------------------------------------

CREATE TABLE POSTE(
        id      int (11) Auto_increment  NOT NULL ,
        libelle Varchar (25) ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: PRODUIT
#------------------------------------------------------------

CREATE TABLE PRODUIT(
        id          int (11) Auto_increment  NOT NULL ,
        nom         Varchar (25) ,
        prix        Float ,
        description Varchar (25) ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: TAILLE
#------------------------------------------------------------

CREATE TABLE TAILLE(
        id      int (11) Auto_increment  NOT NULL ,
        libelle Varchar (25) ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: PHOTO
#------------------------------------------------------------

CREATE TABLE PHOTO(
        id           int (11) Auto_increment  NOT NULL ,
        nom          Varchar (25) ,
        lien         Varchar (25) ,
        id_PERSONNEL Int ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: COMPTE
#------------------------------------------------------------

CREATE TABLE COMPTE(
        id      int (11) Auto_increment  NOT NULL ,
        mail    Varchar (25) ,
        mdp     Varchar (25) ,
        nom     Varchar (25) ,
        prenom  Varchar (25) ,
        tel     Varchar (25) ,
        adresse Varchar (25) ,
        cp      Varchar (25) ,
        ville   Varchar (25) ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: COMMANDE
#------------------------------------------------------------

CREATE TABLE COMMANDE(
        id           int (11) Auto_increment  NOT NULL ,
        dateCommande Date ,
        id_COMPTE    Int NOT NULL ,
        PRIMARY KEY (id ,id_COMPTE )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: ROLE
#------------------------------------------------------------

CREATE TABLE ROLE(
        id      int (11) Auto_increment  NOT NULL ,
        libelle Varchar (25) ,
        PRIMARY KEY (id )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: participe
#------------------------------------------------------------

CREATE TABLE participe(
        butMarques     Int ,
        passeDecisives Int ,
        cartonJauneON  Bool ,
        cartonRougeON  Bool ,
        minutesJouees  Int ,
        id             Int NOT NULL ,
        id_PERSONNEL   Int NOT NULL ,
        PRIMARY KEY (id ,id_PERSONNEL )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: fait
#------------------------------------------------------------

CREATE TABLE fait(
        id        Int NOT NULL ,
        id_TAILLE Int NOT NULL ,
        PRIMARY KEY (id ,id_TAILLE )
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: contient
#------------------------------------------------------------

CREATE TABLE contient(
        id          Int NOT NULL ,
        id_COMMANDE Int NOT NULL ,
        id_COMPTE   Int NOT NULL ,
        PRIMARY KEY (id ,id_COMMANDE ,id_COMPTE )
)ENGINE=InnoDB;

ALTER TABLE JOUEUR ADD CONSTRAINT FK_JOUEUR_id FOREIGN KEY (id) REFERENCES PERSONNEL(id);
ALTER TABLE JOUEUR ADD CONSTRAINT FK_JOUEUR_id_POSTE FOREIGN KEY (id_POSTE) REFERENCES POSTE(id);
ALTER TABLE PERSONNEL ADD CONSTRAINT FK_PERSONNEL_id_NATIONALITE FOREIGN KEY (id_NATIONALITE) REFERENCES NATIONALITE(id);
ALTER TABLE PERSONNEL ADD CONSTRAINT FK_PERSONNEL_id_PHOTO FOREIGN KEY (id_PHOTO) REFERENCES PHOTO(id);
ALTER TABLE STAFF ADD CONSTRAINT FK_STAFF_id FOREIGN KEY (id) REFERENCES PERSONNEL(id);
ALTER TABLE STAFF ADD CONSTRAINT FK_STAFF_id_ROLE FOREIGN KEY (id_ROLE) REFERENCES ROLE(id);
ALTER TABLE MATCHS ADD CONSTRAINT FK_MATCHS_id_STADE FOREIGN KEY (id_STADE) REFERENCES STADE(id);
ALTER TABLE MATCHS ADD CONSTRAINT FK_MATCHS_id_ADVERSAIRE FOREIGN KEY (id_ADVERSAIRE) REFERENCES ADVERSAIRE(id);
ALTER TABLE ADVERSAIRE ADD CONSTRAINT FK_ADVERSAIRE_id_STADE FOREIGN KEY (id_STADE) REFERENCES STADE(id);
ALTER TABLE PHOTO ADD CONSTRAINT FK_PHOTO_id_PERSONNEL FOREIGN KEY (id_PERSONNEL) REFERENCES PERSONNEL(id);
ALTER TABLE COMMANDE ADD CONSTRAINT FK_COMMANDE_id_COMPTE FOREIGN KEY (id_COMPTE) REFERENCES COMPTE(id);
ALTER TABLE participe ADD CONSTRAINT FK_participe_id FOREIGN KEY (id) REFERENCES MATCHS(id);
ALTER TABLE participe ADD CONSTRAINT FK_participe_id_PERSONNEL FOREIGN KEY (id_PERSONNEL) REFERENCES PERSONNEL(id);
ALTER TABLE fait ADD CONSTRAINT FK_fait_id FOREIGN KEY (id) REFERENCES PRODUIT(id);
ALTER TABLE fait ADD CONSTRAINT FK_fait_id_TAILLE FOREIGN KEY (id_TAILLE) REFERENCES TAILLE(id);
ALTER TABLE contient ADD CONSTRAINT FK_contient_id FOREIGN KEY (id) REFERENCES PRODUIT(id);
ALTER TABLE contient ADD CONSTRAINT FK_contient_id_COMMANDE FOREIGN KEY (id_COMMANDE) REFERENCES COMMANDE(id);
ALTER TABLE contient ADD CONSTRAINT FK_contient_id_COMPTE FOREIGN KEY (id_COMPTE) REFERENCES COMPTE(id);