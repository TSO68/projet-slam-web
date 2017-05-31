-- phpMyAdmin SQL Dump
-- version 4.6.6
-- https://www.phpmyadmin.net/
--
-- Client :  front-ha-mysql-01.shpv.fr:3306
-- Généré le :  Mer 31 Mai 2017 à 23:12
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

--
-- Contenu de la table `ADVERSAIRE`
--

INSERT INTO `ADVERSAIRE` (`id`, `libelle`, `logo`, `id_STADE`) VALUES
(1, 'AC Ajaccio', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500765.png', 2),
(2, 'GFC Ajaccio', 'http://www.lfp.fr/images/photos/clubs/logo/grand/546836.png', 3),
(3, 'Amiens SC', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500240.png', 4),
(4, 'AJ Auxerre', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500220.png', 5),
(5, 'FC Bourg-en-Bresse 01', 'http://www.lfp.fr/images/photos/clubs/logo/grand/504281.png', 6),
(6, 'Stade Brestois 29', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500024.png', 7),
(7, 'Clermont Foot', 'http://www.lfp.fr/images/photos/clubs/logo/grand/535789.png', 8),
(8, 'Stade Lavallois', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500016.png', 9),
(9, 'Le Havre AC', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500052.png', 10),
(10, 'RC Lens', 'http://www.lfp.fr/images/photos/clubs/logo/grand/RC_LENS_LOGO.png', 11),
(11, 'Nîmes Olympique', 'http://www.lfp.fr/images/photos/clubs/logo/grand/503313.png', 12),
(12, 'Chamois Niortais', 'http://www.lfp.fr/images/photos/clubs/logo/grand/506978.png', 13),
(13, 'US Orléans', 'http://www.lfp.fr/images/photos/clubs/logo/grand/504891_orleans.png', 14),
(14, 'Red Star FC', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500002.png', 15),
(15, 'Stade de Reims', 'http://www.lfp.fr/images/photos/clubs/logo/grand/Stade_reims.png', 16),
(16, 'FC Sochaux-Montbéliard', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500303.png', 17),
(17, 'Tours FC', 'http://www.lfp.fr/images/photos/clubs/logo/grand/504917.png', 18),
(18, 'ES Troyes AC', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500073.png', 19),
(19, 'Valenciennes FC', 'http://www.lfp.fr/images/photos/clubs/logo/grand/500250.png', 20);

-- --------------------------------------------------------

--
-- Structure de la table `COMMANDE`
--

CREATE TABLE `COMMANDE` (
  `id` varchar(25) NOT NULL,
  `dateCommande` date DEFAULT NULL,
  `id_COMPTE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `COMMANDE`
--

INSERT INTO `COMMANDE` (`id`, `dateCommande`, `id_COMPTE`) VALUES
('59245eb46b083', '2017-05-23', 10),
('5924687b0e06a', '2017-05-23', 10),
('59246f8427c33', '2017-05-23', 40),
('59246fe6a524b', '2017-05-23', 40),
('5925b8362d6c0', '2017-05-24', 10),
('5925b90a5dd43', '2017-05-24', 10),
('59282e58a72a4', '2017-05-26', 10);

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

--
-- Contenu de la table `COMPTE`
--

INSERT INTO `COMPTE` (`id`, `mail`, `mdp`, `nom`, `prenom`, `tel`, `adresse`, `cp`, `ville`) VALUES
(1, 'admin@admin.com', '21232f297a57a5a743894a0e4a801fc3', 'admin', 'admin', '0606060606', '42, Avenue de l\'Europe', '68000', 'Colmar'),
(10, 'riti97@hotmail.fr', '6319e718bc8d5dc9f6d480e1abfc0efa', 'Kammerer', 'Timothee', '0646337904', '15 Route de Strasbourg', '68000', 'Colmar'),
(11, 'vafaireprojectsoujetencul', '0360f275c2c5363482c0dc54fd98a33f', 'Tim', 'Othé', '0789412318498181', 'Suce', '81045', 'Mabite'),
(12, 'tordux2000@gmail.com', '0360f275c2c5363482c0dc54fd98a33f', 'Quintero', 'Jesus', '0641250014', '25 rue Tordue', '68000', 'Colmar'),
(22, 'tffezf@live.fr', 'e358efa489f58062f10dd7316b65649e', 'Sou', 'Is', '0345645641', 't', '78945', 'ISSOU'),
(23, 'gkjroifjgoeif@live.fr', '0cc175b9c0f1b6a831c399e269772661', 'Fzefz', 'POIFJUez', '4567894245', '1427575686917;', '78945', 'Mabite'),
(24, 'fezfgaegagez@live.fr', 'ab4f63f9ac65152575886860dde480a1', 'test', 'test', '1234567890', '5 rue pet', '78945', 'issou'),
(40, 'risitas68000@gmail.com', '0360f275c2c5363482c0dc54fd98a33f', 'Kanawati', 'Samy', '0606060606', '4, chemin du Galtz', '68410', 'Trois-Epis'),
(42, 'test@test.fr', '098f6bcd4621d373cade4e832627b4f6', 'test', 'test', '0325421512', 'test', '68000', 'test'),
(44, 'issou@issou.fr', '0360f275c2c5363482c0dc54fd98a33f', 'Issou', 'Issou', '0389654334', 'Issou', '68000', 'Issou');

-- --------------------------------------------------------

--
-- Structure de la table `fait`
--

CREATE TABLE `fait` (
  `id` int(11) NOT NULL,
  `id_TAILLE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `fait`
--

INSERT INTO `fait` (`id`, `id_TAILLE`) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(1, 2),
(2, 2),
(3, 2),
(4, 2),
(5, 2),
(1, 3),
(2, 3),
(3, 3),
(4, 3),
(5, 3),
(1, 4),
(2, 4),
(3, 4),
(4, 4),
(5, 4),
(1, 5),
(2, 5),
(3, 5),
(4, 5),
(5, 5),
(6, 6),
(7, 6),
(8, 6),
(9, 6),
(10, 6);

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

--
-- Contenu de la table `JOUEUR`
--

INSERT INTO `JOUEUR` (`num`, `taille`, `poids`, `pied`, `venueClub`, `id`, `id_POSTE`) VALUES
(1, 1.84, 72, 'droitier', 'Au club depuis juillet 2016', 5, 1),
(16, 1.85, 78, 'droitier', 'Au club depuis août 2014', 6, 1),
(30, 1.83, 75, 'droitier', 'Formé au club', 7, 1),
(40, 1.84, 79, 'droitier', 'Au club depuis juillet 2016', 8, 1),
(3, 1.86, 70, 'gaucher', 'Au club depuis juillet 2014', 9, 2),
(12, 1.93, 90, 'droitier', 'Au club depuis août 2016', 10, 2),
(21, 1.88, 85, 'droitier', 'Au club depuis juillet 2014', 11, 2),
(22, 1.85, 84, 'droitier', 'Au club depuis juillet 2014', 12, 2),
(23, 1.87, 83, 'gaucher', 'Au club depuis juillet 2015', 13, 2),
(24, 1.72, 67, 'droitier', 'Au club depuis juillet 2015', 14, 2),
(5, 1.7, 61, 'droitier', 'Au club depuis juillet 2016', 15, 3),
(6, 1.81, 69, 'droitier', 'Au club depuis juillet 2013', 16, 3),
(7, 1.83, 70, 'droitier', 'Formé au club', 17, 3),
(8, 1.86, 71, 'gaucher', 'Au club depuis janvier 2017', 18, 3),
(17, 1.78, 79, 'droitier', 'Au club depuis juillet 2016', 19, 3),
(18, 1.76, 67, 'droitier', 'Au club depuis octobre 2014', 20, 3),
(20, 1.77, 70, 'droitier', 'Au club depuis juillet 2016', 21, 3),
(33, 1.84, 70, 'droitier', 'Formé au club', 22, 3),
(34, 1.85, 79, 'droitier', 'Formé au club', 23, 3),
(35, 1.75, 67, 'droitier', 'Formé au club', 24, 3),
(9, 1.89, 77, 'droitier', 'Au club depuis juillet 2016', 25, 4),
(11, 1.84, 77, 'gaucher', 'Au club depuis juillet 2013', 26, 4),
(13, 1.87, 80, 'droitier', 'Au club depuis janvier 2015', 27, 4),
(19, 1.85, 78, 'droitier', 'Au club depuis juillet 2014', 28, 4),
(28, 1.84, 75, 'droitier', 'Au club depuis juillet 2016', 29, 4),
(29, 1.9, 80, 'droitier', 'Au club depuis juillet 2016', 30, 4);

-- --------------------------------------------------------

--
-- Structure de la table `ligneCmd`
--

CREATE TABLE `ligneCmd` (
  `id_PRODUIT` int(11) NOT NULL,
  `id_TAILLE` int(11) NOT NULL,
  `id_COMMANDE` varchar(25) NOT NULL,
  `quantite` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `ligneCmd`
--

INSERT INTO `ligneCmd` (`id_PRODUIT`, `id_TAILLE`, `id_COMMANDE`, `quantite`) VALUES
(1, 3, '59245eb46b083', 1),
(1, 5, '59245eb46b083', 1),
(1, 2, '5924687b0e06a', 2),
(1, 4, '5924687b0e06a', 3),
(1, 1, '59246f8427c33', 1),
(1, 4, '59246f8427c33', 2),
(1, 1, '59282e58a72a4', 5),
(1, 4, '59282e58a72a4', 1),
(2, 3, '5925b90a5dd43', 3),
(3, 1, '5924687b0e06a', 1),
(4, 1, '5924687b0e06a', 3),
(4, 4, '59246fe6a524b', 1),
(4, 3, '5925b8362d6c0', 2),
(4, 1, '5925b90a5dd43', 1),
(5, 4, '5925b90a5dd43', 5),
(6, 6, '5925b8362d6c0', 3),
(7, 6, '59246f8427c33', 1),
(9, 6, '5924687b0e06a', 4),
(10, 6, '5924687b0e06a', 5),
(10, 6, '59246f8427c33', 3),
(10, 6, '5925b90a5dd43', 5);

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

--
-- Contenu de la table `MATCHS`
--

INSERT INTO `MATCHS` (`id`, `dateMatch`, `heure`, `scoreDom`, `scoreExt`, `exterieurON`, `id_ADVERSAIRE`, `id_STADE`) VALUES
(1, '2016-07-29', '20:00:00', 0, 0, 1, 5, 6),
(2, '2016-08-06', '15:00:00', 1, 0, 0, 3, 1),
(3, '2016-08-12', '20:00:00', 1, 3, 1, 17, 18),
(4, '2016-08-19', '20:00:00', 1, 1, 0, 11, 1),
(5, '2016-08-26', '20:00:00', 1, 1, 1, 2, 3),
(6, '2016-09-12', '20:30:00', 2, 0, 0, 18, 1),
(7, '2016-09-16', '20:00:00', 3, 1, 1, 13, 14),
(8, '2016-09-19', '20:30:00', 0, 0, 0, 14, 1),
(9, '2016-09-23', '20:00:00', 0, 0, 1, 7, 8),
(10, '2016-10-01', '15:00:00', 2, 4, 0, 19, 1);

-- --------------------------------------------------------

--
-- Structure de la table `NATIONALITE`
--

CREATE TABLE `NATIONALITE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `NATIONALITE`
--

INSERT INTO `NATIONALITE` (`id`, `libelle`) VALUES
(1, 'Française'),
(2, 'Espagnole'),
(3, 'Sénégalaise'),
(4, 'Brésilienne'),
(5, 'Ivoirienne'),
(6, 'Belge'),
(7, 'Marocaine');

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

--
-- Contenu de la table `participe`
--

INSERT INTO `participe` (`id`, `id_PERSONNEL`, `butMarques`, `passeDecisives`, `cartonJauneON`, `cartonRougeON`, `minutesJouees`) VALUES
(1, 6, 0, 0, 0, 0, 90),
(1, 9, 0, 0, 0, 0, 90),
(1, 12, 0, 0, 0, 0, 90),
(1, 13, 0, 0, 0, 0, 90),
(1, 14, 0, 0, 0, 0, 90),
(1, 15, 0, 0, 0, 0, 90),
(1, 16, 0, 0, 0, 0, 90),
(1, 17, 0, 0, 0, 0, 22),
(1, 19, 0, 0, 0, 0, 84),
(1, 21, 0, 0, 0, 0, 6),
(1, 25, 0, 0, 0, 0, 90),
(1, 28, 0, 0, 0, 0, 1),
(1, 29, 0, 0, 0, 0, 68),
(1, 30, 0, 0, 0, 0, 90),
(2, 6, 0, 0, 0, 0, 90),
(2, 9, 0, 0, 0, 0, 90),
(2, 12, 0, 0, 0, 0, 90),
(2, 13, 0, 0, 0, 0, 90),
(2, 14, 0, 0, 0, 0, 90),
(2, 15, 0, 0, 0, 0, 90),
(2, 16, 1, 0, 0, 0, 90),
(2, 17, 0, 0, 0, 0, 31),
(2, 19, 0, 0, 0, 0, 88),
(2, 20, 0, 0, 0, 0, 2),
(2, 25, 0, 0, 0, 0, 59),
(2, 28, 0, 0, 0, 0, 11),
(2, 29, 0, 1, 1, 0, 79),
(2, 30, 0, 0, 1, 0, 90),
(3, 6, 0, 0, 0, 0, 90),
(3, 9, 0, 0, 0, 0, 90),
(3, 11, 0, 0, 0, 0, 31),
(3, 12, 0, 0, 0, 0, 59),
(3, 13, 0, 0, 0, 0, 90),
(3, 14, 0, 0, 1, 0, 82),
(3, 15, 0, 0, 0, 0, 4),
(3, 16, 0, 0, 0, 0, 90),
(3, 17, 0, 0, 0, 0, 90),
(3, 19, 0, 2, 0, 0, 86),
(3, 20, 0, 0, 0, 0, 90),
(3, 21, 0, 0, 0, 0, 8),
(3, 28, 0, 0, 0, 0, 90),
(3, 30, 3, 0, 0, 0, 90),
(4, 6, 0, 0, 0, 0, 90),
(4, 9, 0, 0, 0, 0, 90),
(4, 11, 0, 0, 0, 0, 31),
(4, 12, 0, 0, 0, 1, 57),
(4, 13, 0, 0, 0, 0, 90),
(4, 15, 0, 0, 1, 0, 90),
(4, 16, 0, 0, 0, 0, 90),
(4, 17, 0, 0, 0, 0, 78),
(4, 19, 0, 0, 0, 0, 65),
(4, 20, 0, 0, 0, 0, 12),
(4, 21, 0, 0, 0, 0, 90),
(4, 28, 0, 0, 0, 0, 25),
(4, 29, 0, 0, 0, 0, 59),
(4, 30, 1, 0, 1, 0, 90),
(5, 6, 0, 0, 1, 0, 90),
(5, 9, 1, 0, 0, 0, 90),
(5, 11, 0, 0, 0, 0, 13),
(5, 12, 0, 0, 0, 0, 90),
(5, 13, 0, 0, 1, 1, 76),
(5, 14, 0, 0, 0, 0, 90),
(5, 15, 0, 1, 0, 0, 90),
(5, 16, 0, 0, 1, 0, 90),
(5, 17, 0, 0, 0, 0, 77),
(5, 19, 0, 0, 0, 0, 90),
(5, 21, 0, 0, 0, 0, 1),
(5, 26, 0, 0, 0, 0, 3),
(5, 28, 0, 0, 0, 0, 87),
(5, 30, 0, 0, 0, 0, 90),
(6, 6, 0, 0, 0, 0, 90),
(6, 9, 0, 0, 0, 0, 90),
(6, 10, 0, 0, 0, 0, 90),
(6, 11, 0, 0, 0, 0, 13),
(6, 12, 0, 0, 0, 0, 90),
(6, 15, 0, 0, 0, 0, 90),
(6, 16, 0, 0, 1, 0, 88),
(6, 19, 0, 0, 0, 0, 90),
(6, 21, 0, 0, 0, 0, 90),
(6, 26, 1, 0, 0, 0, 26),
(6, 27, 0, 0, 0, 0, 2),
(6, 28, 1, 0, 0, 0, 77),
(6, 29, 0, 0, 0, 0, 64),
(6, 30, 0, 1, 0, 0, 90),
(7, 6, 0, 0, 0, 0, 90),
(7, 9, 0, 0, 0, 0, 90),
(7, 11, 0, 0, 0, 0, 90),
(7, 12, 0, 0, 0, 0, 90),
(7, 13, 0, 0, 0, 0, 90),
(7, 14, 0, 0, 0, 0, 90),
(7, 15, 0, 0, 0, 0, 60),
(7, 16, 0, 0, 0, 0, 69),
(7, 19, 0, 0, 1, 0, 90),
(7, 21, 0, 0, 0, 0, 7),
(7, 26, 0, 0, 0, 0, 90),
(7, 28, 0, 1, 0, 0, 30),
(7, 29, 1, 0, 0, 0, 21),
(7, 30, 0, 0, 0, 0, 83),
(8, 6, 0, 0, 0, 0, 90),
(8, 9, 0, 0, 0, 0, 1),
(8, 10, 0, 0, 0, 0, 90),
(8, 12, 0, 0, 0, 0, 90),
(8, 14, 0, 0, 0, 0, 90),
(8, 15, 0, 0, 0, 0, 71),
(8, 16, 0, 0, 0, 0, 69),
(8, 19, 0, 0, 0, 0, 19),
(8, 21, 0, 0, 0, 0, 90),
(8, 26, 0, 0, 0, 0, 90),
(8, 27, 0, 0, 0, 0, 10),
(8, 28, 0, 0, 0, 0, 90),
(8, 29, 0, 0, 0, 0, 90),
(8, 30, 0, 0, 0, 0, 80),
(9, 6, 0, 0, 0, 0, 90),
(9, 9, 0, 0, 0, 0, 90),
(9, 10, 0, 0, 0, 0, 90),
(9, 12, 0, 0, 0, 0, 90),
(9, 13, 0, 0, 0, 0, 90),
(9, 14, 0, 0, 0, 0, 82),
(9, 15, 0, 0, 0, 0, 15),
(9, 19, 0, 0, 0, 0, 90),
(9, 21, 0, 0, 0, 0, 8),
(9, 25, 0, 0, 0, 0, 75),
(9, 26, 0, 0, 0, 0, 90),
(9, 28, 0, 0, 0, 0, 11),
(9, 29, 0, 0, 0, 0, 90),
(9, 30, 0, 0, 0, 0, 79),
(10, 6, 0, 0, 0, 0, 90),
(10, 9, 0, 0, 0, 0, 90),
(10, 10, 0, 0, 0, 0, 90),
(10, 11, 0, 0, 0, 0, 44),
(10, 13, 0, 0, 0, 1, 44),
(10, 15, 0, 1, 0, 0, 90),
(10, 16, 0, 0, 1, 0, 90),
(10, 17, 1, 0, 0, 0, 32),
(10, 21, 0, 0, 0, 0, 90),
(10, 25, 0, 0, 0, 0, 58),
(10, 26, 0, 0, 0, 1, 18),
(10, 27, 0, 0, 0, 0, 9),
(10, 29, 0, 0, 0, 0, 46),
(10, 30, 1, 0, 1, 0, 81);

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

--
-- Contenu de la table `PERSONNEL`
--

INSERT INTO `PERSONNEL` (`id`, `nom`, `prenom`, `dateNaiss`, `lieuNaiss`, `biographie`, `id_NATIONALITE`, `id_PHOTO`) VALUES
(1, 'Hausherr', 'Victor', '1997-09-18', 'Colmar', 'La chance', 1, NULL),
(2, 'Kammerer', 'Timothée', '1997-12-26', 'Colmar', 'Test', 1, NULL),
(3, 'Kanawati', 'Samy', '1991-09-11', 'Forbach', 'Maître course', 1, NULL),
(4, 'Joya Borja', 'Juan', '1962-01-05', 'Séville', 'Fondateur du club', 2, NULL),
(5, 'BONNEFOI', 'Landry', '1983-09-20', 'Villeparisis', 'Gardien d\'expérience, formé à Cannes et parti très jeune à la Juventus, il est rentré en France où il a été titulaire de nombreuses saisons dans les divisions inférieures. Il est venu l\'été dernier à Strasbourg apporter son expérience en tant que doublure.', 1, 1),
(6, 'OUKIDJA', 'Alexandre', '1988-07-19', 'Nevers', 'Formé à Gueugnon et passé longuement par Lille où il n\'a jamais joué, il est ensuite parti chercher une place de titulaire à Bayonne puis Mouscron. Débarqué à Strasbourg en 2014 en tant que doublure de Gauclin, il a rapidement gagné sa place de titulaire, qu\'il n\'a plus quitté depuis.', 1, 2),
(7, 'SCHMITTHEISSLER', 'Corentin', '1997-04-22', 'Strasbourg', 'Jeune gardien, qui a joué dans toutes les équipes du centre de formation du RCS où il est désormais troisième gardien.', 1, 3),
(8, 'GAMBETTA', 'Andréa', '1996-08-13', 'Lyon', 'Formé à Nice, il est le quatrième gardien du Racing.', 1, 4),
(9, 'N\'DOUR', 'Abdallah', '1993-12-20', 'Rufisque (SEN.)', 'Formé à Metz où il n\'a pas eu sa chance, il a lancé sa carrière à Strasbourg depuis son arrivée en 2014.', 3, 5),
(10, 'MANGANE', 'Kader', '1983-03-23', 'Thiès (SEN.)', 'Expérimenté défenseur de Ligue 1, réputé pour son impact physique et sa dureté dans les duels, il a suivi son entraîneur Thierry Laurey d\'Ajaccio à l\'Alsace.', 3, 6),
(11, 'SALMIER', 'Yoann', '1992-11-21', 'Villiers-le-Bel', 'Venu des bas fonds du foot français en 2014, il a progressé et gagné en temps de chaque saison depuis...', 1, 7),
(12, 'SEKA', 'Ernest', '1987-06-22', 'Cliche-la-Garenne', 'Solide défenseur de National à son arrivée, il s\'est imposé comme le roc de la défense strasbourgeoise et comme un capitaine exemplaire.', 1, 8),
(13, 'SAAD', 'Felipe', '1983-09-11', 'Santos (BRE.)', 'Depuis son arrivée en France, il a connu de nombreux clubs de Ligue 2 ou de Ligue 1 avant de débarquer à Strasbourg en 2015. Titulaire lors de sa première saison, il a peu à peu perdu sa place...', 4, 9),
(14, 'MARESTER', 'Eric', '1984-06-12', 'Villeneuve-la-Garenne', 'Grand habitué de la Ligue 2 avec Troyes, Monaco ou encore Auxerre, il est venu apporter son expérience de la division au Racing.', 1, 10),
(15, 'NOGUEIRA', 'Vincent', '1988-01-16', 'Besançon', 'Après de nombreuses années à Sochaux, il a tenté l\'aventure américaine à Philadelphie avant de vouloir rentrer en France pour raisons personnelles. Son choix s\'est porté sur le Racing.', 1, 11),
(16, 'GRIMM', 'Jérémy', '1987-03-27', 'Ostheim', 'Formé au Racing il y a une dizaine d\'années, il est parti en Suisse avant de passer cinq ans à Colmar puis de rentrer à la maison où il s\'est imposé comme un cadre du groupe strasbourgeois.', 1, 12),
(17, 'SACKO', 'Ihsan', '1997-07-19', 'Alfortville', 'Formé à Valenciennes, il a refusé de poursuivre dans le Nord pour rejoindre Strasbourg où il s\'est révélé depuis la saison passée.', 1, 13),
(18, 'AHOLOU', 'Jean-Eudes', '1994-03-20', 'Yapougon (CIV.)', 'Passé par Lille et révélé à Orléans, il a rejoint le Racing en janvier dernier pour passer un cap, ce qu\'il semble réussir puisqu\'il s\'est imposé dans l\'entrejeu.', 5, 14),
(19, 'GONÇALVES', 'Anthony', '1986-03-06', 'Chartres', 'Après une carrière professionnelle entièrement passée à Laval, il a quitté son club pour rejoindre l\'Alsace où il est là aussi considéré comme un titulaire.', 1, 15),
(20, 'NDOYE', 'Mayoro', '1991-12-18', 'Mbao (SEN)', 'Comme N\'Dour, il est venu du Sénégal à Metz, où il disputé plusieurs saisons en National et en Ligue 2. Il a ensuite rejoint Strasbourg pour jouer un rôle de complément.', 3, 16),
(21, 'DOS SANTOS', 'Laurent', '1993-03-21', 'Montmorencey', 'Après trois saisons à Guingamp où il a peu joué, il est venu à Strasbourg où il est venu faire profiter de sa polyvalence au milieu et en défense.', 1, 17),
(22, 'CACI', 'Anthony', '1997-07-01', 'Forbach', 'Jeune du club, il a déjà disputé quelques matchs en équipe première.', 1, 18),
(23, 'SOLVET', 'Steve', '1996-03-20', 'France', 'Jeune du club, il n\'a pas encore débuté officiellement avec le groupe pro.', 1, 19),
(24, 'WEISSBECK', 'Gaëtan', '1997-01-17', 'Wissembourg', 'Grand espoir du club, il a déjà disputé un match de Coupe de France...', 1, 20),
(25, 'GUILLAUME', 'Baptiste', '1995-06-16', 'Bruxelles (BEL.)', 'Lancé à Lens, il a rejoint le voisin Lillois où il a vite été écarté. Il est venu au RCS pour se relancer et enfin faire décoller sa carrière.', 6, 21),
(26, 'LIENARD', 'Dimitri', '1988-02-13', 'Belfort', 'Venu des divisions inférieurs entre Belfort et Mulhouse, il découvre le monde professionnel à Strasbourg cette saison après de bonnes saisons en National.', 1, 22),
(27, 'BLAYAC', 'Jérémy', '1983-06-13', 'Saint-Affrique', 'Il a connu de nombreux clubs en France où il s\'est imposé comme un solide buteur de Ligue 2. Il est se relancer et finir sa carrière à Strasbourg où il réalise de bonnes saisons.', 1, 23),
(28, 'BAHOKEN', 'Stéphane', '1992-05-28', 'Grasse', 'Formé à Nice où il ne s\'est pas imposé, il a signé à Strasbourg pour progresser mais sans réellement s\'imposer depuis son arrivée en 2014.', 1, 24),
(29, 'GRAGNIC', 'Vincent', '1983-06-23', 'Quimperlé', 'Comme Marester et Gonçalves, il apporte son expérience de la Ligue 2 aux autres joueurs du Racing même s\'il joue peu.', 1, 25),
(30, 'BOUTAIB', 'Khalid', '1987-04-24', 'Bagnols-sur-Cèze', 'Révélé tardivement après de nombreuses saisons dans les divisions amateurs, il a suivi son coach d\'Ajaccio à Strasbourg où il est l\'un des artisans majeurs de la belle saison du club. ', 7, 26),
(31, 'KELLER', 'Marc', '1968-01-14', 'Colmar', 'Joueur dans les années 90 puis dirigeant dans les années 2000 avant de vivre deux expériences délicates à Monaco, il a récupéré le Racing en CFA2 pour le mener jusqu\'à la Ligue 2.', 1, 27),
(32, 'LAUREY', 'Thierry', '1964-02-17', 'Troyes', 'Connaisseur de la Ligue 2, il est venu en Alsace pour réaliser la même prouesse réussie au GFC Ajaccio, à savoir enchaîner une montée en Ligue 2 puis en Ligue 1 en deux saisons.', 1, 28),
(33, 'LEFEVRE', 'Fabien', '1971-11-14', 'Montpellier', 'Ancien coéquipier de Laurey à Montpellier dans les années 90, il a retrouvé ce dernier au GFC Ajaccio en 2015 pour être son entraîneur adjoint avant de la suivre en Alsace un an plus tard.', 1, 29),
(34, 'ROI', 'Sébastien', '1978-08-02', 'Valence', 'Passé par le centre de formation du Racing il y a une vingtaine d\'années, il n\'a connu que le foot amateur avant de revenir au RCS en tant qu\'entraîneur adjoint de François Keller en 2011. Il n\'a pas quitté le poste depuis.', 1, 30),
(35, 'HOURS', 'Jean-Yves', '1964-12-28', 'Alès', 'Comme Lefèvre, il a connu Laurey à Montpellier. Après sa carrière, il a connu les staffs de Sedan, Évian, la Guinée et enfin le Racing.', 1, 31),
(36, 'BAILLEUX', 'Florian', '1987-06-18', 'Boulogne-sur-Mer', 'Après avoir exercé à Boulogne-sur-Mer et Carquefou, il est venu poursuivre sa carrière en Alsace en 2014.', 1, 32),
(37, 'FEIGENBRUGEL', 'Guy', '1974-02-26', 'Strasbourg', 'Il a rejoint le club en 2011 alors qu\'il était en CFA2.', 1, 33),
(38, 'PIETRA', 'François', '1960-05-15', 'Saint-Dizier', 'Médecin historique du club, il occupe le poste depuis 1990', 1, 34),
(39, 'ROTH', 'Antoine', '1986-01-27', 'Dambach-la-Ville', 'Il a rejoint le Racing en 2016.', 1, 35),
(40, 'GARNIER', 'Franck', '1982-09-13', 'Strasbourg', 'Il occupe le poste d’ostéopathe du Racing depuis plusieurs saisons.', 1, 36);

-- --------------------------------------------------------

--
-- Structure de la table `PHOTO`
--

CREATE TABLE `PHOTO` (
  `id` int(11) NOT NULL,
  `lien` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `PHOTO`
--

INSERT INTO `PHOTO` (`id`, `lien`) VALUES
(1, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_16635_500191.jpg'),
(2, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_19404_500191.jpg'),
(3, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_48085_500191.jpg'),
(4, 'http://www.lfp.fr/images/photos/joueurs/grand/2015_2016_56610_500208.jpg'),
(5, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_41359_500191.jpg'),
(6, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_36687_500191.jpg'),
(7, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_78366_500191.jpg'),
(8, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_56489_500191.jpg'),
(9, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_19543_500191.jpg'),
(10, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_16340_500191.jpg'),
(11, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_36955_500191.jpg'),
(12, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_5641_500191.jpg'),
(13, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_48210_500191.jpg'),
(14, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_51612_500191.jpg'),
(15, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_17359_500191.jpg'),
(16, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_35887_500191.jpg'),
(17, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_16178_500191.jpg'),
(18, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_78365_500191.jpg'),
(19, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_78455_500191.jpg'),
(20, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_78503_500191.jpg'),
(21, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_42102_500191.jpg'),
(22, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_78185_500191.jpg'),
(23, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_14238_500191.jpg'),
(24, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_5672_500191.jpg'),
(25, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_16473_500191.jpg'),
(26, 'http://www.lfp.fr/images/photos/joueurs/grand/2016_2017_48181_500191.jpg'),
(27, 'http://www.lfp.fr/images/photos/organigramme/1617_Keller_strasbourg.jpg'),
(28, 'http://www.lfp.fr/images/photos/entraineurs/1617_Laurey_strasbourg.jpg'),
(29, 'http://www.mhscfoot.com/sites/default/files/styles/195x295/public/photo_staff/lefevrefabien.jpg'),
(30, 'http://www.rcstrasbourgalsace.fr/wp-content/uploads/2013/01/sebastien-roi-rcsa.jpg'),
(31, 'http://image-uniservice.copainsdavant.com/image/450/9014093280/460295.jpg'),
(32, 'http://i.imgur.com/uk8BFh4.jpg'),
(33, 'http://www.racingccs.com/wp-content/gallery/photos-staff/img_6886.jpg'),
(34, 'https://i.skyrock.net/2046/39472046/pics/1561919536.jpg'),
(35, 'http://i.imgur.com/DAPLwb6.jpg'),
(36, 'http://www.justacote.com/photos_entreprises/garnier-franck-osteopathe-do-strasbourg-1300308390.jpg'),
(37, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/vad%20maillot%20home.jpg'),
(38, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/vad%20maillot%20away.jpg'),
(39, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/vad%20maillot%20third.jpg'),
(40, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/VAD%20sweat%20entrainement.jpg'),
(41, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/VAD%20tshirt%20entrainement%20blanc.jpg'),
(42, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/VAD%20ballon%20RCSA.jpg'),
(43, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/VAD%20drapeau%20bleu.jpg'),
(44, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/VAD%20drapeau%20blanc.jpg'),
(45, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/VAD%20bie%CC%80re.jpg'),
(46, 'https://www.boutique.rcstrasbourgalsace.fr/sites/rcstrasbourg7.ap2s.fr/files/styles/node-merch-product-visuel/public/VAD%20fanion%20blanc.jpg');

-- --------------------------------------------------------

--
-- Structure de la table `POSTE`
--

CREATE TABLE `POSTE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `POSTE`
--

INSERT INTO `POSTE` (`id`, `libelle`) VALUES
(1, 'Gardien'),
(2, 'Défenseur'),
(3, 'Milieu de terrain'),
(4, 'Attaquant');

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

--
-- Contenu de la table `PRODUIT`
--

INSERT INTO `PRODUIT` (`id`, `nom`, `prix`, `description`, `id_PHOTO`) VALUES
(1, 'Maillot Domicile 16/17 Adulte', 70, 'Le maillot domicile du RC Strasbourg !', 37),
(2, 'Maillot Away 16/17 Adulte', 70, 'Le maillot extérieur du RC Strasbourg !', 38),
(3, 'Maillot Third 16/17 Adulte', 70, 'Le maillot third du RC Strasbourg !', 39),
(4, 'Sweat entraînement 16/17', 45, 'Sweat d\'entraînement du RC Strasbourg !', 40),
(5, 'T-shirt entraînement Blanc 16-17', 15, 'T-Shirt d\'entraînement blanc', 41),
(6, 'Ballon 16/17', 20, 'Ballon bleu, idéal pour s\'amuser dans le jardin', 42),
(7, 'Drapeau bleu 16/17', 15, 'Joli drapeau bleu', 43),
(8, 'Drapeau blanc 16/17', 15, 'Joli drapeau blanc', 44),
(9, 'Chope de bière 0,20 L', 10, 'Pour boire une bonne bière alsacienne devant les matchs du Racing !', 45),
(10, 'Mini Fanion blanc', 5, 'Joli fanion à accrocher à son rétroviseur', 46);

-- --------------------------------------------------------

--
-- Structure de la table `ROLE`
--

CREATE TABLE `ROLE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(25) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `ROLE`
--

INSERT INTO `ROLE` (`id`, `libelle`) VALUES
(1, 'Président'),
(2, 'Entraîneur'),
(3, 'Entraîneur-Adjoint'),
(4, 'Entraîneur des gardiens'),
(5, 'Préparateur Physique'),
(6, 'Team Manager'),
(7, 'Médecin'),
(8, 'Kinésithérapeuthe'),
(9, 'Ostéopathe');

-- --------------------------------------------------------

--
-- Structure de la table `STADE`
--

CREATE TABLE `STADE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(50) DEFAULT NULL,
  `nbPlaces` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `STADE`
--

INSERT INTO `STADE` (`id`, `libelle`, `nbPlaces`) VALUES
(1, 'Stade de la Meinau', 29320),
(2, 'Stade François-Coty', 10446),
(3, 'Stade Ange-Casanova', 8000),
(4, 'Stade de la Licorne', 12097),
(5, 'Stade de l\'Abbé-Deschamps', 21379),
(6, 'Stade Marcel-Verchère', 11400),
(7, 'Stade Francis-Le Blé', 16000),
(8, 'Stade Gabriel-Montpied', 11980),
(9, 'Stade Francis-Le-Basser', 18739),
(10, 'Stade Océane', 25178),
(11, 'Stade Bollaert-Delelis', 38223),
(12, 'Stade des Costières', 18482),
(13, 'Stade René-Gaillard', 11352),
(14, 'Stade de la Source', 8000),
(15, 'Stade Jean-Bouin', 20000),
(16, 'Stade Auguste-Delaune', 21628),
(17, 'Stade Auguste-Bonal', 20005),
(18, 'Stade de la Vallée du Cher', 16247),
(19, 'Stade de l\'Aube', 20400),
(20, 'Stade du Hainaut', 24926);

-- --------------------------------------------------------

--
-- Structure de la table `STAFF`
--

CREATE TABLE `STAFF` (
  `id` int(11) NOT NULL,
  `id_ROLE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `STAFF`
--

INSERT INTO `STAFF` (`id`, `id_ROLE`) VALUES
(31, 1),
(32, 2),
(33, 3),
(34, 3),
(35, 4),
(36, 5),
(37, 6),
(38, 7),
(39, 8),
(40, 9);

-- --------------------------------------------------------

--
-- Structure de la table `TAILLE`
--

CREATE TABLE `TAILLE` (
  `id` int(11) NOT NULL,
  `libelle` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `TAILLE`
--

INSERT INTO `TAILLE` (`id`, `libelle`) VALUES
(1, 'S'),
(2, 'M'),
(3, 'L'),
(4, 'XL'),
(5, 'XXL'),
(6, 'TU');

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
-- Index pour la table `ligneCmd`
--
ALTER TABLE `ligneCmd`
  ADD PRIMARY KEY (`id_PRODUIT`,`id_COMMANDE`,`id_TAILLE`),
  ADD KEY `FK_ligneCmd_id_COMMANDE` (`id_COMMANDE`),
  ADD KEY `FK_ligneCmd_id_TAILLE` (`id_TAILLE`);

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
-- AUTO_INCREMENT pour la table `COMPTE`
--
ALTER TABLE `COMPTE`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;
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
-- Contraintes pour la table `ligneCmd`
--
ALTER TABLE `ligneCmd`
  ADD CONSTRAINT `FK_ligneCmd_id_COMMANDE` FOREIGN KEY (`id_COMMANDE`) REFERENCES `COMMANDE` (`id`),
  ADD CONSTRAINT `FK_ligneCmd_id_PRODUIT` FOREIGN KEY (`id_PRODUIT`) REFERENCES `PRODUIT` (`id`),
  ADD CONSTRAINT `FK_ligneCmd_id_TAILLE` FOREIGN KEY (`id_TAILLE`) REFERENCES `TAILLE` (`id`);

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
