<?php
	require_once ("Modele/modele_joueur.php");
	
	$j=new Joueur();
	
	//Je récupère tous les objets
	$unJoueur=$j->findById($_GET['idJoueur']);
	
	//je passe la main à la vue
	include("Vue/vue_detail_joueur.php");
?>