<?php
	require_once ("Modele/modele_staff.php");
	
	$s=new Staff();
	
	//Je récupère tous les objets
	$unStaff=$s->findById($_GET['idStaff']);
	
	//je passe la main à la vue
	include("Vue/vue_detail_staff.php");
?>