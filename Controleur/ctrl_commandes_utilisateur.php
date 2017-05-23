<?php
	require ("Modele/modele_commandes_utilisateur.php");
	
	$cmd= new Commande();
			
	$lesCommandes=$cmd->read();
	
	include("Vue/vue_commandes_utilisateur.php");
?>