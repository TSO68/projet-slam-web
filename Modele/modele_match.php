<?php
	class Match{
		//attribut privé qui recevra une instance de la connexion
		private $cx;
		
		public function __construct(){
			require_once("Modele/modele_connexion_base.php");
			$this->cx = Connexion::getInstance();
		}
		
		//Retourne un curseur contenant tous les joueurs et leurs role
		public function readAll(){
			$req = "SELECT MATCHS.id, dateMatch, heure, exterieurON, scoreDom, scoreExt, STADE.libelle, ADVERSAIRE.libelle, logo
					FROM MATCHS INNER JOIN STADE
					ON MATCHS.id_STADE = STADE.id
					INNER JOIN ADVERSAIRE
					ON MATCHS.id_ADVERSAIRE = ADVERSAIRE.id
					ORDER BY MATCHS.id";
			$curseur=$this->cx->query($req);
			return $curseur;
		}
		
		//retourne un curseur contenant l'objet associer à l'identifiant passé en paramètre
		//on utilise ici la technique des requêtes préparées qui permettent d'éviter les injonctions SQL
		public function findById($idMatch){
			//je reçois ma requête SQL
			$req = "SELECT PERSONNEL.nom, prenom, dateNaiss, lieuNaiss, biographie, ROLE.libelle, lien, NATIONALITE.libelle AS libelleNat
					FROM PHOTO INNER JOIN PERSONNEL
					ON PHOTO.id=PERSONNEL.id_PHOTO
					INNER JOIN NATIONALITE
					ON NATIONALITE.id=PERSONNEL.id_NATIONALITE
					INNER JOIN STAFF
					ON PERSONNEL.id=STAFF.id
					INNER JOIN ROLE
					ON ROLE.id=STAFF.id_ROLE
					WHERE PERSONNEL.id = :id
					GROUP BY PERSONNEL.nom, prenom, dateNaiss, lieuNaiss, biographie, ROLE.libelle, NATIONALITE.libelle, lien";
			
			//je prépare ma requête
			$prep = $this->cx->prepare($req);
			
			//j'associe les paramètres
			$prep->bindValue(':id', $idMatch, PDO::PARAM_STR);
			
			//j'exécute
			$prep->execute();
			
			//je rempli le curseur
			$curseur = $prep->fetchObject();
			return $curseur;
		}
	}
?>