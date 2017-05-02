<?php
session_start();
?>

<HTML>
    <HEAD>
        <TITLE>Accueil</TITLE>
		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
        <!--Feuilles de style globale-->
		<link rel = "stylesheet" type = "text/css" href = "CSS/bootstrap-3.3.7-dist/css/bootstrap.css">
		<!--Favicon-->
		<link rel="shortcut icon" href="Images/logo-racing-academy-2016.png" />
         <!--Fonctions JavaScript-->
		<script type="text/javascript">$(document).ready(function(){$("div.messConf").delay(2000).fadeOut();});</script>
		<script type="text/javascript" src="JS/jquery.min.js"></script>
		<script type="text/javascript" src="JS/bootstrap.min.js"></script>
	</HEAD>

     
    <BODY>
        <div id ='page'>
            <!--En-tête-->
            <?php include('header.php');?>
            <!--Contenu de la page-->
			
			<?php
					
				if(!isset($_GET['do'])){
			?>
					 <div id='content'>
						<center>
							<img src="Images/1-sam_6012.jpg" name="accueil" onmouseover="accueil.src='Images/1-sam_6012.jpg'" onmouseout="accueil.src='Images/1-sam_6012.jpg'" width="1950">
						</center>
						<br>
						<br>
					</div>
			<?php		
				}
				else {
					
					switch($_GET['do']){
						//exemple
						case 'listeProduits':{
							include("Controleur/ctrl_liste_articles.php");
							break;
						}
					}
				}
			?>			
           
            <!--Pied de page-->
         <?php include('footer.php');?>
        </div>
  </BODY>
</HTML>