-- phpMyAdmin SQL Dump
-- version 4.6.6
-- https://www.phpmyadmin.net/
--
-- Client :  front-ha-mysql-01.shpv.fr:3306
-- Généré le :  Sam 20 Mai 2017 à 18:06
-- Version du serveur :  5.6.31
-- Version de PHP :  5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `rnsycxun_projet_slam_bdd`
--

-- --------------------------------------------------------

--
-- Structure de la table `ADVERSAIRE`
--

CREATE TABLE `ADVERSAIRE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(25) DEFAULT NULL,
  `logo` varchar(100) NOT NULL,
  `id_STADE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `COMMANDE`
--

CREATE TABLE `COMMANDE` (
  `id` int(11) NOT NULL,
  `dateCommande` date DEFAULT NULL,
  `id_COMPTE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `COMPTE`
--

CREATE TABLE `COMPTE` (
  `id` int(11) NOT NULL,
  `mail` varchar(25) DEFAULT NULL,
  `mdp` varchar(50) DEFAULT NULL,
  `nom` varchar(25) DEFAULT NULL,
  `prenom` varchar(25) DEFAULT NULL,
  `tel` varchar(25) DEFAULT NULL,
  `adresse` varchar(50) DEFAULT NULL,
  `cp` varchar(25) DEFAULT NULL,
  `ville` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `contient`
--

CREATE TABLE `contient` (
  `id` int(11) NOT NULL,
  `id_COMMANDE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `fait`
--

CREATE TABLE `fait` (
  `id` int(11) NOT NULL,
  `id_TAILLE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `JOUEUR`
--

CREATE TABLE `JOUEUR` (
  `num` int(11) DEFAULT NULL,
  `taille` float DEFAULT NULL,
  `poids` float DEFAULT NULL,
  `pied` varchar(25) DEFAULT NULL,
  `venueClub` varchar(50) DEFAULT NULL,
  `id` int(11) NOT NULL,
  `id_POSTE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `MATCHS`
--

CREATE TABLE `MATCHS` (
  `id` int(11) NOT NULL,
  `dateMatch` date DEFAULT NULL,
  `heure` time DEFAULT NULL,
  `scoreDom` int(11) DEFAULT NULL,
  `scoreExt` int(11) DEFAULT NULL,
  `exterieurON` tinyint(1) DEFAULT NULL,
  `id_ADVERSAIRE` int(11) DEFAULT NULL,
  `id_STADE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `NATIONALITE`
--

CREATE TABLE `NATIONALITE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `participe`
--

CREATE TABLE `participe` (
  `id` int(11) NOT NULL,
  `id_PERSONNEL` int(11) NOT NULL,
  `butMarques` int(11) DEFAULT '0',
  `passeDecisives` int(11) DEFAULT '0',
  `cartonJauneON` tinyint(1) DEFAULT '0',
  `cartonRougeON` tinyint(1) DEFAULT '0',
  `minutesJouees` int(11) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `PERSONNEL`
--

CREATE TABLE `PERSONNEL` (
  `id` int(11) NOT NULL,
  `nom` varchar(25) DEFAULT NULL,
  `prenom` varchar(25) DEFAULT NULL,
  `dateNaiss` date DEFAULT NULL,
  `lieuNaiss` varchar(25) DEFAULT NULL,
  `biographie` varchar(2000) DEFAULT NULL,
  `id_NATIONALITE` int(11) DEFAULT NULL,
  `id_PHOTO` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `PHOTO`
--

CREATE TABLE `PHOTO` (
  `id` int(11) NOT NULL,
  `lien` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `POSTE`
--

CREATE TABLE `POSTE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `PRODUIT`
--

CREATE TABLE `PRODUIT` (
  `id` int(11) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prix` float DEFAULT NULL,
  `description` varchar(100) DEFAULT NULL,
  `id_PHOTO` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `ROLE`
--

CREATE TABLE `ROLE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `STADE`
--

CREATE TABLE `STADE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(50) DEFAULT NULL,
  `nbPlaces` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `STAFF`
--

CREATE TABLE `STAFF` (
  `id` int(11) NOT NULL,
  `id_ROLE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `TAILLE`
--

CREATE TABLE `TAILLE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Index pour les tables exportées
--

--
-- Index pour la table `ADVERSAIRE`
--
ALTER TABLE `ADVERSAIRE`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_ADVERSAIRE_id_STADE` (`id_STADE`);

--
-- Index pour la table `COMMANDE`
--
ALTER TABLE `COMMANDE`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_COMMANDE_id_COMPTE` (`id_COMPTE`);

--
-- Index pour la table `COMPTE`
--
ALTER TABLE `COMPTE`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `contient`
--
ALTER TABLE `contient`
  ADD PRIMARY KEY (`id`,`id_COMMANDE`),
  ADD KEY `FK_contient_id_COMMANDE` (`id_COMMANDE`);

--
-- Index pour la table `fait`
--
ALTER TABLE `fait`
  ADD PRIMARY KEY (`id`,`id_TAILLE`),
  ADD KEY `FK_fait_id_TAILLE` (`id_TAILLE`);

--
-- Index pour la table `JOUEUR`
--
ALTER TABLE `JOUEUR`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_JOUEUR_id_POSTE` (`id_POSTE`);

--
-- Index pour la table `MATCHS`
--
ALTER TABLE `MATCHS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_MATCHS_id_STADE` (`id_STADE`),
  ADD KEY `FK_MATCHS_id_ADVERSAIRE` (`id_ADVERSAIRE`);

--
-- Index pour la table `NATIONALITE`
--
ALTER TABLE `NATIONALITE`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `participe`
--
ALTER TABLE `participe`
  ADD PRIMARY KEY (`id`,`id_PERSONNEL`),
  ADD KEY `FK_participe_id_PERSONNEL` (`id_PERSONNEL`);

--
-- Index pour la table `PERSONNEL`
--
ALTER TABLE `PERSONNEL`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_PERSONNEL_id_NATIONALITE` (`id_NATIONALITE`),
  ADD KEY `FK_PERSONNEL_id_PHOTO` (`id_PHOTO`);

--
-- Index pour la table `PHOTO`
--
ALTER TABLE `PHOTO`
  ADD PRIMARY KEY (`id`) USING BTREE;

--
-- Index pour la table `POSTE`
--
ALTER TABLE `POSTE`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `PRODUIT`
--
ALTER TABLE `PRODUIT`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_PRODUIT_id_PHOTO` (`id_PHOTO`);

--
-- Index pour la table `ROLE`
--
ALTER TABLE `ROLE`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `STADE`
--
ALTER TABLE `STADE`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `STAFF`
--
ALTER TABLE `STAFF`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_STAFF_id_ROLE` (`id_ROLE`);

--
-- Index pour la table `TAILLE`
--
ALTER TABLE `TAILLE`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `ADVERSAIRE`
--
ALTER TABLE `ADVERSAIRE`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
--
-- AUTO_INCREMENT pour la table `COMMANDE`
--
ALTER TABLE `COMMANDE`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT pour la table `COMPTE`
--
ALTER TABLE `COMPTE`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
--
-- AUTO_INCREMENT pour la table `MATCHS`
--
ALTER TABLE `MATCHS`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT pour la table `NATIONALITE`
--
ALTER TABLE `NATIONALITE`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT pour la table `PERSONNEL`
--
ALTER TABLE `PERSONNEL`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;
--
-- AUTO_INCREMENT pour la table `PHOTO`
--
ALTER TABLE `PHOTO`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;
--
-- AUTO_INCREMENT pour la table `POSTE`
--
ALTER TABLE `POSTE`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT pour la table `PRODUIT`
--
ALTER TABLE `PRODUIT`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT pour la table `ROLE`
--
ALTER TABLE `ROLE`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT pour la table `STADE`
--
ALTER TABLE `STADE`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;
--
-- AUTO_INCREMENT pour la table `TAILLE`
--
ALTER TABLE `TAILLE`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `ADVERSAIRE`
--
ALTER TABLE `ADVERSAIRE`
  ADD CONSTRAINT `FK_ADVERSAIRE_id_STADE` FOREIGN KEY (`id_STADE`) REFERENCES `STADE` (`id`);

--
-- Contraintes pour la table `COMMANDE`
--
ALTER TABLE `COMMANDE`
  ADD CONSTRAINT `FK_COMMANDE_id_COMPTE` FOREIGN KEY (`id_COMPTE`) REFERENCES `COMPTE` (`id`);

--
-- Contraintes pour la table `contient`
--
ALTER TABLE `contient`
  ADD CONSTRAINT `FK_contient_id` FOREIGN KEY (`id`) REFERENCES `PRODUIT` (`id`),
  ADD CONSTRAINT `FK_contient_id_COMMANDE` FOREIGN KEY (`id_COMMANDE`) REFERENCES `COMMANDE` (`id`);

--
-- Contraintes pour la table `fait`
--
ALTER TABLE `fait`
  ADD CONSTRAINT `FK_fait_id` FOREIGN KEY (`id`) REFERENCES `PRODUIT` (`id`),
  ADD CONSTRAINT `FK_fait_id_TAILLE` FOREIGN KEY (`id_TAILLE`) REFERENCES `TAILLE` (`id`);

--
-- Contraintes pour la table `JOUEUR`
--
ALTER TABLE `JOUEUR`
  ADD CONSTRAINT `FK_JOUEUR_id` FOREIGN KEY (`id`) REFERENCES `PERSONNEL` (`id`),
  ADD CONSTRAINT `FK_JOUEUR_id_POSTE` FOREIGN KEY (`id_POSTE`) REFERENCES `POSTE` (`id`);

--
-- Contraintes pour la table `MATCHS`
--
ALTER TABLE `MATCHS`
  ADD CONSTRAINT `FK_MATCHS_id_ADVERSAIRE` FOREIGN KEY (`id_ADVERSAIRE`) REFERENCES `ADVERSAIRE` (`id`),
  ADD CONSTRAINT `FK_MATCHS_id_STADE` FOREIGN KEY (`id_STADE`) REFERENCES `STADE` (`id`);

--
-- Contraintes pour la table `participe`
--
ALTER TABLE `participe`
  ADD CONSTRAINT `FK_participe_id` FOREIGN KEY (`id`) REFERENCES `MATCHS` (`id`),
  ADD CONSTRAINT `FK_participe_id_PERSONNEL` FOREIGN KEY (`id_PERSONNEL`) REFERENCES `PERSONNEL` (`id`);

--
-- Contraintes pour la table `PERSONNEL`
--
ALTER TABLE `PERSONNEL`
  ADD CONSTRAINT `FK_PERSONNEL_id_NATIONALITE` FOREIGN KEY (`id_NATIONALITE`) REFERENCES `NATIONALITE` (`id`),
  ADD CONSTRAINT `FK_PERSONNEL_id_PHOTO` FOREIGN KEY (`id_PHOTO`) REFERENCES `PHOTO` (`id`);

--
-- Contraintes pour la table `PRODUIT`
--
ALTER TABLE `PRODUIT`
  ADD CONSTRAINT `FK_PRODUIT_id_PHOTO` FOREIGN KEY (`id_PHOTO`) REFERENCES `PHOTO` (`id`);

--
-- Contraintes pour la table `STAFF`
--
ALTER TABLE `STAFF`
  ADD CONSTRAINT `FK_STAFF_id` FOREIGN KEY (`id`) REFERENCES `PERSONNEL` (`id`),
  ADD CONSTRAINT `FK_STAFF_id_ROLE` FOREIGN KEY (`id_ROLE`) REFERENCES `ROLE` (`id`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
