<?php
		
		if(isset($_GET['ins'])){
			
			require ("Modele/modele_inscription.php");
			
			$i= new Inscription();			
			
			$reussi=$i->create();
			
			if($reussi){
				echo"<script> alert ('Votre inscription a été prise en compte !');</script>";
				// et redirection vers la page d'accueil
				print ("<script language = \"JavaScript\">");
				print ("location.href = 'index.php?do=connexion';");
				print ("</script>");
			}else{
				echo"<script> alert('Email déja présent dans la base de données !');</script>";
				// et redirection vers la page d'inscription
				print ("<script language = \"JavaScript\">");
				print ("location.href = 'index.php?do=inscription';");
				print ("</script>");				
			}
			
		}
		else{
			//et je passe la main à la vue
			include("Vue/vue_inscription.php");
		}

?>